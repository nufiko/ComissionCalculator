namespace ComissionCalculator.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public List<InvoiceItem> Products { get; set; }
        public SalesPerson SalesPerson { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal Comission { get; set; }
    }
}
