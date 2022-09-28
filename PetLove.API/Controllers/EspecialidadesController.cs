using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System.Data;

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

        /// <summary>
        /// Cadastra especialidades na aplicação
        /// </summary>
        /// <param name="especialidade">Dados da especialidade</param>
        /// <returns>Dados de especialidades cadastrados</returns>
        [HttpPost]
        [Authorize(Roles = "Desenvolvedor")]
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

        /// <summary>
        /// Lista todas as especialidades da aplicação
        /// </summary>
        /// <returns>Lista de especialidades</returns>
        [HttpGet]
        [Authorize(Roles = "Desenvolvedor, Medico, Paciente")]
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

        /// <summary>
        /// Busca uma especialidade pelo Id
        /// </summary>
        /// <param name="id">Id da especialidade</param>
        /// <returns>Dados da especialidade</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Desenvolvedor, Medico, Paciente")]
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

        /// <summary>
        /// Altera os dados de uma especialidade
        /// </summary>
        /// <param name="id">Id da especialidade</param>
        /// <param name="especialidade">Todas as informações da especialidade</param>
        /// <returns>Especialidade alterada</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Desenvolvedor")]
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

        /// <summary>
        /// Altera os dados parcial de uma especialidade
        /// </summary>
        /// <param name="id">Id da especialidade</param>
        /// <param name="patchEspecialidade">Dados da especialidade</param>
        /// <returns>Dados parciais da especialidade alterados</returns>
        [HttpPatch("{id}")]
        [Authorize(Roles = "Desenvolvedor")]
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

        /// <summary>
        /// Exclui uma especialidade da aplicação
        /// </summary>
        /// <param name="id">Id da especialidade</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Desenvolvedor")]
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

                return Ok(new
                {
                    msg = "Especialidade excluída com sucesso"
                });
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
