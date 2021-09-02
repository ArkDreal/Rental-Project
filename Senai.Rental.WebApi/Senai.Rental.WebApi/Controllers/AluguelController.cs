using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
            private IAluguelRepository _aluguelRepository { get; set; }

            [HttpGet]
            public IActionResult Get()
            {
                List<AluguelDomain> listaAluguels = _aluguelRepository.ListarTodos();

                return Ok(listaAluguels);

            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                AluguelDomain AluguelBuscado = _aluguelRepository.BuscarPorId(id);

                if (AluguelBuscado == null)
                {
                    return NotFound("Nenhum aluguel encontrado!");
                }

                return Ok(AluguelBuscado);
            }


            [HttpPost]
            public IActionResult Post(AluguelDomain novoAluguel)
            {

                _aluguelRepository.Cadastrar(novoAluguel);

                return StatusCode(201);
            }

            [HttpPut("{id}")]
            public IActionResult PutIdUrl(int id, AluguelDomain AluguelAtualizado)
            {
                AluguelDomain AluguelBuscado = _aluguelRepository.BuscarPorId(id);

                if (AluguelBuscado == null)
                {
                    return NotFound(
                            new
                            {
                                mensagem = "Aluguel não encontrado!",
                                erro = true
                            }
                        );
                }

                try
                {
                    _aluguelRepository.AtualizarIdUrl(id, AluguelAtualizado);

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

                _aluguelRepository.Deletar(id);

                return NoContent();
            }
        }
}
