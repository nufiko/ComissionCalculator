namespace ComissionCalculator.Models.ComissionRules
{
    public partial class CapComissionRule : ComissionRule
    {
        public override decimal CalculateComission(Invoice invoice)
        {
            if (IsPercentage)
            {
                return CalculatePercentageComission(invoice);
            }

            return Value;
        }

        private decimal CalculatePercentageComission(Invoice invoice)
        {
            var invoiceValue = invoice.GetValue();
            return invoiceValue * Value / 100m;
        }
    }
}
