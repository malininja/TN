using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Text;
using System.Web.Mvc;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;

namespace NinjaSoftware.TrzisteNovca.Models.Home
{
    public class TrgovanjeGodinaViewModel
    {
        #region Constructors

        public TrgovanjeGodinaViewModel(DataAccessAdapterBase adapter, int godina)
        {
            this.TrgovanjeMjesecList = TrgovanjeMjesec.GetTrgovanjeMjesecCollection(adapter, godina);
            this.Godina = godina;
            LoadChartData(adapter, this.TrgovanjeMjesecList.Where(tm => tm.Valuta == ValutaEnum.Kn));

            this.GodinaSelectList = Helper.CreateTrgovanjeGlavaGodinaSelectList(adapter, godina);
        }

        #endregion

        #region Private methods

        private void LoadChartData(DataAccessAdapterBase adapter, IEnumerable<TrgovanjeMjesec> trgovanjeMjesecCollection)
        {
            StringBuilder chartLinePonuda = new StringBuilder(256);
            chartLinePonuda.Append("[");

            StringBuilder chartLinePotraznja = new StringBuilder(256);
            chartLinePotraznja.Append("[");

            StringBuilder chartLinePromet = new StringBuilder(256);
            chartLinePromet.Append("[");

            foreach (TrgovanjeMjesec trgovanjeMjesec in trgovanjeMjesecCollection)
            {
                if (ZakljuceniMjesecEntity.JeZakljucenMjesec(adapter, trgovanjeMjesec.Godina, trgovanjeMjesec.Mjesec))
                {
                    string ponudaString = trgovanjeMjesec.Ponuda.HasValue ? trgovanjeMjesec.Ponuda.Value.ToStringInMilions("F", "en") : "0";
                    chartLinePonuda.Append(string.Format("['{0}', {1}],", trgovanjeMjesec.Mjesec, ponudaString));

                    string potraznjaString = trgovanjeMjesec.Potraznja.HasValue ? trgovanjeMjesec.Potraznja.Value.ToStringInMilions("F", "en") : "0";
                    chartLinePotraznja.Append(string.Format("['{0}', {1}],", trgovanjeMjesec.Mjesec, potraznjaString));

                    string prometString = trgovanjeMjesec.Promet.HasValue ? trgovanjeMjesec.Promet.Value.ToStringInMilions("F", "en") : "0";
                    chartLinePromet.Append(string.Format("['{0}', {1}],", trgovanjeMjesec.Mjesec, prometString));
                }
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

        public List<TrgovanjeMjesec> TrgovanjeMjesecList { get; set; }
        public int Godina { get; set; }
        public HtmlString ChartLinePonudaDataSource { get; set; }
        public HtmlString ChartLinePotraznjaDataSource { get; set; }
        public HtmlString ChartLinePrometDataSource { get; set; }
        public List<SelectListItem> GodinaSelectList { get; set; }

        #endregion
    }
}