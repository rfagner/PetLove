using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
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

        public void AlterarParcialmente(JsonPatchDocument patchTipoUsuario, TipoUsuario tipoUsuario)
        {
            // Pega as alterações que mandar pelo patch e aplica no objeto
            patchTipoUsuario.ApplyTo(tipoUsuario);

            // Compara a base de dados atual da TipoUsuario e vê se tem modificações
            contextoBanco.Entry(tipoUsuario).State = EntityState.Modified;
            contextoBanco.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
           return contextoBanco.TipoUsuario.Find(id);
        }

        public void Excluir(TipoUsuario tipoUsuario)
        {
            contextoBanco.TipoUsuario.Remove(tipoUsuario);
            contextoBanco.SaveChanges();
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
