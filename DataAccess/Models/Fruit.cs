using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Fruit
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? Type { get; set; }
        public string Description { get; set; }

        public virtual FruitType TypeNavigation { get; set; }
    }
}
