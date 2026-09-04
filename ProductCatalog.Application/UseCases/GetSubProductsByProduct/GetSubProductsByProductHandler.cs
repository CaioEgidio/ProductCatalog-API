using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.UseCases.GetSubProductsByProduct;

public class GetSubProductsByProductHandler
{
   private readonly ISubProductRepository _subProductRepository;

   public GetSubProductsByProductHandler(ISubProductRepository subProductRepository)
   {
      _subProductRepository = subProductRepository;
   }

   public List<SubProduct> Handle(Guid productId)
   {
      return _subProductRepository.GetByProductId(productId);
   }
}

