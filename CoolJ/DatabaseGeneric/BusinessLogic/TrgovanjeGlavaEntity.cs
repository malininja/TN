using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses;
using NinjaSoftware.Api.Core;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;
using NinjaSoftware.TrzisteNovca.CoolJ.FactoryClasses;
using NinjaSoftware.Api.CoolJ;
using SD.LLBLGen.Pro.LinqSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.Linq;

namespace NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses
{
    public partial class TrgovanjeGlavaEntity
    {
        #region Custom properties

        private TrgovanjeGlavaEntity _trgovanjeGlavaPrethodniDan;
        public TrgovanjeGlavaEntity TrgovanjeGlavaPrethodniDan 
        {
            get
            {
                return _trgovanjeGlavaPrethodniDan;
            }
        }

        public decimal Ponuda(ValutaEnum valutaEnum)
        {
            return this.TrgovanjeStavkaCollection.Where(ts => (long)valutaEnum == ts.ValutaId).Sum(ts => ts.Ponuda);
        }

        public decimal Potraznja(ValutaEnum valutaEnum)
        {
            return this.TrgovanjeStavkaCollection.Where(ts => (long)valutaEnum == ts.ValutaId).Sum(ts => ts.Potraznja);
        }

        public decimal Promet(ValutaEnum valutaEnum)
        {
            return this.TrgovanjeStavkaCollection.Where(ts => (long)valutaEnum == ts.ValutaId).Sum(ts => ts.Promet);
        }

        public decimal? PonudaPromjenaPosto(ValutaEnum valutaEnum)
        {
            decimal ponudaPrethodniDan = 0;

            if (null != this.TrgovanjeGlavaPrethodniDan)
            {
                ponudaPrethodniDan = this.TrgovanjeGlavaPrethodniDan.Ponuda(valutaEnum);
            }

            if (0 != ponudaPrethodniDan)
            {
                return (this.Ponuda(valutaEnum) / ponudaPrethodniDan - 1) * 100;
            }
            else
            {
                return null;
            }
        }

        public decimal? PotraznjaPromjenaPosto(ValutaEnum valutaEnum)
        {
            decimal potraznjaPrethodniDan = 0;

            if (null != this.TrgovanjeGlavaPrethodniDan)
            {
                potraznjaPrethodniDan = this.TrgovanjeGlavaPrethodniDan.Potraznja(valutaEnum);
            }

            if (0 != potraznjaPrethodniDan)
            {
                return (this.Potraznja(valutaEnum) / potraznjaPrethodniDan - 1) * 100;
            }
            else
            {
                return null;
            }
        }

        public decimal? PrometPromjenaPosto(ValutaEnum valutaEnum)
        {
            decimal prometPrethodniDan = 0;

            if (null != this.TrgovanjeGlavaPrethodniDan)
            {
                prometPrethodniDan = this.TrgovanjeGlavaPrethodniDan.Promet(valutaEnum);
            }

            if (0 != prometPrethodniDan)
            {
                return (this.Promet(valutaEnum) / prometPrethodniDan - 1) * 100;
            }
            else
            {
                return null;
            }
        }

        public decimal? PrometKamatnaStopaPosto(ValutaEnum valutaEnum)
        {
            decimal promet = this.Promet(valutaEnum);

            if (0 != promet)
            {
                decimal tmp = this.TrgovanjeStavkaCollection.
                    Where(ts => (long)valutaEnum == ts.ValutaId).
                    Sum(ts => ts.Promet * ts.PrometDodatak);

                return tmp / promet;
            }
            else
            {
                return null;
            }
        }

        public decimal? PrometKamatnaStopaPromjenaPosto(ValutaEnum valutaEnum)
        {
            decimal? prometKamatnaStopa = this.PrometKamatnaStopaPosto(valutaEnum);
            decimal? prometKamatnaStopaPrethodniDan = 0;

            if (null != this.TrgovanjeGlavaPrethodniDan)
            {
                prometKamatnaStopaPrethodniDan = this.TrgovanjeGlavaPrethodniDan.PrometKamatnaStopaPosto(valutaEnum);
            }

            if (prometKamatnaStopa.HasValue &&
                prometKamatnaStopaPrethodniDan.HasValue &&
                0 != prometKamatnaStopaPrethodniDan)
            {
                return (Math.Round(prometKamatnaStopa.Value, 2) / Math.Round(prometKamatnaStopaPrethodniDan.Value, 2) - 1) * 100;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Dynamic methods

        /// <summary>
        /// Ne radi rekurzivni save, već briše dane TrgovanjeStavka, pohranjuje TrgovanjeStavka jednu po jednu i na kraju pohranjuje TrgovanjeGlava.
        /// </summary>
        public void Save(DataAccessAdapterBase adapter,
            IEnumerable<TrgovanjeStavkaEntity> trgovanjeStavkaCollectionToDelete,
            bool refetchAfterSave)
        {
            if (null != trgovanjeStavkaCollectionToDelete)
            {
                foreach (TrgovanjeStavkaEntity trgovanjeStavka in trgovanjeStavkaCollectionToDelete)
                {
                    trgovanjeStavka.Delete(adapter);
                }
            }

            this.Save(adapter, refetchAfterSave, false);

            foreach (TrgovanjeStavkaEntity trgovanjeStavka in this.TrgovanjeStavkaCollection)
            {
                trgovanjeStavka.Save(adapter, refetchAfterSave, false);
            }

            TrgovanjeGlavaEntity._godinaTrgovanjaCollection = null;
        }

        public override void Save(DataAccessAdapterBase adapter, bool refetchAfterSave, bool recurse)
        {
            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(TrgovanjeGlavaFields.Datum == this.Datum.Date);
            bucket.PredicateExpression.Add(TrgovanjeGlavaFields.TrgovanjeGlavaId != this.TrgovanjeGlavaId);

            int count = TrgovanjeGlavaEntity.GetNumberOfEntities(adapter, bucket);
            if (count > 0)
            {
                throw new UserException(string.Format("Trgovanje za datum {0} je već uneseno.", this.Datum.ToShortDateString()));
            }

            base.Save(adapter, refetchAfterSave, recurse);

            TrgovanjeGlavaEntity._godinaTrgovanjaCollection = null;
        }

        public override void Delete(DataAccessAdapterBase adapter)
        {
            EntityCollection<TrgovanjeStavkaEntity> trgovanjeStavkaCollection = this.TrgovanjeStavkaCollection;

            if (null == trgovanjeStavkaCollection ||
                0 == trgovanjeStavkaCollection.Count)
            {
                RelationPredicateBucket bucket = new RelationPredicateBucket(TrgovanjeStavkaFields.TrgovanjeGlavaId == this.TrgovanjeGlavaId);
                trgovanjeStavkaCollection = TrgovanjeStavkaEntity.FetchTrgovanjeStavkaCollection(adapter, bucket, null);
            }

            foreach (TrgovanjeStavkaEntity trgovanjeStavka in trgovanjeStavkaCollection)
            {
                trgovanjeStavka.Delete(adapter);
            }

            base.Delete(adapter);

            TrgovanjeGlavaEntity._godinaTrgovanjaCollection = null;
        }

        public void LoadTrgovanjeGlavaPrethodniDan(DataAccessAdapterBase adapter)
        {
            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(TrgovanjeGlavaFields.Datum < this.Datum);

            PrefetchPath2 prefetchPath = new PrefetchPath2(EntityType.TrgovanjeGlavaEntity);
            prefetchPath.Add(TrgovanjeGlavaEntity.PrefetchPathTrgovanjeStavkaCollection);

            SortExpression sort = new SortExpression(TrgovanjeGlavaFields.Datum | SortOperator.Descending);

            EntityCollection<TrgovanjeGlavaEntity> trgovanjeGlavaCollection = new EntityCollection<TrgovanjeGlavaEntity>(new TrgovanjeGlavaEntityFactory());
            adapter.FetchEntityCollection(trgovanjeGlavaCollection, bucket, 1, sort, prefetchPath);

            _trgovanjeGlavaPrethodniDan = trgovanjeGlavaCollection.SingleOrDefault();
        }

        #endregion

        #region Public static methods

        private static List<int> _godinaTrgovanjaCollection;
        public static List<int> GodinaTrgovanjaCollection(DataAccessAdapterBase adapter)
        {
            if (null == _godinaTrgovanjaCollection)
            {
                LoadTrgovanjeGodinaList(adapter);
            }

            return _godinaTrgovanjaCollection;
        }


        public static EntityCollection<TrgovanjeGlavaEntity> FetchTrgovanjeGlavaCollection(DataAccessAdapterBase adapter, int godina, int mjesec, ValutaEnum valutaEnum)
        {
            DateTime startDate = new DateTime(godina, mjesec, 1);
            DateTime endDate = startDate.AddMonths(1);

            return FetchTrgovanjeGlavaCollection(adapter, startDate, endDate, valutaEnum);
        }

        public static EntityCollection<TrgovanjeGlavaEntity> FetchTrgovanjeGlavaCollection(DataAccessAdapterBase adapter, 
            DateTime startDate, 
            DateTime endDate, 
            ValutaEnum valutaEnum)
        {
            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(PredicateHelper.FilterValidEntities(startDate, endDate, TrgovanjeGlavaFields.Datum));
            
            PredicateExpression valutaPredicate = new PredicateExpression(TrgovanjeStavkaFields.ValutaId == (long)valutaEnum);

            PrefetchPath2 prefetchPath = new PrefetchPath2(EntityType.TrgovanjeGlavaEntity);
            prefetchPath.Add(TrgovanjeGlavaEntity.PrefetchPathTrgovanjeStavkaCollection, 0, valutaPredicate);

            return FetchTrgovanjeGlavaCollection(adapter, bucket, prefetchPath);
        }

        public static TrgovanjeGlavaEntity FetchTrgovanjeGlavaForGuiDisplay(DataAccessAdapterBase adapter, DateTime date)
        {
            long trgovanjeGlavaId = GetTrgovanjeGlavaIdFromDate(adapter, date);

            return FetchTrgovanjeGlavaForGuiDisplay(adapter, trgovanjeGlavaId);
        }

        public static long GetTrgovanjeGlavaIdFromDate(DataAccessAdapterBase adapter, DateTime date)
        {
            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(TrgovanjeGlavaFields.Datum <= date.Date);

            SortExpression sort = new SortExpression(TrgovanjeGlavaFields.Datum | SortOperator.Descending);

            EntityCollection<TrgovanjeGlavaEntity> trgovanjeGlavaCollection = new EntityCollection<TrgovanjeGlavaEntity>(new TrgovanjeGlavaEntityFactory());
            adapter.FetchEntityCollection(trgovanjeGlavaCollection, bucket, 1, sort);

            if (0 == trgovanjeGlavaCollection.Count)
            {
                sort = new SortExpression(TrgovanjeGlavaFields.Datum | SortOperator.Ascending);
                adapter.FetchEntityCollection(trgovanjeGlavaCollection, null, 1, sort);
            }

            return trgovanjeGlavaCollection.Single().TrgovanjeGlavaId;
        }

        public static TrgovanjeGlavaEntity FetchTrgovanjeGlavaForGuiDisplay(DataAccessAdapterBase adapter, long trgovanjeGlavaId)
        { 
            PrefetchPath2 prefetchPath = new PrefetchPath2(EntityType.TrgovanjeGlavaEntity);
            IPrefetchPathElement2 trgovanjeStavkaPrefetchElement = prefetchPath.Add(TrgovanjeGlavaEntity.PrefetchPathTrgovanjeStavkaCollection);
            trgovanjeStavkaPrefetchElement.SubPath.Add(TrgovanjeStavkaEntity.PrefetchPathValuta);
            trgovanjeStavkaPrefetchElement.SubPath.Add(TrgovanjeStavkaEntity.PrefetchPathTrgovanjeVrsta);

            TrgovanjeGlavaEntity trgovanjeGlava = TrgovanjeGlavaEntity.FetchTrgovanjeGlava(adapter, prefetchPath, trgovanjeGlavaId);
            trgovanjeGlava.LoadTrgovanjeGlavaPrethodniDan(adapter);

            return trgovanjeGlava;
        }

        public static TrgovanjeGlavaEntity LoadTrgovanjeFromSettFile(DataAccessAdapterBase adapter, string filePath, string fileName)
        {
            fileName = fileName.Replace(".txt", "");
            string[] fileNameParts = fileName.Split('_');

            ValidateSettFileName(fileNameParts);

            DateTime date = new DateTime(int.Parse(fileNameParts[1]), 
                int.Parse(fileNameParts[2]), 
                int.Parse(fileNameParts[3]));

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(TrgovanjeGlavaFields.Datum == date);

            int count = TrgovanjeGlavaEntity.GetNumberOfEntities(adapter, bucket);

            if (count > 0)
            {
                throw new UserException(string.Format("Trgovanje za datum {0} je već uneseno.", date.ToShortDateString()));
            }

            TrgovanjeGlavaEntity trgovanjeGlava = new TrgovanjeGlavaEntity();
            trgovanjeGlava.Datum = date;

            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(filePath);

            try
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        TrgovanjeStavkaEntity trgovanjeStavka = CreateTrgovanjeStavkaFromSettRecord(adapter, line);
                        trgovanjeGlava.TrgovanjeStavkaCollection.Add(trgovanjeStavka);
                    }
                }
            }
            finally
            {
                file.Close();
            }

            if (0 == trgovanjeGlava.TrgovanjeStavkaCollection.Count)
            {
                throw new UserException("Datoteka je prazna.");
            }

            trgovanjeGlava.Save(adapter, null, true);

            return trgovanjeGlava;
        }

        #endregion

        #region private static methods

        private static TrgovanjeStavkaEntity CreateTrgovanjeStavkaFromSettRecord(DataAccessAdapterBase adapter, string settRecord)
        {
            ValidateSettRecord(settRecord);

            string[] settRecordParts = settRecord.Split('#');

            TrgovanjeStavkaEntity trgovanjeStavka = new TrgovanjeStavkaEntity();
            trgovanjeStavka.Ponuda = ParseDecimal(settRecordParts[2]);
            trgovanjeStavka.PonudaDodatak = ParseDecimal(settRecordParts[3]);
            trgovanjeStavka.Potraznja = ParseDecimal(settRecordParts[4]);
            trgovanjeStavka.PotraznjaDodatak = ParseDecimal(settRecordParts[5]);
            trgovanjeStavka.Promet = ParseDecimal(settRecordParts[6]);
            trgovanjeStavka.PrometDodatak = ParseDecimal(settRecordParts[7]);

            settRecordParts[0] = settRecordParts[0].Replace(" - ", ";");
            string[] vrstaTrgovanjaValutaParts = settRecordParts[0].Split(';');
            string trgovanjeVrstaSifraSlog = string.Empty;
            bool isVrstaTrgovanjaValutaInvalid = false;

            if (vrstaTrgovanjaValutaParts.Length == 1)
            {
                trgovanjeStavka.ValutaId = (long)ValutaEnum.Kn;
                trgovanjeVrstaSifraSlog = vrstaTrgovanjaValutaParts[0].Trim();
            }
            else if (vrstaTrgovanjaValutaParts.Length == 2)
            {
                ValutaRoEntity valuta = ValutaRoEntity.FetchValutaRo(adapter, vrstaTrgovanjaValutaParts[0].Trim());
                if (null == valuta)
                {
                    isVrstaTrgovanjaValutaInvalid = true;
                }
                else
                {
                    trgovanjeStavka.ValutaId = valuta.ValutaId;
                    trgovanjeVrstaSifraSlog = vrstaTrgovanjaValutaParts[1].Trim();
                }
            }
            else
            {
                isVrstaTrgovanjaValutaInvalid = true;
            }

            TrgovanjeVrstaRoEntity trgovanjeVrsta = TrgovanjeVrstaRoEntity.FetchTrgovanjeVrstaRo(adapter, trgovanjeVrstaSifraSlog);
            if (null == trgovanjeVrsta)
            {
                isVrstaTrgovanjaValutaInvalid = true;
            }

            if (isVrstaTrgovanjaValutaInvalid)
            {
                throw new UserException(string.Format("Neispravna vrsta trgovanja - '{0}'", settRecordParts[0]));
            }

            trgovanjeStavka.TrgovanjeVrstaId = trgovanjeVrsta.TrgovanjeVrstaId;

            return trgovanjeStavka;
        }

        private static decimal ParseDecimal(string numberString)
        {
            if (string.IsNullOrEmpty(numberString))
            {
                return 0;
            }
            else
            {
                return decimal.Parse(numberString);
            }
        }

        private static void ValidateSettFileName(string[] fileNameParts)
        {
            string fileNameError = "Neispravan naziv datoteke.";
            
            if (4 != fileNameParts.Length)
            {
                throw new UserException(fileNameError);
            }

            if ("web" != fileNameParts[0].ToLower())
            {
                throw new UserException(fileNameError);
            }

            bool areDatePartsValid = true;
            for (int i = 1; i < 4; i++)
            {
                int foo;
                areDatePartsValid = int.TryParse(fileNameParts[i], out foo);
            }

            if (!areDatePartsValid)
            {
                throw new UserException(fileNameError);
            }
        }

        private static void ValidateSettRecord(string record)
        {
            string[] settRecordParts = record.Split('#');
            if (8 != settRecordParts.Length)
            {
                throw new UserException("Neispravan broj polja u slogu.");
            }

            for (int i = 2; i < 8; i++)
            {
                bool isNumberValid = true;

                if (!string.IsNullOrEmpty(settRecordParts[i]))
                {
                    decimal foo;
                    isNumberValid = decimal.TryParse(settRecordParts[i], out foo);
                }

                if (!isNumberValid)
                {
                    throw new UserException("Brojčane vrijednosti u datoteci nisu ispravne.");
                }
            }
        }

        private static void LoadTrgovanjeGodinaList(DataAccessAdapterBase adapter)
        {
            EntityCollection<TrgovanjeGlavaEntity> trgovanjeGlavaCollection = new EntityCollection<TrgovanjeGlavaEntity>(new TrgovanjeGlavaEntityFactory());
            
            ExcludeIncludeFieldsList includeFieldList = new ExcludeIncludeFieldsList(false);
            includeFieldList.Add(TrgovanjeGlavaFields.Datum);

            adapter.FetchEntityCollection(trgovanjeGlavaCollection, includeFieldList, null);

            _godinaTrgovanjaCollection = trgovanjeGlavaCollection.Select(tg => tg.Datum.Year).Distinct().ToList();

            _godinaTrgovanjaCollection.Sort();
        }

        #endregion
    }
}
