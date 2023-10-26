using GenericProductAPI.Shared;
using Microsoft.EntityFrameworkCore;

namespace GenericProductAPI.Server.Infrastructure
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) 
        {

        }

        public DbSet<Product> Products { get; set; }

    }
}
