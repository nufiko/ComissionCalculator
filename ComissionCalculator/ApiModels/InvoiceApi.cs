namespace ComissionCalculator.ApiModels
{
    public class InvoiceApi
    {
        public int Id { get; set; }
        public List<InvoiceItemApi> Products { get; set; }
        public SalesPersonApi SalesPerson { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal Comission { get; set; }
    }
}
