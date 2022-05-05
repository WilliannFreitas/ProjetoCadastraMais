using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;


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

        public CadastraMaisContext(DbContextOptions<CadastraMaisContext> opcoes) : base(opcoes)
        {

        }

    }

}


