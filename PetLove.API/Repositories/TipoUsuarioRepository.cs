﻿using Microsoft.EntityFrameworkCore;
using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetLove.API.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        //Injeção de Dependência
        PetLoveContext contextoBanco;
        public TipoUsuarioRepository(PetLoveContext _contextoBanco)
        {
            contextoBanco = _contextoBanco;
        }


        public void Alterar(TipoUsuario tipoUsuario)
        {
            // Compara a base de dados atual do Tipo Usuário e vê se tem modificações
            contextoBanco.Entry(tipoUsuario).State = EntityState.Modified;
            contextoBanco.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
           return contextoBanco.TipoUsuario.Find(id);
        }

        public void Excluir(TipoUsuario tipoUsuario)
        {
            throw new System.NotImplementedException();
        }

        public TipoUsuario Inserir(TipoUsuario tipoUsuario)
        {
            contextoBanco.TipoUsuario.Add(tipoUsuario);
            contextoBanco.SaveChanges();
            return tipoUsuario;
        }

        public ICollection<TipoUsuario> ListarTodos()
        {
            return contextoBanco.TipoUsuario.ToList();
        }
    }
}
