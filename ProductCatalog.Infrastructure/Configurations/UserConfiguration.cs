using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Define a chave primária.
        builder.HasKey(user => user.Id);

        // Define a tabela do banco.
        builder.ToTable("Users");

        // Nome é obrigatório.
        builder.Property(user => user.Nome)
            .IsRequired();

        // Email é obrigatório.
        builder.Property(user => user.Email)
            .IsRequired();

        // Garante que dois usuários não possam
        // possuir o mesmo email.
        builder.HasIndex(user => user.Email)
            .IsUnique();

        // Data de criação é obrigatória.
        builder.Property(user => user.DataCriacao)
            .IsRequired();
    }
}