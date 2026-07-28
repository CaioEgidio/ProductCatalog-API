using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Infrastructure.Persistence; 
using Microsoft.EntityFrameworkCore;

namespace ProductCatalog.Infrastructure.Repositories;

//implementação concreta de IProductRepository.
//aqui é onde acontece a "conversa" com o banco de dados.
public class ProductRepository : IProductRepository 
{
   // Guarda uma referência ao contexto do banco (EF Core).
   // É através dele que fazemos qualquer operação no banco de dados.
   // Conexão com o banco
   private readonly AppDbContext _context; 

   // Construtor: recebe o AppDbContext "de fora" (injeção de dependência)
   // e guarda na variável _context para usar nos métodos abaixo.
   public ProductRepository(AppDbContext context)
   {
      _context = context;
   }
   
   // Metodo que adiciona um novo produto ao banco de dados.
   public void Add(Product product)
   {
      // Marca o produto como "novo" para ser inserido 
      _context.Products.Add(product);
      
      //  grava no banco de dados (executa o INSERT).
      _context.SaveChanges();
   }
   // Metodo que busca todos os produtos cadastrados no banco.
   public List<Product> GetAll()
   {
      // ToList() consulta o banco e traz todos os registros
      // da tabela Products como uma lista de objetos Product.
      return _context.Products.ToList();
   }
}

// Implementar o acesso ao banco usando Entity Framework.
// Quem cumpre a lista de tarefas.