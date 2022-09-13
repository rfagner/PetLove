using Microsoft.EntityFrameworkCore.Diagnostics;
using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }

        public Consulta BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(Consulta consulta)
        {
            throw new System.NotImplementedException();
        }

        public Consulta Inserir(Consulta consulta)
        {
            contextoBanco.Consulta.Add(consulta);
            contextoBanco.SaveChanges();
            return consulta;
        }

        public ICollection<Consulta> ListarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
