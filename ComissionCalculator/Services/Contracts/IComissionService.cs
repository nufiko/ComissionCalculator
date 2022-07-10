using ComissionCalculator.Models;

namespace ComissionCalculator.Services.Contracts
{
    public interface IComissionService
    {
        decimal CalculateComission(Invoice invoice);
    }
}