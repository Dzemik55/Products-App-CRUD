using Microsoft.EntityFrameworkCore;
using Projekt.Models;
using System.Reflection.Emit;

namespace Projekt.Data
{
    public class DB_Context :DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasIndex(u => u.Name)
                .IsUnique();
            builder.Entity<Subcategory>()
                .HasIndex(u => u.Name)
                .IsUnique();
            builder.Entity<Role>()
                .HasIndex(u => u.Name)
                .IsUnique();
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            builder.Entity<Product_Ingredient>()
                .HasKey(pi => new { pi.Ingredient_id, pi.Product_id });
            builder.Entity<Product_Ingredient>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.Product_Ingredients)
                .HasForeignKey(pi => pi.Product_id);
            builder.Entity<Product_Ingredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.Product_Ingredients)
                .HasForeignKey(pi => pi.Ingredient_id);

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set;}
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Product_Ingredient> Product_Ingredients { get; set; }
    }
}
