namespace ComissionCalculator.Models
{
    public partial class Invoice
    {
        public decimal GetValue()
        {
            var invoiceValue = 0m;
            foreach(var product in Products)
            {
                invoiceValue += product.Value;
            }
            return invoiceValue;
        }
    }
}
