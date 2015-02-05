using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team2Capstone.Managers;
using Team2Capstone.Models;

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
            var _typeManager = new DevTypeManager();
            ViewBag.TypeList = _typeManager.GetTypes();
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
            var _eventManager = new DevEventManager();
            var _userManager = new DevUserManager();
            var _registrationManager = new DevRegistrationManager();
            var _typeManager = new DevTypeManager();
            
            var ev = _eventManager.GetEventById(id);
            var owner = _userManager.GetUserById(ev.Owner_ID);
            var registrations = _registrationManager.GetRegistrationsByEventId(ev.Id);
            
            var eventViewModel = new EventViewModel
            {
                Event = ev,
                Owner = owner,
                Registrations = registrations,
                StartDate = ev.StartDate.ToShortDateString(),
                EndDate = ev.EndDate.ToShortDateString(),
                StartTime = ev.StartDate.ToString("h:mm tt"),
                EndTime = ev.EndDate.ToString("h:mm tt")
            };

            return View(eventViewModel);
        }
        

    }
}