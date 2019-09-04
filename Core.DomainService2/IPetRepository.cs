using System.Collections.Generic;
using Petshop.Core.Entity2;

namespace Core.DomainService2
{
    public interface IPetRepository
    {
        Pet CreatePet(Pet pet);

        Pet FindPetById(int Id);

        List<Pet> GetAllPets();

        

        Pet UpdatePet(Pet UpDatedPet);

        Pet DeletePet(int id);
    }

    
}
