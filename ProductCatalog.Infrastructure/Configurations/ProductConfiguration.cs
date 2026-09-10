using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Define o Id como chave primária.
        builder.HasKey(product => product.Id);

        // Define a tabela utilizada pela entidade Product.
        builder.ToTable("Products");

        // Nome do produto é obrigatório.
        builder.Property(product => product.Nome)
            .IsRequired();

        // Descrição do produto é obrigatória.
        builder.Property(product => product.Descricao)
            .IsRequired();

        // Define que o preço terá 2 casas decimais.
        builder.Property(product => product.Preco)
            .HasPrecision(18, 2);

        // UserId é obrigatório.
        builder.Property(product => product.UserId)
            .IsRequired();

        // Data de criação é obrigatória.
        builder.Property(product => product.DataCriacao)
            .IsRequired();

        // Um Product pode possuir vários SubProducts.
        // Quando o Product for excluído, seus SubProducts
        // também serão excluídos.
        builder
            .HasMany<SubProduct>()
            .WithOne()
            .HasForeignKey(subProduct => subProduct.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}