using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeBox.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Legal()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Foundation()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Senior()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Further()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Phases()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Intermediate()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
