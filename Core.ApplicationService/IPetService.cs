using System;
using System.Collections.Generic;
using System.Text;
using Petshop.Core.Entity;

namespace Core.ApplicationService
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

        void DeltedPet(int Id);

        List<Pet> GetPetsBySpecies(string specise);

        List<MenuItem> getAllMenuItems();

        List<Pet> GetPetsByPrice();

        List<Pet> GetFiveCheapest();



   }
}
