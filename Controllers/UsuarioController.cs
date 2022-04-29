using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApiTeste.Models;
using WebApiTeste.Repository;

namespace WebApiTeste.Controllers
// Este código contém um passo a passo litertal para melhor entendimento de sua construção.
//API's de consulta e inclusão do banco de dados via Link.
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository repos;

        public UsuarioController(IUsuarioRepository _repos)
        {
            repos = _repos;
        }

        /// <summary>
        /// Método de consulta da API.
        /// </summary>
        /// <param name="usuario">objeto usuário</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ConsultarUsuario([FromQuery] Usuario usuario)
        {
            //setando no try e catch a variavel que recebe a consulta no banco de dados
            try
            {
                var usuario_db = repos.Consultar(usuario);
                return Ok(usuario_db);
            }
            catch (Exception ex)
            {
                return Ok($" ERRO: {ex} - {ex.InnerException} ");
            }

        }
        //Método de inclusão de usuário da API.
        [HttpPost]
        public IActionResult InserirAlterarUsuario(UsuarioParam Param)
        {
            // filtros de validação de preenchimento de campos de pesquisa.
            string campos = string.Empty;
            if (string.IsNullOrWhiteSpace(Param.Nome))
                campos += " Nome,";
            if (string.IsNullOrWhiteSpace(Param.Sobrenome))
                campos += " Sobrenome,";
            if (string.IsNullOrWhiteSpace(Param.Login))
                campos += " Login,";
            if (Param.DataNascimento < DateTime.Now.AddYears(-100))
                campos += " Data de Nascimento";

            if (!string.IsNullOrWhiteSpace(campos))
                return StatusCode((int)HttpStatusCode.NotAcceptable, $"O(s) campos(s){campos} são de preenchimento obrigatório!");
            //-------------------------------------------------------------

            try
            {
                //atribuindo os valores de param para dentro do novo usuario instanciado.
                Usuario usuario = new Usuario();
                usuario.Nome = Param.Nome;
                usuario.Sobrenome = Param.Sobrenome;
                usuario.Login = Param.Login;
                usuario.DataNascimento = Param.DataNascimento;

                //atrinbuindo novo usuario. 
                if (Param.IdUsuario <= 0)
                {
                    usuario.DataInclusao = DateTime.Now;
                    repos.Inserir(usuario);
                }
                //atrinbuindo alterações em um usuario existente.
                else
                {
                    usuario.DataAlteracao = DateTime.Now;
                    usuario.IdUsuario = Param.IdUsuario;
                    repos.Alterar(usuario);
                }

                //retornando usuario instanciado acima.
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }

    }
}
