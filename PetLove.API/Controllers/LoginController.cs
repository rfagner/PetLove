using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetLove.API.Interfaces;

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

        [HttpPost]
        public IActionResult Logar(string email, string senha)
        {
            var logar = repo.Logar(email, senha);
            if (logar == null)
                return Unauthorized();
            return Ok(logar);
        }
    }
}
