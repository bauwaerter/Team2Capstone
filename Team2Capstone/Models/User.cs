using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team2Capstone.Models
{
    public class User
    {
        public int ID { get; set; }
        public string User_ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(2, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string State { get; set; }
        [Required]
        public int Zip { get; set; } 
        public long? PhoneHome { get; set; }
        public long? PhoneCell { get; set; }
        public long? PhoneOffice { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string BranchLocation { get; set; }
        
        public int Food_ID { get; set; }
        public string AdditionalInfo { get; set; }

    }
}