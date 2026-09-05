using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.UseCases.GetSubProductsByProductId;

public class GetSubProductsByProductIdHandler
{
    // Repositório usado para buscar os SubProducts
    private readonly ISubProductRepository _subProductRepository;

    // Injeta o repositório no Handler
    public GetSubProductsByProductIdHandler(ISubProductRepository subProductRepository)
    {
        _subProductRepository = subProductRepository;
    }

    // Executa a busca pelo ProductId
    public List<SubProduct> Handle(Guid productId)
    {
        return _subProductRepository.GetByProductId(productId);
    }
}