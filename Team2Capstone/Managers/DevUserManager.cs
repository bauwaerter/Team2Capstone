using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team2Capstone.Core;
using Team2Capstone.Models;
using Team2Capstone.Data;

namespace Team2Capstone.Managers
{
    public class DevUserManager
    {
        private static CapstoneEntities1 _entities = new CapstoneEntities1();
        private Repository _respository = new Repository(_entities);

        public List<Models.User> GetUsers()
        {
            return _Map(_respository.GetAll<Data.User>());
        }

        public Models.User GetUserById(int userId)
        {
            return _Map(_respository.GetAll<Data.User>(x => x.ID == userId).FirstOrDefault());
        }

        private List<Models.User> _Map(IEnumerable<Data.User> source)
        {
            var model = source.Select(x => new Models.User
            {
                ID = x.ID,
                UserName = x.Username,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address1 = x.Address1,
                Address2 = x.Address2,
                City = x.City,
                State = x.State,
                PhoneHome = x.PhoneHome,
                PhoneCell = x.PhoneCell,
                PhoneOffice = x.PhoneOffice,
                CompanyName = x.CompanyName,
                BranchLocation = x.BranchLocation,
                Food_ID = x.Food_ID,
                AdditionalInfo = x.AdditionalInfo.ToString()
            });

            return model.ToList();
        }

        private Models.User _Map(Data.User source)
        {
            var model = new Models.User
            {
                ID = source.ID,
                UserName = source.Username,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Address1 = source.Address1,
                Address2 = source.Address2,
                City = source.City,
                State = source.State,
                PhoneHome = source.PhoneHome,
                PhoneCell = source.PhoneCell,
                PhoneOffice = source.PhoneOffice,
                CompanyName = source.CompanyName,
                BranchLocation = source.BranchLocation,
                Food_ID = source.Food_ID,
                AdditionalInfo = source.AdditionalInfo.ToString()

            };

            return model;
        }
    }
}