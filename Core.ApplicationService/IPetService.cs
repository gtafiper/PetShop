using System;
using System.Collections.Generic;
using System.Text;
using Petshop.Core.Entity;

namespace Core.ApplicationService
{
   public interface IPetService

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
        void CreatePet();

        Pet FindPetById(int Id);

        List<Pet> GetAllPets();

        Pet UpdatePet(int id, string name, string color, DateTime birthdate, double price, string species,
            string previousOwner, DateTime soltDate);

        void DeltedPet(int Id);

        List<Pet> GetPetsBySpecis(string specise);

        List<MenuItem> getAllMenuItems();

        
    }
}
