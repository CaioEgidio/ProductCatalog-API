using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.UseCases.GetProductById;

public class GetProductByIdHandler
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)// construtor
    {
        _productRepository = productRepository;
    }
    
    public Product? Handle(Guid id) // metodo que recebe o ID e pede ao repositório para buscar o produto.
    {
        return _productRepository.GetById(id);
    }
}

