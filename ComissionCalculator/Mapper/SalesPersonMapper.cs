using ComissionCalculator.ApiModels;
using ComissionCalculator.Models;

namespace ComissionCalculator.Mapper
{
    public class SalesPersonMapper : IMapper<SalesPerson, SalesPersonApi>
    {
        public SalesPersonApi Map(SalesPerson source)
        {
            var result = new SalesPersonApi
            {
                Name = source.Name,
                Surname = source.Surname
            };

            return result;
        }
    }
}
