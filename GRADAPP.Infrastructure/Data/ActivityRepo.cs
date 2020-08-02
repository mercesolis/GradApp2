using System;
using System.Collections.Generic;
using System.Linq;
using GRADAPP.Core.Models;
using GRADAPP.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace GRADAPP.Infrastructure.Data
{
    public class ActivityRepo : IActivityRepository
    {
        private readonly AppDbContext _dbContext;
        public ActivityRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Activity Add(Activity activity)
        {
            _dbContext.Activities.Add(activity);
            _dbContext.SaveChanges();
            return activity;
        }

        public Activity Get(int Id)
        {
            return _dbContext.Activities
                .Include(a => a.Family)
                .SingleOrDefault(b => b.Id == Id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return _dbContext.Activities
                .Include(a => a.Family)
                .ToList();
        }

        public Activity Update(Activity updatedActivity)
        {
            // get the ToDo object in the current list with this id 
            var currentActivity = _dbContext.Activities.Find(updatedActivity.Id);

            // return null if todo to update isn't found
            if (currentActivity == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _dbContext.Entry(currentActivity)
                .CurrentValues
                .SetValues(updatedActivity);

            // update the todo and save
            _dbContext.Activities.Update(currentActivity);
            _dbContext.SaveChanges();
            return currentActivity;
        }

        public void Remove(Activity activity)
        {

            _dbContext.Activities.Remove(activity);
            _dbContext.SaveChanges();
        }



        // TODO: Class Project: Add GetAllForUser() method
        public IEnumerable<Activity> GetAllForUser(int familyId)
        {
            return _dbContext.Activities
                .Include(a => a.Family)
                .Where(a => a.FamilyId == familyId) // only for the given user
                .ToList();
        }
    }
}
