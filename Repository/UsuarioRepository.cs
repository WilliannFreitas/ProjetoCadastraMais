using System;
using System.Collections.Generic;
using System.Linq;
using WebApiTeste.Models;

namespace WebApiTeste.Repository
{
    public interface IUsuarioRepository
    {
        public bool Inserir(Usuario param);

        public List<Usuario> Consultar(Usuario usuario, bool EAlteracao = false);

    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CadastraMaisContext db;

        public UsuarioRepository(CadastraMaisContext _db)
        {
            db = _db;
        }
        public bool Inserir(Usuario usuario)
        {
            try
            {
                var usuario_db = new Usuario()
                {
                    Nome = usuario.Nome,
                    Sobrenome = usuario.Sobrenome,
                    Login = usuario.Login,
                    DataNascimento = usuario.DataNascimento
                };
                db.Add(usuario_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Usuario> Consultar(Usuario usuario, bool EAlteracao = false)
        {
            try
            {
                using (var context = db)
                {

                    //var teste = context.Clientes.Find(cliente.IdCliente);
                    var teste = context.Usuarios.ToList();

                    if (usuario.IdUsuario > 0)
                        teste = teste.Where(banco => banco.IdCliente == usuario.IdUsuario).ToList();
                    if (!EAlteracao)
                    {
                        if (!String.IsNullOrWhiteSpace(usuario.Nome))
                            teste = teste.Where(banco => banco.Nome.Contains(usuario.Nome)).ToList();

                        if (!String.IsNullOrWhiteSpace(usuario.Sobrenome))
                            teste = teste.Where(banco => banco.Sobrenome.Contains(usuario.Sobrenome)).ToList();
                    }




                    return teste;
                }

            }
            catch (Exception ex)
            {
                return new List<Usuario>();
            }
        }
    }
}
