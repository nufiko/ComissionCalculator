using ComissionCalculator.ApiModels;
using ComissionCalculator.DAL;
using ComissionCalculator.Models;
using ComissionCalculator.Services.Contracts;

namespace ComissionCalculator.Services
{
    public class SalesPersonService : ISalesPersonService
    {
        private readonly ComissionDbContext _dbContext;

        public SalesPersonService(ComissionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SalesPerson Get(SalesPersonApi salesperson)
        {
            var result = _dbContext.SalesPeople
                .FirstOrDefault(person => person.Name == salesperson.Name && person.Surname == salesperson.Surname);

            return result;
        }
    }
}
