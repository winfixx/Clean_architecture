using Microsoft.EntityFrameworkCore;
using Onion_Architecture.Core.DomainModels;
using Onion_Architecture.Core.DomainRepositories;
using Onion_Architecture.Core.DomainRepositories.Dto;
using Onion_Architecture.Infractructure.Db;

namespace Onion_Architecture.Infrastructure.Repositories
{
    public class SqlUsersRepository(PostgresContext dContext) : IUsersRepository
    {
        private readonly PostgresContext dbContext = dContext;

        public IEnumerable<User?> GetAll()
        {
            return dbContext.Users.ToList();
        }

        public User? GetById(int id)
        {
            return dContext.Users.FirstOrDefault(user => user.Id == id);
        }

        public bool? GetByIdBool(int id)
        {
            return dContext.Users.Any(u => u.Id ==id);
        }

        public User Create(CreateUserDto userDto)
        {
            var user = dContext.Users
                           .Add(new User { Email = userDto.Email, Name = userDto.Name })
                           .Entity;
            dContext.SaveChanges();

            return user;
        }

        public User Change(User userDto)
        {
            dContext.Users.Update(userDto);
            dContext.SaveChanges();

            return userDto;
        }

        public User Delete(User user)
        {
            dContext.Users.Remove(user);
            dContext.SaveChanges();

            return user;
        }
    }
}
