using System.ComponentModel.DataAnnotations.Schema;

namespace ComissionCalculator.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Invoice Invoice { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public decimal Value { get => Amount * Price; }
    }
}
