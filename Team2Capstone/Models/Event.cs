using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team2Capstone.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public DateTime StartTime { get; set; }
        //public DateTime EndTime { get; set; }
        public int Type_ID { get; set; }
        public string Description { get; set; }
        public int Owner_ID { get; set; }
        public string Logo_Path { get; set;}
        public string Location { get; set; }
        public string Status { get; set; }
        public int Category_ID { get; set; }
        
    }

    public class EventViewModel
    {
        public Event Event { get; set; }
        public User Owner { get; set; }
        public Type Type { get; set; }
        public List<Registration> Registrations { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Location { get; set; }
    }
}