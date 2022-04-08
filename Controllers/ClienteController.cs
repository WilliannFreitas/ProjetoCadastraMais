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

            Cliente cliente = new Cliente();
            try
            {
                return Ok(cliente);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult InserirAlterarCliente(ClienteParam Param)
        {
            string campos = string.Empty;
            if (string.IsNullOrWhiteSpace(Param.Nome))
                campos += " Nome,";
            if (string.IsNullOrWhiteSpace(Param.Sobrenome))
                campos += " Sobrenome,";
            if (string.IsNullOrWhiteSpace(Param.DDD))
                campos += " DDD,";
            if (string.IsNullOrWhiteSpace(Param.Cpf))
                campos += " CPF,";
            if (string.IsNullOrWhiteSpace(Param.Rg))
                campos += " RG,";
            if (Param.DataNascimento < DateTime.Now.AddYears(-100))
                campos += " Data de Nascimento";

            if (!string.IsNullOrWhiteSpace(campos))
                return StatusCode((int)HttpStatusCode.NotAcceptable, $"O(s) campos(s){campos} são de preenchimento obrigatório!");

            Cliente cliente = new Cliente();
            cliente.Nome = Param.Nome;
            cliente.Sobrenome = Param.Sobrenome;
            cliente.DDD = Param.DDD;
            cliente.Cpf = Param.Cpf;
            cliente.Rg = Param.Rg;

            if (Param.IdCliente <= 0)
            {
                cliente.DataInclusao = DateTime.Now;
                cliente.IdUsuarioInclusao = Param.IdUsuarioInclusao;
            }
            else
            {
                cliente.DataAlteracao = DateTime.Now;
                cliente.IdCliente = Param.IdCliente;
                cliente.IdUsuarioAlteracao = Param.IdUsuarioAlteracao;
            }

            try
            {
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
