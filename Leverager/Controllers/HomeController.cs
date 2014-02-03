using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Leverager.Models;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace Leverager.Controllers
{
    public class HomeController : Controller
    {
        private ModelContext context = new ModelContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.Title = "Home";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About Leverager";
            ViewBag.Message = "The Power of Collective Buying";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }

        public ActionResult FAQ()
        {
            ViewBag.Message = "Frequently Asked Questions";
            ViewBag.Title = "FAQ";

            var questions = new ModelContext().FAQSet.ToList();

            return View(questions);
        }

        public ActionResult Suggest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Suggest(SuggestProduct suggestProduct)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    suggestProduct.StatusId = Status.New;
                    context.SuggestProduct.Add(suggestProduct);
                    context.SaveChanges();
                    MailMessage msg = new MailMessage("dont_reply@theleverager.com", "evgeniysolovey@gmail.com") { 
                        Subject="Product Suggestions", 
                        Body="New product have beed suggested, please visit theleverager.com"  
                    };
                    SmtpClient smtpClient = new SmtpClient("");
                    smtpClient.Credentials = CredentialCache.DefaultNetworkCredentials;
                    //smtpClient.Send(msg);
                    return View("Index");
                }

            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator." + ex.Message);
            }
            return View();
        }

    }
}
