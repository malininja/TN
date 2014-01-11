using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses;
using System.Web.Mvc;

namespace NinjaSoftware.TrzisteNovca.Models.Home
{
    public class TrgovanjeGodinaRokViewModelBase
    {
        #region Constructors

        public TrgovanjeGodinaRokViewModelBase(DataAccessAdapterBase adapter, int godina, TrgovanjeVrstaEnum[] trgovanjeVrstaEnumArray)
        {
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
        public List<SelectListItem> GodinaSelectList { get; set; }

        #endregion
    }
}