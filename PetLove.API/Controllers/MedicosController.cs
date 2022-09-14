using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PetLove.API.Interfaces;
using PetLove.API.Models;

namespace PetLove.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IMedicoRepository repositorio;

        // Método construtor
        public MedicosController(IMedicoRepository _repositorio)
        {
            repositorio = _repositorio;
        }

        [HttpPost]
        public IActionResult Cadastrar(Medico medico)
        {
            try
            {
                var retorno = repositorio.Inserir(medico);
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
        public IActionResult MedicoPorId(int id)
        {
            try
            {
                var retorno = repositorio.BuscarPorId(id);
                if(retorno == null)
                {
                    return NotFound(new {Message = "Médico não encontrado"});
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
        public IActionResult Alterar(int id, Medico medico)
        {
            try
            {
                // Verificar se o Id bate com o objeto 
                if (id != medico.Id)
                {
                    return BadRequest(new { Message = "Dados não conferem" });
                }

                // Verificar se Id existe no banco
                var retorno = repositorio.BuscarPorId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = "Médico não encontrado" });
                }

                // Altera efetivamente o objeto medico
                repositorio.Alterar(medico);

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
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchMedico)
        {
            try
            {
                if (patchMedico == null)
                {
                    return BadRequest();
                }

                // Temos que buscar o objeto
                var medico = repositorio.BuscarPorId(id);
                if (medico == null)
                {
                    return NotFound(new { Message = "Médico não encontrado" });
                }

                repositorio.AlterarParcialmente(patchMedico, medico);

                return Ok(medico);
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
                var medico = repositorio.BuscarPorId(id);
                if (medico == null)
                {
                    return NotFound(new { Message = "Médico não encontrado" });
                }

                repositorio.Excluir(medico);

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
