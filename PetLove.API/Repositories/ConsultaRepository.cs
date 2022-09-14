using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetLove.API.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        //Injeção de Dependência
        PetLoveContext contextoBanco;
        public ConsultaRepository(PetLoveContext _contextoBanco)
        {
            contextoBanco = _contextoBanco;
        }


        public void Alterar(Consulta consulta)
        {
            // Compara a base de dados atual da Consulta e vê se tem modificações
            contextoBanco.Entry(consulta).State = EntityState.Modified;
            contextoBanco.SaveChanges();
        }

        public void AlterarParcialmente(JsonPatchDocument patchConsulta, Consulta consulta)
        {
            // Pega as alterações que mandar pelo patch e aplica no objeto
            patchConsulta.ApplyTo(consulta);

            // Compara a base de dados atual da Consulta e vê se tem modificações
            contextoBanco.Entry(consulta).State = EntityState.Modified;
            contextoBanco.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            return contextoBanco.Consulta.Find(id);
        }

        public void Excluir(Consulta consulta)
        {
            contextoBanco.Consulta.Remove(consulta);
            contextoBanco.SaveChanges();
        }

        public Consulta Inserir(Consulta consulta)
        {
            contextoBanco.Consulta.Add(consulta);
            contextoBanco.SaveChanges();
            return consulta;
        }

        public ICollection<Consulta> ListarTodos()
        {
            return contextoBanco.Consulta.ToList();
        }
    }
}
