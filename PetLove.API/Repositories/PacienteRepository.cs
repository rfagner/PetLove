using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetLove.API.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        //Injeção de Dependência
        PetLoveContext contextoBanco;
        public PacienteRepository(PetLoveContext _contextoBanco)
        {
            contextoBanco = _contextoBanco;
        }


        public void Alterar(Paciente paciente)
        {
            // Compara a base de dados atual do Paciente e vê se tem modificações
            contextoBanco.Entry(paciente).State = EntityState.Modified;
            contextoBanco.SaveChanges();
        }

        public void AlterarParcialmente(JsonPatchDocument patchPaciente, Paciente paciente)
        {
            // Pega as alterações que mandar pelo patch e aplica no objeto
            patchPaciente.ApplyTo(paciente);

            // Compara a base de dados atual da Paciente e vê se tem modificações
            contextoBanco.Entry(paciente).State = EntityState.Modified;
            contextoBanco.SaveChanges();
        }

        public Paciente BuscarPorId(int id)
        {
            return contextoBanco.Paciente.Find(id);
        }

        public void Excluir(Paciente paciente)
        {
            contextoBanco.Paciente.Remove(paciente);
            contextoBanco.SaveChanges();
        }

        public Paciente Inserir(Paciente paciente)
        {
            contextoBanco.Paciente.Add(paciente);
            contextoBanco.SaveChanges();
            return paciente;
        }

        public ICollection<Paciente> ListarTodos()
        {
            return contextoBanco.Paciente.ToList();
        }
    }
}
