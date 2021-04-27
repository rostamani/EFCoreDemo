using System;
using System.Collections.Generic;
using System.Text;
using EFCore.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Infrastructure.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.Name).HasMaxLength(250).IsRequired();
            builder.Property(p => p.CreationDate).HasDefaultValueSql("getdate()");
            builder.HasOne(p => p.ProductCategory).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
        }
    }
}
