using System;
using System.Collections.Generic;
using System.Text;

namespace Petshop.Core.Entity
{
    public class Owner 
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Adress { get; set; }

        public List<Pet> listOfPets { get; set; }
    }
}
