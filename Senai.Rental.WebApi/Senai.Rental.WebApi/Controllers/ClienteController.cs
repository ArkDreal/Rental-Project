using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository { get; set; }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> listaClientes = _clienteRepository.ListarTodos();

            return Ok(listaClientes);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClienteDomain ClienteBuscado = _clienteRepository.BuscarPorId(id);

            if (ClienteBuscado == null)
            {
                return NotFound("Nenhum cliente encontrado!");
            }

            return Ok(ClienteBuscado);
        }


        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {

            _clienteRepository.Cadastrar(novoCliente);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, ClienteDomain ClienteAtualizado)
        {
            ClienteDomain ClienteBuscado = _clienteRepository.BuscarPorId(id);

            if (ClienteBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Cliente não encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                _clienteRepository.AtualizarIdUrl(id, ClienteAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {

            _clienteRepository.Deletar(id);

            return NoContent();
        }
    }
}
