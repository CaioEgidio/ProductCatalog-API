using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Infrastructure.Persistence;

public class AppDbContext : DbContext 
{
    
    // Construtor: recebe as configurações do banco (string de conexão, qual banco usar, etc.)
    // O : base(options)" repassa essas configurações para o DbContext pai.
    // Essas configurações vêm lá da Program.cs (AddDbContext)
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // construtor 
    {
    }
    
    // Representa a tabela "Products" no banco de dados
    public DbSet<Product> Products { get; set; } // peço uma tabela chamada products 
    
    // Representa a tabela de usuarios
    public DbSet<User> Users { get; set; } // peço uma tabela chamada users
    
    // Representa a tabela de subprodutos
    public DbSet<SubProduct> SubProducts { get; set; }

    
    
    // Método executado pelo Entity Framework Core durante a criação/configuração
    // do modelo do banco de dados.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Mantém as configurações padrão do DbContext
        base.OnModelCreating(modelBuilder);
        
        
        // Procura automaticamente, nesta Assembly, todas as classes
        // que implementam IEntityTypeConfiguration e aplica suas configurações.
        //
        // Exemplo:
        // ProductConfiguration.cs → configuração da entidade Product
        // SubProductConfiguration.cs → configuração da entidade SubProduct
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
    }
}

// O EF vai usar isso para criar a tabela automaticamente na migration