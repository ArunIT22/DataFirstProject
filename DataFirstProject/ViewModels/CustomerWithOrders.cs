namespace DataFirstProject.ViewModels
{
    public class CustomerWithOrdersViewModel
    {
        public string ContactName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Freight { get; set; }
    }
}
