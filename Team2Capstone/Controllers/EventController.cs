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
            return View(new Models.Event());
        }

        [HttpPost]
        public ActionResult Create(Models.Event model)
        {
            return null;
        }

        public ActionResult Edit(int id)
        {
            var _devEventManager = new DevEventManager();
            var ev = _devEventManager.GetEventById(id);
            
            return View(ev);
        }

        [HttpPost]
        public ActionResult Edit(Models.Event model)
        {
            var _devEventManager = new DevEventManager();
            return null;
        }
        //get event details
        public ActionResult Details(int id)
        {
            
            var _eventDetail = new DevEventManager();
            var ev = _eventDetail.GetEventById(id);
            return View(ev);
        }
    }
}