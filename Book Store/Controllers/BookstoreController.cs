using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Store.Controllers
{
    public class BookstoreController : Controller
    {
        // GET: Bookstore
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bookstore/Books
        public ActionResult Books()
        {
            ViewBag.Message = "Our books page.";

            return View();
        }

        // GET: Bookstore/Publishers
        public ActionResult Publishers()
        {
            ViewBag.Message = "Our publisers page.";

            return View();
        }

        // GET: Bookstore/Authors
        public ActionResult Authors()
        {
            ViewBag.Message = "Our authors page.";

            return View();
        }

        // GET: Bookstore/Categories
        public ActionResult Categories()
        {
            ViewBag.Message = "Our categories page.";

            return View();
        }
    }
}