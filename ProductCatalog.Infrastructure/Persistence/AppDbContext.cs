using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Infrastructure.Persistence;

public class AppDbContext : DbContext // Classe principal do entitiy framework, ponte entre C# e o banco 
{
    
    // Construtor: recebe as configurações do banco (string de conexão, qual banco usar, etc.)
    // O : base(options)" repassa essas configurações para o DbContext pai.
    // Essas configurações vêm lá da Program.cs (AddDbContext)
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // construtor 
    {
    }
    
    // Representa a tabela "Products" no banco de dados.
    // DbSet<Product> = cada item da lista é uma linha da tabela.
    public DbSet<Product> Products { get; set; } // peço uma tabela chamada products 
}

// O EF vai usar isso para criar a tabela automaticamente na migration