﻿using PetLove.API.Contexts;
using PetLove.API.Interfaces;
using PetLove.API.Models;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(TipoUsuario tipoUsuario)
        {
            throw new System.NotImplementedException();
        }

        public TipoUsuario Inserir(TipoUsuario tipoUsuario)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<TipoUsuario> ListarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}