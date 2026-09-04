using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Infrastructure.Persistence;

namespace ProductCatalog.Infrastructure.Repositories;

public class SubProductRepository : ISubProductRepository
{
    private readonly AppDbContext _context;

    // Injeta o contexto do banco de dados.
    public SubProductRepository(AppDbContext context)
    {
        _context = context;
    }

    // Salva um novo SubProduct no banco.
    public void Add(SubProduct subProduct)
    {
        _context.SubProducts.Add(subProduct);
        _context.SaveChanges();
    }

    //Busca todos os SubProducts pertencentes a um Product.
    public List<SubProduct> GetByProductId(Guid productId)
    {
        return _context.SubProducts.Where(x => x.ProductId == productId).ToList();
    }

}   