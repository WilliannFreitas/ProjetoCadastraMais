using Microsoft.Extensions.Configuration;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApiTeste.Models
{
    public class CadastraMaisContext : DbContext
    {
        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var stringConexao = Configuration.GetConnectionString("DefaultConnection");
        }

    }

}
