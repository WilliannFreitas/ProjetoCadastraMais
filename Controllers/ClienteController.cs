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
    public class ClienteController : ControllerBase
    {

        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult ConsultarCliente(string Nome = "", string Sobrenome = "", string DDD = "", string Telefone = "", string Cpf = "", string Rg = "")
        {
            try
            {
                return Ok("testeRetorno");
            }
            catch(Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult InserirAlterarCliente(ClienteParam Param)
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
