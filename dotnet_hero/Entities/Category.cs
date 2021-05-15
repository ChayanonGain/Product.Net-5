using System;
using System.Collections.Generic;

#nullable disable

namespace dotnet_hero.Entities
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
