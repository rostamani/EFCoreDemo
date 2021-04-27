using System;
using System.Collections.Generic;
using System.Text;
using EFCore.Domain.ProductCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Infrastructure.EFCore.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(250).IsRequired();
            builder.Property(c => c.CreationDate).HasDefaultValueSql("getdate()");

            builder.HasMany(c => c.Products).WithOne(p => p.ProductCategory).HasForeignKey(p => p.CategoryId);
        }
    }
}
