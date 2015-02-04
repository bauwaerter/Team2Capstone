using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team2Capstone.Core;
using Team2Capstone.Models;
using Team2Capstone.Data;

namespace Team2Capstone.Managers
{
    public class DevTypeManager
    {
        private static CapstoneEntities2 _entities = new CapstoneEntities2();
        private Repository _respository = new Repository(_entities);

        public List<Models.Type> GetTypes()
        {
            return _Map(_respository.GetAll<Data.Type>());
        }

        public Models.Type GetTypeById(int typeId)
        {
            return _Map(_respository.GetAll<Data.Type>(x => x.ID == typeId).FirstOrDefault());
        }

        private List<Models.Type> _Map(IEnumerable<Data.Type> source)
        {
            var model = source.Select(x => new Models.Type
            {
                ID = x.ID,
                Type1 = x.Type1
            });

            return model.ToList();
        }

        private Models.Type _Map(Data.Type source)
        {
            var model = new Models.Type
            {
                ID = source.ID,
                Type1 = source.Type1
            };

            return model;
        }
    }
}