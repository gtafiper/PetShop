using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Petshop.Core.Entity;

namespace Petshop.Inferstructur.SQL
{
    public class Context : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; } 
        
        public Context(DbContextOptions<Context> opt) : base(opt) {}
    }
}
