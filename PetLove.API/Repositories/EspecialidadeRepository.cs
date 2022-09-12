using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System.Collections.Generic;

namespace PetLove.API.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        //Injeção de Dependência
        PetLoveContext contextoBanco;
        public EspecialidadeRepository(PetLoveContext _contextoBanco)
        {
            contextoBanco = _contextoBanco;
        }


        public void Alterar(Especialidade especialidade)
        {
            throw new System.NotImplementedException();
        }

        public Especialidade BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(Especialidade especialidade)
        {
            throw new System.NotImplementedException();
        }

        public Especialidade Inserir(Especialidade especialidade)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Especialidade> ListarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
