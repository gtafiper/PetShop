using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainService2;
using Petshop.Core.Entity;

namespace Petshop.Inferstructur.SQL.Reposetory
{
    public class PetReposetory : IPetRepository
    {
        private Context _context;

        public PetReposetory(Context context)
        {
            _context = context;
        }
        public Pet CreatePet(Pet pet)
        {
            var PetToCreate = _context.Add(pet).Entity;
            _context.SaveChanges();
            return pet;
        }

        public Pet FindPetById(int Id)
        {
            return _context.Pets.FirstOrDefault(p => p.ID == Id);
        }

        public List<Pet> GetAllPets()
        {
            throw new NotImplementedException();
        }

        public Pet UpdatePet(Pet UpDatedPet)
        {
            throw new NotImplementedException();
        }

        public Pet DeletePet(int id)
        {
            var petToRemove = _context.Remove(new Pet {ID = id}).Entity;
            return petToRemove;
        }

        public Owner GetOwners(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
