using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Infrastructure.Configurations;

public class ProductConfiguration
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);
        
        builder
            .HasMany<SubProduct>()
            .WithOne()
            .HasForeignKey(product => product.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}