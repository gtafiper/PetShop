using Microsoft.EntityFrameworkCore;
using Petshop.Core.Entity;
using Petshop.Inferstructur.Data.Reposetory;

namespace Petshop.Inferstructur.SQL
{
    public class Context : DbContext
    {
       
        public DbSet<Owner> Owners { get; set; }
        
        public  DbSet<PetOwner> PetOwners { get; set; }
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
