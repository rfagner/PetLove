using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PetLove.API.Interfaces;
using PetLove.API.Models;

namespace PetLove.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly ITipoUsuarioRepository repositorio;

        // Método construtor
        public TipoUsuariosController(ITipoUsuarioRepository _repositorio)
        {
            repositorio = _repositorio;
        }

        /// <summary>
        /// Cadastra TipoUsuario na aplicação
        /// </summary>
        /// <param name="tipoUsuario">Id do TipoUsuario</param>
        /// <returns>Dados do TipoUsuario cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                var retorno = repositorio.Inserir(tipoUsuario);
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
        /// Lista todos os TipoUsuario da aplicação
        /// </summary>
        /// <returns>Lista de TipoUsuario</returns>
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

        /// <summary>
        /// Busca um TipoUsuario pelo Id
        /// </summary>
        /// <param name="id">Id do TipoUsuario</param>
        /// <returns>Dados do TipoUsuario</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarTipoUsuarioPorId(int id)
        {
            try
            {
                var retorno = repositorio.BuscarPorId(id);
                if(retorno == null)
                {
                    return NotFound(new {Message = "Tipo usuário não encontrado"});
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
        /// Altera os dados de um TipoUsuario
        /// </summary>
        /// <param name="id">Id do TipoUsuario</param>
        /// <param name="tipoUsuario">Todas as informações do TipoUsuario</param>
        /// <returns>TipoUsuario alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, TipoUsuario tipoUsuario)
        {
            try
            {
                // Verificar se o Id bate com o objeto 
                if (id != tipoUsuario.Id)
                {
                    return BadRequest(new { Message = "Dados não conferem" });
                }

                // Verificar se Id existe no banco
                var retorno = repositorio.BuscarPorId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = "Tipo Usuário não encontrado" });
                }

                // Altera efetivamente o Tipo Usuário
                repositorio.Alterar(tipoUsuario);

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
        /// Altera os dados parcial de um TipoUsuario
        /// </summary>
        /// <param name="id">Id de TipoUsuario</param>
        /// <param name="patchTipoUsuario">Dados de TipoUsuario</param>
        /// <returns>Dados parciais do TipoUsuario alterado</returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchTipoUsuario)
        {
            try
            {
                if (patchTipoUsuario == null)
                {
                    return BadRequest();
                }

                // Temos que buscar o objeto
                var tipoUsuario = repositorio.BuscarPorId(id);
                if (tipoUsuario == null)
                {
                    return NotFound(new { Message = "Tipo Usuário não encontrado" });
                }

                repositorio.AlterarParcialmente(patchTipoUsuario, tipoUsuario);

                return Ok(tipoUsuario);
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
        /// Exclui um TipoUsuario da aplicação
        /// </summary>
        /// <param name="id">Id do TipoUsuario</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                // Temos que buscar o objeto
                var tipoUsuario = repositorio.BuscarPorId(id);
                if (tipoUsuario == null)
                {
                    return NotFound(new { Message = "Tipo Usuário não encontrado" });
                }

                repositorio.Excluir(tipoUsuario);

                return Ok(new
                {
                    msg = "TipoUsuario excluído com sucesso"
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
