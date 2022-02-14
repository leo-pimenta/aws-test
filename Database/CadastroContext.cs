using aws_test.Domain;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace aws_test.Database
{
    public class CadastroContext : DbContext
    {
        private const string MIGRATIONS_ASSEMBLY_NAME = "Migrations";

        private readonly IConfiguration Configuration;
        private readonly IHostEnvironment Environment;

        public DbSet<Cadastro> Cadastros { get; set; }

        public CadastroContext(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            ConfigureMySql(options);
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            new Migration(model).Create();
        }

        private void ConfigureMySql(DbContextOptionsBuilder options)
        {
            string connectionString = Configuration["database:connectionString"];
            ServerVersion serverVersion = GetMySqlVersion();
            options.UseMySql(connectionString, serverVersion);
        }

        private ServerVersion GetMySqlVersion()
        {
            return Environment.IsDevelopment() 
                ? ServerVersion.Create(Version.Parse("8.0.28"), ServerType.MySql) 
                : ServerVersion.Create(Version.Parse("8.0.27"), ServerType.MariaDb);
        }
    }
}