using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Interfaces;

public interface IProductRepository
{
    private static List<Product> _products = new();

    void Add(Product product)
    {
        _products.Add(product);
    }

    List<Product> GetAll()
    {
        return _products;
    }
}