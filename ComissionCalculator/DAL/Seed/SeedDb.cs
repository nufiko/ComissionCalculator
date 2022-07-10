using ComissionCalculator.Models;
using ComissionCalculator.Models.ComissionRules;

namespace ComissionCalculator.DAL.Seed
{
    public static class DbSeeder
    {
        public static void Seed(ComissionDbContext dbContext)
        {
            SeedSalesPeople(dbContext);
            SeedProducts(dbContext);
            SeedRules(dbContext);
        }

        private static void SeedSalesPeople(ComissionDbContext dbContext)
        {
            var salesPeople = new List<SalesPerson>
            {
                new SalesPerson
                {
                    Name = "John",
                    Surname = "Washington"
                },

                new SalesPerson
                {
                    Name = "Robert",
                    Surname = "Ford"
                }
            };

            dbContext.SalesPeople.AddRange(salesPeople);
            dbContext.SaveChanges();
        }

        private static void SeedProducts(ComissionDbContext dbContext)
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Bucket",
                    Price = 10
                },
                new Product
                {
                    Name = "Nails",
                    Price = 0.2m
                },
                new Product
                {
                    Name = "Hammer",
                    Price = 2
                }
            };

            dbContext.Products.AddRange(products);
            dbContext.SaveChanges();
        }

        private static void SeedRules(ComissionDbContext dbContext)
        {
            dbContext.ComissionRules.Add(new FlatComissionRule
            {
                IsPerUnit = false,
                Name = "Bucket Bonus",
                IsProductRule = true,
                Product = dbContext.Products.First(p => p.Name == "Bucket"),
                SalesPerson = dbContext.SalesPeople.First(),
                Value = 5
            });
            dbContext.ComissionRules.Add(new PercentageComissionRule
            {
                IsProductRule = false,
                SalesPerson = dbContext.SalesPeople.First(),
                Value = 10,
                Name = "Invoice Bonus"
            });
            dbContext.ComissionRules.Add(new CapComissionRule
            {
                Name = "Cap rule",
                IsProductRule = false,
                SalesPerson = dbContext.SalesPeople.First(),
                Value = 8,
                IsPercentage = false
            });

            dbContext.SaveChanges();
        }
    }
}
