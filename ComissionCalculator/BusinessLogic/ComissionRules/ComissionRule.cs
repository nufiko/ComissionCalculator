namespace ComissionCalculator.Models.ComissionRules
{
    public abstract partial class ComissionRule
    {
        public abstract decimal CalculateComission(Invoice invoice);
    }
}
