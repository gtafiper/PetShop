using System;
using System.Collections.Generic;
using System.Text;
using Petshop.Core.Entity;

namespace Core.DomainService
{
    public class MenuitemsReposetory
    {
        public List<MenuItem> menuItemses = new List<MenuItem>()
        {
            new MenuItem("List of pets"),
            new MenuItem("Add new pet"),
            new MenuItem("Delete pet"),
            new MenuItem("Edit pet"),
            new MenuItem("get pet by species")

        };

        public List<MenuItem> GetAllMenuItems()
        {
            return menuItemses;
        }
    }
}
