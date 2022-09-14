using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
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
            // Compara a base de dados atual da Especialidade e vê se tem modificações
            contextoBanco.Entry(especialidade).State = EntityState.Modified;
            contextoBanco.SaveChanges();
        }

        public void AlterarParcialmente(JsonPatchDocument patchEspecialidade, Especialidade especialidade)
        {
            // Pega as alterações que mandar pelo patch e aplica no objeto
            patchEspecialidade.ApplyTo(especialidade);

            // Compara a base de dados atual da Especialidade e vê se tem modificações
            contextoBanco.Entry(especialidade).State = EntityState.Modified;
            contextoBanco.SaveChanges();
        }

        public Especialidade BuscarPorId(int id)
        {
            return contextoBanco.Especialidade.Find(id);
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
