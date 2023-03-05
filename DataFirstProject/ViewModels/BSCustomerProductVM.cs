using DataFirstProject.Models.BikeStores;
using System.ComponentModel.DataAnnotations;

namespace DataFirstProject.ViewModels
{
    public class BSCustomerProductVM
    {
        [Required]
        public string? BrandName { get; set; }

        [Required]
        public string? CategoryName { get; set; }

        public List<Customer>? Customers{ get; set; }
        public List<Product>? Products{ get; set; }
    }
}
