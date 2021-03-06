﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.Models;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;
using NinjaSoftware.TrzisteNovca.Models.Home;
using System.IO;
using NinjaSoftware.TrzisteNovca.Common;
using System.Net;
using HtmlAgilityPack;

namespace NinjaSoftware.TrzisteNovca.Controllers
{
    //[HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index(DateTime? date)
        { 
            return RedirectToAction("TrgovanjeDan");
        }

        [HttpGet]
        public ActionResult Aukcija()
        {
            return View();
        }

        #region Trgovanje

        [HttpGet]
        public ActionResult TrgovanjeDan(DateTime? date)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                if (!date.HasValue)
                {
                    date = DateTime.Now.Date;
                }

                TrgovanjeDanViewModel trgovanjeDanViewModel = new TrgovanjeDanViewModel(adapter, date.Value);
                return View(trgovanjeDanViewModel);
            }       
        }

        [HttpGet]
        public ActionResult TrgovanjeGodina(int? godina)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                if (!godina.HasValue)
                {
                    godina = DateTime.Now.Year;
                }

                TrgovanjeGodinaViewModel trgovanjeGodinaViewModel = new TrgovanjeGodinaViewModel(adapter, godina.Value);
                return View(trgovanjeGodinaViewModel);
            }
        }

        [HttpGet]
        public ActionResult TrgovanjeMjesec(int godina, int mjesec, ValutaEnum valutaEnum)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                TrgovanjeMjesecViewModel trgovanjeMjesecViewModel = new TrgovanjeMjesecViewModel(adapter, godina, mjesec, valutaEnum);
                return View(trgovanjeMjesecViewModel);
            }        
        }

        [HttpGet]
        public ActionResult TrgovanjeGodinaRok(int? godina)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                if (!godina.HasValue)
                {
                    godina = DateTime.Now.Year;
                }

                TrgovanjeGodinaRokTrzisteViewModel trgovanjeGodinaRokViewModel = 
                    new TrgovanjeGodinaRokTrzisteViewModel(adapter, godina.Value, Helper.TrgovanjeVrstaEnumArrayZaPrikaz);
                return View(trgovanjeGodinaRokViewModel);
            }  
        }

        [HttpGet]
        public ActionResult TrgovanjeGodinaRokKamatneStope(int? godina)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                if (!godina.HasValue)
                {
                    godina = DateTime.Now.Year;
                }

                TrgovanjeGodinaRokTrzisteViewModel trgovanjeGodinaRokViewModel = 
                    new TrgovanjeGodinaRokTrzisteViewModel(adapter, godina.Value, Helper.TrgovanjeVrstaEnumArrayZaPrikaz);
                return View(trgovanjeGodinaRokViewModel);
            }
        }

        [HttpGet]
        public ActionResult TrgovanjeMjesecRokTrziste(int godina, int mjesec)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                TrgovanjeMjesecRokTrzisteViewModel trgovanjeMjesecRokViewModel = 
                    new TrgovanjeMjesecRokTrzisteViewModel(adapter, godina, mjesec, Helper.TrgovanjeVrstaEnumArrayZaPrikaz);
                return View(trgovanjeMjesecRokViewModel);
            }
        }

        [HttpGet]
        public ActionResult TrgovanjeMjesecRokTrzisteKamatneStope(int godina, int mjesec)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                TrgovanjeMjesecRokTrzisteViewModel trgovanjeMjesecRokViewModel = 
                    new TrgovanjeMjesecRokTrzisteViewModel(adapter, godina, mjesec, Helper.TrgovanjeVrstaEnumArrayZaPrikaz);
                return View(trgovanjeMjesecRokViewModel);
            }
        }

        #endregion

        #region TrgovanjeHnb

        [HttpGet]
        public ActionResult TrgovanjeGodinaRokHnbKamatneStope(int? godina)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                if (!godina.HasValue)
                {
                    godina = DateTime.Now.Year;
                }

                TrgovanjeGodinaRokHnbViewModel viewModel = 
                    new TrgovanjeGodinaRokHnbViewModel(adapter, godina.Value, Helper.HnbTrgovanjeVrstaEnumArrayZaPrikaz);
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult TrgovanjeMjesecRokHnbKamatneStope(int godina, int mjesec)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                TrgovanjeMjesecRokHnbViewModel trgovanjeMjesecRokViewModel = 
                    new TrgovanjeMjesecRokHnbViewModel(adapter, godina, mjesec, Helper.HnbTrgovanjeVrstaEnumArrayZaPrikaz);
                return View(trgovanjeMjesecRokViewModel);
            }
        }

        #endregion

        #region RepoAukcija

        [HttpGet]
        public ActionResult RepoAukcija(DateTime? datumAukcije)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                RepoAukcijaViewModel repoAukcijaViewModel = new RepoAukcijaViewModel(adapter, datumAukcije);
                return View(repoAukcijaViewModel);
            }
        }

        #endregion

        #region Sudionik

        [HttpGet]
        public ActionResult SudionikGrupaList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SudionikList(long sudionikGrupaId)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                SudionikViewModel sudionikViewModel = new SudionikViewModel(adapter, sudionikGrupaId);
                return View(sudionikViewModel);
            }
        }

        #endregion

        #region AukcijaTrezorskihZapisa

        [HttpGet]
        public ActionResult AukcijaTrezorskihZapisa(int? pageNumber, string sortField, bool? isSortAscending)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                AukcijaTrezorskihZapisaPager viewModel = new AukcijaTrezorskihZapisaPager(adapter, AppDomain.CurrentDomain.BaseDirectory);
                viewModel.LoadData(adapter, pageNumber, Config.PageSize(), sortField, isSortAscending);
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult AukcijaTrezorskihZapisaDownload(string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Config.AukcijaTrezorskihZapisaFolderPath(), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "application/vnd.ms-excel", fileName);
        }

        #endregion

        #region HtmlPage

        [HttpGet]
        public ActionResult SysHtmlPage(long sistemskaInstancaPodatakaId)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                HtmlPageEntity htmlPage = HtmlPageEntity.FetchHtmlPage(adapter, sistemskaInstancaPodatakaId);
                return View("HtmlPage" ,htmlPage);
            }
        }

        [HttpGet]
        public ActionResult HtmlPage(long htmlPageId)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                HtmlPageEntity htmlPage = HtmlPageEntity.FetchHtmlPage(adapter, null, htmlPageId);
                return View(htmlPage);
            }
        }

        [HttpGet]
        public ActionResult PdfDownload(string folderName, string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Config.PdfFolderPath(), folderName, fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Pdf, fileName);
        }

        [HttpGet]
        public ActionResult DocDownload(string folderName, string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Config.PdfFolderPath(), folderName, fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "application/msword", fileName);
        }

        [HttpGet]
        public ActionResult PptDownload(string folderName, string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Config.PdfFolderPath(), folderName, fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "application/x-mspowerpoint", fileName);
        }

        [HttpGet]
        public ActionResult KonferencijaList()
        {
            return View();
        }

        #endregion

        #region Kamatna stope HNB

        [HttpGet]
        public ActionResult KamatnaStopaHnb()
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                KamatnaStopaHnbEntity kamatnaStopaHnb = KamatnaStopaHnbEntity.FetchKamatnaStopaHnb(adapter, null, 1);
                return View(kamatnaStopaHnb);
            }
        }

        #endregion

        #region Kamatna stopa

        [HttpGet]
        public ActionResult KamatnaStopa(DateTime? date, long? trgovanjeId, bool jeHnbTrgovanje)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                KamatnaStopaViewModel viewModel = new KamatnaStopaViewModel(adapter, jeHnbTrgovanje, trgovanjeId, date);
                return View(viewModel);
            }
        }

        #endregion
    }
}
