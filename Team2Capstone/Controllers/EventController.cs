using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team2Capstone.Managers;
using Team2Capstone.Models;
using Microsoft.AspNet.Identity;

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
            var model = new Models.Event
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Models.Event model)
        {
            var ownerId = User.Identity.GetUserId();
            var _devUserManager = new DevUserManager();
            var _devEventManager = new DevEventManager();

            model.Owner_ID = _devUserManager.GetUserById(ownerId).ID;
            model.Status = "0";
            model.Logo_Path = "Not implemented";

            _devEventManager.AddEvent(model);

            return RedirectToAction("Index","Home");
        }

        public ActionResult Edit(int id)
        {
            var _devEventManager = new DevEventManager();
            var _devTypeManager = new DevTypeManager();
            var ev = _devEventManager.GetEventById(id);
            ViewBag.TypeList = _devTypeManager.GetTypes();
            return View(ev);
        }

        [HttpPost]
        public ActionResult Edit(Models.Event model)
        {
            
            var ownerId = User.Identity.GetUserId();
            var _devUserManager = new DevUserManager();
            var _devEventManager = new DevEventManager();

            model.Owner_ID = _devUserManager.GetUserById(ownerId).ID;
            model.Status = "0";
            model.Logo_Path = "Not implemented";
            
            _devEventManager.UpdateEvent(model);
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
                EndTime = ev.EndDate.ToString("h:mm tt"),
                Location = ev.Location,
                CurrentUserId = _userManager.GetUserById(User.Identity.GetUserId()).ID
            };

            ViewBag.EventType = _typeManager.GetTypeById(ev.Type_ID).Type1;

            return View(eventViewModel);
        }

        public ActionResult MyEvents()
        {
            var _devUserManager = new DevUserManager();
            var _devRegisterManager = new DevRegistrationManager();
            var _eventManager = new DevEventManager();

            var currentUserId = _devUserManager.GetUserById(User.Identity.GetUserId()).ID;

            var ownedEvents = _eventManager.GetEventsByUserId(currentUserId);
            var eventsReg = _devRegisterManager.GetAllRegistrationsByUserId(currentUserId);

            var registeredEvents = _eventManager.GetAllEventsByEventId(eventsReg);

            var model = new Models.MyEventsViewModel
            {
                OwnedEvents = ownedEvents,
                RegisteredEvents = registeredEvents
            };

            return View(model);

        }

        [HttpPost]
        public ActionResult RegisterForEvent(int id)
        {
            var _registrationManager = new DevRegistrationManager();
            var _userManager = new DevUserManager();
            var register = new Registration
            {
                User_ID = _userManager.GetUserById(User.Identity.GetUserId()).ID,
                Event_ID = id,
                Type = "1"
            };

            _registrationManager.AddRegistration(register);

            return null;
        }
        

    }
}