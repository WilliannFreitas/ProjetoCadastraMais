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
        public IActionResult ConsultarCliente()
        {
            try
            {
                //Cliente teste = new Cliente();

                //return Ok(teste);
                return Ok("testeRetorno");
            }
            catch
            {

                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            /*
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Cliente
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();*/
        }
    }
}
