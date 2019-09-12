using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Petshop.Core.Entity2;

namespace Petshop.Inferstructur.SQL
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions opt) : base(opt)
        {

        }
        public DbSet<Pet> pets { get; set; }    
    }
}
