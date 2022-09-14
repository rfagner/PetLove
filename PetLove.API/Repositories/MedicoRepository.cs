using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
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
            // Compara a base de dados atual do Medico e vê se tem modificações
            contextoBanco.Entry(medico).State = EntityState.Modified;
            contextoBanco.SaveChanges();
        }

        public void AlterarParcialmente(JsonPatchDocument patchMedico, Medico medico)
        {
            // Pega as alterações que mandar pelo patch e aplica no objeto
            patchMedico.ApplyTo(medico);

            // Compara a base de dados atual da Médico e vê se tem modificações
            contextoBanco.Entry(medico).State = EntityState.Modified;
            contextoBanco.SaveChanges();
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
