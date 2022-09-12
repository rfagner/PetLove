using PetLove.API.Models;
using System.Collections.Generic;

namespace PetLove.API.Interfaces
{
    public interface IPacienteRepository
    {
        // CRUD

        // POST
        Paciente Inserir(Paciente paciente);

        // GET
        ICollection<Paciente> ListarTodos();
        Paciente BuscarPorId(int id);

        // PUT
        void Alterar(Paciente paciente);

        // DELETE
        void Excluir(Paciente paciente);
    }
}
