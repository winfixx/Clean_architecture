using System.Globalization;
using Onion_Architecture.Core.DomainModels;
using Onion_Architecture.Core.DomainRepositories;
using Onion_Architecture.Core.DomainRepositories.Dto;
using Onion_Architecture.Core.Exceptions;

namespace Onion_Architecture.Core.Services
{
    public class UsersService(IUsersRepository usersRepository)
    {
        private readonly IUsersRepository usersRepository = usersRepository;

        public async Task<IEnumerable<User?>> GetAll()
        {
            return await Task.Run(usersRepository.GetAll);
        }

        public async Task<User?> GetById(int id)
        {
            var user = await Task.Run(() => usersRepository.GetById(id));

            if (user != null) return user;

            throw new NotFoundException("User not found");
        }

        public async Task<User?> Create(CreateUserDto userDto)
        {
            return await Task.Run(() => usersRepository.Create(userDto));
        }

        public async Task<User?> Change(User user)
        {
            if (usersRepository.GetByIdBool(user.Id)!.Value)
                return await Task.Run(() => usersRepository.Change(user));

            throw new NotFoundException("User not found");
        }

        public async Task<User?> Delete(int id)
        {
            var user = await Task.Run(() => usersRepository.GetById(id));

            if (user != null)
                return await Task.Run(() => usersRepository.Delete(user));

            throw new NotFoundException("User not found");
        }
    }
}
