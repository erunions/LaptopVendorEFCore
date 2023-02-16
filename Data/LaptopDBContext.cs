using LaptopVendorEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopVendorEFCore.Data
{
    public partial class LaptopDBContext : DbContext
    {
        public DbSet<Laptop> Laptops { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;

        public LaptopDBContext()
        {

        }

        public LaptopDBContext(DbContextOptions<LaptopDBContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LaptopDB;Integrated Security=True;");
        }
    }
}
