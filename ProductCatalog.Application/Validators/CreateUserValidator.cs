using FluentValidation;
using ProductCatalog.Application.DTOs;

namespace ProductCatalog.Application.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        // Dizemos que a propriedade "Nome" do request
        // não pode ser vazia ou conter apenas espaços.
        RuleFor(x => x.Nome)
            .NotEmpty()
            
            // Mensagem retornada caso a regra seja violada.
            .WithMessage("O nome é obrigatorio");

        // Agora estamos criando uma regra para o "Email".
        RuleFor(x => x.Email)
            
            // O email não pode estar vazio.
            .NotEmpty()
            
            // Além de não estar vazio, precisa ter
            // um formato válido de email.
            .EmailAddress()
            
            // Mensagem caso alguma dessas regras falhe.
            .WithMessage("O email deve ser valido");
    }
}