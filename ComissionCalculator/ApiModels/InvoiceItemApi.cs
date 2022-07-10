namespace ComissionCalculator.ApiModels
{
    public class InvoiceItemApi
    {
        public string Product { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Value { get => Amount * Price; }
    }
}
