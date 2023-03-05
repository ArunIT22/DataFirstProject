using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataFirstProject.Models.BikeStores
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int BrandId { get; set; }

        [Required]
        public string BrandName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
