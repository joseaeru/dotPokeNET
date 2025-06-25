using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Context
{
    public class DotPokeNETContext : DbContext
    {
        public DbSet<EntityPokeAPI> PokeAPI { get; set; }
        public DbSet<EntityResource> Resource { get; set; }


        public DotPokeNETContext()
        {

        }

        public DotPokeNETContext(DbContextOptions<DotPokeNETContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityResource>(b =>
            {
                b.HasIndex(u => u.Code).IsUnique();//Ensure Code is unique
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"
                Server={ServerAddress};
                Database={DataBaseName};
                User Id={UserName};
                Password={UserPassword};
                TrustServerCertificate=True";

            if (!optionsBuilder.IsConfigured)
            {
                connectionString = connectionString
                    .Replace("{ServerAddress}", ConnectionStringData.SERVER_ADDRESS)
                    .Replace("{DataBaseName}", ConnectionStringData.DATA_BASE_NAME)
                    .Replace("{UserName}", ConnectionStringData.USER_NAME)
                    .Replace("{UserPassword}", ConnectionStringData.USER_PASSWORD);

                optionsBuilder.UseSqlServer($"Server={ConnectionStringData.SERVER_ADDRESS};Database={ConnectionStringData.DATA_BASE_NAME};User Id={ConnectionStringData.USER_NAME};Password={ConnectionStringData.USER_PASSWORD};TrustServerCertificate=True;");
            }
        }

        private static class ConnectionStringData
        {
            public const string SERVER_ADDRESS = "AORUS";
            public const string DATA_BASE_NAME = "DOT_POKE_NET";
            public const string USER_NAME = "sa";
            public const string USER_PASSWORD = "041008";
        }

    }
}
