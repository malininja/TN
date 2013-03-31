﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NinjaSoftware.TrzisteNovca.Models;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using NinjaSoftware.TrzisteNovca.Models.BackOffice;
using NinjaSoftware.TrzisteNovca.Common;
using NinjaSoftware.Api.Core;
using System.Text.RegularExpressions;

namespace NinjaSoftware.TrzisteNovca.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class BackOfficeController : NinjaSoftware.Api.Mvc.NsController
    {
        public ActionResult Index()
        {
            return View();
        }

        #region Trgovanje

        [HttpGet]
        public ActionResult TrgovanjeGlavaList(int? pageNumber, string sortField, bool? isSortAscending)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                TrgovanjeGlavaPager trgovanjeGlavaPager = new TrgovanjeGlavaPager();
                trgovanjeGlavaPager.LoadData(adapter, pageNumber, Config.PageSize(), sortField, isSortAscending);
                return View(trgovanjeGlavaPager);
            }
        }

        [HttpGet]
        public ActionResult TrgovanjeEdit(long? trgovanjeGlavaId)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                TrgovanjeViewModel viewModel = new TrgovanjeViewModel(adapter, trgovanjeGlavaId);
                viewModel.LoadViewSpecificData(adapter);
                return View(viewModel);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ContentResult TrgovanjeSave(long trgovanjeGlavaId, string trgovanjeGlavaJson, string trgovanjeStavkaCollectionJson)
        {
            string returnJson;

            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory(User.Identity.Name);

            try
            {
                adapter.StartTransaction(System.Data.IsolationLevel.Serializable, "TrgovanjeSave");
                TrgovanjeViewModel viewModel = new TrgovanjeViewModel(adapter, trgovanjeGlavaId);
                viewModel.UpdateModelFromJson(trgovanjeGlavaJson, trgovanjeStavkaCollectionJson);
                viewModel.Save(adapter);

                adapter.Commit();

                string url = this.Url.Action("TrgovanjeEdit", new { trgovanjeGlavaId = viewModel.TrgovanjeGlava.TrgovanjeGlavaId });
                returnJson = string.Format("{{ \"Url\": \"{0}\" }}", url);
            }
            catch (UserException ex)
            {
                returnJson = string.Format("{{ \"Error\": \"{0}\" }}", ex.Message);
                adapter.Rollback();
            }
            catch (Exception)
            {
                adapter.Rollback();
                throw;
            }
            finally
            {
                adapter.Dispose();
            }

            return new ContentResult() { Content = returnJson, ContentType = "application/json" };
        }

        [HttpGet]
        public ActionResult TrgovanjeUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TrgovanjeUpload(FormCollection formCollection)
        {
            try
            {
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase httpPostedFileBase = Request.Files[file];

                    if (httpPostedFileBase.ContentLength > 0)
                    {
                        DateTime now = DateTime.Now;
                        string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                            Config.SettFolderPath(),
                            System.IO.Path.GetFileName(httpPostedFileBase.FileName));

                        httpPostedFileBase.SaveAs(filePath);

                        DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory(User.Identity.Name);

                        TrgovanjeGlavaEntity trgovanjeGlava = TrgovanjeGlavaEntity.LoadTrgovanjeFromSettFile(adapter, filePath, httpPostedFileBase.FileName);

                        return RedirectToAction("TrgovanjeEdit", new { trgovanjeGlavaId = trgovanjeGlava.TrgovanjeGlavaId });
                    }
                }
            }
            catch (UserException ex)
            {
                this.ViewUserErrorMessage = ex.Message;
            }


            return View();
        }

        [HttpGet]
        public ActionResult TrgovanjeDelete(long trgovanjeGlavaId)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory(User.Identity.Name);
            using (adapter)
            {
                TrgovanjeGlavaEntity trgovanjeGlava = TrgovanjeGlavaEntity.FetchTrgovanjeGlava(adapter, null, trgovanjeGlavaId);
                trgovanjeGlava.Delete(adapter);

                return RedirectToAction("TrgovanjeGlavaList");
            }
        }

        #endregion Trgovanje

        #region Repo aukcija

        [HttpGet]
        public ActionResult RepoAukcijaList(int? pageNumber, string sortField, bool? isSortAscending)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                RepoAukcijaPager repoAukcijaPager = new RepoAukcijaPager();
                repoAukcijaPager.LoadData(adapter, pageNumber, Config.PageSize(), sortField, isSortAscending);
                return View(repoAukcijaPager);
            }
        }

        [HttpGet]
        public ActionResult RepoAukcijaEdit(long? repoAukcijaId)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                RepoAukcijaEntity repoAukcija = GetRepoAukcija(adapter, repoAukcijaId);
                return View(repoAukcija);
            }
        }

        [HttpPost]
        public ActionResult RepoAukcijaEdit(long? repoAukcijaId, FormCollection formCollection)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory(User.Identity.Name);
            using (adapter)
            {
                RepoAukcijaEntity repoAukcija = GetRepoAukcija(adapter, repoAukcijaId);

                if (TryUpdateAndSaveIEntity2(repoAukcija, adapter, false, false))
                {
                    return RedirectToAction("RepoAukcijaList");
                }
                else
                {
                    return View(repoAukcija);
                }
            }
        }

        private RepoAukcijaEntity GetRepoAukcija(DataAccessAdapterBase adapter, long? repoAukcijaId)
        {
            if (repoAukcijaId.HasValue && repoAukcijaId.Value > 0)
            {
                return RepoAukcijaEntity.FetchRepoAukcija(adapter, null, repoAukcijaId.Value);
            }
            else
            {
                RepoAukcijaEntity repoAukcija = new RepoAukcijaEntity();
                repoAukcija.DatumAukcije = DateTime.Now.Date;

                return repoAukcija;
            }
        }

        [HttpGet]
        public ActionResult RepoAukcijaDelete(long repoAukcijaId)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory(User.Identity.Name);
            using (adapter)
            {
                RepoAukcijaEntity repoAukcija = GetRepoAukcija(adapter, repoAukcijaId);
                repoAukcija.Delete(adapter);
                return RedirectToAction("RepoAukcijaList");
            }
        }

        #endregion

        #region Sudionik

        [HttpGet]
        public ActionResult SudionikList(int? pageNumber, string sortField, bool? isSortAscending)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory(User.Identity.Name);
            using (adapter)
            {
                SudionikPager sudionikPager = new SudionikPager();
                sudionikPager.LoadData(adapter, pageNumber, Config.PageSize(), sortField, isSortAscending);

                return View(sudionikPager);
            }
        }

        [HttpGet]
        public ActionResult SudionikEdit(long? sudionikId)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory(User.Identity.Name);
            using (adapter)
            {
                SudionikViewModel sudionikViewModel = new SudionikViewModel(adapter, sudionikId);
                sudionikViewModel.LoadViewSpecificData(adapter);
                return View(sudionikViewModel);
            }
        }

        [HttpPost]
        public ActionResult SudionikEdit(FormCollection formCollection, long? sudionikId)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory(User.Identity.Name);
            using (adapter)
            {
                SudionikViewModel sudionikViewModel = new SudionikViewModel(adapter, sudionikId);

                if (TryUpdateAndSaveIViewModel(sudionikViewModel, adapter))
                {
                    return RedirectToAction("SudionikList");
                }
                else
                {
                    return View(sudionikViewModel);
                }
            }
        }

        [HttpGet]
        public ActionResult SudionikDelete(long sudionikId)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory(User.Identity.Name);
            using (adapter)
            {
                SudionikEntity sudionik = SudionikEntity.FetchSudionik(adapter, null, sudionikId);
                sudionik.Delete(adapter);

                return RedirectToAction("SudionikList");
            }
        }

        #endregion

        #region AukcijaTrezorskihZapisa

        [HttpGet]
        public ActionResult AukcijaTrezorskihZapisa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AukcijaTrezorskihZapisa(FormCollection formCollection)
        {
            try
            {
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase httpPostedFileBase = Request.Files[file];

                    string fileName = httpPostedFileBase.FileName;

                    if (Regex.IsMatch(fileName, @"REZUL_(\d{1,2})_(\d{1,2})_(\d{4}).xls"))
                    {
                        if (httpPostedFileBase.ContentLength > 0)
                        {
                            DateTime now = DateTime.Now;
                            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                Config.AukcijaTrezorskihZapisaFolderPath(),
                                System.IO.Path.GetFileName(fileName));

                            httpPostedFileBase.SaveAs(filePath);
                        }
                    }
                    else
                    {
                        this.ViewUserErrorMessage = "Neispravan naziv datoteke.";
                    }
                }
            }
            catch (UserException ex)
            {
                this.ViewUserErrorMessage = ex.Message;
            }


            return View();
        }

        #endregion

        #region TrgovanjeHnb

        [HttpGet]
        public ActionResult TrgovanjeGlavaHnbList(int? pageNumber, string sortField, bool? isSortAscending)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                TrgovanjeGlavaHnbPager trgovanjeGlavaHnbPager = new TrgovanjeGlavaHnbPager();
                trgovanjeGlavaHnbPager.LoadData(adapter, pageNumber, Config.PageSize(), sortField, isSortAscending);
                return View(trgovanjeGlavaHnbPager);
            }
        }

        [HttpGet]
        public ActionResult TrgovanjeHnbEdit(long? trgovanjeGlavaHnbId)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                TrgovanjeHnbViewModel viewModel = new TrgovanjeHnbViewModel(adapter, trgovanjeGlavaHnbId);
                viewModel.LoadViewSpecificData(adapter);
                return View(viewModel);
            }
        }

        [HttpPost]
        public ContentResult TrgovanjeHnbSave(long trgovanjeGlavaHnbId, string trgovanjeGlavaHnbJson, string trgovanjeStavkaHnbCollectionJson)
        {
            string returnJson;

            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory(User.Identity.Name);

            try
            {
                adapter.StartTransaction(System.Data.IsolationLevel.Serializable, "TrgovanjeHnbSave");
                TrgovanjeHnbViewModel viewModel = new TrgovanjeHnbViewModel(adapter, trgovanjeGlavaHnbId);
                viewModel.UpdateModelFromJson(trgovanjeGlavaHnbJson, trgovanjeStavkaHnbCollectionJson);
                viewModel.Save(adapter);

                adapter.Commit();

                string url = this.Url.Action("TrgovanjeHnbEdit", new { trgovanjeGlavaHnbId = viewModel.TrgovanjeGlavaHnb.TrgovanjeGlavaHnbId });
                returnJson = string.Format("{{ \"Url\": \"{0}\" }}", url);
            }
            catch (UserException ex)
            {
                returnJson = string.Format("{{ \"Error\": \"{0}\" }}", ex.Message);
                adapter.Rollback();
            }
            catch (Exception)
            {
                adapter.Rollback();
                throw;
            }
            finally
            {
                adapter.Dispose();
            }

            return new ContentResult() { Content = returnJson, ContentType = "application/json" };
        }

        [HttpGet]
        public ActionResult DohvatiTrgovanjeHnb()
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                string trgovanjeStavkaHnbCollectionJson = TrgovanjeHnbViewModel.DohvatiWebTrgovanjeGlavaHnb(adapter);
                return new ContentResult() { Content = trgovanjeStavkaHnbCollectionJson, ContentType = "application/json" };
            }
        }

        #endregion
    }
}
