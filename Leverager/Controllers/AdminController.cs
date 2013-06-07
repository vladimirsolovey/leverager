using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Leverager.Models;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;

namespace Leverager.Controllers
{
    public class AdminController : Controller
    {
        private ModelContext context = new ModelContext();

        //
        // GET: /Admin/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ShowCategory()
        {
            return View("ShowCategory", context.Categories.Include(p => p.Parents).ToList());
        }

        //GET: /Admin/NewCategory
        [Authorize(Roles = "Admin")]
        public ActionResult NewCategory()
        {
            return PartialView("_NewCategory");
        }

        //POST:/Admin/NewCategory/<Category>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult NewCategory(Category newCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Categories.Add(newCategory);
                    context.SaveChanges();
                    return RedirectToAction("ShowCategory");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return PartialView("_NewCategory");
        }

        //For Security reasons i restrict access to delete action, now it is only possible by HTTP POST, which requires form, or javascript aproach. 
        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCategory(int id = 0)
        {
            var categoryIdSqlParam = new SqlParameter("@catagoryID",id);
            context.Database.ExecuteSqlCommand("EXEC DeleteCategory @catagoryID", categoryIdSqlParam);
            context.SaveChanges();
            return RedirectToActionPermanent("ShowCategory", "Admin");
        }

        public ActionResult DetailsCategory(int id)
        {
            var categoryToView = new ModelContext().Categories.Include(p => p.Children).Where(p => p.Id == id).Single();
            context.Entry(categoryToView).State=EntityState.Modified;
            return View(categoryToView);
        }

        public ActionResult DeleteChildren(int id)
        {
            context.Categories.SqlQuery("DELETE FROM CategoryCategories WHERE ParentId=@id", new System.Data.SqlClient.SqlParameter( "id", id ));
            return View("DetailsCategory",context.Categories.Include(p=>p.Children).Where(p=>p.Id==id).Single());
        }

        //GET:
        [Authorize(Roles = "Admin")]
        public ActionResult EditCategory(int id)
        {
            var categoryToEdit = context.Categories.Find(id);
            return PartialView("_EditCategory", categoryToEdit);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditCategory(Category editCategory)
        {
            if (ModelState.IsValid)
            {
                context.Entry(editCategory).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("ShowCategory"); 
            }
            return PartialView("_EditCategory",editCategory);
        }

        public ActionResult SuggestList(string status="All")
        {
            int iStatus = Status.ToInt(status);
            ViewBag.CurrentStatus = iStatus;
            if (Status.ToInt(status) != Status.All)
                return View(context.SuggestProduct.Where(p => p.StatusId == iStatus).Include(p => p.Status).ToList());
            else
                return View(context.SuggestProduct.Include(p => p.Status).ToList());
        }

        public ActionResult SetStatus(int id, int status)
        {
            SuggestProduct product = context.SuggestProduct.Find(id);
            product.StatusId = status;
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToActionPermanent("SuggestList", "Admin");
        }

        public ActionResult FAQ()
        {
            return View("FAQ", context.FAQSet.ToList());
        }

        //GET: /Admin/NewCategory
        [Authorize(Roles = "Admin")]
        public ActionResult NewFAQ()
        {
            return PartialView("_NewFAQ");
        }

        //POST:/Admin/NewCategory/<Category>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult NewFAQ(FAQ newFAQ)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.FAQSet.Add(newFAQ);
                    context.SaveChanges();
                    return RedirectToAction("FAQ");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return PartialView("_NewFAQ");
        }

        //For Security reasons i restrict access to delete action, now it is only possible by HTTP POST, which requires form, or javascript aproach. 
        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteFAQ(int id = 0)
        {
            var FAQToDelete = new ModelContext().FAQSet.Where(p => p.Id == id).Single();
            context.FAQSet.Remove(FAQToDelete);
            context.SaveChanges();
            return RedirectToActionPermanent("FAQ", "Admin");
        }

        //GET:
        [Authorize(Roles = "Admin")]
        public ActionResult EditFAQ(int id)
        {
            var categoryToEdit = context.FAQSet.Find(id);
            return PartialView("_EditFAQ", categoryToEdit);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditFAQ(FAQ editFAQ)
        {
            if (ModelState.IsValid)
            {
                context.Entry(editFAQ).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("FAQ");
            }
            return PartialView("_EditFAQ", editFAQ);
        }
    }
}
