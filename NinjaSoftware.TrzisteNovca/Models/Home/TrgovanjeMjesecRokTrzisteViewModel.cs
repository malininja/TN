using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Text;
using System.Globalization;

namespace NinjaSoftware.TrzisteNovca.Models.Home
{
    public class TrgovanjeMjesecRokTrzisteViewModel : TrgovanjeMjesecRokViewModelBase
    {

        #region Constructors

        public TrgovanjeMjesecRokTrzisteViewModel(DataAccessAdapterBase adapter, int godina, int mjesec, TrgovanjeVrstaEnum[] trgovanjeVrstaEnumArray) :
            base(adapter, godina, mjesec, trgovanjeVrstaEnumArray)
        {
            this.TrgovanjeGlavaCollection = TrgovanjeGlavaEntity.FetchTrgovanjeGlavaCollection(adapter, godina, mjesec, ValutaEnum.Kn).OrderBy(tg => tg.Datum);
            //this.TrgovanjeMjesecRok = TrgovanjeMjesecRok.GetTrgovanjeMjesecRok(adapter, godina, mjesec, Helper.TrgovanjeVrstaEnumArrayZaPrikaz);

            StringBuilder bob = new StringBuilder(256);
            bob.Append("[");

            foreach (TrgovanjeGlavaEntity trgovanjeGlava in this.TrgovanjeGlavaCollection)
            {
                string dateString = trgovanjeGlava.Datum.ToString("yyyy-MM-dd");

                string kamatnaStopaString = "0";
                decimal? kamatnaStopa = trgovanjeGlava.PrometKamatnaStopaPosto(ValutaEnum.Kn);
                if (kamatnaStopa.HasValue)
                {
                    kamatnaStopaString = kamatnaStopa.Value.ToString("F", new CultureInfo("en"));
                }
                
                bob.Append(string.Format("['{0}', {1}],", dateString, kamatnaStopaString));
            }

            bob.Append("]");

            this.ChartLineProsjecnaDataSource = new HtmlString(bob.ToString());
        }

        #endregion

        #region Properties

        public IEnumerable<TrgovanjeGlavaEntity> TrgovanjeGlavaCollection { get; set; }
        //public TrgovanjeMjesecRok TrgovanjeMjesecRok { get; set; }
        public HtmlString ChartLineProsjecnaDataSource { get; set; }

        #endregion
    }
}