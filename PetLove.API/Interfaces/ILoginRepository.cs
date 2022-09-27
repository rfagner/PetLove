using PetLove.API.Models;

namespace PetLove.API.Interfaces
{
    public interface ILoginRepository
    {
        Usuario Logar(string email, string senha);
    }
}
