using System;
using System.Collections.Generic;

namespace GRADAPP.Core.Models
{
    public class Family
    {
        public int Id { get; set; }
        

        public string Name { get; set; }
        public ICollection<Activity> Activities { get; set; }

        
    }
}
