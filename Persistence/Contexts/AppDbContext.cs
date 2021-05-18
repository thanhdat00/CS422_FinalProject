using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<Order> Orders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();//.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
                new Category { Id = 101, Name = "Dairy" }
            );

            //builder.Entity<Order>().ToTable("Orders");
            //builder.Entity<Order>().HasKey(p => p.ID);
            //builder.Entity<Order>().Property(p => p.CustomerName).IsRequired().HasMaxLength(30);
            //builder.Entity<Order>().Property(p => p.CustomerEmail).IsRequired().HasMaxLength(30);
            //builder.Entity<Order>().Property(p => p.CustomerAddress).IsRequired().HasMaxLength(30);
            //builder.Entity<Order>().Property(p => p.PaymentMethod).IsRequired();


            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.Price).IsRequired();
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
            builder.Entity<Product>().Property(p => p.Rating).IsRequired();

            builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 100,
                    Name = "Apple",
                    Price = 10000,
                    QuantityInPackage = 1,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    Rating = 5,
                    CategoryId = 100
                },
                new Product
                {
                    Id = 101,
                    Name = "Milk",
                    Price = 20000,
                    QuantityInPackage = 2,
                    UnitOfMeasurement = EUnitOfMeasurement.Liter,
                    Rating = 5,
                    CategoryId = 101,
                },
                new Product
                {
                    Id = 102,
                    Name = "Banana",
                    Price = 12000,
                    QuantityInPackage = 10,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    Rating = 2,
                    CategoryId = 100
                },
                new Product
                {
                    Id = 103,
                    Name = "Mango",
                    Price = 13000,
                    QuantityInPackage = 10,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    Rating = 3,
                    CategoryId = 100
                },
                new Product
                {
                    Id = 104,
                    Name = "Banana",
                    Price = 14000,
                    QuantityInPackage = 10,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    Rating = 3,
                    CategoryId = 100
                }
            ) ;;
        }
    }
}