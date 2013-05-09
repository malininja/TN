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
    public class TrgovanjeMjesecRokHnbViewModel : TrgovanjeMjesecRokViewModelBase
    {
        #region Constructors

        public TrgovanjeMjesecRokHnbViewModel(DataAccessAdapterBase adapter, int godina, int mjesec, TrgovanjeVrstaEnum[] trgovanjeVrstaEnumArray) :
            base(adapter, godina, mjesec, trgovanjeVrstaEnumArray)
        {
            this.TrgovanjeGlavaHnbCollection = TrgovanjeGlavaHnbEntity.FetchTrgovanjeGlavaHnbCollection(adapter, godina, mjesec).OrderBy(tg => tg.Datum);

            StringBuilder bob = new StringBuilder(256);
            bob.Append("[");

            foreach (TrgovanjeGlavaHnbEntity trgovanjeGlavaHnb in this.TrgovanjeGlavaHnbCollection)
            {
                string dateString = trgovanjeGlavaHnb.Datum.ToString("yyyy-MM-dd");

                string kamatnaStopaString = "0";
                decimal? kamatnaStopa = trgovanjeGlavaHnb.KamatnaStopaUkupno();
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

        public IEnumerable<TrgovanjeGlavaHnbEntity> TrgovanjeGlavaHnbCollection { get; set; }
        public HtmlString ChartLineProsjecnaDataSource { get; set; }

        #endregion
    }
}