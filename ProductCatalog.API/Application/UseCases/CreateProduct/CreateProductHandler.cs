using ProductCatalog.Domain.Entities;
using ProductCatalog.API.DTOs;


namespace ProductCatalog.API.Application.UseCases.CreateProduct;

public class CreateProductHandler
{
    public Product Handle(CreateProductRequest request)
    {
        var product = new Product(
            request.Nome,
            request.Descricao,
            request.Preco,
            Guid.NewGuid()
        );
        return product;
    }
}