using Microsoft.AspNetCore.JsonPatch;
using PetLove.API.Models;
using System.Collections.Generic;

namespace PetLove.API.Interfaces
{
    public interface IMedicoRepository
    {
        // CRUD

        // POST
        Medico Inserir(Medico medico);

        // GET
        ICollection<Medico> ListarTodos();
        Medico BuscarPorId(int id);

        // PUT
        void Alterar(Medico medico);

        // DELETE
        void Excluir(Medico medico);

        // PATCH
        void AlterarParcialmente(JsonPatchDocument patchMedico, Medico medico);
    }
}
