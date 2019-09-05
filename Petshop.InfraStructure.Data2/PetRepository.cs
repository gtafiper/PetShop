﻿using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainService2;
using Petshop.Core.Entity2;

namespace Petshop.InfraStructure.Data2
{
    public class PetRepository : IPetRepository

    {

        //public static IEnumerable<Pet> InuEnumerablOfPets = new List<Pet>(){new Pet()
        //    {
        //        Birthdate = new DateTime(2002, 9, 20), ID = 1, Name = "bob", Species = "Rock",
        //        Color = "blue", Price = 99,
        //    },
        //    new Pet()
        //    {
        //        Birthdate = new DateTime(2002, 9, 20), ID = 2, Name = "per", Species = "Dog",
        //        Color = "blue", Price = 99,
        //    }};

        public static List<Pet> ListOfPets = new List<Pet>()
        {
            new Core.Entity2.Pet()

            {
                Birthdate = new DateTime(2002, 9, 20), ID = 1, Name = "bob", Species = "Rock",
                Color = "blue", Price = 20,
            },
            new Core.Entity2.Pet()
            {
                Birthdate = new DateTime(2002, 9, 20), ID = 2, Name = "per", Species = "Dog",
                Color = "blue", Price = 99.99,
            },

            new Core.Entity2.Pet()
            {
                Birthdate = new DateTime(2002, 9, 20), ID = 3, Name = "per", Species = "Dog",
                Color = "blue", Price = 999.0,
            },
            new Core.Entity2.Pet()
            {
                Birthdate = new DateTime(2002, 9, 20), ID = 4, Name = "per", Species = "Dog",
                Color = "blue", Price = 80.0,
            },
            new Core.Entity2.Pet()
            {
                Birthdate = new DateTime(2002, 9, 20), ID = 5, Name = "per", Species = "Dog",
                Color = "blue", Price = 40.20,
            },
            new Core.Entity2.Pet()
            {
                Birthdate = new DateTime(2002, 9, 20), ID = 6, Name = "per", Species = "Dog",
                Color = "blue", Price = 0.2,
            },
        };


        //};
        private int Id = ListOfPets.Count();


        public Pet CreatePet(Pet pet)
        {
            pet.ID = Id++;
            ListOfPets.Add(pet);
            return pet;
        }

        public Pet FindPetById(int Id)
        {
            {
                foreach (Pet animal in ListOfPets)
                {
                    if (animal.ID == Id)
                    {
                        return animal;
                    }

                }

                return null;
            }
        }

        public List<Pet> GetAllPets()
        {
            return ListOfPets;
        }


        public Pet UpdatePet(Pet upDatedPet)
        {
            var petFromDb = this.FindPetById(upDatedPet.ID);

            if (petFromDb != null)
            {
                petFromDb.Name = upDatedPet.Name;
                petFromDb.Price = upDatedPet.Price;
                petFromDb.Birthdate = upDatedPet.Birthdate;
                petFromDb.Color = upDatedPet.Color;
                petFromDb.PreviousOwner = upDatedPet.PreviousOwner;
                petFromDb.SoldDate = petFromDb.SoldDate;
                petFromDb.Species = upDatedPet.Species;

                return petFromDb;
            }

            return null;
        }

        public Pet DeletePet(int id)
        {
            var petToFind = this.FindPetById(id);
            if (petToFind != null)
            {
                ListOfPets.Remove(petToFind);
                return petToFind;
            }

            return null;
        }






    }
}