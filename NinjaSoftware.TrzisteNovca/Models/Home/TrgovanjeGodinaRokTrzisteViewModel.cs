using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses;
using System.Web.Mvc;

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

            foreach (TrgovanjeMjesecRok trgovanjeMjesecRok in this.TrgovanjeMjesecRokCollection)
            {
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
        }

        #endregion

        #region Private methods

        

        #endregion

        #region Properties

        public IEnumerable<TrgovanjeMjesecRok> TrgovanjeMjesecRokCollection { get; set; }
        public List<TrgovanjeRok> TrgovanjeRokList { get; set; }

        #endregion
    }
}