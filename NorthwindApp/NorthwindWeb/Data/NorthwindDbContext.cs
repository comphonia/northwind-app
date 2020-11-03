using Microsoft.EntityFrameworkCore;
using NorthwindWeb.Models;

namespace NorthwindWeb.Data
{
    public class NorthwindDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public NorthwindDbContext(DbContextOptions options)
           : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
