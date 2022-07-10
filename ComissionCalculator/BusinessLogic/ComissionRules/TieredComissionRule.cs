namespace ComissionCalculator.Models.ComissionRules
{
    public partial class TieredComissionRule : ComissionRule
    {
        public override decimal CalculateComission(Invoice invoice)
        {
            if (IsProductRule)
            {
                return CalculateProductTieredComission(invoice.Products);
            }

            return CalculateInvoiceTieredComission(invoice);
        }

        private decimal CalculateInvoiceTieredComission(Invoice invoice)
        {
            var invoiceValue = invoice.GetValue();
            var tier = FindTier(invoiceValue);

            if (IsPercentage)
            {
                return invoiceValue * tier.Value * 100m;
            }

            return tier.Value;
        }

        private decimal CalculateProductTieredComission(List<InvoiceItem> products)
        {
            var amount = 0m;

            if (IsPerUnit)
            {
                amount = products.Where(product => product.Product == Product).Sum(product => product.Amount);
            }
            else
            {
                amount = products.Where(product => product.Product == Product).Sum(product => product.Value);
            }

            var tier = FindTier(amount);
            return CalculateComission(amount, tier);
        }

        private decimal CalculateComission(decimal units, RuleTier tier)
        {
            if (units == 0)
            {
                return 0;
            }

            if (IsPercentage)
            {
                return units * tier.Value * 100m;
            }

            return units * tier.Value;
        }

        private RuleTier FindTier(decimal value)
        {
            return Tiers.Single(tier => tier.Bottom < value && tier.Top > value);
        }
    }
}
