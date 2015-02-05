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
        private static CapstoneEntities2 _entities = new CapstoneEntities2();
        private Repository _respository = new Repository(_entities);

        public List<Models.User> GetUsers()
        {
            return _Map(_respository.GetAll<Data.User>());
        }

        public Models.User GetUserById(string userId)
        {
            return _Map(_respository.GetAll<Data.User>(x => x.User_ID == userId).FirstOrDefault());
        }
        public Models.User GetUserById(int userId)
        {
            return _Map(_respository.GetAll<Data.User>(x => x.ID == userId).FirstOrDefault());
        }

        public void UpdateUser(Models.User user)
        {
            _respository.Update<Data.User>(_Map(user));
        }

        public void AddUser(Models.User user)
        {
            _respository.Add<Data.User>(_Map(user));
        }

        private List<Models.User> _Map(IEnumerable<Data.User> source)
        {
            var model = source.Select(x => new Models.User
            {
                ID = x.ID,
                User_ID = x.User_ID,
                UserName = x.Username,
                Password = x.Password,
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
                AdditionalInfo = x.AdditionalInfo
            });

            return model.ToList();
        }

        private Models.User _Map(Data.User source)
        {
            var model = new Models.User
            {
                ID = source.ID,
                User_ID = source.User_ID,
                UserName = source.Username,
                Password = source.Password,
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
                AdditionalInfo = source.AdditionalInfo

            };

            return model;
        }

        private Data.User _Map(Models.User user)
        {
            var data = new Data.User
            {
                ID = user.ID,
                User_ID = user.User_ID,
                Username = user.UserName,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address1 = user.Address1,
                Address2 = user.Address2,
                City = user.City,
                State = user.State,
                PhoneHome = user.PhoneHome,
                PhoneCell = user.PhoneCell,
                PhoneOffice = user.PhoneOffice,
                CompanyName = user.CompanyName,
                BranchLocation = user.BranchLocation,
                Food_ID = user.Food_ID,
                AdditionalInfo = user.AdditionalInfo
            };

            return data;
        }

        
    }
}