using System;
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
        private static CapstoneEntities1 _entities = new CapstoneEntities1();
        private Repository _respository = new Repository(_entities);

        public List<Models.Event> GetEvents()
        {
            return _Map(_respository.GetAll<Data.Event>());
        }

        private List<Models.Event> _Map(IEnumerable<Data.Event> source)
        {
            var model = source.Select(x => new Models.Event
            {
                Title = x.Title,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Type_ID = x.Type_ID,
                Description = x.Description,
                Owner_ID = x.Owner_ID,
                Logo_Path = x.Logo_Path,
                Location = x.Location,
                Status = x.Status
            });

            return model.ToList();
        }
    }
}