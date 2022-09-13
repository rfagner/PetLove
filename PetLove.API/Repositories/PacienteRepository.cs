using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }

        public Paciente BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(Paciente paciente)
        {
            throw new System.NotImplementedException();
        }

        public Paciente Inserir(Paciente paciente)
        {
            contextoBanco.Paciente.Add(paciente);
            contextoBanco.SaveChanges();
            return paciente;
        }

        public ICollection<Paciente> ListarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
