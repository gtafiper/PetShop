
using Petshop.Core.Entity;

namespace Petshop.Inferstructur.SQL.Reposetory
{
    public class PetOwner
    {
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}