using System.Collections.Generic;
using Petshop.Core.Entity;

namespace Core.DomainService2
{
    public interface IMenuitemsReposetory
    {
        List<MenuItem> GetAllMenuItems();
    }
}