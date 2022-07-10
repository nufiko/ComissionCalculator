namespace ComissionCalculator.Models.ComissionRules
{
    public partial class TieredComissionRule : ComissionRule
    {

        public bool IsPerUnit { get; set; }
        public bool IsPercentage { get; set; }
        public List<RuleTier> Tiers { get; set; }
    }
}
