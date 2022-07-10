namespace ComissionCalculator.Models.ComissionRules
{
    public partial class CapComissionRule : ComissionRule
    {
        public bool IsPercentage { get; set; }
        public decimal Value { get; set; }
    }
}
