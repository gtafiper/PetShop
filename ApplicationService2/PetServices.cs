using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainService2;
using Petshop.Core.Entity2;

namespace ApplicationService2
{
    public class PetServices: IPetService
    {
        readonly IPetRepository _petRepo;
        

        public PetServices(IPetRepository petRepository)
        {
            _petRepo = petRepository;
            
        }

        public Pet NewPet(string name, DateTime birthdate, string color, double price, string prOvner, string species )
        {
            var pet = new Pet()
            {
                Name = name,
                Color = color,
                Price = price,
                Birthdate = birthdate,
                PreviousOwner = prOvner,
                Species = species
            };
            return pet;
        }

       

        public Pet CreatePet(Pet pet)
        {


            return _petRepo.CreatePet(pet);


        }
        
        public Pet FindPetById(int Id)
        {
            return _petRepo.FindPetById(Id);
        }

        public List<Pet> GetAllPets()
        {
            var list = _petRepo.GetAllPets();

            
            _petRepo.GetAllPets().OrderBy(pet => pet.Species);
            return list.ToList();
        }

        public Pet UpdatePet(Pet petToUpdate)
        {
            var pet = FindPetById(petToUpdate.ID);
            pet.Name = petToUpdate.Name;
            pet.Price = petToUpdate.Price;
            pet.Birthdate = petToUpdate.Birthdate;
            pet.Color = petToUpdate.Color;
            pet.PreviousOwner = petToUpdate.PreviousOwner;
            pet.SoldDate = pet.SoldDate;
            pet.Species = petToUpdate.Species;

            return pet;

        }

        public void DeltedPet(int Id)
        {
            _petRepo.DeletePet(Id);
        }

        
        public List<Pet> GetPetsBySpecies(string species)
        {
            string strToLower = species.ToLower();
            var list = _petRepo.GetAllPets();
            var queryContinued = list.Where(pet => pet.Species.ToLower().Equals(strToLower));
            queryContinued.OrderBy(pet => pet.Name);
            //Not executed anything yet
            return queryContinued.ToList();

        }

        public List<Pet> GetPetsByPrice()
        {
            return _petRepo.GetAllPets().OrderBy(pet => pet.Price).ToList();
        }

        public List<Pet> GetFiveCheapest()
        {
            return GetPetsByPrice().Take(5).ToList();
        }


        
    }
}
