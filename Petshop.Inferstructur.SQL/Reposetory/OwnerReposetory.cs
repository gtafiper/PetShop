using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainService2;
using Petshop.Core.Entity2;

namespace Petshop.Inferstructur.SQL.Reposetory
{
    public class OwnerReposetory : iOwnerReposetory

    {
        private OwnerContext _context;

        public OwnerReposetory(OwnerContext context)
        {
            _context = context;
        }
        public Owner CreatOwner(Owner owner)
        {
            var OwerToCrate = _context.Add(owner).Entity;
            _context.SaveChanges();
            return owner;
        }

        public Owner DeletedOwner(int id)
        {
            throw new NotImplementedException();
        }

        public Owner UpdateOwner(Owner owner)
        {
            throw new NotImplementedException();
        }

        public Owner GetOwnerById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Owner> GetAllOwners()
        {
            return _context.owners.ToList();
        }
    }
}
