using System;
using GRADAPP.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace GRADAPP.APIModels
{
    public static class FamilyMappingExtensions
    {
        public static FamilyModel ToApiModel(this Family family)
        {
            return new FamilyModel
            {
                Id = family.Id,
                Name = family.Name,
                
            };
        }


        public static Family ToDomainModel(this FamilyModel familyModel)
        {
            return new Family
            {

                Id = familyModel.Id,
                Name = familyModel.Name

            };
        }

        public static IEnumerable<FamilyModel> ToApiModel(this IEnumerable<Family> family)
        {
            return family.Select(f => f.ToApiModel());
        }

        public static IEnumerable<Family> ToDomainModel(this IEnumerable<FamilyModel> familyModels)
        {
            return familyModels.Select(f => f.ToDomainModel());
        }
    }
}
    

