using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PetLove.API.Interfaces;
using PetLove.API.Models;

namespace PetLove.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IPacienteRepository repositorio;

        // Método construtor
        public PacientesController(IPacienteRepository _repositorio)
        {
            repositorio = _repositorio;
        }

        [HttpPost]
        public IActionResult Cadastrar(Paciente paciente)
        {
            try
            {
                var retorno = repositorio.Inserir(paciente);
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var retorno = repositorio.ListarTodos();
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPacientesPorId(int id)
        {
            try
            {
                var retorno = repositorio.BuscarPorId(id);
                if(retorno == null)
                {
                    return NotFound(new {Message = "Paciente não encontrado"});                    
                }

                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Paciente paciente)
        {
            try
            {
                // Verificar se o Id bate com o objeto 
                if (id != paciente.Id)
                {
                    return BadRequest(new { Message = "Dados não conferem" });
                }

                // Verificar se Id existe no banco
                var retorno = repositorio.BuscarPorId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = "Paciente não encontrado" });
                }

                // Altera efetivamente o paciente
                repositorio.Alterar(paciente);

                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchPaciente)
        {
            try
            {
                if (patchPaciente == null)
                {
                    return BadRequest();
                }

                // Temos que buscar o objeto
                var paciente = repositorio.BuscarPorId(id);
                if (paciente == null)
                {
                    return NotFound(new { Message = "Paciente não encontrado" });
                }

                repositorio.AlterarParcialmente(patchPaciente, paciente);

                return Ok(paciente);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                // Temos que buscar o objeto
                var paciente = repositorio.BuscarPorId(id);
                if (paciente == null)
                {
                    return NotFound(new { Message = "Paciente não encontrado" });
                }

                repositorio.Excluir(paciente);

                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }
    }
}
