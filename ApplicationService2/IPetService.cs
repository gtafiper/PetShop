using System;
using System.Collections.Generic;
using Petshop.Core.Entity;
using Petshop.Inferstructur.SQL.Reposetory;

namespace ApplicationService2
{
   public interface IPetService

   {
       Pet NewPet(string name,
           DateTime birthdate,
           string color,
           double price,
           string prOvner,
           string species);

       Pet CreatePet(Pet pet);

        Pet FindPetById(int Id);

        List<Pet> GetAllPets();

        Pet UpdatePet(Pet petToUpdate);

        Pet DeltedPet(int Id);

        List<Pet> GetPetsBySpecies(string specise);

        

        List<Pet> GetPetsByPrice();

        List<Pet> GetFiveCheapest();

        IEnumerable<PetOwner> GetOwners(Pet pet);


   }
}
