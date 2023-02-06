using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class FruitType
    {
        public FruitType()
        {
            Fruits = new HashSet<Fruit>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Fruit> Fruits { get; set; }
    }
}
