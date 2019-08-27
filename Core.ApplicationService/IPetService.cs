using System;
using System.Collections.Generic;
using System.Text;
using Petshop.Core.Entity;

namespace Core.ApplicationService
{
    interface IPetService

    {
        Pet NewPet
        (
            int Id,
            string name,
            Pet.Type type,
            DateTime birthdate,
            string color,
            double price

        );
        Pet CreatePet(Pet pet);

        Pet FindPetById(int Id);

        List<Pet> GetAllPets();

        Pet UpdatePet(Pet updatedPet);

        void DeltedPed(int Id);

        List<Pet> GetPetsByEnum(Pet pet, List<Pet> petsByEnumList);
    }
}
