using System;
using System.Collections.Generic;
using GRADAPP.Core.Models;

namespace GRADAPP.Core.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _familyRepository;
        public FamilyService(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }

        public Family Add(Family family)
        {
            _familyRepository.Add(family);
            return family;
        }

        public Family Get(int Id)
        {
            return _familyRepository.Get(Id);
        }

        public IEnumerable<Family> GetAll()
        {
            return _familyRepository.GetAll();
        }

        public void Remove(int Id)
        {
            var family = _familyRepository.Get(Id);
            _familyRepository.Remove(family);
        }

        public Family Update(Family family)
        {
            var Family = _familyRepository.Update(family);
            return Family;
        }
    }
}
