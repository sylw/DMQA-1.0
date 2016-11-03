using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMQA.Web.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET: Demo
        public ActionResult ListTree()
        {
            return View();
        }
    }
}