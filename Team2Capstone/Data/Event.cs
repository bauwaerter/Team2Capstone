//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Team2Capstone.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public Event()
        {
            this.Registrations = new HashSet<Registration>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int Category_ID { get; set; }
        public int Type_ID { get; set; }
        public string Description { get; set; }
        public int Owner_ID { get; set; }
        public string Logo_Path { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Type Type { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
