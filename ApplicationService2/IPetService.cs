using System;
using System.Collections.Generic;
using Petshop.Core.Entity;
using Petshop.Core.Entity2;
using Petshop.Inferstructur.Data.Reposetory;


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

        List<Pet> GetAllPets(Filter filter = null);

        Pet UpdatePet(Pet petToUpdate);

        Pet DeltedPet(int Id);

        List<Pet> GetPetsBySpecies(string specise);



        List<Pet> GetPetsByPrice();

        List<Pet> GetFiveCheapest();

        IEnumerable<PetOwner> GetOwners(Pet pet);

        FilteredList<Pet> GetAllFiltertPets(Filter filter);


   }
}
