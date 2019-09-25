using System;
using System.Collections.Generic;
using Petshop.Core.Entity;
using Petshop.Inferstructur.Data.Reposetory;

namespace Petshop.Inferstructur.SQL
{
    public class DbSeeder
    {
        public static void seedDb(Context ctx)
        {
            
            
            
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var owner1 = new Owner()
            {
                Adress = "nej gade",
                Firstname = "Nej",
                Lastname = "Lastname",

            };

            var pet = new Pet()
            {
                Name = "chr",
                Color = "sort som døden",
                Birthdate = DateTime.Now,
                Price = 99999,
                Species = "ko",
                SoldDate = DateTime.Today,
                PreviousOwners = new List<PetOwner>() { }
            };
            
            PetOwner petOwner = new PetOwner
            {
                Pet = pet,
                Owner = owner1
                
            };
            
            pet.PreviousOwners.Add(petOwner);

            owner1 = ctx.Owners.Add(owner1).Entity;
            pet = ctx.Add(pet).Entity;
            petOwner = ctx.PetOwners.Add(petOwner).Entity;
          

           
            
            

            ctx.SaveChanges();
        }
    }
}