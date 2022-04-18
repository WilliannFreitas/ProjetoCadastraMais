using System;
using System.Collections.Generic;
using System.Linq;
using WebApiTeste.Models;

namespace WebApiTeste.Repository
{
    public interface IClienteRepository
    {
        public bool Create(Cliente param);

        public List<Cliente> Read(Cliente cliente);


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

        public List<Cliente> Read(Cliente cliente)
        {
            try
            {
                using (var context = db)
                {

                    //var teste = context.Clientes.Find(cliente.IdCliente);
                    var teste = context.Clientes.ToList();

                    if (cliente.IdCliente > 0)
                        teste = teste.Where(banco => banco.IdCliente == cliente.IdCliente).ToList();

                    if (!String.IsNullOrWhiteSpace(cliente.Nome))
                        teste = teste.Where(banco => banco.Nome.Contains(cliente.Nome)).ToList();

                    if (!String.IsNullOrWhiteSpace(cliente.Sobrenome))
                        teste = teste.Where(banco => banco.Sobrenome.Contains(cliente.Sobrenome)).ToList();



                    return teste;
                }

            }
            catch (Exception ex)
            {
                return new List<Cliente>();
            }
        }
    }
}
