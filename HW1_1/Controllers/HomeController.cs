﻿using HW1_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HW1_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login(string ReturnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
            //return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM login,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                
                FormsAuthentication.RedirectFromLoginPage(login.Username, false);
                //FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "SHA1");

                if (ReturnUrl.StartsWith("/"))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}