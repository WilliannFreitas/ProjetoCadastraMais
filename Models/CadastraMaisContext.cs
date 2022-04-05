using Microsoft.Extensions.Configuration;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApiTeste.Models
{
    public class CadastraMaisContext : DbContext
    {
        //public CadastraMaisContext(DbContextOptions<CadastraMaisContext> options) : base(options)
        //{
        //}

        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConve‌​ntion>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var stringConexao = Configuration.GetConnectionString("DefaultConnection");

            //optionsBuilder.UseSqlServer(stringConexao);
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {

        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //.AddJsonFile("appsettings.json")
        //.Build();

        //var stringConexao = (configuration.GetConnectionString("DefaultConnection");

        //optionsBuilder.UseSqlServer(stringConexao);
        //    }
        //}

    }

}
