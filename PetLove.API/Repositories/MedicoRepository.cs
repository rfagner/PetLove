using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System.Collections.Generic;
using System.Linq;

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
            return contextoBanco.Medico.Find(id);
        }

        public void Excluir(Medico medico)
        {
            throw new System.NotImplementedException();
        }

        public Medico Inserir(Medico medico)
        {
            contextoBanco.Medico.Add(medico);
            contextoBanco.SaveChanges();
            return medico;
        }

        public ICollection<Medico> ListarTodos()
        {
            return contextoBanco.Medico.ToList();
        }
    }
}
