using System;
using System.Collections.Generic;
using System.Text;
using Petshop.Core.Entity;

namespace Core.DomainService
{
    public interface IPetRepository
    {
        Pet CreatePet(Pet pet);

        Pet FindPetById(int Id);

        List<Pet> GetAllPets();

        Pet UpdatePet(Pet UpDatedPet);

        void DeltedPed(int Id);
    }
}
