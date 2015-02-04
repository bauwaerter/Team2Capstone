using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team2Capstone.Models
{
    public class Registration
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int Event_ID { get; set; }
        public string Type { get; set; }
    }
}