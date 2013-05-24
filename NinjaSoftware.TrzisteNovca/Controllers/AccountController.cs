using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NinjaSoftware.TrzisteNovca.Models;
using System.Web.Security;

namespace NinjaSoftware.TrzisteNovca.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                NsMembershipProvider membershipProvider = new NsMembershipProvider();
                if (membershipProvider.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.RedirectFromLoginPage(model.UserName, false);
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Index", "BackOffice");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Neispravno korisničko ime ili lozinka.");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
