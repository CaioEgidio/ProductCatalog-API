using ProductCatalog.Domain.Entities;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Application.DTOs;
using FluentValidation;

namespace ProductCatalog.Application.UseCases.CreateSubProduct;
 
public class CreateSubProductHandler
{
    private readonly ISubProductRepository _subProductRepository;
    private readonly IProductRepository _productRepository;
    private readonly IValidator<CreateSubProductRequest> _validator;

    public CreateSubProductHandler(
        ISubProductRepository subProductRepository,
        IProductRepository productRepository,
        IValidator<CreateSubProductRequest> validator)
    {
        _subProductRepository = subProductRepository;
        _productRepository = productRepository;
        _validator = validator;
    }


    public SubProduct Handle(CreateSubProductRequest request)
    {
        // Executa as regras do CreateSubProductValidator.
        var validationResult = _validator.Validate(request);
        
        // Verifica se alguma validação falhou.
        if (!validationResult.IsValid)
        {
            throw new ArgumentException(
                string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage))
            );
        }

        // Verifica se o produto existe no banco.
        var product = _productRepository.GetById(request.ProductId);

        if (product == null)
        {
            throw new ArgumentException("Produto não encontrado");
        }

        var subProduct = new SubProduct(request.Name,request.ProductId,request.PrecoAdicional);
        
        // Salva o subproduto no banco.
        _subProductRepository.Add(subProduct);

        // Retorna o subproduto criado.
        return subProduct;
    }
}