using System;
using System.Collections.Generic;

namespace GRADAPP.APIModels
{
    public class FamilyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ActivityModel> Activities { get; set; }
        
    }
}
