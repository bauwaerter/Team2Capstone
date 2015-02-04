using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team2Capstone.Core;
using Team2Capstone.Models;
using Team2Capstone.Data;

namespace Team2Capstone.Managers
{
    public class DevFoodManager
    {
        private static CapstoneEntities1 _entities = new CapstoneEntities1();
        private Repository _respository = new Repository(_entities);

        public List<Models.Food> GetFoods()
        {
            return _Map(_respository.GetAll<Data.Food>());
        }

        public Models.Food GetFoodById(int foodId)
        {
            return _Map(_respository.GetAll<Data.Food>(x => x.ID == foodId).FirstOrDefault());
        }

        private List<Models.Food> _Map(IEnumerable<Data.Food> source)
        {
            var model = source.Select(x => new Models.Food
            {
                ID = x.ID,
                Food1 = x.Food1
            });

            return model.ToList();
        }

        private Models.Food _Map(Data.Food source)
        {
            var model = new Models.Food
            {
                ID = source.ID,
                Food1 = source.Food1
            };

            return model;
        }
    }
}