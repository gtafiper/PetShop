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
                Firstname = "Nej nej",
                Lastname = "Lastname",
                PetOwners = new List<PetOwner>()

            };
            var owner2 = new Owner()
            {
                Adress = "nej gade",
                Firstname = "Nej blev der sagt jeg",
                Lastname = "Lastname",

            };
            var owner3 = new Owner()
            {
                Adress = "nej gade",
                Firstname = "okay",
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

            var pet1 = new Pet()
            {
                Name = "ole",
                Color = "sort som døden",
                Birthdate = DateTime.Now,
                Price = 99999,
                Species = "ko",
                SoldDate = DateTime.Today,
                PreviousOwners = new List<PetOwner>() { }
            };
            
            var petOwner = new PetOwner
            {
               
                Owner = owner1,
                
            };
            var petOwner1 = new PetOwner
            {
                
                Owner = owner2
            };
            
            pet1.PreviousOwners.Add(petOwner);
            pet1.PreviousOwners.Add(petOwner1);
           

            owner1 = ctx.Owners.Add(owner1).Entity;
            owner2 = ctx.Owners.Add(owner2).Entity;
            owner3 = ctx.Owners.Add(owner3).Entity;
            pet1 = ctx.Pets.Add(pet1).Entity;
            pet = ctx.Pets.Add(pet).Entity;
            petOwner1 = ctx.PetOwners.Add(petOwner1).Entity;
            petOwner = ctx.PetOwners.Add(petOwner).Entity;
          
ctx.SaveChanges();
        }
    }
}