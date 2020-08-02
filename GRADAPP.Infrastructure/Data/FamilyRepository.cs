using System;
using System.Collections.Generic;
using System.Linq;
using GRADAPP.Core.Models;
using GRADAPP.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace GRADAPP.Infrastructure.Data
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly AppDbContext _dbContext;

        public FamilyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Family Add(Family item)
        {
            _dbContext.Members.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public Family Get(int id)
        {
            return _dbContext.Members
                .Include(a => a.Activities)
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Family> GetAll()
        {
            return _dbContext.Members
                .Include(a => a.Activities)
                .ToList();
        }

        public Family Update(Family updatedFamily)
        {
            // get the ToDo object in the current list with this id 
            var currentFamily = _dbContext.Members.Find(updatedFamily.Id);

            // return null if todo to update isn't found
            if (currentFamily == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _dbContext.Entry(currentFamily)
                .CurrentValues
                .SetValues(updatedFamily);

            // update the todo and save
            _dbContext.Members.Update(currentFamily);
            _dbContext.SaveChanges();
            return currentFamily;
        }

        public void Remove(Family Family)
        {
            _dbContext.Members.Remove(Family);
            _dbContext.SaveChanges();
        }



        
    }
}
