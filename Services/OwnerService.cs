using System.Collections.Generic;
using Core.DomainService2;
using Petshop.Core.Entity;

namespace ApplicationService2
{
    public class OwnerService : IOwnerService
    {
        private iOwnerReposetory _repo;

        public OwnerService(iOwnerReposetory repo)
        {
            _repo = repo;
        }
       

        public Owner CreateOwner(Owner owner)
        {
            return _repo.CreatOwner(owner);
        }

        public Owner UpdateOwner(Owner ownerToUpdate)
        {
            var owner = FindOwnerById(ownerToUpdate.Id);
            owner.Firstname = ownerToUpdate.Firstname;
            owner.Lastname = ownerToUpdate.Lastname;
            owner.Adress = ownerToUpdate.Adress;
            return owner;
        }   

        public Owner FindOwnerById(int id)
        {
            return _repo.GetOwnerById(id);
        }

        public List<Owner> GetOwners()
        {
            return _repo.GetAllOwners();
        }

        public Owner Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}