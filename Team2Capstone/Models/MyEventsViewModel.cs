using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team2Capstone.Models
{
    public class MyEventsViewModel
    {
        public List<Models.Event> OwnedEvents { get; set; }

        public List<Models.Event> RegisteredEvents { get; set; }
    }
}