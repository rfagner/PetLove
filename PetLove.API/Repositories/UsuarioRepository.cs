using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System.Collections.Generic;

namespace PetLove.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //Injeção de Dependência
        PetLoveContext contextoBanco;
        public UsuarioRepository(PetLoveContext _contextoBanco)
        {
            contextoBanco = _contextoBanco;
        }


        public void Alterar(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public Usuario Inserir(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Usuario> ListarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
