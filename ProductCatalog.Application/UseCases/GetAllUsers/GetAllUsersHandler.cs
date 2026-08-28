using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;


namespace ProductCatalog.Application.UseCases.GetAllUsers;

public class GetAllUsersHandler
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> Handle()
    {
        return _userRepository.GetAll();
    }
}