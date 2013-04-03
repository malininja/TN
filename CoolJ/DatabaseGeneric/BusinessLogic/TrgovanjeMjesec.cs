﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.Api.CoolJ;
using NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;

namespace NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic
{
    public class TrgovanjeMjesec : TrgovanjeMjesecBase
    {
        public ValutaEnum Valuta { get; set; }
        public decimal? Potraznja { get; set; }
        public decimal? Ponuda { get; set; }
        public decimal? Promet { get; set; }
        public decimal? KamatnaStopa { get; set; }

        public static List<TrgovanjeMjesec> GetTrgovanjeMjesecCollection(DataAccessAdapterBase adapter, int godina)
        {
            List<TrgovanjeMjesec> trgovanjeMjesecList = new List<TrgovanjeMjesec>();

            EntityCollection<TrgovanjeStavkaEntity> trgovanjeStavkaCollection = 
                TrgovanjeStavkaEntity.FetchTrgovanjeStavkaCollection(adapter, godina, ValutaEnum.Kn);

            IEnumerable<long> valutaIdCollection = trgovanjeStavkaCollection.Select(ts => ts.ValutaId).Distinct();

            foreach (long valutaId in valutaIdCollection)
            {
                for (int mjesec = 1; mjesec < 13; mjesec++)
                {
                    TrgovanjeMjesec trgovanjeMjesec = (from ts in trgovanjeStavkaCollection
                                                       where ts.ValutaId == valutaId && ts.TrgovanjeGlava.Datum.Month == mjesec
                                                       group ts by ts.ValutaId into g
                                                       select new TrgovanjeMjesec()
                                                       {
                                                           Valuta = (ValutaEnum)g.Key,
                                                           Godina = godina,
                                                           Mjesec = mjesec,
                                                           Potraznja = g.Sum(ts => ts.Potraznja),
                                                           Ponuda = g.Sum(ts => ts.Ponuda),
                                                           Promet = g.Sum(ts => ts.Promet),
                                                           KamatnaStopa = g.Sum(ts => ts.Promet * ts.PrometDodatak) / g.Sum(ts => ts.Promet)
                                                       }).SingleOrDefault();

                    if (null != trgovanjeMjesec)
                    {
                        trgovanjeMjesecList.Add(trgovanjeMjesec);
                    }
                }
            }

            return trgovanjeMjesecList;
        }
    }
}