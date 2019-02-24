using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.Models;
using NinjaSoftware.TrzisteNovca.Models.Admin;
using NinjaSoftware.TrzisteNovca.Common;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;

namespace NinjaSoftware.TrzisteNovca.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : NinjaSoftware.Api.Mvc.NsController
    {
        #region HtmlPage

        [HttpGet]
        public ActionResult HtmlPageList(int? pageNumber, string sortField, bool? isSortAscending)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                HtmlPagePager pager = new HtmlPagePager();
                pager.LoadData(adapter, pageNumber, Config.PageSize(), sortField, isSortAscending);

                return View(pager);
            }
        }

        [HttpGet]
        public ActionResult HtmlPageEdit(long? htmlPageId)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                HtmlPageEntity htmlPage = GetHtmlPage(adapter, htmlPageId);
                return View(htmlPage);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult HtmlPageEdit(long? htmlPageId, FormCollection formCollection)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory(User.Identity.Name);
            using (adapter)
            {
                HtmlPageEntity htmlPage = GetHtmlPage(adapter, htmlPageId);

                if (TryUpdateAndSaveIEntity2(htmlPage, adapter, false, false))
                {
                    return RedirectToAction("HtmlPageList");
                }
                else
                {
                    return View(htmlPage);
                }
            }
        }

        private HtmlPageEntity GetHtmlPage(DataAccessAdapterBase adapter, long? htmlPageId)
        {
            if (htmlPageId.HasValue && htmlPageId.Value > 0)
            {
                return HtmlPageEntity.FetchHtmlPage(adapter, null, htmlPageId.Value);
            }
            else
            {
                return new HtmlPageEntity();
            }
        }

        #endregion
    }
}
