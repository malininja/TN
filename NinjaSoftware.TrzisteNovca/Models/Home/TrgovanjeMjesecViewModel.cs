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
                LoadChartData(this.TrgovanjeGlavaCollection, godina, mjesec);
            }

            CalculateSums(this.TrgovanjeGlavaCollection, valutaEnum);
        }

        #endregion

        #region Private methods

        private void LoadChartData(IEnumerable<TrgovanjeGlavaEntity> trgovanjeGlavaCollection, int godina, int mjesec)
        {
            StringBuilder chartLinePonuda = new StringBuilder(256);
            chartLinePonuda.Append("[");

            StringBuilder chartLinePotraznja = new StringBuilder(256);
            chartLinePotraznja.Append("[");

            StringBuilder chartLinePromet = new StringBuilder(256);
            chartLinePromet.Append("[");

            StringBuilder chartTicks = new StringBuilder(256);
            chartTicks.Append("[");

            int i = 0;

            foreach (TrgovanjeGlavaEntity trgovanjeGlava in trgovanjeGlavaCollection)
            {
                i++;

                decimal ponuda = trgovanjeGlava.Ponuda(ValutaEnum.Kn);
                decimal potraznja = trgovanjeGlava.Potraznja(ValutaEnum.Kn);
                decimal promet = trgovanjeGlava.Promet(ValutaEnum.Kn);

                //string dateString = trgovanjeGlava.Datum.ToString("yyyy-MM-dd");
                chartLinePonuda.Append(string.Format("['{0}', {1}],", i, ponuda.ToStringInMilions("F", "en")));
                chartLinePotraznja.Append(string.Format("['{0}', {1}],",i, potraznja.ToStringInMilions("F", "en")));
                chartLinePromet.Append(string.Format("['{0}', {1}],", i, promet.ToStringInMilions("F", "en")));

                string dateString = string.Format("{0}.{1}.", trgovanjeGlava.Datum.Day, mjesec);
                chartTicks.Append(string.Format("[{0}, '{1}'],", i, dateString));
            }

            chartLinePonuda.Append("]");
            chartLinePotraznja.Append("]");
            chartLinePromet.Append("]");

            int noOfDays = DateTime.DaysInMonth(godina, mjesec);

            //StringBuilder chartTicks = new StringBuilder(256);
            //chartTicks.Append("[");

            //for (int i = 1; i <= noOfDays; i = i + 1)
            //{
            //    string dateString = string.Format("{0}.{1}.", i, mjesec);
            //    chartTicks.Append(string.Format("[{0}, '{1}'],", i, dateString));
            //}
            chartTicks.Append("]");

            this.ChartLinePonudaDataSource = new HtmlString(chartLinePonuda.ToString());
            this.ChartLinePotraznjaDataSource = new HtmlString(chartLinePotraznja.ToString());
            this.ChartLinePrometDataSource = new HtmlString(chartLinePromet.ToString());
            this.ChartTicks = new HtmlString(chartTicks.ToString());
        }

        private void CalculateSums(IEnumerable<TrgovanjeGlavaEntity> trgovanjeGlavaCollection, ValutaEnum valutaEnum)
        {
            foreach (TrgovanjeGlavaEntity trgovanjeGlava in trgovanjeGlavaCollection)
            {
                decimal ponuda = trgovanjeGlava.Ponuda(valutaEnum);
                decimal potraznja = trgovanjeGlava.Potraznja(valutaEnum);
                decimal promet = trgovanjeGlava.Promet(valutaEnum);

                this.PonudaUkupno += ponuda;
                this.PotraznjaUkupno += potraznja;
                this.PrometUkupno += promet;
            }
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
        public HtmlString ChartTicks { get; set; }
        public decimal PonudaUkupno { get; set; }
        public decimal PotraznjaUkupno { get; set; }
        public decimal PrometUkupno { get; set; }

        #endregion
    }
}