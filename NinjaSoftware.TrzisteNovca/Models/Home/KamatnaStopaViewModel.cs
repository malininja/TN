using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using NinjaSoftware.TrzisteNovca.CoolJ;

namespace NinjaSoftware.TrzisteNovca.Models.Home
{
    public class KamatnaStopaViewModel
    {
        public KamatnaStopaViewModel(DataAccessAdapterBase adapter, bool jeHnbTrgovanje, long trgovanjeId)
        {
            this.JeHnbTrgovanje = jeHnbTrgovanje;

            if (jeHnbTrgovanje)
            {
                this.LoadKamateHnb(adapter, trgovanjeId);
            }
            else
            {
                this.LoadKamateTrzisteNovca(adapter, trgovanjeId);
            }
        }

        private void LoadKamateTrzisteNovca(DataAccessAdapterBase adapter, long trgovanjeId)
        {
            PrefetchPath2 prefetchPath = new PrefetchPath2(EntityType.TrgovanjeGlavaEntity);
            prefetchPath.Add(TrgovanjeGlavaEntity.PrefetchPathTrgovanjeStavkaCollection);

            TrgovanjeGlavaEntity trgovanjeGlava = TrgovanjeGlavaEntity.FetchTrgovanjeGlava(adapter, prefetchPath, trgovanjeId);
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
                    this.KamatnaStopaContainerList.Add(new KamatnaStopaContainer() 
                    {
                        TrgovanjeVrsta = trgovanjeVrsta, 
                        KamatnaStopa = trgovanjeStavka.PrometDodatak.ToString("N2"), 
                        KamatnaStopaPromjena = null 
                    });
                }
            }
        }

        private void LoadKamateHnb(DataAccessAdapterBase adapter, long trgovanjeId)
        {
            PrefetchPath2 prefetchPath = new PrefetchPath2(EntityType.TrgovanjeGlavaHnbEntity);
            prefetchPath.Add(TrgovanjeGlavaHnbEntity.PrefetchPathTrgovanjeStavkaHnbCollection);

            TrgovanjeGlavaHnbEntity trgovanjeGlava = TrgovanjeGlavaHnbEntity.FetchTrgovanjeGlavaHnb(adapter, prefetchPath, trgovanjeId);
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
                    this.KamatnaStopaContainerList.Add(new KamatnaStopaContainer() 
                    {
                        TrgovanjeVrsta = trgovanjeVrsta, 
                        KamatnaStopa = trgovanjeStavka.KamatnaStopa.ToString("N2"), 
                        KamatnaStopaPromjena = "todo" 
                    });
                }
            }
        }

        public List<KamatnaStopaContainer> KamatnaStopaContainerList { get; set; }
        public DateTime Datum { get; set; }
        public bool JeHnbTrgovanje { get; set; }
    }

    public class KamatnaStopaContainer
    {
        public TrgovanjeVrstaRoEntity TrgovanjeVrsta { get; set; }
        public string KamatnaStopa { get; set; }
        public string KamatnaStopaPromjena { get; set; }
    }
}