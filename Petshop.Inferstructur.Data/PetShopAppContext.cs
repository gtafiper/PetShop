using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Petshop.Core.Entity;
using Petshop.Inferstructur.SQL.Reposetory;

namespace Petshop.Inferstructur.SQL
{
    public class Context : DbContext
    {
        public int OwnerId { get; set; }
        public DbSet<Owner> Owners { get; set; }
        
        public int PetId { get; set; }
        public DbSet<Pet> Pets { get; set; } 
        
        public Context(DbContextOptions<Context> opt) : base(opt) {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetOwner>().HasKey(pt  => new { pt.PetId, pt.OwnerId });
            
            modelBuilder.Entity<PetOwner>()
                .HasOne<Pet>(po => po.Pet)
                .WithMany(p => p.PreviousOwners)
                .HasForeignKey(po => po.PetId);


            modelBuilder.Entity<PetOwner>()
                .HasOne<Owner>(po => po.Owner)
                .WithMany(p => p.PetOwners)
                .HasForeignKey(po => po.OwnerId);
        }
    }
}
