using System;
using System.Collections.Generic;
using System.Text;
using EFCore.Domain.ProductAgg;
using EFCore.Domain.ProductCategoryAgg;
using EFCore.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Infrastructure.EFCore
{
    public class EfContext:DbContext
    {
        public EfContext(DbContextOptions<EfContext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
