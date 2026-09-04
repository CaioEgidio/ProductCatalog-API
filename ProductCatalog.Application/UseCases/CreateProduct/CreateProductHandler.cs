using ProductCatalog.Domain.Entities;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;

namespace ProductCatalog.Application.UseCases.CreateProduct;
 
// Caso de uso: criar um produto
public class CreateProductHandler
{
    
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;

    // Recebe o repositório via injeção de dependência
    public CreateProductHandler(IProductRepository productRepository, IUserRepository userRepository)
    {
        _productRepository = productRepository;
        _userRepository = userRepository;
    }
    
    // Executa a criação do produto
    public Product Handle(CreateProductRequest request) // Metodo Handler 
    {

        var user = _userRepository.GetById(request.UserId);

        if (user == null)
        {
            throw new ArgumentException("Usuario não encontrado");
        }
         
        // Cria a entidade Product com um novo Id (Guid)
        var product = new Product( 
            request.Nome,
            request.Descricao,
            request.Preco,
            Guid.NewGuid()
        );
        
        // Salva no banco através do repositório
        _productRepository.Add(product);
        
        // Retorna o produto criado
        return product;
    }
}

