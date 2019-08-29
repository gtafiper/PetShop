using System.Collections.Generic;
using Petshop.Core.Entity;

namespace Core.DomainService
{
    public interface IMenuitemsReposetory
    {
        List<MenuItem> GetAllMenuItems();
    }
}