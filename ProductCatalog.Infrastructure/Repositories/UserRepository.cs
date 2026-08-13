using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Infrastructure.Persistence;
   
namespace ProductCatalog.Infrastructure.Repositories;

public class UserRepository : IUserRepository // : implementa ou herda 
{
    private readonly AppDbContext _context;
    
    //injeçao de dependencia,Constructor Injection
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    //Salva um usuario no banco
    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    //Busca todos os usuarios 
    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }
    // Busca um usuário pelo ID.
    public User? GetById(Guid id)
    {
        return _context.Users.FirstOrDefault(user => user.Id == id);
    }
    // Busca um usuário pelo email.
    public User? GetByEmail(string email)
    {
        return _context.Users.FirstOrDefault(user => user.Email == email);
    }
}