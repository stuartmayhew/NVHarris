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
            Contact contact = new Contact();
            contact.ContactDate = DateTime.Now;
            return View("Contact",contact);
        }

        public ActionResult SaveContact(Contact contact)
        {
            contact.ContactID = new ModelToSQL<Contact>().WriteInsertSQL("Contact", contact, "ContactID");
            MailHelper mh = new MailHelper();
            if (mh.SendContactEmail(contact))
                ViewBag.SentMessage = "Your Message has been sent and we have emailed you a copy";
            else
                ViewBag.SentMessage = "Sending failed. Please contact us at 251-454-3514";
            return View("Contact", contact);
        }

        public ActionResult Portfolio()
        {
            List<Portfolio> portList = ModelGetters.GetPortfolioList();
            ViewBag.Message = "Portfolio";

            return View("Portfolio",portList);
        }
    }
}