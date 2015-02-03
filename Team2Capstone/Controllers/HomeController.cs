using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team2Capstone.Models;
using Team2Capstone.Managers;

namespace Team2Capstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly DevEventManager _devEventManager;

        public HomeController(DevEventManager devEventManager)
        {
            _devEventManager = devEventManager;
        }
        public ActionResult Index()
        {

            var list = _devEventManager.GetEvents();
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