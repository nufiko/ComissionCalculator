namespace ComissionCalculator.Models.ComissionRules
{
    public partial class PercentageComissionRule : ComissionRule
    {
        public override decimal CalculateComission(Invoice invoice)
        {
            if (IsProductRule)
            {
                return CalulateProductComission(invoice.Products);
            }

            return CalculateInvoiceComission(invoice);
        }

        private decimal CalculateInvoiceComission(Invoice invoice)
        {
            return invoice.GetValue() * Value / 100m;
        }

        private decimal CalulateProductComission(List<InvoiceItem> products)
        {
            return products.Sum(prod => prod.Value) * Value / 100m;
        }
    }
}
