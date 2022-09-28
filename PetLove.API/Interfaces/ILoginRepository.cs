using PetLove.API.Models;

namespace PetLove.API.Interfaces
{
    public interface ILoginRepository
    {
        string Logar(string email, string senha);
    }
}
