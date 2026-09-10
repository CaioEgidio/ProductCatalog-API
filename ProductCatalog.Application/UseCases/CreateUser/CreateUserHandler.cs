using System.ComponentModel.DataAnnotations;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;
using FluentValidation; 
using System.Linq;

namespace ProductCatalog.Application.UseCases.CreateUser;

public class CreateUserHandler
{
   private readonly IUserRepository _userRepository;
   private readonly IValidator<CreateUserRequest> _validator;
   
   // Recebe o repositório pela injeção de dependência.
   public CreateUserHandler(IUserRepository userRepository, IValidator<CreateUserRequest> validator)
   {
      _userRepository = userRepository;
      _validator = validator;
   }
    
   //Executa criação do usuario.
   public User Handle(CreateUserRequest request)
   {
      
      var validationResult = _validator.Validate(request);
      
      if (!validationResult.IsValid)
      {
         throw new ArgumentException(string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
      }
      
      //Procura se ja existe alguem com esse email
      var existingUser = _userRepository.GetByEmail(request.Email);

      if (existingUser  != null) 
      {
         throw new ArgumentException("Este email já está cadastrado.");
      }
      
      //Cria a entidade user 
      var user = new User(request.Nome, request.Email);
      
      //Salva o usuario no banco.
      _userRepository.Add(user);
      
      //Devolve o usuario criado.
      return user; 
   }
}

