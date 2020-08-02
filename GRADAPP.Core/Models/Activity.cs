using System;


namespace GRADAPP.Core.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public int FamilyId { get; set; }
        public Family Family { get; set; } 
        
        
        
    }
}
