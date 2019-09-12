using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Petshop.Core.Entity2;

namespace Petshop.Inferstructur.SQL
{
    public class OwnerContext : DbContext
    {
        public DbSet<Owner> owners { get; set; }
    }
}
