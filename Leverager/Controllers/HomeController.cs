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
            /*{

                new FAQ { Id = 1, Question = "Lorem ipsum dolor sit amet?", Answer = "Cras facilisis euismod mollis. Suspendisse potenti. Suspendisse rutrum commodo nisl id ultricies. Nam consequat molestie ipsum quis euismod." },
                new FAQ { Id = 2, Question = "Mauris at lacus eu lectus pharetra varius?", Answer = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. Investigationes demonstraverunt lectores legere me lius quod ii legunt saepius. Claritas est etiam processus dynamicus, qui sequitur mutationem consuetudium lectorum. Mirum est notare quam littera gothica, quam nunc putamus parum claram, anteposuerit litterarum formas humanitatis per seacula quarta decima et quinta decima. Eodem modo typi, qui nunc nobis videntur parum clari, fiant sollemnes in futurum." },
                new FAQ { Id = 3, Question = "Nulla vitae dolor enim, vel adipiscing tortor?", Answer = "Quisque enim odio, mollis nec rutrum ac, blandit eu massa." }
            };*/

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
            catch (DataException dex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View();
        }

    }
}
