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
            this.TrgovanjeMjesecRok = TrgovanjeMjesecRok.GetTrgovanjeMjesecRok(adapter, godina, mjesec, Helper.TrgovanjeVrstaEnumArrayZaPrikaz); 
                
            this.TrgovanjeGlavaCollection = TrgovanjeGlavaEntity.FetchTrgovanjeGlavaCollection(adapter, godina, mjesec, ValutaEnum.Kn).OrderBy(tg => tg.Datum);

            StringBuilder bob = new StringBuilder(256);
            bob.Append("[");

            StringBuilder chartTicks = new StringBuilder(256);
            chartTicks.Append("[");

            int i = 0;

            foreach (TrgovanjeGlavaEntity trgovanjeGlava in this.TrgovanjeGlavaCollection)
            {
                i++;

                string kamatnaStopaString = "0";
                decimal? kamatnaStopa = trgovanjeGlava.PrometKamatnaStopaPosto(ValutaEnum.Kn);
                if (kamatnaStopa.HasValue)
                {
                    kamatnaStopaString = kamatnaStopa.Value.ToString("F", new CultureInfo("en"));
                }
                
                bob.Append(string.Format("['{0}', {1}],", i, kamatnaStopaString));

                string dateString = string.Format("{0}.{1}.", trgovanjeGlava.Datum.Day, mjesec);
                chartTicks.Append(string.Format("[{0}, '{1}'],", i, dateString));
            }

            bob.Append("]");
            chartTicks.Append("]");

            this.ChartLineProsjecnaDataSource = new HtmlString(bob.ToString());
            this.ChartTicks = new HtmlString(chartTicks.ToString());
        }

        #endregion

        #region Properties

        public IEnumerable<TrgovanjeGlavaEntity> TrgovanjeGlavaCollection { get; set; }
        public HtmlString ChartLineProsjecnaDataSource { get; set; }
        public HtmlString ChartTicks { get; set; }
        public TrgovanjeMjesecRok TrgovanjeMjesecRok { get; set; } 

        #endregion
    }
}