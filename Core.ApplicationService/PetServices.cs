using System;
using System.Collections.Generic;
using System.Text;
using Core.DomainService;
using Petshop.Core.Entity;

namespace Core.ApplicationService
{
    class PetServices: IPetService
    {
        readonly IPetRepository _petRepo;

        public PetServices(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }

        public Pet NewPet(int Id, string name, Pet.Type type, DateTime birthdate, string color, double price)
        {
            throw new NotImplementedException();
        }

        public Pet CreatePet(Pet pet)
        {
            return null;
            //int id = _petRepo.GetAllPets().Count;
            //Console.WriteLine("type the name of the new pet");
            //string inputString = Console.ReadLine();
            //Console.WriteLine();


            //DateTime date = new DateTime();

            //pet = new Pet(id, inputString, , date, );
        }

        public Pet FindPetById(int Id)
        {
            return _petRepo.FindPetById(Id);
        }

        public List<Pet> GetAllPets()
        {
            return _petRepo.GetAllPets();
        }

        public Pet UpdatePet(Pet updatedPet)
        {
            var pet = FindPetById(updatedPet.ID);
            pet.Name = updatedPet.Name;
            pet.Color = updatedPet.Color;
            pet.Birthdate = updatedPet.Birthdate;
            pet.Price = updatedPet.Price;
            pet._type = updatedPet._type;
            pet.PreviousOwner = updatedPet.PreviousOwner;
            pet.SoldDate = updatedPet.SoldDate;
            return pet;
        }

        public void DeltedPed(int Id)
        {
            _petRepo.DeltedPed(Id);
        }

        
        public List<Pet> GetPetsByEnum(Pet pet, List<Pet> petsByEnumList)
        {
            foreach (var animal in _petRepo.GetAllPets())
            {
                if (pet._type == animal._type)
                {
                    petsByEnumList.Add(animal);
                }
            }

            return petsByEnumList;
        }
    }
}
