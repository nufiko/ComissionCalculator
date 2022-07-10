namespace ComissionCalculator.Models.ComissionRules
{
    public partial class FlatComissionRule : ComissionRule
    {
        public override decimal CalculateComission(Invoice invoice)
        {
            if (IsProductRule)
            {
                return CalculateProductComission(invoice.Products);
            }

            return CalculateInvoiceComission(invoice);
        }

        private decimal CalculateInvoiceComission(Invoice invoice)
        {
            return Value;
        }

        private decimal CalculateProductComission(List<InvoiceItem> products)
        {
            var units = products.Where(product => product.Product == Product).Sum(product => product.Amount);
            
            if (IsPerUnit)
            {
                return Value * units;
            }

            if ( units > 0)
            {
                return Value;
            }

            return 0;
        }
    }
}
