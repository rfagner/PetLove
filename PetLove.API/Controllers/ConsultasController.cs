using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PetLove.API.Interfaces;
using PetLove.API.Models;

namespace PetLove.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IConsultaRepository repositorio;

        // Método construtor
        public ConsultasController(IConsultaRepository _repositorio)
        {
            repositorio = _repositorio;
        }

        [HttpPost]
        public IActionResult Cadastrar(Consulta consulta)
        {
            try
            {
                var retorno = repositorio.Inserir(consulta);
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
        public IActionResult BuscarConsultasPorId(int id)
        {
            try
            {
                var retorno = repositorio.BuscarPorId(id);
                if(retorno == null)
                {
                    return NotFound(new {Message = "Consulta não encontrada"});
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
        public IActionResult Alterar(int id, Consulta consulta)
        {
            try
            {
                // Verificar se o Id bate com o objeto 
                if(id != consulta.Id)
                {
                    return BadRequest(new {Message = "Dados não conferem"});
                }

                // Verificar se Id existe no banco
                var retorno = repositorio.BuscarPorId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = "Consulta não encontrada" });
                }

                // Altera efetivamente a consulta
                repositorio.Alterar(consulta);

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
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchConsulta)
        {
            try
            {
                if(patchConsulta == null)
                {
                    return BadRequest();
                }

                // Temos que buscar o objeto
                var consulta = repositorio.BuscarPorId(id);
                if(consulta == null)
                {
                    return NotFound(new { Message = "Consulta não encontrada" });
                }

                repositorio.AlterarParcialmente(patchConsulta, consulta);

                return Ok(consulta);
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
