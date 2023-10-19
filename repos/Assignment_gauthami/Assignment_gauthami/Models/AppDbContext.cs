using Microsoft.EntityFrameworkCore;

namespace Assignment_gauthami.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-SSTRSUT0\\MSSQLSERVER01; Initial Catalog=lbs; User Id=sa; password=It20755188@#; TrustServerCertificate= True");
        }
    
}
}