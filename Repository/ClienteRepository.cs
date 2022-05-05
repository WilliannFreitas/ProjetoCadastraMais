using System;
using System.Collections.Generic;
using System.Linq;
using WebApiTeste.Models;

namespace WebApiTeste.Repository
{
    public interface IClienteRepository
    {
        public bool Inserir(Cliente param);
        public bool Alterar(Cliente param);

        public List<Cliente> Consultar(Cliente cliente, bool EAlteracao = false);


    }
    public class ClienteRepository : IClienteRepository
    {
        private readonly CadastraMaisContext db;

        public ClienteRepository(CadastraMaisContext _db)
        {
            db = _db;
        }
        public bool Inserir(Cliente cliente)
        {
            try
            {
                db.Add(cliente);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Alterar(Cliente cliente)
        {
            try
            {
                db.Update(cliente);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Cliente> Consultar(Cliente cliente, bool EAlteracao = false)
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
                        teste = teste.Where(banco => banco.Nome.ToUpper().Contains(cliente.Nome.ToUpper())).ToList();

                    if (!String.IsNullOrWhiteSpace(cliente.Sobrenome))
                        teste = teste.Where(banco => banco.Sobrenome.ToUpper().Contains(cliente.Sobrenome.ToUpper())).ToList();



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
