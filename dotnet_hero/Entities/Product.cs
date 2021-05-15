using System;
using System.Collections.Generic;

#nullable disable

namespace dotnet_hero.Entities
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
