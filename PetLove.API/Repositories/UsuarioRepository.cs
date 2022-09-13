using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System.Collections.Generic;
using System.Linq;

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
            contextoBanco.Usuario.Add(usuario);
            contextoBanco.SaveChanges();
            return usuario;
        }

        public ICollection<Usuario> ListarTodos()
        {
            return contextoBanco.Usuario.ToList();
        }
    }
}
