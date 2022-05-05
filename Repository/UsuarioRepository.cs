using System;
using System.Collections.Generic;
using System.Linq;
using WebApiTeste.Models;

namespace WebApiTeste.Repository
{
    public interface IUsuarioRepository
    {
        public bool Inserir(Usuario param);
        public bool Alterar(Usuario param);

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
                db.Add(usuario);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Alterar(Usuario usuario)
        {
            try
            {
                db.Update(usuario);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Método para consultar no Banco de dados.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="EAlteracao"></param>
        /// <returns></returns>
        public List<Usuario> Consultar(Usuario usuario, bool EAlteracao = false)
        {
            try
            {
                using (var context = db)
                {

                    var teste = context.Usuarios.ToList();

                    if (usuario.IdUsuario > 0)
                        teste = teste.Where(banco => banco.IdUsuario == usuario.IdUsuario).ToList();
                    if (!EAlteracao)
                    {
                        if (!String.IsNullOrWhiteSpace(usuario.Nome))
                            teste = teste.Where(banco => banco.Nome.ToUpper().Contains(usuario.Nome.ToUpper())).ToList();

                        if (!String.IsNullOrWhiteSpace(usuario.Sobrenome))
                            teste = teste.Where(banco => banco.Sobrenome.ToUpper().Contains(usuario.Sobrenome.ToUpper())).ToList();
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
