using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Interfaces;

public interface IUserRepository
{
    // Salva um usuário.
    void Add(User user);

    // Busca todos os usuários.
    List<User> GetAll();

    // Busca um usuário pelo ID.
    User? GetById(Guid id);

    // Busca um usuário pelo e-mail.
    User? GetByEmail(string email);
}