namespace ComissionCalculator.Models.ComissionRules
{
    public abstract partial class ComissionRule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsProductRule { get; set; }
        public Product? Product { get; set; }
        public SalesPerson SalesPerson { get; set; }
    }
}
