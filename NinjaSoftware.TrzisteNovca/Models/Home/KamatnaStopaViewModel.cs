using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using NinjaSoftware.TrzisteNovca.CoolJ;
using NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses;

namespace NinjaSoftware.TrzisteNovca.Models.Home
{
    public class KamatnaStopaViewModel
    {
        #region Constructors

        public KamatnaStopaViewModel(DataAccessAdapterBase adapter, bool jeHnbTrgovanje, long? trgovanjeId, DateTime? datum)
        {
            this.JeHnbTrgovanje = jeHnbTrgovanje;

            if (jeHnbTrgovanje)
            {
                this.LoadKamateHnb(adapter, trgovanjeId, datum);
            }
            else
            {
                this.LoadKamateTrzisteNovca(adapter, trgovanjeId, datum);
            }
        }

        #endregion

        #region Private methods

        private void LoadKamateTrzisteNovca(DataAccessAdapterBase adapter, long? trgovanjeId, DateTime? datum)
        {
            if (!trgovanjeId.HasValue)
            {
                trgovanjeId = TrgovanjeGlavaEntity.GetTrgovanjeGlavaIdFromDate(adapter, datum.Value);
            }

            PrefetchPath2 prefetchPath = new PrefetchPath2(EntityType.TrgovanjeGlavaEntity);

            PredicateExpression stavkaPredicate = new PredicateExpression(TrgovanjeStavkaFields.ValutaId == (long)ValutaEnum.Kn);
            prefetchPath.Add(TrgovanjeGlavaEntity.PrefetchPathTrgovanjeStavkaCollection, 0, stavkaPredicate);

            TrgovanjeGlavaEntity trgovanjeGlava = TrgovanjeGlavaEntity.FetchTrgovanjeGlava(adapter, prefetchPath, trgovanjeId.Value);
            trgovanjeGlava.LoadTrgovanjeGlavaPrethodniDan(adapter);

            this.Datum = trgovanjeGlava.Datum;

            this.KamatnaStopaContainerList = new List<KamatnaStopaContainer>();

            foreach (TrgovanjeVrstaEnum trgovanjeVrstaEnum in Helper.TrgovanjeVrstaEnumArrayZaPrikaz)
            {
                TrgovanjeStavkaEntity trgovanjeStavka = trgovanjeGlava.TrgovanjeStavkaCollection.Where(ts => ts.TrgovanjeVrstaId == (long)trgovanjeVrstaEnum).SingleOrDefault();
                TrgovanjeVrstaRoEntity trgovanjeVrsta = TrgovanjeVrstaRoEntity.FetchTrgovanjeVrstaRo(adapter, null, (long)trgovanjeVrstaEnum);

                if (null == trgovanjeStavka)
                {
                    this.KamatnaStopaContainerList.Add(new KamatnaStopaContainer() { TrgovanjeVrsta = trgovanjeVrsta, KamatnaStopa = "-", KamatnaStopaPromjena = "-" });
                }
                else
                {
                    string promjenaPosto = "-";
                    if (trgovanjeStavka.PrometDodatakPromjenaPosto.HasValue)
                    {
                        promjenaPosto = trgovanjeStavka.PrometDodatakPromjenaPosto.Value.ToString("N2");
                    }

                    this.KamatnaStopaContainerList.Add(new KamatnaStopaContainer() 
                    {
                        TrgovanjeVrsta = trgovanjeVrsta, 
                        KamatnaStopa = trgovanjeStavka.PrometDodatak.ToString("N2"), 
                        KamatnaStopaPromjena =  promjenaPosto
                    });
                }
            }

            this.ProsjecnaKamatnaStopa = trgovanjeGlava.PrometKamatnaStopaPosto(ValutaEnum.Kn);

            this.ProsjecnaKamatnaStopaPromjena = trgovanjeGlava.PrometKamatnaStopaPromjenaPosto(ValutaEnum.Kn);
        }

        private void LoadKamateHnb(DataAccessAdapterBase adapter, long? trgovanjeId, DateTime? datum)
        {
            if (!trgovanjeId.HasValue)
            {
                trgovanjeId = TrgovanjeGlavaHnbEntity.GetTrgovanjeGlavaHnbIdFromDate(adapter, datum.Value);
            }

            PrefetchPath2 prefetchPath = new PrefetchPath2(EntityType.TrgovanjeGlavaHnbEntity);
            prefetchPath.Add(TrgovanjeGlavaHnbEntity.PrefetchPathTrgovanjeStavkaHnbCollection);

            TrgovanjeGlavaHnbEntity trgovanjeGlava = TrgovanjeGlavaHnbEntity.FetchTrgovanjeGlavaHnb(adapter, prefetchPath, trgovanjeId.Value);
            trgovanjeGlava.LoadTrgovanjeGlavaHnbPrethodniDan(adapter);

            this.Datum = trgovanjeGlava.Datum;

            this.KamatnaStopaContainerList = new List<KamatnaStopaContainer>();

            foreach (TrgovanjeVrstaEnum trgovanjeVrstaEnum in Helper.TrgovanjeVrstaEnumArrayZaPrikaz)
            {
                TrgovanjeStavkaHnbEntity trgovanjeStavka = trgovanjeGlava.TrgovanjeStavkaHnbCollection.Where(ts => ts.TrgovanjeVrstaId == (long)trgovanjeVrstaEnum).SingleOrDefault();
                TrgovanjeVrstaRoEntity trgovanjeVrsta = TrgovanjeVrstaRoEntity.FetchTrgovanjeVrstaRo(adapter, null, (long)trgovanjeVrstaEnum);

                if (null == trgovanjeStavka)
                {
                    this.KamatnaStopaContainerList.Add(new KamatnaStopaContainer() { TrgovanjeVrsta = trgovanjeVrsta, KamatnaStopa = "-", KamatnaStopaPromjena = "-" });
                }
                else
                {
                    string promjenaPosto = "-";
                    if (trgovanjeStavka.KamatnaStopaPromjenaPosto.HasValue)
                    {
                        promjenaPosto = trgovanjeStavka.KamatnaStopaPromjenaPosto.Value.ToString("N2");
                    }

                    this.KamatnaStopaContainerList.Add(new KamatnaStopaContainer() 
                    {
                        TrgovanjeVrsta = trgovanjeVrsta, 
                        KamatnaStopa = trgovanjeStavka.KamatnaStopa.ToString("N2"), 
                        KamatnaStopaPromjena = promjenaPosto 
                    });
                }
            }

            this.ProsjecnaKamatnaStopa = trgovanjeGlava.KamatnaStopaUkupno();


            this.ProsjecnaKamatnaStopaPromjena = trgovanjeGlava.KamatnaStopaUkupnoPromjena();
        }

        #endregion

        #region Properties

        public List<KamatnaStopaContainer> KamatnaStopaContainerList { get; set; }
        public DateTime Datum { get; set; }
        public bool JeHnbTrgovanje { get; set; }
        public decimal? ProsjecnaKamatnaStopa { get; set; }
        public decimal? ProsjecnaKamatnaStopaPromjena { get; set; }

        #endregion
    }

    public class KamatnaStopaContainer
    {
        public TrgovanjeVrstaRoEntity TrgovanjeVrsta { get; set; }
        public string KamatnaStopa { get; set; }
        public string KamatnaStopaPromjena { get; set; }
    }
}