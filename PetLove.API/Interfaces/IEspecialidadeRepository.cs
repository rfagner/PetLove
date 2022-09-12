using PetLove.API.Models;
using System.Collections.Generic;

namespace PetLove.API.Interfaces
{
    public interface IEspecialidadeRepository
    {
        // CRUD

        // POST
        Especialidade Inserir(Especialidade especialidade);

        // GET
        ICollection<Especialidade> ListarTodos();
        Especialidade BuscarPorId(int id);

        // PUT
        void Alterar(Especialidade especialidade);

        // DELETE
        void Excluir(Especialidade especialidade);
    }
}
