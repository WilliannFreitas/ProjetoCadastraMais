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
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepository repos;

        public ClienteController(IClienteRepository _repos)
        {
            repos = _repos;
        }


        [HttpGet]
        public IActionResult ConsultarCliente([FromQuery] Cliente cliente)
        {

            try
            {
                var cliente_db = repos.Consultar(cliente);
                return Ok(cliente_db);
            }
            catch (Exception ex)
            {
                return Ok($" ERRO: {ex} - {ex.InnerException} ");
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

            try
            {

                Cliente cliente = new Cliente();
                cliente.Nome = Param.Nome;
                cliente.Sobrenome = Param.Sobrenome;
                cliente.Telefone = Param.Telefone;
                cliente.DDD = Param.DDD;
                cliente.Cpf = Param.Cpf;
                cliente.Rg = Param.Rg;

                if (Param.IdCliente <= 0)
                {
                    cliente.DataInclusao = DateTime.Now;
                    cliente.IdUsuarioInclusao = Param.IdUsuarioInclusao;
                    repos.Inserir(cliente);
                }
                else
                {
                    cliente.DataAlteracao = DateTime.Now;
                    cliente.IdCliente = Param.IdCliente;
                    cliente.IdUsuarioAlteracao = Param.IdUsuarioAlteracao;
                }


                //if (repos.Create(cliente));
               
                //return BadRequest();
            }
            catch (Exception ex)
            {
                //return StatusCode((int)HttpStatusCode.InternalServerError);
                return Ok($" ERRO: {ex} - {ex.InnerException} ");
            }
            return Ok();
        }
    }
}
