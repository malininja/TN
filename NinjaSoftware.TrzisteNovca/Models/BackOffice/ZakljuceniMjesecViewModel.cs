using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.Api.Mvc;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using System.Web.Mvc;

namespace NinjaSoftware.TrzisteNovca.Models.BackOffice
{
    public class ZakljuceniMjesecViewModel: IViewModel
    {
        #region Constructors

        public ZakljuceniMjesecViewModel()
        {
            this.ZakljuceniMjesec = new ZakljuceniMjesecEntity();
        }

        #endregion

        #region Public methods

        public void LoadViewSpecificData(DataAccessAdapterBase adapter)
        {
            this.ZakljuceniMjesecCollection = ZakljuceniMjesecEntity.FetchZakljuceniMjesecCollection(adapter, null, null).
                OrderByDescending(zm => zm.Mjesec).
                OrderByDescending(zm => zm.Godina);

            this.GodinaSelectList = new List<SelectListItem>();
            for (int i = 2000; i <= DateTime.Now.Year; i++)
            {
                SelectListItem item = new SelectListItem() 
                {
                    Value = i.ToString(),
                    Text = i.ToString(),
                    Selected = i == DateTime.Now.Year
                };

                this.GodinaSelectList.Add(item);
            }

            this.MjesecSelectList = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                SelectListItem item = new SelectListItem()
                {
                    Value = i.ToString(),
                    Text = i.ToString(),
                    Selected = i == DateTime.Now.Month
                };

                this.MjesecSelectList.Add(item);
            }
        }

        public void Save(DataAccessAdapterBase adapter)
        {
            this.ZakljuceniMjesec.Save(adapter, false, false);
        }

        #endregion

        #region Properties

        public IEnumerable<ZakljuceniMjesecEntity> ZakljuceniMjesecCollection { get; set; }
        public List<SelectListItem> GodinaSelectList { get; set; }
        public List<SelectListItem> MjesecSelectList { get; set; }
        public ZakljuceniMjesecEntity ZakljuceniMjesec { get; set; }

        #endregion
    }
}