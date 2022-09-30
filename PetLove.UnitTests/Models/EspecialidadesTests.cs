

using PetLove.API.Models;
using Xunit;

namespace PetLove.UnitTests.Models
{
    public class EspecialidadesTests
    {
        [Fact]
        public void DeveRetornarNotNullNaEspecialidade()
        {
            // Preparação
            Especialidade especialidade;

            // Execução
            especialidade = new Especialidade();

            // Retorno esperado
            Assert.NotNull(especialidade);

            // Verifica se é do tipo Especialidade
            Assert.IsType<Especialidade>(especialidade);
        }

        [Fact]
        public void VerificaSeEdoTipoEspecialidade()
        {
            // Preparação
            Especialidade especialidade;

            // Execução
            especialidade = new Especialidade();

            // Retorno esperado
            Assert.IsType<Especialidade>(especialidade);
        }
    }
}
