using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team2Capstone.Managers;

namespace Team2Capstone.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var _devEventManager = new DevEventManager();
            //var ev = _devEventManager.GetEventById(x.Id == id);
            
            return View();
        }

        //get event details
        public ActionResult Details(int id)
        {
            
            var _eventDetail = new DevEventManager();
            //var ed = _eventDetail.GetEventDetails(x.Id == id);
            return View();
        }
    }
}