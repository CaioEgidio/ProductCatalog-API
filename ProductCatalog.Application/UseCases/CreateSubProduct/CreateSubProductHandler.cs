using ProductCatalog.Domain.Entities;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.UseCases.CreateSubProduct;
 
public class CreateSubProductHandler
{
    private readonly ISubProductRepository _subProductRepository;
    private readonly IProductRepository _productRepository;

    //Construtor
    public CreateSubProductHandler(ISubProductRepository subProductRepository, IProductRepository productRepository)
    {
        _productRepository = productRepository;
        _subProductRepository = subProductRepository;
    }

    public SubProduct Handle(CreateSubProductRequest request)
    {
        var product = _productRepository.GetById(request.ProductId);

        if (product is null)
        {
            throw new ArgumentException("Produto não encontrado");
        }

        var subProduct = new SubProduct(request.Name,request.ProductId,request.PrecoAdicional);
        
        _subProductRepository.Add(subProduct);

        return subProduct;
    }
}