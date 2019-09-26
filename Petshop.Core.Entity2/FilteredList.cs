using System.Collections.Generic;

namespace Petshop.Core.Entity2
{
    public class FilteredList<T>
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}