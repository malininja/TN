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

            StringBuilder chartTicks = new StringBuilder(256);
            chartTicks.Append("[");

            int i = 0;

            foreach (TrgovanjeGlavaHnbEntity trgovanjeGlavaHnb in this.TrgovanjeGlavaHnbCollection)
            {
                i++;

                string kamatnaStopaString = "0";
                decimal? kamatnaStopa = trgovanjeGlavaHnb.KamatnaStopaUkupno();
                if (kamatnaStopa.HasValue)
                {
                    kamatnaStopaString = kamatnaStopa.Value.ToString("F", new CultureInfo("en"));
                }

                bob.Append(string.Format("['{0}', {1}],", i, kamatnaStopaString));

                string dateString = string.Format("{0}.{1}.", trgovanjeGlavaHnb.Datum.Day, mjesec);
                chartTicks.Append(string.Format("[{0}, '{1}'],", i, dateString));
            }

            bob.Append("]");
            chartTicks.Append("]");

            this.ChartLineProsjecnaDataSource = new HtmlString(bob.ToString());
            this.ChartTicks = new HtmlString(chartTicks.ToString());
        }

        #endregion

        #region Properties

        public IEnumerable<TrgovanjeGlavaHnbEntity> TrgovanjeGlavaHnbCollection { get; set; }
        public HtmlString ChartLineProsjecnaDataSource { get; set; }
        public HtmlString ChartTicks { get; set; }

        #endregion
    }
}