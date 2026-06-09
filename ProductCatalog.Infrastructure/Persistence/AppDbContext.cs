using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Infrastructure.Persistence;

public class AppDbContext : DbContext // Classe principal do entitiy framework, ponte entre C# e o banco 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // construtor 
    {
    }
    public DbSet<Product> Products { get; set; } // peço uma tabela chamada products 
}

// O EF vai usar isso para criar a tabela automaticamente na migration