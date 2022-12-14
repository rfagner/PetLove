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
    public class PacientesController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IPacienteRepository repositorio;

        // Método construtor
        public PacientesController(IPacienteRepository _repositorio)
        {
            repositorio = _repositorio;
        }

        /// <summary>
        /// Cadastra pacientes na aplicação
        /// </summary>
        /// <param name="paciente">Dados de paciente</param>
        /// <returns>Dados do paciente cadastrado</returns>
        [HttpPost]
        [Authorize(Roles = "Desenvolvedor")]
        public IActionResult Cadastrar(Paciente paciente)
        {
            try
            {
                paciente.Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(paciente.Usuario.Senha);
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

        /// <summary>
        /// Lista todos os pacientes da aplicação
        /// </summary>
        /// <returns>Lista de pacientes</returns>
        [HttpGet]
        [Authorize(Roles = "Desenvolvedor, Paciente, Medico")]
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
        /// Busca um paciente pelo Id
        /// </summary>
        /// <param name="id">Id de paciente</param>
        /// <returns>Dados de paciente</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Desenvolvedor, Paciente, Medico")]
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

        /// <summary>
        /// Altera os dados de um paciente
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <param name="paciente">Todas as informações do paciente</param>
        /// <returns>Paciente alterado</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Desenvolvedor")]
        public IActionResult Alterar(int id, Paciente paciente)
        {
            try
            {
                // Verificar se o Id bate com o objeto 
                if (id != paciente.Id)
                {
                    return BadRequest(new { Message = "Dados não conferem" });
                }
                paciente.Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(paciente.Usuario.Senha);
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

        /// <summary>
        /// Altera os dados parcial de um paciente
        /// </summary>
        /// <param name="id">Id de paciente</param>
        /// <param name="patchPaciente">Dados de paciente</param>
        /// <returns>Dados parciais de paciente alterado</returns>
        [HttpPatch("{id}")]
        [Authorize(Roles = "Desenvolvedor")]
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
                paciente.Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(paciente.Usuario.Senha);
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

        /// <summary>
        /// Exclui um paciente da aplicação
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Desenvolvedor")]
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

                return Ok(new
                {
                    msg = "Paciente excluído com sucesso"
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
