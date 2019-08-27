using System;

namespace Petshop.Core.Entity
{
    public class Pet
    {
        public int ID { get;}

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

    public DateTime Birthdate { get; set; }

    public DateTime SoldDate { get; set; }

        public string Color { get; set; }

        public string PreviousOwner { get; set; }

        public double Price { get; set; }

        public Type _type; 

    private Pet(int Id, string name, Type type, DateTime birthdate, string color, double price)
        {
            this._type = type;
            this.ID = Id;
            this.Name = name;
            this.Color = color;
            this.Birthdate = birthdate;
            this.Price = price;
        }

          
    }
}
