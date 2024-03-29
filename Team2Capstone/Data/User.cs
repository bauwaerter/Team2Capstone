//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Team2Capstone.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Events = new HashSet<Event>();
            this.Registrations = new HashSet<Registration>();
        }
    
        public int ID { get; set; }
        public string User_ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Nullable<long> PhoneHome { get; set; }
        public Nullable<long> PhoneCell { get; set; }
        public Nullable<long> PhoneOffice { get; set; }
        public string CompanyName { get; set; }
        public string BranchLocation { get; set; }
        public int Food_ID { get; set; }
        public string AdditionalInfo { get; set; }
    
        public virtual ICollection<Event> Events { get; set; }
        public virtual Food Food { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
