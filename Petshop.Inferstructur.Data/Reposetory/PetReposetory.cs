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
            _context.Attach(pet).State = EntityState.Added;
            _context.SaveChanges();
//            var changeTracker = _context.ChangeTracker.Entries<PetOwner>();
//            if (PetOwner != null && 
//               _context.ChangeTracker.Entries<PetOwner>().FirstOrDefault(oe => oe.Entity.Owner.Id == O ))
//            {
//                _context.Attach(pet.PreviousOwners);
//            }
//            var petToCreate = _context.Add(pet).Entity;
//            _context.SaveChanges();
//            return petToCreate;
            return pet;

        }

        public Pet FindPetById(int Id)
        {
            return _context.Pets.FirstOrDefault(p => p.ID == Id);
        }

        public List<Pet> GetAllPets()
        {
            return _context.Pets.Include(o => o.PreviousOwners).ThenInclude(po => po.Owner).ToList();
           
        }

        public Pet UpdatePet(Pet petToUpdate)
        {
            _context.Attach(petToUpdate).State = EntityState.Modified;
            
            _context.SaveChanges();
            return petToUpdate;
        }

        public Pet DeletePet(int id)
        {
            var petToRemove = _context.Remove(new Pet {ID = id}).Entity;
            _context.SaveChanges();
            return petToRemove;
        }

        
        
        
    }
}
