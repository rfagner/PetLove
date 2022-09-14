using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PetLove.API.Interfaces;
using PetLove.API.Models;

namespace PetLove.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IEspecialidadeRepository repositorio;

        // Método construtor
        public EspecialidadesController(IEspecialidadeRepository _repositorio)
        {
            repositorio = _repositorio;
        }

        [HttpPost]
        public IActionResult Cadastrar(Especialidade especialidade)
        {
            try
            {
                var retorno = repositorio.Inserir(especialidade);
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
        public IActionResult BuscarEspecialidadePorId(int id)
        {
            try
            {
                var retorno = repositorio.BuscarPorId(id);
                if(retorno == null)
                {
                    return NotFound(new {Message = "Especialidade não encontrada"});
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
        public IActionResult Alterar(int id, Especialidade especialidade)
        {
            try
            {
                // Verificar se o Id bate com o objeto 
                if (id != especialidade.Id)
                {
                    return BadRequest(new { Message = "Dados não conferem" });
                }

                // Verificar se Id existe no banco
                var retorno = repositorio.BuscarPorId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = "Especialidade não encontrada" });
                }

                // Altera efetivamente a especialidade
                repositorio.Alterar(especialidade);

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
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchEspecialidade)
        {
            try
            {
                if (patchEspecialidade == null)
                {
                    return BadRequest();
                }

                // Temos que buscar o objeto
                var especialidade = repositorio.BuscarPorId(id);
                if (especialidade == null)
                {
                    return NotFound(new { Message = "Especialidade não encontrada" });
                }

                repositorio.AlterarParcialmente(patchEspecialidade, especialidade);

                return Ok(especialidade);
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
                var especialidade = repositorio.BuscarPorId(id);
                if (especialidade == null)
                {
                    return NotFound(new { Message = "Especialidade não encontrada" });
                }

                repositorio.Excluir(especialidade);

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
