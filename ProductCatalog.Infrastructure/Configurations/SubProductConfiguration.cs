using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Infrastructure.Configurations;

public class SubProductConfiguration
{
    public void Configure(EntityTypeBuilder<SubProduct> builder)
    {
        // Define a chave primária.
        builder.HasKey(subProduct => subProduct.Id);

        // Define a tabela do banco.
        builder.ToTable("SubProducts");

        // Nome é obrigatório.
        builder.Property(subProduct => subProduct.Name)
            .IsRequired();

        // ProductId é obrigatório.
        builder.Property(subProduct => subProduct.ProductId)
            .IsRequired();

        // Define duas casas decimais para o preço adicional.
        builder.Property(subProduct => subProduct.PrecoAdicional)
            .HasPrecision(18, 2); 
    }
}