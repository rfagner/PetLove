using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PetLove.API.Interfaces;
using PetLove.API.Models;

namespace PetLove.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IUsuarioRepository repositorio;

        // Método construtor
        public UsuariosController(IUsuarioRepository _repositorio)
        {
            repositorio = _repositorio;
        }

        /// <summary>
        /// Cadastra usuários na aplicação
        /// </summary>
        /// <param name="usuario">Id do usuário</param>
        /// <returns>Dados do usuário cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                
                var retorno = repositorio.Inserir(usuario);
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
        /// Lista todos os usuários da aplicação
        /// </summary>
        /// <returns>Lista de usuários</returns>
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
        /// Busca um usuário pelo Id
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns>Dados do usuário</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarUsuarioPorId(int id)
        {
            try
            {
                var retorno = repositorio.BuscarPorId(id);
                if(retorno == null)
                {
                    return NotFound(new {Message = "Usuário não encontrado"});
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
        /// Altera os dados de um usuário
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <param name="usuario">Todas as informações do usuário</param>
        /// <returns>Usuário alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Usuario usuario)
        {
            try
            {
                // Verificar se o Id bate com o objeto 
                if (id != usuario.Id)
                {
                    return BadRequest(new { Message = "Dados não conferem" });
                }

                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

                // Verificar se Id existe no banco
                var retorno = repositorio.BuscarPorId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = "Usuário não encontrado" });
                }

                // Altera efetivamente o usuário
                repositorio.Alterar(usuario);

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
        /// Altera os dados parcial de um usuário
        /// </summary>
        /// <param name="id">Id de usuário</param>
        /// <param name="patchUsuario">Dados de usuário</param>
        /// <returns>Dados parciais do usuário alterado</returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchUsuario)
        {
            try
            {
                if (patchUsuario == null)
                {
                    return BadRequest();
                }

                // Temos que buscar o objeto
                var usuario = repositorio.BuscarPorId(id);
                if (usuario == null)
                {
                    return NotFound(new { Message = "Usuário não encontrado" });
                }

                repositorio.AlterarParcialmente(patchUsuario, usuario);

                return Ok(usuario);
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
        /// Exclui um usuário da aplicação
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                // Temos que buscar o objeto
                var usuario = repositorio.BuscarPorId(id);
                if (usuario == null)
                {
                    return NotFound(new { Message = "Usuário não encontrado" });
                }

                repositorio.Excluir(usuario);

                return Ok(new
                {
                    msg = "Usuário excluído com sucesso"
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
