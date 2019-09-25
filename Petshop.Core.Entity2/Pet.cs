using System;
using System.Collections.Generic;
using Petshop.Inferstructur.Data.Reposetory;

namespace Petshop.Core.Entity
{
    public class Pet
    {
        public int ID { get; set; }

        public String Name { get; set; }


        public  string Species { get; set;}
        public DateTime Birthdate { get; set; }

        public DateTime SoldDate { get; set; }

        public string Color { get; set; }

        public List<PetOwner> PreviousOwners { get; set; }

        public double Price { get; set; }
        
        


        





    }
}
