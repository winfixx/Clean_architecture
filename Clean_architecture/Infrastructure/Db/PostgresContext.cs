using Microsoft.EntityFrameworkCore;
using Onion_Architecture.Core.DomainModels;

namespace Onion_Architecture.Infractructure.Db
{
    public sealed class PostgresContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public PostgresContext(DbContextOptions<PostgresContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
