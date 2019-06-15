using KnockoutJS.Core;
using KnockoutJS.Core.Authors;
using KnockoutJS.Core.Books;
using KnockoutJS.Core.CartItems;
using KnockoutJS.Core.Carts;
using KnockoutJS.Core.Categories;
using Microsoft.EntityFrameworkCore;
using System;

namespace KnockoutJS.EFCore
{
    /// <summary>
    /// 书城限界上下文
    /// </summary>
    public class ShoppingCartContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql(Configuration.GetConnectionString("Default"));
        }
    }
}
