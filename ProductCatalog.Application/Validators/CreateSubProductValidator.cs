using FluentValidation;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Validators;

public class CreateSubProductValidator : AbstractValidator<CreateSubProductRequest>
{
    public CreateSubProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("O nome do subproduto é obrigatorio");
        
        // O preço adicional não pode ser negativo.
        // Zero é permitido.
        RuleFor(x => x.PrecoAdicional)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O preço adicional não pode ser negativo.");

        // O subproduto precisa estar vinculado a um produto.
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("O ProductId é obrigatório.");
    }
    
}