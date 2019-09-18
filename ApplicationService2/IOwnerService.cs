using System.Collections.Generic;
using Petshop.Core.Entity;

namespace ApplicationService2
{
    public interface IOwnerService
    {
        
            Owner CreateOwner(Owner owner);

            Owner UpdateOwner(Owner ownerToUpdate);

            Owner FindOwnerById(int id);

            List<Owner> GetOwners();

            Owner Delete(int id);
            
            
    }
}