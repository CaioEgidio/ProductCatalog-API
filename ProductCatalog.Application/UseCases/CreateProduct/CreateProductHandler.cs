using FluentValidation;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Application.Validators;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.UseCases.CreateProduct;
 
// Caso de uso: criar um produto
public class CreateProductHandler
{
    
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly IValidator<CreateProductRequest> _validator;

    // Recebe o repositório via injeção de dependência
    public CreateProductHandler(IProductRepository productRepository, IUserRepository userRepository, IValidator<CreateProductRequest> validator)
    {
        _productRepository = productRepository;
        _userRepository = userRepository;
        _validator = validator;
    }
    
    // Executa a criação do produto
    public Product Handle(CreateProductRequest request) // Metodo Handler 
    {
        
        var validationResult =  _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new ArgumentException(string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
        }
        
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
            request.UserId
        );
        
        // Salva no banco através do repositório
        _productRepository.Add(product);
        
        // Retorna o produto criado
        return product;
    }
}

