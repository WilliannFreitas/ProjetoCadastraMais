using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;


namespace WebApiTeste.Models
{
    public class CadastraMaisContext : DbContext
    {
        internal object cliente;

        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

        //public DbContextOptions conection = GetOptions();

        public CadastraMaisContext(DbContextOptions<CadastraMaisContext> opcoes) : base(opcoes)
        {

        }
        ////    public CadastraMaisContext()
        ////    {
        ////        GetOptions();
        ////    }


        ////    public static DbContextOptions GetOptions()
        ////    {
        ////        string connectionString = Configuration.GetConnectionString("DefaultConnection");
        ////        return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        ////    }

        ////}
        //public CadastraMaisContext(string connectionString) : base(GetOptions(connectionString))
        //{
        //}

        //private static DbContextOptions GetOptions(string connectionString)
        //{
        //    return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        //}

    }

}


