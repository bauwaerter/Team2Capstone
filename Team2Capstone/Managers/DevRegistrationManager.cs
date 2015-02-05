using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team2Capstone.Core;
using Team2Capstone.Models;
using Team2Capstone.Data;

namespace Team2Capstone.Managers
{
    public class DevRegistrationManager
    {
        private static CapstoneEntities2 _entities = new CapstoneEntities2();
        private Repository _respository = new Repository(_entities);

        public List<Models.Registration> GetRegistrations()
        {
            return _Map(_respository.GetAll<Data.Registration>());
        }

        public Models.Registration GetRegistrationById(int regestrationId)
        {
            return _Map(_respository.GetAll<Data.Registration>(x => x.ID == regestrationId).FirstOrDefault());
        }

        public List<Models.Registration> GetAllRegistrationsByUserId(int userId)
        {
            return _Map(_respository.GetAll<Data.Registration>(x => x.User_ID == userId));
        }

        public List<Models.Registration> GetRegistrationsByEventId(int eventId)
        {
            return _Map(_respository.GetAll<Data.Registration>(x => x.Event_ID == eventId).ToList());
        }

        public void UpdateRegistration(Models.Registration registration)
        {
            _respository.Update<Data.Registration>(_Map(registration));
        }

        public void AddRegistration(Models.Registration registration)
        {
            _respository.Add<Data.Registration>(_Map(registration));
        }

        private List<Models.Registration> _Map(IEnumerable<Data.Registration> source)
        {
            var model = source.Select(x => new Models.Registration
            {
                ID = x.ID,
                User_ID = x.User_ID,
                Event_ID = x.Event_ID,
                Type = x.Type
            });

            return model.ToList();
        }

        private Models.Registration _Map(Data.Registration source)
        {
            var model = new Models.Registration
            {
                ID = source.ID,
                User_ID = source.User_ID,
                Event_ID = source.Event_ID,
                Type = source.Type
            };
            
            return model;
        }

        private Data.Registration _Map(Models.Registration registration)
        {
            var data = new Data.Registration
            {
                ID = registration.ID,
                User_ID = registration.User_ID,
                Event_ID = registration.Event_ID,
                Type = registration.Type
            };

            return data;
        }
    }
}