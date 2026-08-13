using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.UseCases.CreateProduct;
using ProductCatalog.Application.UseCases.GetAllProducts;
using ProductCatalog.Application.UseCases.GetProductById;

namespace ProductCatalog.API.Controllers;

[ApiController] 

[Route("products")] // defino a url base 
public class ProductsController : ControllerBase
{
    private readonly CreateProductHandler _createProductHandler;
    private readonly GetAllProductsHandler _getAllProductsHandler;
    private readonly GetProductByIdHandler _getProductByIdHandler;

    // construtor do ProductsController, 0 .NET entrega os dois Handlers automaticamente, injeção de dependencia
    public ProductsController(
        CreateProductHandler createProductHandler,
        GetAllProductsHandler getAllProductsHandler,
        GetProductByIdHandler getProductByIdHandler)
    {
        // Guarda os Handlers recebidos nos campos privados.
        _createProductHandler = createProductHandler;
        _getAllProductsHandler = getAllProductsHandler;
        _getProductByIdHandler = getProductByIdHandler;
    }
//guardo os Handlers recebidos nos campos privados da classe
    
    [HttpGet] // Requisição do tipo GET
    public IActionResult Get()
    {
        // Busca todos os produtos
        var products = _getAllProductsHandler.Handle();

        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id) 
    {
        var product = _getProductByIdHandler.Handle(id); //Controller envia o ID para Handler busca o produto no banco

        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost] // Define um requisição do tipo POST 
    public IActionResult Create([FromBody] CreateProductRequest request)
    {
        
        var product = _createProductHandler.Handle(request);

        return Ok(product);
        
    }
}



