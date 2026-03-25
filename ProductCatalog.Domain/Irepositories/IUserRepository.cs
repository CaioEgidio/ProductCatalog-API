using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Irepositories;

public interface IUserRepository
{
    // Busca um usuário pelo ID (Pode retornar nulo se não achar")
    Task<User?> GetByIdAsync(Guid id);
    
    // Busca a lista de todos os usuários
    Task<IEnumerable<User>> GetAllAsync();

    // Salva um novo usuário no banco
    Task AddAsync(User user);
    
    // Busca um usuário pelo e-mail
    Task<User?> GetByEmailAsync(string email);
}