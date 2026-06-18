using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Interfaces;

// Contrato do repositório de produtos
public interface IProductRepository
{
    // Adiciona um produto
    void Add(Product product);

    // Retorna todos os produtos
    List<Product> GetAll();
}