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

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult ConsultarUsuario(string Nome = "", string Sobrenome = "", string LogIn = "", string DataNascimento = "01/01/1900")
        {
            Usuario teste = new Usuario();
            try
            {
                return Ok(teste);
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult InserirAlterarUsuario(ClienteParam Param)
        {
            try
            {  
                return Ok("testeRetorno");
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }

    }
}
