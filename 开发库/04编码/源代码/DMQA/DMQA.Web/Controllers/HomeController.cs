using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMQA.DataService.Service;

namespace DMQA.Web.Controllers
{
    public class HomeController : Controller
    {
        public IHomeService homeService { get; set; }

        public HomeController(IHomeService service)
        {
            homeService = service;
        }

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
    }
}