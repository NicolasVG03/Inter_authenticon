using Microsoft.EntityFrameworkCore;

namespace authenticon.Models;

public class DBauthenticon : DbContext
{
    public DBauthenticon(DbContextOptions<DBauthenticon> options) : base(options)
    {
    }

    //Defining the Tables
    public DbSet<Person> People => Set<Person>();
    public DbSet<Phone> Phones => Set<Phone>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Administrator> Administrators => Set<Administrator>();
    public DbSet<Collection> Collections => Set<Collection>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderProducts> OrderProducts => Set<OrderProducts>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Defining the Composite Primary Keys
        modelBuilder.Entity<Phone>()
            .HasKey(phone => new { phone.PersonID, phone.Number });

        modelBuilder.Entity<OrderProducts>()
            .HasKey(orderProducts => new { orderProducts.OrderID, orderProducts.ProductID });

    }

}
