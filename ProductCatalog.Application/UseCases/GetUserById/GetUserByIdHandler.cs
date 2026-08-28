using ProductCatalog.Application.Interfaces;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.UseCases.GetUserById;

public class GetUserByIdHandler
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User? Handle(Guid id)
    {
        return _userRepository.GetById(id);
    }
}