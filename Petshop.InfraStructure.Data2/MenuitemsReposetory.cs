using System.Collections.Generic;
using Core.DomainService2;
using Petshop.Core.Entity2;

namespace Petshop.InfraStructure.Data2
{
    public class MenuitemsReposetory : IMenuitemsReposetory
    {
        public List<MenuItem> menuItemses = new List<MenuItem>()
        {
            new MenuItem("List of pets"),
            new MenuItem("Add new pet"),
            new MenuItem("Delete pet"),
            new MenuItem("Edit pet"),
            new MenuItem("Search Pets by Type"),
            new MenuItem("Get pets soretd by price"),
            new MenuItem("Get top five cheapest pets"),
            new MenuItem("Exit program")

        };

        public List<MenuItem> GetAllMenuItems()
        {
            return menuItemses;
        }
    }
}
