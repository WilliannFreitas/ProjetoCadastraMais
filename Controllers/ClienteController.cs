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

            if (CpfCnpjValidador.IsValid(Param.Cpf))
                return StatusCode((int)HttpStatusCode.NotAcceptable, $"O CPF digitado não é válido!");

            try
            {
                //atribuindo os valores de param para dentro do novo cliente instanciado.
                Cliente cliente = new Cliente();
                cliente.Nome = Param.Nome;
                cliente.Sobrenome = Param.Sobrenome;
                cliente.Telefone = Param.Telefone;
                cliente.DDD = Param.DDD;
                cliente.Cpf = Param.Cpf;
                cliente.Rg = Param.Rg;

                //atrinbuindo novo cliente. 
                if (Param.IdCliente <= 0)
                {
                    cliente.DataInclusao = DateTime.Now;
                    repos.Inserir(cliente);
                }
                //atrinbuindo alterações em um cliente existente.
                else
                {
                    cliente.DataAlteracao = DateTime.Now;
                    cliente.IdCliente = Param.IdCliente;
                    repos.Alterar(cliente);
                }

                //retornando cliente instanciado acima.
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
