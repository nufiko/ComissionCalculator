namespace ComissionCalculator.Models.ComissionRules
{
    public class RuleTier
    {
        public int Id { get; set; }
        public TieredComissionRule Rule { get; set; }
        public string Name { get; set; }
        public decimal Bottom { get; set; }
        public decimal Top { get; set; }
        public decimal Value { get; set; }
    }
}
