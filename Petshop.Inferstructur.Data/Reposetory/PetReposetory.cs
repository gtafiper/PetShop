using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainService2;
using Microsoft.EntityFrameworkCore;
using Petshop.Core.Entity;
using Petshop.Inferstructur.SQL;

namespace Petshop.Inferstructur.Data.Reposetory
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
            var petToCreate = _context.Add(pet).Entity;
            _context.SaveChanges();
            return petToCreate;
        }

        public Pet FindPetById(int Id)
        {
            return _context.Pets.FirstOrDefault(p => p.ID == Id);
        }

        public List<Pet> GetAllPets()
        {
            return _context.Pets.Include(o => o.PreviousOwners).ThenInclude(po => po.Owner).ToList();
           
        }

        public Pet UpdatePet(Pet UpDatedPet)
        {
            throw new NotImplementedException();
        }

        public Pet DeletePet(int id)
        {
            var petToRemove = _context.Remove(new Pet {ID = id}).Entity;
            _context.SaveChanges();
            return petToRemove;
        }

        
        
        
    }
}
