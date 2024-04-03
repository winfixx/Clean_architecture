using Microsoft.AspNetCore.Mvc;
using Onion_Architecture.Core.DomainModels;
using Onion_Architecture.Core.DomainRepositories.Dto;

namespace Onion_Architecture.Core.DomainRepositories
{
    public interface IUsersRepository
    {
        IEnumerable<User?> GetAll();
        User? GetById(int id);
        bool? GetByIdBool(int id);
        User Create(CreateUserDto userDto);
        User? Change(User user);
        User? Delete(User user);
    }
}
