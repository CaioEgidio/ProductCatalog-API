using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Irepositories;

public interface IProductRepository
{
    //Busca um produto pelo Id
    Task<Product> GetByIdAsync(Guid id);
    
    //Busca a Lista de todos os produtos
    Task<IEnumerable<Product>> GetAllAsync();
    
    //Salva um novo produto no banco
    Task AddAsync(Product product);
}