using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.UseCases.CreateUser;

public class CreateUserHandler
{
   private readonly IUserRepository _userRepository;
   
   // Recebe o repositório pela injeção de dependência.
   public CreateUserHandler(IUserRepository userRepository)
   {
      _userRepository = userRepository;
   }
   
   //Executa criação do usuario.
   public User Handle(CreateUserRequest request)
   {
      //Procura se ja existe alguem com esse email
      var existingUser = _userRepository.GetByEmail(request.Email);

      if (existingUser is not null) 
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

