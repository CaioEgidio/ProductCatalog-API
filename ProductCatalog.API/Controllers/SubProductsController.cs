using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.UseCases.CreateSubProduct;

namespace ProductCatalog.API.Controllers;

[ApiController]
[Route("subproducts")]
public class SubProductsController : ControllerBase
{
    private readonly CreateSubProductHandler  _createSubProductHandler;
    
    // Recebe o Handler através da injeção de dependência.
    public SubProductsController(CreateSubProductHandler createSubProductHandler)
    {
        _createSubProductHandler = createSubProductHandler;
    }

    // Cria um novo SubProduct.
    [HttpPost]
    public IActionResult Create(CreateSubProductRequest request)
    {
        var subProduct = _createSubProductHandler.Handle(request);

        return Ok(subProduct);
    }
}