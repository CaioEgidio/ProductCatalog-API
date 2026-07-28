using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.UseCases.GetAllProducts;

public class GetAllProductsHandler
{
    // Guarda o repositório que será usado para buscar os produtos.
    private readonly IProductRepository _productRepository;
    
    // O .NET entrega o repositório automaticamente
    // através da injeção de dependência.
    public GetAllProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    // Executa a ação de buscar todos os produtos.
    public List<Product> Handle()
    {
        // Pede ao repositório todos os produtos
        // e devolve a lista para o Controller.
        return _productRepository.GetAll();
    }
}

