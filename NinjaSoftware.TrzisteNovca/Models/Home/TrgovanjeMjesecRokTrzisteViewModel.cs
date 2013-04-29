using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace NinjaSoftware.TrzisteNovca.Models.Home
{
    public class TrgovanjeMjesecRokTrzisteViewModel : TrgovanjeMjesecRokViewModelBase
    {

        #region Constructors

        public TrgovanjeMjesecRokTrzisteViewModel(DataAccessAdapterBase adapter, int godina, int mjesec):
            base(adapter, godina, mjesec)
        {
            this.TrgovanjeGlavaCollection = TrgovanjeGlavaEntity.FetchTrgovanjeGlavaCollection(adapter, godina, mjesec, ValutaEnum.Kn).OrderBy(tg => tg.Datum);
            this.TrgovanjeMjesecRok = TrgovanjeMjesecRok.GetTrgovanjeMjesecRok(adapter, godina, mjesec, Helper.TrgovanjeVrstaEnumArrayZaPrikaz);

            //foreach (TrgovanjeGlavaEntity trgovanjeGlava in this.TrgovanjeGlavaCollection)
            //{
            //    trgovanjeGlava.LoadTrgovanjeGlavaPrethodniDan(adapter);
            //}
        }

        #endregion

        #region Properties

        public IEnumerable<TrgovanjeGlavaEntity> TrgovanjeGlavaCollection { get; set; }
        public TrgovanjeMjesecRok TrgovanjeMjesecRok { get; set; }

        #endregion
    }
}