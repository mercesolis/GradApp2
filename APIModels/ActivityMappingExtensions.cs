using System;
using System.Collections.Generic;
using System.Linq;
using GRADAPP.Core.Models;

namespace GRADAPP.APIModels
{
    public static class ActivityMappingExtension
    {
        public static ActivityModel ToApiModel(this Activity Activity)
        {
            return new ActivityModel
            {
                Id = Activity.Id,
                ActivityName = Activity.Name,
                Date = Activity.Date,
                FamilyId = Activity.FamilyId,
                Family = Activity.Family.Name

            };
        }


        public static Activity ToDomainModel(this ActivityModel ActivityModel)
        {
            return new Activity
            {

                Id = ActivityModel.Id,
                Name = ActivityModel.ActivityName,
                Date = ActivityModel.Date,
                FamilyId = ActivityModel.FamilyId

            };
        }

        public static IEnumerable<ActivityModel> ToApiModel(this IEnumerable<Activity> Activity)
        {
            return Activity.Select(f => f.ToApiModel());
        }

        public static IEnumerable<Activity> ToDomainModel(this IEnumerable<ActivityModel> ActivityModel)
        {
            return ActivityModel.Select(f => f.ToDomainModel());
        }
    }
}
