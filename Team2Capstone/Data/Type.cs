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
    
    public partial class Type
    {
        public Type()
        {
            this.Events = new HashSet<Event>();
        }
    
        public int ID { get; set; }
        public string Type1 { get; set; }
    
        public virtual ICollection<Event> Events { get; set; }
    }
}
