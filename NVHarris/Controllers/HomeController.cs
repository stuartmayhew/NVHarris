using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NVHarris.Models;
using NVHarris.Helpers;

namespace NVHarris.Controllers
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

        public ActionResult Portfolio()
        {
            List<Portfolio> portList = ModelGetters.GetPortfolioList();
            ViewBag.Message = "Portfolio";

            return View("Portfolio",portList);
        }
    }
}