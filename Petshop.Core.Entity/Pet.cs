using System;
using System.Threading;

namespace Petshop.Core.Entity
{
    public class Pet
    {
        public int ID { get; set; }

        public String Name { get; set; }

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

        public  string Species { get; set;}
        public DateTime Birthdate { get; set; }

    public DateTime SoldDate { get; set; }

        public string Color { get; set; }

        public string PreviousOwner { get; set; }

        public double Price { get; set; }

        

       /// public Type _type; 

    public Pet(int Id, string name, string species , DateTime birthdate, string color, double price)
        {
            
            this.ID = Id;
            this.Name = name;
            this.Color = color;
            this.Birthdate = birthdate;
            this.Price = price;
            this.Species = species;
        }

       
    }
}
