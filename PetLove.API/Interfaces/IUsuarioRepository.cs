using Microsoft.AspNetCore.JsonPatch;
using PetLove.API.Models;
using System.Collections.Generic;

namespace PetLove.API.Interfaces
{
    public interface IUsuarioRepository
    {
        // CRUD

        // POST
        Usuario Inserir(Usuario usuario);

        // GET
        ICollection<Usuario> ListarTodos();
        Usuario BuscarPorId(int id);

        // PUT
        void Alterar(Usuario usuario);

        // DELETE
        void Excluir(Usuario usuario);

        // PATCH
        void AlterarParcialmente(JsonPatchDocument patchUsuario, Usuario usuario);
    }
}
