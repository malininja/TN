using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Text;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;

namespace NinjaSoftware.TrzisteNovca.Models.Home
{
    public class TrgovanjeMjesecViewModel
    {
        #region Constructors

        public TrgovanjeMjesecViewModel(DataAccessAdapterBase adapter, int godina, int mjesec, ValutaEnum valutaEnum)
        {
            this.TrgovanjeGlavaCollection = TrgovanjeGlavaEntity.FetchTrgovanjeGlavaCollection(adapter, godina, mjesec, valutaEnum).OrderBy(tg => tg.Datum);
            this.Godina = godina;
            this.Mjesec = mjesec;
            this.ValutaEnum = valutaEnum;

            if (ValutaEnum.Kn == valutaEnum)
            {
                LoadChartData(this.TrgovanjeGlavaCollection);
            }
        }

        #endregion

        #region Private methods

        private void LoadChartData(IEnumerable<TrgovanjeGlavaEntity> trgovanjeGlavaCollection)
        {
            StringBuilder chartLinePonuda = new StringBuilder(256);
            chartLinePonuda.Append("[");

            StringBuilder chartLinePotraznja = new StringBuilder(256);
            chartLinePotraznja.Append("[");

            StringBuilder chartLinePromet = new StringBuilder(256);
            chartLinePromet.Append("[");

            foreach (TrgovanjeGlavaEntity trgovanjeGlava in trgovanjeGlavaCollection)
            {
                string dateString = trgovanjeGlava.Datum.ToString("yyyy-MM-dd");
                chartLinePonuda.Append(string.Format("['{0}', {1}],", dateString, trgovanjeGlava.Ponuda(ValutaEnum.Kn).ToStringInMilions("F", "en")));
                chartLinePotraznja.Append(string.Format("['{0}', {1}],", dateString, trgovanjeGlava.Potraznja(ValutaEnum.Kn).ToStringInMilions("F", "en")));
                chartLinePromet.Append(string.Format("['{0}', {1}],", dateString, trgovanjeGlava.Promet(ValutaEnum.Kn).ToStringInMilions("F", "en")));
            }

            chartLinePonuda.Append("]");
            chartLinePotraznja.Append("]");
            chartLinePromet.Append("]");

            this.ChartLinePonudaDataSource = new HtmlString(chartLinePonuda.ToString());
            this.ChartLinePotraznjaDataSource = new HtmlString(chartLinePotraznja.ToString());
            this.ChartLinePrometDataSource = new HtmlString(chartLinePromet.ToString());
        }

        #endregion

        #region Properties

        public IEnumerable<TrgovanjeGlavaEntity> TrgovanjeGlavaCollection { get; set; }
        public int Godina { get; set; }
        public int Mjesec { get; set; }
        public ValutaEnum ValutaEnum { get; set; }
        public HtmlString ChartLinePonudaDataSource { get; set; }
        public HtmlString ChartLinePotraznjaDataSource { get; set; }
        public HtmlString ChartLinePrometDataSource { get; set; }

        #endregion
    }
}