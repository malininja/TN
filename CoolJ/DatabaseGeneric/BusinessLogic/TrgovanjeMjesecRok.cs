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
    public class TrgovanjeMjesecRok : TrgovanjeMjesecBase
    {
        public ValutaEnum Valuta { get; set; }
        public List<TrgovanjeRok> TrgovanjeRokList { get; set; }
        public decimal? PrometUkupno { get; set; }
        public decimal? KamatnaStopaUkupno { get; set; }

        public static TrgovanjeMjesecRok GetTrgovanjeMjesecRok(DataAccessAdapterBase adapter, int godina, int mjesec, TrgovanjeVrstaEnum[] trgovanjeVrstaEnumArray)
        {
            EntityCollection<TrgovanjeStavkaEntity> trgovanjeStavkaCollection =
                    TrgovanjeStavkaEntity.FetchTrgovanjeStavkaCollection(adapter, godina, mjesec, ValutaEnum.Kn);

            TrgovanjeMjesecRok trgovanjeMjesecRok = (from ts in trgovanjeStavkaCollection
                                                     where ts.ValutaId == (long)ValutaEnum.Kn && ts.TrgovanjeGlava.Datum.Month == mjesec
                                                     group ts by ts.ValutaId into g
                                                     select new TrgovanjeMjesecRok()
                                                     {
                                                         Valuta = (ValutaEnum)g.Key,
                                                         Godina = godina,
                                                         Mjesec = mjesec,
                                                         PrometUkupno = g.Sum(ts => ts.Promet),
                                                         KamatnaStopaUkupno = g.Sum(ts => ts.Promet * ts.PrometDodatak) / g.Sum(ts => ts.Promet)
                                                     }).SingleOrDefault();

            if (null != trgovanjeMjesecRok)
            {
                trgovanjeMjesecRok.TrgovanjeRokList = new List<TrgovanjeRok>();
                foreach (TrgovanjeVrstaEnum trgovanjeVrstaEnum in trgovanjeVrstaEnumArray)
                {
                    TrgovanjeRok trgovanjeRok = (from ts in trgovanjeStavkaCollection
                                                 where ts.ValutaId == (long)ValutaEnum.Kn &&
                                                 ts.TrgovanjeGlava.Datum.Month == mjesec &&
                                                 ts.TrgovanjeVrstaId == (long)trgovanjeVrstaEnum &&
                                                 ts.Promet > 0
                                                 group ts by ts.ValutaId into g
                                                 select new TrgovanjeRok()
                                                 {
                                                     TrgovanjeVrstaEnum = trgovanjeVrstaEnum,
                                                     Promet = g.Sum(ts => ts.Promet),
                                                     KamatnaStopa = g.Sum(ts => ts.Promet * ts.PrometDodatak) / g.Sum(ts => ts.Promet)
                                                 }).SingleOrDefault();

                    if (null != trgovanjeRok)
                    {
                        trgovanjeMjesecRok.TrgovanjeRokList.Add(trgovanjeRok);
                    }
                }
            }

            return trgovanjeMjesecRok;
        }

        public static List<TrgovanjeMjesecRok> GetTrgovanjeMjesecRokCollection(DataAccessAdapterBase adapter, int godina, TrgovanjeVrstaEnum[] trgovanjeVrstaEnumArray)
        {
            List<TrgovanjeMjesecRok> trgovanjeMjesecListRok = new List<TrgovanjeMjesecRok>();

            EntityCollection<TrgovanjeStavkaEntity> trgovanjeStavkaCollection =
                TrgovanjeStavkaEntity.FetchTrgovanjeStavkaCollection(adapter, godina, ValutaEnum.Kn);

            for (int mjesec = 1; mjesec < 13; mjesec++)
            {
                TrgovanjeMjesecRok trgovanjeMjesecRok = (from ts in trgovanjeStavkaCollection
                                                         where ts.ValutaId == (long)ValutaEnum.Kn && ts.TrgovanjeGlava.Datum.Month == mjesec
                                                         group ts by ts.ValutaId into g
                                                         select new TrgovanjeMjesecRok()
                                                         {
                                                             Valuta = (ValutaEnum)g.Key,
                                                             Godina = godina,
                                                             Mjesec = mjesec,
                                                             PrometUkupno = g.Sum(ts => ts.Promet),
                                                             KamatnaStopaUkupno = g.Sum(ts => ts.Promet * ts.PrometDodatak) / g.Sum(ts => ts.Promet)
                                                         }).SingleOrDefault();

                if (null != trgovanjeMjesecRok)
                {
                    trgovanjeMjesecRok.TrgovanjeRokList = new List<TrgovanjeRok>();
                    foreach (TrgovanjeVrstaEnum trgovanjeVrstaEnum in trgovanjeVrstaEnumArray)
                    {
                        TrgovanjeRok trgovanjeRok = (from ts in trgovanjeStavkaCollection
                                                     where ts.ValutaId == (long)ValutaEnum.Kn &&
                                                     ts.TrgovanjeGlava.Datum.Month == mjesec &&
                                                     ts.TrgovanjeVrstaId == (long)trgovanjeVrstaEnum &&
                                                     ts.Promet > 0
                                                     group ts by ts.ValutaId into g
                                                     select new TrgovanjeRok()
                                                     {
                                                         TrgovanjeVrstaEnum = trgovanjeVrstaEnum,
                                                         Promet = g.Sum(ts => ts.Promet),
                                                         KamatnaStopa = g.Sum(ts => ts.Promet * ts.PrometDodatak) / g.Sum(ts => ts.Promet)
                                                     }).SingleOrDefault();

                        if (null != trgovanjeRok)
                        {
                            trgovanjeMjesecRok.TrgovanjeRokList.Add(trgovanjeRok);
                        }
                    }

                    trgovanjeMjesecListRok.Add(trgovanjeMjesecRok);
                }
            }

            if (DateTime.Now.Year == godina)
            {
                int currentMonth = DateTime.Now.Month;
                TrgovanjeMjesecRok trgovanjeCurrentMonth = trgovanjeMjesecListRok.Where(tm => tm.Mjesec == currentMonth).SingleOrDefault();
                if (null == trgovanjeCurrentMonth)
                {
                    trgovanjeCurrentMonth = new TrgovanjeMjesecRok()
                    {
                        Valuta = ValutaEnum.Kn,
                        Godina = godina,
                        Mjesec = currentMonth,
                        PrometUkupno = null,
                        KamatnaStopaUkupno = null
                    };

                    trgovanjeCurrentMonth.TrgovanjeRokList = new List<TrgovanjeRok>();

                    trgovanjeMjesecListRok.Add(trgovanjeCurrentMonth);
                }
            }

            return trgovanjeMjesecListRok;
        }
    }

    public class TrgovanjeRok
    {
        public TrgovanjeVrstaEnum TrgovanjeVrstaEnum { get; set; }
        public decimal? Promet { get; set; }
        public decimal? KamatnaStopa { get; set; }
    }
}