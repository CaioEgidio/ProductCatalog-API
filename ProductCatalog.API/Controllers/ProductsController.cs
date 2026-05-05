using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.DTOs;
using ProductCatalog.Domain.Entities;
using ProductCatalog.API.Application.UseCases.CreateProduct;

namespace ProductCatalog.API.Controllers;

[ApiController] // digo pro .net que isso é uma api 
[Route("products")] // defino a url base 
public class ProductsController : ControllerBase
{
    private readonly CreateProductHandler _handler;

    public ProductsController(CreateProductHandler handler)
    {
        _handler = handler;
    }
    
    [HttpGet] // Requisição do tipo GET
    public IActionResult Get()
    {
        var products = new List<Product>
        {
            new Product("Notebook", "Notebook gamer", 3500, Guid.NewGuid())
        };
        return Ok(products);
    }

    [HttpPost] // Define um requisição do tipo POST 
    public IActionResult Create([FromBody] CreateProductRequest request)
    {
        var product = _handler.Handle(request);
        return Ok(product);
    }
}

