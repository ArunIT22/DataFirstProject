
using System.ComponentModel.DataAnnotations;

namespace DataFirstProject.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
