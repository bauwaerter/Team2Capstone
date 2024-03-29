﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team2Capstone.Core;
using Team2Capstone.Models;
using Team2Capstone.Data;

namespace Team2Capstone.Managers
{
    public class DevEventManager
    {
        private static CapstoneEntities2 _entities = new CapstoneEntities2();
        private Repository _respository = new Repository(_entities);

        public List<Models.Event> GetEvents()
        {
            return _Map(_respository.GetAll<Data.Event>());
        }

        public Models.Event GetEventById(int eventId)
        {
            return _Map(_respository.GetAll<Data.Event>(x => x.ID == eventId).FirstOrDefault());
        }

        public List<Models.Event> GetAllEventsByEventId(List<Models.Registration> regList)
        {
            var list = new List<Models.Event>();

            foreach (var reg in regList)
            {
                var temp_event = _Map(_respository.GetAll<Data.Event>(x => x.ID == reg.Event_ID).FirstOrDefault());
                list.Add(temp_event);
            }

            return list;
        }

        public void UpdateEvent(Models.Event evnt)
        {
            _respository.Update<Data.Event>(_Map(evnt));
        }

        public void AddEvent(Models.Event evnt)
        {
            _respository.Add<Data.Event>(_Map(evnt));
        }

        public List<Models.Event> GetEventsByUserId(int userId)
        {
            return _Map(_respository.GetAll<Data.Event>(x => x.Owner_ID == userId));
        }

        private List<Models.Event> _Map(IEnumerable<Data.Event> source)
        {
            var model = source.Select(x => new Models.Event
            {
                Id = x.ID,
                Title = x.Title,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Type_ID = x.Type_ID,
                Description = x.Description,
                Owner_ID = x.Owner_ID,
                Logo_Path = x.Logo_Path,
                Location = x.Location,
                Status = x.Status,
                Category_ID = 1
            });

            return model.ToList();
        }

        private Models.Event _Map(Data.Event source)
        {            
            var model = new Models.Event
            {
                Id = source.ID,
                Title = source.Title,
                StartDate = source.StartDate,
                EndDate = source.EndDate,
                Type_ID = source.Type_ID,
                Description = source.Description,
                Owner_ID = source.Owner_ID,
                Logo_Path = source.Logo_Path,
                Location = source.Location,
                Status = source.Status,
                Category_ID = 1,
            };
            
            return model;
        }

        private Data.Event _Map(Models.Event evnt){

            var data = new Data.Event{
                ID = evnt.Id,
                Title = evnt.Title,
                StartDate = evnt.StartDate,
                EndDate = evnt.EndDate,
                Type_ID = evnt.Type_ID,
                Description = evnt.Description,
                Owner_ID = evnt.Owner_ID,
                Logo_Path = evnt.Logo_Path,
                Location = evnt.Location,
                Status = evnt.Status,
                Category_ID = 1
            };

            return data;
        }
    }
}