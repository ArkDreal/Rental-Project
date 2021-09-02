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
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private IVeiculoRepository _veiculoRepository { get; set; }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaVeiculos = _veiculoRepository.ListarTodos();

            return Ok(listaVeiculos);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculoDomain VeiculoBuscado = _veiculoRepository.BuscarPorId(id);

            if (VeiculoBuscado == null)
            {
                return NotFound("Nenhum veiculo encontrado!");
            }

            return Ok(VeiculoBuscado);
        }


        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {

            _veiculoRepository.Cadastrar(novoVeiculo);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, VeiculoDomain VeiculoAtualizado)
        {
            VeiculoDomain VeiculoBuscado = _veiculoRepository.BuscarPorId(id);

            if (VeiculoBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Veiculo não encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                _veiculoRepository.AtualizarIdUrl(id, VeiculoAtualizado);

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

            _veiculoRepository.Deletar(id);

            return NoContent();
        }
    }
}
