using FluentValidation;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
      RuleFor(x => x.Nome)
          .NotEmpty()
          .WithMessage("O nome do produto é obrigatorio");

      RuleFor(x => x.Preco)
          .GreaterThan(0)
          .WithMessage("O preço dever ser maior que zero");
      
      RuleFor(x => x.UserId)
          .NotEmpty()
          .WithMessage("O UserId é obrigatorio");
    }
}

