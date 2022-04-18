using WebApiTeste.Models;

namespace WebApiTeste.Repository
{
    public interface IClienteRepository
    {
        public bool Create(Cliente param);

        //public Cliente Read(int id);
    }
    public class ClienteRepository : IClienteRepository
    {
        private readonly CadastraMaisContext db;

        public ClienteRepository(CadastraMaisContext _db)
        {
            db = _db;
        }
        public bool Create(Cliente cliente)
        {
            try
            {
                var cliente_db = new Cliente()
                {
                    Nome = cliente.Nome,
                    Sobrenome = cliente.Sobrenome,
                    DDD = cliente.DDD,
                    Telefone = cliente.Telefone,
                    Cpf = cliente.Cpf,
                    Rg = cliente.Rg
                };
                db.Add(cliente_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //public Cliente Read(int id)
        //{
        //    try
        //    {
        //        //var cliente_db = db.cliente.Find(id);
        //        //return cliente_db;
        //    }
        //    catch
        //    {
        //        return new Cliente();
        //    }
        //}
    }
}
