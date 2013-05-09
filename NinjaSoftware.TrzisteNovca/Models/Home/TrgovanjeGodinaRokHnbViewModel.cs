using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses;
using System.Web.Mvc;
using System.Text;
using System.Globalization;

namespace NinjaSoftware.TrzisteNovca.Models.Home
{
    public class TrgovanjeGodinaRokHnbViewModel : TrgovanjeGodinaRokViewModelBase
    {
        #region Constructors

        public TrgovanjeGodinaRokHnbViewModel(DataAccessAdapterBase adapter, int godina, TrgovanjeVrstaEnum[] trgovanjeVrstaEnumArray)
            :base(adapter, godina, trgovanjeVrstaEnumArray)
        {
            this.TrgovanjeMjesecRokHnbCollection = TrgovanjeMjesecRokHnb.GetTrgovanjeMjesecRokHnbCollection(adapter, godina, trgovanjeVrstaEnumArray);
            this.GodinaSelectList = Helper.CreateTrgovanjeGlavaHnbGodinaSelectList(adapter, godina);

            StringBuilder bob = new StringBuilder(256);
            bob.Append("[");

            foreach (TrgovanjeMjesecRokHnb trgovanjeMjesecRokHnb in this.TrgovanjeMjesecRokHnbCollection)
            {
                if (ZakljuceniMjesecEntity.JeZakljucenMjesec(adapter, trgovanjeMjesecRokHnb.Godina, trgovanjeMjesecRokHnb.Mjesec))
                {
                    string kamatnaUkupno = "0";
                    if (trgovanjeMjesecRokHnb.KamatnaStopaUkupno.HasValue)
                    {
                        kamatnaUkupno = trgovanjeMjesecRokHnb.KamatnaStopaUkupno.Value.ToString("F", new CultureInfo("en"));
                    }

                    bob.Append(string.Format("['{0}', {1}],", trgovanjeMjesecRokHnb.Mjesec, kamatnaUkupno));
                }
                else
                {
                    trgovanjeMjesecRokHnb.PrometUkupno = null;
                    trgovanjeMjesecRokHnb.KamatnaStopaUkupno = null;
                    trgovanjeMjesecRokHnb.TrgovanjeRokList.Clear();
                }
            }

            bob.Append("]");
            this.ChartLineProsjecnaDataSource = new HtmlString(bob.ToString());
        }

        #endregion

        #region Properties

        public IEnumerable<TrgovanjeMjesecRokHnb> TrgovanjeMjesecRokHnbCollection { get; set; }
        public HtmlString ChartLineProsjecnaDataSource { get; set; }

        #endregion
    }
}