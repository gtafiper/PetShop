﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainService2;
using Microsoft.EntityFrameworkCore;
using Petshop.Core.Entity;
using Petshop.Core.Entity2;
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
            return _context.Pets
                .Include(o => o.PreviousOwners)
                .ThenInclude(po => po.Owner)
                .FirstOrDefault(p => p.ID == Id);
        }

        public List<Pet> GetAllPets(Filter filter)
        {
            return _context.Pets.Include(o => o.PreviousOwners).ThenInclude(po => po.Owner).ToList();

        }

        public FilteredList<Pet> GetAllFiltertPets(Filter filter)
        {
            var filterdlist = new FilteredList<Pet>();
            if(filter != null && filter.CurrentPage > 0 && filter.ItemsPrPage > 0)
            {
                filterdlist.List = _context.Pets
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage)
                    .OrderBy(p => p.ID)
                    .Include(o => o.PreviousOwners).ThenInclude(po => po.Owner)
                    .ToList();
                return filterdlist;
            }

            filterdlist.List = _context.Pets.Include(o => o.PreviousOwners).ThenInclude(po => po.Owner);
            return filterdlist;
        }

        public Pet UpdatePet(Pet petToUpdate)
        {
            if (petToUpdate != null)
            {
                _context.Attach(petToUpdate).State = EntityState.Modified;
                
            }
            var petOwners = new List<PetOwner>(petToUpdate.PreviousOwners ?? new List<PetOwner>());
            _context.PetOwners.RemoveRange(
                _context.PetOwners.Where(p => p.id == petToUpdate.ID)
            );
            foreach (var po in petOwners)
            {
                _context.Entry(po).State = EntityState.Added;
            }
            _context.SaveChanges();
            return petToUpdate;
            
        }

        public Pet DeletePet(int id)
        {
            var petToRemove = _context.Remove(new Pet {ID = id}).Entity;
            _context.SaveChanges();
            return petToRemove;
        }

        public Owner GetOwner(Owner owner)
        {
            return _context.Owners.FirstOrDefault(o => o.Id == owner.Id);
        }

        public int Count()
        {
            return _context.Pets.Count();
        }
    }
}
