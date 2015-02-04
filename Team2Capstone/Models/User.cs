using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team2Capstone.Models
{
    public class User
    {
        public int ID { get; set; }
        public string User_ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long? PhoneHome { get; set; }
        public long? PhoneCell { get; set; }
        public long? PhoneOffice { get; set; }
        public string CompanyName { get; set; }
        public string BranchLocation { get; set; }
        public int? Food_ID { get; set; }
        public string AdditionalInfo { get; set; }

    }
}