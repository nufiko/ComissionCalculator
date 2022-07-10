using ComissionCalculator.Models;
using ComissionCalculator.Models.ComissionRules;
using Microsoft.EntityFrameworkCore;

namespace ComissionCalculator.DAL
{
    public class ComissionDbContext : DbContext
    {
        public ComissionDbContext(DbContextOptions<ComissionDbContext> options) : base(options)
        { }

        public DbSet<SalesPerson> SalesPeople { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ComissionRule> ComissionRules { get; set; }
        public DbSet<RuleTier> RuleTiers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CapComissionRule>();
            modelBuilder.Entity<FlatComissionRule>();
            modelBuilder.Entity<PercentageComissionRule>();
            modelBuilder.Entity<TieredComissionRule>();
        }
    }
}
