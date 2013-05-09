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
    public class TrgovanjeGodinaRokTrzisteViewModel : TrgovanjeGodinaRokViewModelBase
    {
        #region Constructors

        public TrgovanjeGodinaRokTrzisteViewModel(DataAccessAdapterBase adapter, int godina, TrgovanjeVrstaEnum[] trgovanjeVrstaEnumArray)
            :base(adapter, godina, trgovanjeVrstaEnumArray)
        {
            this.TrgovanjeMjesecRokCollection = TrgovanjeMjesecRok.GetTrgovanjeMjesecRokCollection(adapter, godina, trgovanjeVrstaEnumArray);
            this.GodinaSelectList = Helper.CreateTrgovanjeGlavaGodinaSelectList(adapter, godina);

            this.TrgovanjeRokList = new List<TrgovanjeRok>();

            StringBuilder bob = new StringBuilder(256);
            bob.Append("[");

            foreach (TrgovanjeMjesecRok trgovanjeMjesecRok in this.TrgovanjeMjesecRokCollection)
            {
                if (ZakljuceniMjesecEntity.JeZakljucenMjesec(adapter, trgovanjeMjesecRok.Godina, trgovanjeMjesecRok.Mjesec))
                {
                    string kamatnaUkupno = "0";
                    if (trgovanjeMjesecRok.KamatnaStopaUkupno.HasValue)
                    {
                        kamatnaUkupno = trgovanjeMjesecRok.KamatnaStopaUkupno.Value.ToString("F", new CultureInfo("en"));
                    }

                    bob.Append(string.Format("['{0}', {1}],", trgovanjeMjesecRok.Mjesec, kamatnaUkupno));
                }

                foreach (TrgovanjeRok trgovanjeRok in trgovanjeMjesecRok.TrgovanjeRokList)
                {
                    TrgovanjeRok trgovanjeRokTmp =
                        this.TrgovanjeRokList.Where(tr => tr.TrgovanjeVrstaEnum == trgovanjeRok.TrgovanjeVrstaEnum).SingleOrDefault();

                    if (null == trgovanjeRokTmp)
                    {
                        this.TrgovanjeRokList.Add(new TrgovanjeRok() 
                        { 
                            KamatnaStopa = trgovanjeRok.KamatnaStopa,
                            Promet = trgovanjeRok.Promet,
                            TrgovanjeVrstaEnum = trgovanjeRok.TrgovanjeVrstaEnum
                        });
                    }
                    else
                    {
                        trgovanjeRokTmp.Promet += trgovanjeRok.Promet;
                    }
                }
            }

            bob.Append("]");
            this.ChartLineProsjecnaDataSource = new HtmlString(bob.ToString());
        }

        #endregion

        #region Private methods

        

        #endregion

        #region Properties

        public IEnumerable<TrgovanjeMjesecRok> TrgovanjeMjesecRokCollection { get; set; }
        public List<TrgovanjeRok> TrgovanjeRokList { get; set; }
        public HtmlString ChartLineProsjecnaDataSource { get; set; }

        #endregion
    }
}