using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainService;
using Petshop.Core.Entity;

namespace Core.ApplicationService
{
    public class PetServices: IPetService
    {
        readonly IPetRepository _petRepo;
        private readonly MenuitemsReposetory _menuitemsReposetory;

        public PetServices(IPetRepository petRepository, MenuitemsReposetory menuitemsReposetory)
        {
            _petRepo = petRepository;
            _menuitemsReposetory = menuitemsReposetory;
        }

        public Pet NewPet(int Id, string name, Pet.Type type, DateTime birthdate, string color, double price)
        {
            throw new NotImplementedException();
        }

        public void CreatePet()
        {
            string inpString;
            int id = _petRepo.GetAllPets().ToList().Count;
            Console.WriteLine("Type the name of the new pet");
            inpString = Console.ReadLine();
            Console.WriteLine("Type the price of " + inpString);
            double price = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("Write the color of " + inpString);
            inpString = Console.ReadLine();
            Console.WriteLine("Type the species");
            inpString = Console.ReadLine();
            
            
            
            DateTime date = new DateTime();

            Pet pet = new Pet(id, inpString, inpString , date, inpString, price);

            _petRepo.GetAllPets().ToList().Add(pet);

            
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

        public Pet UpdatePet(int id, string name, string color, DateTime birthdate, double price, string species, string previousOwner, DateTime soltDate)
        {
            var pet = FindPetById(id);
            pet.Name = name;
            pet.Color = color;
            pet.Birthdate = birthdate;
            pet.Price = price;
            pet.Species = species;
            pet.PreviousOwner = previousOwner;
            pet.SoldDate = soltDate;
            return pet;
        }

        public void DeltedPet(int Id)
        {
            _petRepo.DeltedPed(Id);
        }

        
        public List<Pet> GetPetsBySpecis(string specise)
        {
            var list = _petRepo.GetAllPets();

            var query = list.Where(pet => pet.Species.Equals(specise));
            query.OrderBy(pet => pet.Name);
            return query.ToList();
        }

        public List<MenuItem> getAllMenuItems()
        {
            return _menuitemsReposetory.GetAllMenuItems();
        }
    }
}
