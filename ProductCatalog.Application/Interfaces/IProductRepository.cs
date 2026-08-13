using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Interfaces;

// Contrato do repositório de produtos
public interface IProductRepository
{
    // Adiciona um produto
    void Add(Product product);

    // Retorna todos os produtos
    List<Product> GetAll();

    // Busca um produto pelo ID.
    Product? GetById(Guid id);
}

//Define o contrato de acesso aos produtos.
//Lista de tarefas.

