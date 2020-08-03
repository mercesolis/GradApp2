using System;
using System.Collections.Generic;
using GRADAPP.Core.Models;

namespace GRADAPP.Core.Services
{
    public interface IActivityService
    {
        Activity Add(Activity Activity);
        Activity Update(Activity updatedActivity);
        Activity Get(int Id);
        IEnumerable<Activity> GetAll();
        void Remove(int Id);
        IEnumerable<Activity> GetAllForUser(int familyId);

    }
}
