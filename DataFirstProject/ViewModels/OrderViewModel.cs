using System.ComponentModel.DataAnnotations;

namespace DataFirstProject.ViewModels
{
    public class OrderViewModel
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
