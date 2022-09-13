using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System.Collections.Generic;
using System.Linq;

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
            contextoBanco.Especialidade.Add(especialidade);
            contextoBanco.SaveChanges();
            return especialidade;
        }

        public ICollection<Especialidade> ListarTodos()
        {
            return contextoBanco.Especialidade.ToList();
        }
    }
}
