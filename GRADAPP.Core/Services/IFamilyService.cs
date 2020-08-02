using System;
using System.Collections.Generic;
using GRADAPP.Core.Models;

namespace GRADAPP.Core.Services
{
    public interface IFamilyService
    {
        Family Add(Family family);
        Family Update(Family family);
        Family Get(int Id);
        IEnumerable<Family> GetAll();
        void Remove(int Id);
    }
}
