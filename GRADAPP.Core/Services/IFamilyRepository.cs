using System;
using System.Collections.Generic;
using GRADAPP.Core.Models;

namespace GRADAPP.Core.Services
{
    public interface IFamilyRepository
    {
        // Create
        Family Add(Family family);
        // Read
        Family Get(int id);
        // Update
        Family Update(Family todo);
        // Delete
        void Remove(Family todo);
        // List
        IEnumerable<Family> GetAll();
    }
}
