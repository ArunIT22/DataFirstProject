using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataFirstProject.Models.BikeStores
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
