using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Petshop.Core.Entity;

namespace Core.DomainService
{
    public class PetRepository: IPetRepository

    {
       


        public IEnumerable<Pet> listOfPets = new List<Pet>()
        {new Pet(1, "Lola", "dog", new DateTime(2002, 9, 20), "Black", 1999.99 ),
         new Pet(2, "Boris","cat", new DateTime(2017, 10, 02), "Black", 99999999999.99),
         new Pet(3, "Arne", "Rock", new DateTime(01, 1, 1), "Gray", 10.50),
         new Pet(4, "Blob", "Fish", new DateTime(2019, 8, 27), "Gold", 1.99 )
        };


        public Pet CreatePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public Pet FindPetById(int Id)
        {
            foreach (Pet animal in listOfPets)
            {
                if (animal.ID == Id)
                {
                    return animal;
                }
               
            }

            return null;
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return listOfPets;
        }

        public Pet UpdatePet(Pet upDatedPet)
        {
            String stringInput = "";
            DateTime date = new DateTime();
            double price = 0;
            
            
            foreach (var pet in listOfPets)
            {
                if (pet.ID == upDatedPet.ID)
                {
                    pet.Name = stringInput;
                    pet.Color = stringInput;
                    pet.SoldDate = date;
                    pet.Birthdate = date;
                    pet.PreviousOwner = stringInput;
                    pet.Price = price;
                    
                }
            }

            return upDatedPet;
        }

        public void DeltedPed(int Id)
        {
            foreach (var pet in listOfPets)
            {
                if (pet.ID == Id)
                {
                    listOfPets.ToList().Remove(pet);

                }
            }

        }
    }
}
