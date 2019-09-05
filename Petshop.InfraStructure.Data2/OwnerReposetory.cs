using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainService2;
using Petshop.Core.Entity2;

namespace Petshop.InfraStructure.Data2
{
    public class OwnerReposetory: iOwnerReposetory

    {
        private static List<Owner> _ListOfOwners = new List<Owner>()
        {
            new Owner(){Adress = "Sportsvej",Firstname = "Per", Lastname = "Person", Id = 1},
            new Owner(){Adress = "Sportsvej",Firstname = "Per", Lastname = "Person", Id = 2},
            new Owner(){Adress = "Sportsvej",Firstname = "Ole", Lastname = "Whedel", Id = 3}

        };

        private int TheNumberOFOwners = _ListOfOwners.Count()+1;

        public Owner CreatOwner(Owner owner)
        {
            owner.Id = TheNumberOFOwners++;
            _ListOfOwners.Add(owner);
            return owner;
        }

        public Owner DeletedOwner(int id)
        {
            foreach (var owner in _ListOfOwners)
            {
                if (owner.Id == id)
                {
                    return owner;
                }
    
            }
            return null;
        }

        public Owner UpdateOwner(Owner ownerToUpdate)
        {
            var ownerFromList = this.GetOwnerById(ownerToUpdate.Id);

            if (ownerFromList != null)
            {
                ownerFromList.Firstname = ownerToUpdate.Firstname;
                ownerFromList.Lastname = ownerToUpdate.Lastname;
                ownerFromList.Adress = ownerToUpdate.Lastname;

                return ownerFromList;
            }

            return null;
        }

        public Owner GetOwnerById(int id)
        {
            {
                foreach (Owner owner in _ListOfOwners)
                {
                    if (owner.Id == id)
                    {
                        return owner;
                    }

                }

                return null;
            }
        }
    }
}
