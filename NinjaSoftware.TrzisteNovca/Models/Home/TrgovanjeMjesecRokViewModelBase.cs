using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace NinjaSoftware.TrzisteNovca.Models.Home
{
    public class TrgovanjeMjesecRokViewModelBase
    {

        #region Constructors

        public TrgovanjeMjesecRokViewModelBase(DataAccessAdapterBase adapter, int godina, int mjesec, TrgovanjeVrstaEnum[] trgovanjeVrstaEnumArray)
        {
            this.Godina = godina;
            this.Mjesec = mjesec;

            this.TrgovanjeVrstaList = new List<TrgovanjeVrstaRoEntity>();
            foreach (TrgovanjeVrstaEnum trgovanjeVrstaEnum in trgovanjeVrstaEnumArray)
            {
                TrgovanjeVrstaRoEntity trgovanjeVrsta = TrgovanjeVrstaRoEntity.FetchTrgovanjeVrstaRo(adapter, null, (long)trgovanjeVrstaEnum);
                this.TrgovanjeVrstaList.Add(trgovanjeVrsta);
            }
        }

        #endregion

        #region Properties

        public List<TrgovanjeVrstaRoEntity> TrgovanjeVrstaList { get; set; }
        public int Godina { get; set; }
        public int Mjesec { get; set; }

        #endregion
    }
}