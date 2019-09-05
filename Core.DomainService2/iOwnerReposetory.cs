using System;
using System.Collections.Generic;
using System.Text;
using Petshop.Core.Entity2;

namespace Core.DomainService2
{
    public interface iOwnerReposetory
    {

        Owner CreatOwner(Owner owner);

        Owner DeletedOwner(int id);

        Owner UpdateOwner(Owner owner);

        Owner GetOwnerById(int id);


    }
}
