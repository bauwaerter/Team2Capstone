using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team2Capstone.Models
{
    public class Event
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Type_ID { get; set; }
        public string Description { get; set; }
        public int Owner_ID { get; set; }
        public string Logo_Path { get; set;}
        public string Location { get; set; }
        public string Status { get; set; }
    }
}