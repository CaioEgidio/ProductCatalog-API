using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Application.UseCases.CreateProduct;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Application.UseCases.GetAllProducts;

namespace ProductCatalog.API.Controllers;

[ApiController] 

[Route("products")] // defino a url base 
public class ProductsController : ControllerBase
{
    
    private readonly CreateProductHandler _createProductHandler;
    
    
    private readonly GetAllProductsHandler _getAllProductsHandler;

    // construtor do ProductsController, 0 .NET entrega os dois Handlers automaticamente, injeção de dependencia
    public ProductsController(
        CreateProductHandler createProductHandler,
        GetAllProductsHandler getAllProductsHandler)
    {
        _createProductHandler = createProductHandler;
        _getAllProductsHandler = getAllProductsHandler;
    }
//guardo os Handlers recebidos nos campos privados da classe
    
    [HttpGet] // Requisição do tipo GET
    public IActionResult Get()
    {
        // Busca todos os produtos
        var products = _getAllProductsHandler.Handle();

        return Ok(products);
    }

    [HttpPost] // Define um requisição do tipo POST 
    public IActionResult Create([FromBody] CreateProductRequest request)
    {
        
        var product = _createProductHandler.Handle(request);

        return Ok(product);
    }
}

