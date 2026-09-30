using Microsoft.EntityFrameworkCore;

public class AppDbContext(string connectionString) : DbContext
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    // Tables were created with unquoted names, so Postgres stored them in lowercase.
    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseNpgsql(connectionString).UseLowerCaseNamingConvention();
}
