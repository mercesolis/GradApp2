using System;
using System.Collections.Generic;
using GRADAPP.Core.Models;

namespace GRADAPP.Core.Services
{
    public interface IActivityRepository
    {
        // Create
        Activity Add(Activity Id);
        // Read
        Activity Get(int Id);
        // Update
        Activity Update(Activity Id);
        // Delete
        void Remove(Activity activity);
        // List
        IEnumerable<Activity> GetAll();
        IEnumerable<Activity> GetAllForUser(int familyId);
    }
}
