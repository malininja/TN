using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;
using System.Text;
using System.Globalization;

namespace NinjaSoftware.TrzisteNovca.Models.Home
{
    public class TrgovanjeDanViewModel
    {
        #region Constructors

        public TrgovanjeDanViewModel(DataAccessAdapterBase adapter, DateTime date)
        {
            this.TrgovanjeGlava = TrgovanjeGlavaEntity.FetchTrgovanjeGlavaForGuiDisplay(adapter, date);
            IEnumerable<TrgovanjeGlavaEntity> trgovanjeGlavaCollection = TrgovanjeGlavaEntity.FetchTrgovanjeGlavaCollection(adapter, date.AddDays(-14), date.AddDays(1), ValutaEnum.Kn);
            LoadChartData(trgovanjeGlavaCollection);
        }

        #endregion

        #region PrivateMethods

        private void LoadChartData(IEnumerable<TrgovanjeGlavaEntity> trgovanjeGlavaCollection)
        {
            StringBuilder chartLinePonuda = new StringBuilder(512);
            chartLinePonuda.Append("[");

            StringBuilder chartLinePotraznja = new StringBuilder(512);
            chartLinePotraznja.Append("[");

            StringBuilder chartLinePromet = new StringBuilder(512);
            chartLinePromet.Append("[");

            StringBuilder chartLineKamatnaStopa = new StringBuilder(512);
            chartLineKamatnaStopa.Append("[");

            StringBuilder chartTicks = new StringBuilder(256);
            chartTicks.Append("[");

            int i = 0;

            foreach (TrgovanjeGlavaEntity trgovanjeGlava in trgovanjeGlavaCollection)
            {
                i++;

                chartLinePonuda.Append(string.Format("['{0}', {1}],", i, trgovanjeGlava.Ponuda(ValutaEnum.Kn).ToStringInMilions("F", "en")));
                chartLinePotraznja.Append(string.Format("['{0}', {1}],", i, trgovanjeGlava.Potraznja(ValutaEnum.Kn).ToStringInMilions("F", "en")));
                chartLinePromet.Append(string.Format("['{0}', {1}],", i, trgovanjeGlava.Promet(ValutaEnum.Kn).ToStringInMilions("F", "en")));

                CultureInfo cultureInfo = new CultureInfo("en");
                decimal? kamatnaStopa = trgovanjeGlava.PrometKamatnaStopaPosto(ValutaEnum.Kn);
                string kamatnaStopaString = kamatnaStopa.HasValue ? kamatnaStopa.Value.ToString("F", cultureInfo) : "0";
                chartLineKamatnaStopa.Append(string.Format("['{0}', {1}],", i, kamatnaStopaString));

                string dateString = string.Format("{0}.{1}.", trgovanjeGlava.Datum.Day, trgovanjeGlava.Datum.Month);
                chartTicks.Append(string.Format("[{0}, '{1}'],", i, dateString));
            }

            chartLinePonuda.Append("]");
            chartLinePotraznja.Append("]");
            chartLinePromet.Append("]");
            chartLineKamatnaStopa.Append("]");
            chartTicks.Append("]");

            this.ChartLinePonudaDataSource = new HtmlString(chartLinePonuda.ToString());
            this.ChartLinePotraznjaDataSource = new HtmlString(chartLinePotraznja.ToString());
            this.ChartLinePrometDataSource = new HtmlString(chartLinePromet.ToString());
            this.ChartLineKamatnaStopaDataSource = new HtmlString(chartLineKamatnaStopa.ToString());
            this.ChartTicks = new HtmlString(chartTicks.ToString());
        }

        #endregion

        #region Properties

        public TrgovanjeGlavaEntity TrgovanjeGlava { get; set; }
        public HtmlString ChartLinePonudaDataSource { get; set; }
        public HtmlString ChartLinePotraznjaDataSource { get; set; }
        public HtmlString ChartLinePrometDataSource { get; set; }
        public HtmlString ChartLineKamatnaStopaDataSource { get; set; }
        public HtmlString ChartTicks { get; set; }

        #endregion
    }
}