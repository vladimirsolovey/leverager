﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leverager.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/");
        }

        public string Details(int id)
        {
            string message = "Category = " + id;

            return message;
        }

    }
}
