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
    public class OwnerReposetory : iOwnerReposetory

    {
        private readonly Context _context;

        public OwnerReposetory(Context context)
        {
            _context = context;
        }
        public Owner CreatOwner(Owner owner)
        {
            var OwerToCrate = _context.Add(owner).Entity;
            _context.SaveChanges();
            return OwerToCrate;
        }

        public Owner DeletedOwner(int id)
        {
            var OwnerToRemove = _context.Remove(new Owner() {Id = id}).Entity;
            _context.SaveChanges();
            return OwnerToRemove;
        }

        public Owner UpdateOwner(Owner owner)
        {
            throw new NotImplementedException();
        }

        public Owner GetOwnerById(int id)
        {
            return _context.Owners.FirstOrDefault(O => O.Id == id);
        }

        public List<Owner> GetAllOwners()
        {
            return _context.Owners.Include(po => po.PetOwners).ToList();
        }
    }
}
