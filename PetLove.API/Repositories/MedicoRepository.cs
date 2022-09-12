using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System.Collections.Generic;

namespace PetLove.API.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        //Injeção de Dependência
        PetLoveContext contextoBanco;
        public MedicoRepository(PetLoveContext _contextoBanco)
        {
            contextoBanco = _contextoBanco;
        }


        public void Alterar(Medico medico)
        {
            throw new System.NotImplementedException();
        }

        public Medico BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(Medico medico)
        {
            throw new System.NotImplementedException();
        }

        public Medico Inserir(Medico medico)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Medico> ListarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
