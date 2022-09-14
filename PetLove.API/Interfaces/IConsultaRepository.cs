using Microsoft.AspNetCore.JsonPatch;
using PetLove.API.Models;
using System.Collections.Generic;

namespace PetLove.API.Interfaces
{
    public interface IConsultaRepository
    {
        // CRUD

        // POST
        Consulta Inserir(Consulta consulta);

        // GET
        ICollection<Consulta> ListarTodos();
        Consulta BuscarPorId(int id);

        // PUT
        void Alterar(Consulta consulta);

        // DELETE
        void Excluir(Consulta consulta);

        // PATCH
        void AlterarParcialmente(JsonPatchDocument patchConsulta, Consulta consulta);
    }
}
