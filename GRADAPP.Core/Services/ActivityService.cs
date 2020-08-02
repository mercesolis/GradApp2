using System;
using System.Collections.Generic;
using GRADAPP.Core.Models;

namespace GRADAPP.Core.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public Activity Add(Activity Activity)
        {
           _activityRepository.Add(Activity);
           
            return Activity;

           

        }

        public Activity Get(int Id)
        {
            return _activityRepository.Get(Id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return _activityRepository.GetAll();
        }

        public IEnumerable<Activity> GetAllForUser(int familyId)
        {
            return _activityRepository.GetAllForUser(familyId);
        }

        public void Remove(int Id)
        {
            var activity = _activityRepository.Get(Id);
            _activityRepository.Remove(activity);
        }

        public Activity Update(Activity Activity)
        {
            _activityRepository.Update(Activity);
            return Activity;
        }
    }
}
