using ComissionCalculator.ApiModels;
using ComissionCalculator.Models;

namespace ComissionCalculator.Services.Contracts
{
    public interface ISalesPersonService
    {
        SalesPerson Get(SalesPersonApi salesperson);
    }
}
