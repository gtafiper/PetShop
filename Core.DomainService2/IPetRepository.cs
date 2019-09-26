using System.Collections.Generic;
using Petshop.Core.Entity;
using Petshop.Core.Entity2;

namespace Core.DomainService2
{
    public interface IPetRepository
    {
        Pet CreatePet(Pet pet);

        Pet FindPetById(int Id);

        List<Pet> GetAllPets(Filter filter = null);

        FilteredList<Pet> GetAllFiltertPets(Filter filter);

        int Count();

        Pet UpdatePet(Pet petToUpdate);

        Pet DeletePet(int id);
        

    }

    
}
