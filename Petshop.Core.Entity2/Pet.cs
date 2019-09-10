﻿using System;
using System.Collections.Generic;

namespace Petshop.Core.Entity2
{
    public class Pet
    {
        public int ID { get; set; }

        public String Name { get; set; }


        public  string Species { get; set;}
        public DateTime Birthdate { get; set; }

        public DateTime SoldDate { get; set; }

        public string Color { get; set; }

        public List<int> PreviousOwnerIds { get; set; }

        public double Price { get; set; }


        public enum Type
        {
            Cat,
            Dog,
            Goat,
            Fish,
            Snake,
            Sausage,
            Rock
        }





    }
}
