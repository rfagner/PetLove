using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetLove.API.Interfaces;
using System.Data;

namespace PetLove.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository repo;

        public LoginController(ILoginRepository _repo)
        {
            repo = _repo;
        }
        /// <summary>
        /// Permite o acesso do usuário na aplicação
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Usuário logado na aplicação</returns>
        [HttpPost]        
        public IActionResult Logar(string email, string senha)
        {
            var logar = repo.Logar(email, senha);
            if (logar == null)
                return Unauthorized();

            return Ok(new { token = logar });
        }
    }
}
