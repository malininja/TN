using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace NinjaSoftware.TrzisteNovca.Models.Home
{
    public class TrgovanjeMjesecRokHnbViewModel : TrgovanjeMjesecRokViewModelBase
    {
        #region Constructors

        public TrgovanjeMjesecRokHnbViewModel(DataAccessAdapterBase adapter, int godina, int mjesec, TrgovanjeVrstaEnum[] trgovanjeVrstaEnumArray) :
            base(adapter, godina, mjesec, trgovanjeVrstaEnumArray)
        {
            this.TrgovanjeGlavaHnbCollection = TrgovanjeGlavaHnbEntity.FetchTrgovanjeGlavaHnbCollection(adapter, godina, mjesec).OrderBy(tg => tg.Datum);

            //foreach (TrgovanjeGlavaEntity trgovanjeGlava in this.TrgovanjeGlavaCollection)
            //{
            //    trgovanjeGlava.LoadTrgovanjeGlavaPrethodniDan(adapter);
            //}
        }

        #endregion

        #region Properties

        public IEnumerable<TrgovanjeGlavaHnbEntity> TrgovanjeGlavaHnbCollection { get; set; }

        #endregion
    }
}