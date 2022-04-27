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

        [HttpGet]
        public IActionResult ConsultarUsuario([FromQuery] Usuario usuario)
        {
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

        [HttpPost]
        public IActionResult InserirAlterarUsuario(UsuarioParam Param)
        {

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

            try
            {
                Usuario usuario = new Usuario();
                usuario.Nome = Param.Nome;
                usuario.Sobrenome = Param.Sobrenome;
                usuario.Login = Param.Login;
                usuario.DataNascimento = Param.DataNascimento;

                if (Param.IdUsuario <= 0)
                {
                    usuario.DataInclusao = DateTime.Now;
                    repos.Inserir(usuario);
                }
                else
                {
                    usuario.DataAlteracao = DateTime.Now;
                    usuario.IdUsuario = Param.IdUsuario;
                    repos.Alterar(usuario);
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }

    }
}
