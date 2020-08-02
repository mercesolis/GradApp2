using System;

namespace GRADAPP.APIModels
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public string Date { get; set; }
        public string Family { get; set; }
        public int FamilyId { get; set; }
    }
}