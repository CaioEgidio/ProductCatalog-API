using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Interfaces;

public interface ISubProductRepository
{
    
    //Define uma operação para salvar um SubProduct.
    void Add(SubProduct subProduct);

    //Define uma operação para buscar todos os SubProducts pertencentes a um Product específico.
    List<SubProduct> GetByProductId(Guid productId);

}    
    