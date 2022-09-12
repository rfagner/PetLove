using PetLove.API.Models;
using System.Collections.Generic;

namespace PetLove.API.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        // CRUD

        // POST
        TipoUsuario Inserir(TipoUsuario tipoUsuario);

        // GET
        ICollection<TipoUsuario> ListarTodos();
        TipoUsuario BuscarPorId(int id);

        // PUT
        void Alterar(TipoUsuario tipoUsuario);

        // DELETE
        void Excluir(TipoUsuario tipoUsuario);
    }
}
