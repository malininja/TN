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

                TrgovanjeGodinaRokTrzisteViewModel trgovanjeGodinaRokViewModel = new TrgovanjeGodinaRokTrzisteViewModel(adapter, godina.Value);
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

                TrgovanjeGodinaRokTrzisteViewModel trgovanjeGodinaRokViewModel = new TrgovanjeGodinaRokTrzisteViewModel(adapter, godina.Value);
                return View(trgovanjeGodinaRokViewModel);
            }
        }

        [HttpGet]
        public ActionResult TrgovanjeMjesecRokTrziste(int godina, int mjesec)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                TrgovanjeMjesecRokTrzisteViewModel trgovanjeMjesecRokViewModel = new TrgovanjeMjesecRokTrzisteViewModel(adapter, godina, mjesec);
                return View(trgovanjeMjesecRokViewModel);
            }
        }

        [HttpGet]
        public ActionResult TrgovanjeMjesecRokTrzisteKamatneStope(int godina, int mjesec)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                TrgovanjeMjesecRokTrzisteViewModel trgovanjeMjesecRokViewModel = new TrgovanjeMjesecRokTrzisteViewModel(adapter, godina, mjesec);
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

                TrgovanjeGodinaRokHnbViewModel viewModel = new TrgovanjeGodinaRokHnbViewModel(adapter, godina.Value);
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult TrgovanjeMjesecRokHnbKamatneStope(int godina, int mjesec)
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                TrgovanjeMjesecRokHnbViewModel trgovanjeMjesecRokViewModel = new TrgovanjeMjesecRokHnbViewModel(adapter, godina, mjesec);
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
        public ActionResult AukcijaTrezorskihZapisa()
        {
            DataAccessAdapterBase adapter = Helper.GetDataAccessAdapterFactory();
            using (adapter)
            {
                AukcijaTrezorskihZapisaViewModel viewModel = new AukcijaTrezorskihZapisaViewModel(adapter, AppDomain.CurrentDomain.BaseDirectory);
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult AukcijaTrezorskihZapisaDownload(string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Config.AukcijaTrezorskihZapisaFolderPath(), fileName);
            return File(path, "application/vnd.ms-excel");
        }

        #endregion

        #region Kamatne stope HNB

        [HttpGet]
        public ActionResult FetchKamatneStopeHnb()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.hnb.hr/monet/novcano-trziste/h-tablice-depozitni-novac.htm");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader resultStream = new StreamReader(responseStream);
            //string source = resultStream.ReadToEnd();
            
            HtmlDocument doc = new HtmlDocument();
            doc.Load(resultStream);

            string s = doc.DocumentNode.SelectNodes("/html[1]/body[1]/table[1]/tbody[1]/tr[5]/td[2]")[0].InnerText;

            return View();
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
            return File(path, "application/pdf");
        }

        #endregion
    }
}
