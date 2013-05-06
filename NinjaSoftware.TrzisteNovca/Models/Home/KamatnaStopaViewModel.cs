using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace NinjaSoftware.TrzisteNovca.Models.Home
{
    public class KamatnaStopaViewModel
    {
        public KamatnaStopaViewModel(DataAccessAdapterBase adapter, bool jeMedubankarskoTrgovanje, long trgovanjeId)
        { }

        public Dictionary<TrgovanjeVrstaEnum, decimal?> TrgovanjeKamatnaStopaDictionary { get; set; }
        public DateTime Datum { get; set; }
        public bool JeMedubankarskoTrgovanje { get; set; }
    }
}