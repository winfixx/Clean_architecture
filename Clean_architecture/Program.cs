using Microsoft.EntityFrameworkCore;
using Onion_Architecture.Core.DomainRepositories;
using Onion_Architecture.Core.Services;
using Onion_Architecture.Infractructure.Db;
using Onion_Architecture.Infrastructure.Repositories;

namespace Onion_Architecture
{
    public class Program
    {
        public static void Main()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<UsersService>();
            builder.Services.AddTransient<IUsersRepository, SqlUsersRepository>();

            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddNpgsql<PostgresContext>(connection);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
