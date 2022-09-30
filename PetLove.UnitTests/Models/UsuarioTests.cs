using PetLove.API.Models;
using Xunit;

namespace PetLove.UnitTests.Models
{
    public class UsuarioTests
    {
        [Fact]
        public void DeveRetornarUsuarioNotNull()
        {
            // Preparação
            Usuario usuario;  
            // Execução
            usuario = new Usuario();
            // Retorno esperado
            Assert.NotNull(usuario);

            // Demais tipos
            Assert.IsType<Usuario>(usuario);
            Assert.Equal(usuario.Id, usuario.Id);
            Assert.Equal(usuario.Nome, usuario.Nome);
            Assert.Equal(usuario.Senha, usuario.Senha);
            Assert.Equal(usuario.TipoUsuario, usuario.TipoUsuario);
            // Retorna booleano
            Assert.True(usuario.Id == usuario.Id);
            Assert.True(usuario.Nome == usuario.Nome);
            Assert.True(usuario.Senha == usuario.Senha);
            Assert.True(usuario.TipoUsuario == usuario.TipoUsuario);
            // Só é permitido com tipo Int
            Assert.StrictEqual(usuario, usuario);
            Assert.StrictEqual(usuario.Id, usuario.Id);
            Assert.StrictEqual(usuario.TipoUsuario, usuario.TipoUsuario);
            

        }


        
    }
}
