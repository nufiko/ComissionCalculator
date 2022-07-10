namespace ComissionCalculator.Models.ComissionRules
{
    public partial class FlatComissionRule : ComissionRule
    {
        public bool IsPerUnit { get; set; }
        public decimal Value { get; set; }
    }
}
