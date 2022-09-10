using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerce.Application.Models;

namespace ECommerce.EFCore
{
	public class ECommerceContext : DbContext
	{
        private string _connectionString = @"Data Source=localhost\SQL2k17;database=ECommerce;Integrated Security=true";
		public ECommerceContext(string connectionString)
		{
			_connectionString = connectionString;
		}

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public ECommerceContext()
        {

        }

		public ECommerceContext(DbContextOptions<ECommerceContext> dbContextOptions) : base(dbContextOptions)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("ecommerce");
        }

    }

    [Table("product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } 
        
        public ProductModel ToModel()
        {
            return new Application.Models.ProductModel()
            {
                Name = Name,
                Description = Description,
                Category = Category,
            };
        }
    }

    [Table("user")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }

    [Table("cart")]
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }    

        public List<Product> Products { get; } = new List<Product>();
    }
}
