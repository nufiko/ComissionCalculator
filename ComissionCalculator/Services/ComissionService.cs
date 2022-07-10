using ComissionCalculator.DAL;
using ComissionCalculator.Models;
using ComissionCalculator.Models.ComissionRules;
using ComissionCalculator.Services.Contracts;

namespace ComissionCalculator.Services
{
    public class ComissionService : IComissionService
    {
        private readonly ComissionDbContext dbContext;

        public ComissionService(ComissionDbContext context)
        {
            dbContext = context;    
        }

        public decimal CalculateComission(Invoice invoice)
        {
            var comission = 0m;
            var cap = decimal.MaxValue;

            var rules = GetComissionRules(invoice.SalesPerson);
            foreach(var rule in rules)
            {
                if (rule is not CapComissionRule)
                {
                    comission += rule.CalculateComission(invoice);
                }
                else
                {
                    cap = rule.CalculateComission(invoice);
                }

                if (comission > cap)
                {
                    return cap;
                }
            }

            return comission;
        }

        private IEnumerable<ComissionRule> GetComissionRules(SalesPerson salesPerson)
        {
            return dbContext.ComissionRules.Where(rule => rule.SalesPerson == salesPerson);
        }
    }
}
