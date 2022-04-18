using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApiTeste.Models;

namespace WebApiTeste.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;
        //private CadastraMaisContext db = GetOptions();

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult ConsultarUsuario(string Nome = "", string Sobrenome = "", string LogIn = "", string DataNascimento = "01/01/1900")
        {
            Usuario usuario = new Usuario();
            try
            {
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
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

            Usuario usuario = new Usuario();
            usuario.Nome = Param.Nome;
            usuario.Sobrenome = Param.Sobrenome;
            usuario.Login = Param.Login;
            usuario.DataNascimento = Param.DataNascimento;

            if (Param.IdUsuario <= 0)
            {
                usuario.DataInclusao = DateTime.Now;
            }
            else
            {
                usuario.DataAlteracao = DateTime.Now;
                usuario.IdUsuario = Param.IdUsuario;
            }

            try
            {
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }

    }
}
