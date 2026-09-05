using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.UseCases.CreateSubProduct;
using ProductCatalog.Application.UseCases.GetSubProductsByProductId;

namespace ProductCatalog.API.Controllers;

[ApiController]
[Route("subproducts")]
public class SubProductsController : ControllerBase
{
    private readonly CreateSubProductHandler  _createSubProductHandler;
    private readonly GetSubProductsByProductIdHandler _getSubProductsByProductIdHandler;
    
    // Recebe o Handler através da injeção de dependência.
    public SubProductsController(CreateSubProductHandler createSubProductHandler,  GetSubProductsByProductIdHandler getSubProductsByProductIdHandler)
    {
        _createSubProductHandler = createSubProductHandler;
        _getSubProductsByProductIdHandler = getSubProductsByProductIdHandler;
        
    }

    // Cria um novo SubProduct.
    [HttpPost]
    public IActionResult Create(CreateSubProductRequest request)
    {
        var subProduct = _createSubProductHandler.Handle(request);

        return Ok(subProduct);
    }

    [HttpGet]
    public IActionResult GetByproductId(Guid productId)
    {
        var subProduct = _getSubProductsByProductIdHandler.Handle(productId);

        return Ok(subProduct);
    }
}