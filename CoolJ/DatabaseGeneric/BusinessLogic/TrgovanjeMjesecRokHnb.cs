using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.Api.CoolJ;
using NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;

namespace NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic
{
    public class TrgovanjeMjesecRokHnb : TrgovanjeMjesecBase
    {
        public List<TrgovanjeRok> TrgovanjeRokList { get; set; }
        public decimal? PrometUkupno { get; set; }
        public decimal? KamatnaStopaUkupno { get; set; }

        public static List<TrgovanjeMjesecRokHnb> GetTrgovanjeMjesecRokHnbCollection(DataAccessAdapterBase adapter, 
            int godina, 
            TrgovanjeVrstaEnum[] trgovanjeVrstaEnumArray)
        {
            List<TrgovanjeMjesecRokHnb> trgovanjeMjesecListRok = new List<TrgovanjeMjesecRokHnb>();

            EntityCollection<TrgovanjeStavkaHnbEntity> trgovanjeStavkaHnbCollection =
                TrgovanjeStavkaHnbEntity.FetchTrgovanjeStavkaHnbCollection(adapter, godina);

            for (int mjesec = 1; mjesec < 13; mjesec++)
            {
                IEnumerable<TrgovanjeStavkaHnbEntity> trgovanjeStavkaHnbCollectionForMonth = trgovanjeStavkaHnbCollection.Where(ts => ts.TrgovanjeGlavaHnb.Datum.Month == mjesec);

                decimal prometUkupno = trgovanjeStavkaHnbCollectionForMonth.Sum(ts => ts.IznosMilijuniKn);
                
                decimal? kamatnaStopa;
                if (0 == prometUkupno)
                {
                    kamatnaStopa = null;
                }
                else
                {
                    kamatnaStopa = trgovanjeStavkaHnbCollectionForMonth.Sum(ts => ts.IznosMilijuniKn * ts.KamatnaStopa) / prometUkupno;
                }

                TrgovanjeMjesecRokHnb trgovanjeMjesecRokHnb = new TrgovanjeMjesecRokHnb()
                                                               {
                                                                   Godina = godina,
                                                                   Mjesec = mjesec,
                                                                   PrometUkupno = prometUkupno,
                                                                   KamatnaStopaUkupno = kamatnaStopa
                                                               };

                if (trgovanjeMjesecRokHnb.PrometUkupno.HasValue &&
                    trgovanjeMjesecRokHnb.KamatnaStopaUkupno.HasValue)
                {
                    trgovanjeMjesecRokHnb.TrgovanjeRokList = new List<TrgovanjeRok>();
                    foreach (TrgovanjeVrstaEnum trgovanjeVrstaEnum in trgovanjeVrstaEnumArray)
                    {
                        IEnumerable<TrgovanjeStavkaHnbEntity> trgovanjeStavkaHnbCollectionForMonthAndVrsta =
                            trgovanjeStavkaHnbCollectionForMonth.Where(ts => ts.TrgovanjeVrstaId == (long)trgovanjeVrstaEnum);

                        decimal prometUkupnoVrsta = trgovanjeStavkaHnbCollectionForMonthAndVrsta.Sum(ts => ts.IznosMilijuniKn);

                        decimal? kamatnaStopaVrsta;
                        if (0 == prometUkupnoVrsta)
                        {
                            kamatnaStopaVrsta = null;
                        }
                        else
                        {
                            kamatnaStopaVrsta = trgovanjeStavkaHnbCollectionForMonthAndVrsta.Sum(ts => ts.IznosMilijuniKn * ts.KamatnaStopa) / prometUkupnoVrsta;
                        }

                        TrgovanjeRok trgovanjeRok = new TrgovanjeRok()
                                                     {
                                                         TrgovanjeVrstaEnum = trgovanjeVrstaEnum,
                                                         Promet = prometUkupnoVrsta,
                                                         KamatnaStopa = kamatnaStopaVrsta
                                                     };

                        if (null != trgovanjeRok)
                        {
                            trgovanjeMjesecRokHnb.TrgovanjeRokList.Add(trgovanjeRok);
                        }
                    }

                    trgovanjeMjesecListRok.Add(trgovanjeMjesecRokHnb);
                }
            }

            return trgovanjeMjesecListRok;
        }
    }
}