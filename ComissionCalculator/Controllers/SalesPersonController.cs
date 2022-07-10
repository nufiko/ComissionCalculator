using ComissionCalculator.DAL;
using ComissionCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComissionCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesPersonController : ControllerBase
    {
        ComissionDbContext dbContext;

        public SalesPersonController(ComissionDbContext context)
        {
            dbContext = context;
        }

        [HttpGet("[action]")]
        public ActionResult<SalesPerson> Get(int id)
        {
            var salesPerson = dbContext.SalesPeople.FirstOrDefault(sp => sp.Id == id);

            if (salesPerson == null)
            {
                return NotFound();
            }

            return Ok(salesPerson);
        }

        [HttpPost("[action]")]
        public ActionResult<SalesPerson> Add([FromBody] SalesPerson salesPerson)
        {
            dbContext.SalesPeople.Add(salesPerson);
            dbContext.SaveChanges();

            return Ok(salesPerson);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<SalesPerson>> List([FromHeader]int amount, [FromHeader]int page)
        {
            var salesPeople = dbContext.SalesPeople.OrderBy(sp => sp.Id).Skip(amount * (page - 1)).Take(amount);
            return Ok(salesPeople);
        }
    }
}
