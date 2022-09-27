using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System.Linq;

namespace PetLove.API.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        //Injeção de Dependência
        PetLoveContext contextoBanco;

        public LoginRepository(PetLoveContext _contextoBanco)
        {
            contextoBanco = _contextoBanco;
        }

        public Usuario Logar(string email, string senha)
        {
            //return contextoBanco.Usuarios.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            // Irá realizar uma pesquisa pelo email do usuário
            var usuario = contextoBanco.Usuario.FirstOrDefault(x => x.Email == email);

            if (usuario != null)
            {
                // Verifica se a senha que recebe por parâmetro é a mesma senha que está no banco
                bool validPassword = BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);
                if (validPassword)
                    return usuario;
            }

            return null;
        }
    }
}
