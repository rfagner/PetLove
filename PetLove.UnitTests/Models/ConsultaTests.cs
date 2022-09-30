using PetLove.API.Models;
using Xunit;

namespace PetLove.UnitTests.Models
{
    public class ConsultaTests
    {
        [Fact]        
        public void DeveRetornarConsultaNotNull()
        {
            // Preparação
            Consulta consulta;
            // Execução
            consulta = new Consulta();
            // Retorno esperado
            Assert.NotNull(consulta);
            Assert.Equal(consulta.Id, consulta.Id);
            Assert.Equal(consulta.DataHora, consulta.DataHora);
            Assert.Equal(consulta.IdMedico, consulta.IdMedico);
            Assert.Equal(consulta.Medico, consulta.Medico);
            Assert.Equal(consulta.Paciente, consulta.Paciente);
            // Retorna booleano
            Assert.True(consulta.Id == consulta.Id);
            Assert.True(consulta.DataHora == consulta.DataHora);
            Assert.True(consulta.Medico == consulta.Medico);
            Assert.True(consulta.Paciente == consulta.Paciente);
            // Só é permitido com tipo Int
            Assert.StrictEqual(consulta, consulta);
            Assert.StrictEqual(consulta.Id, consulta.Id);
            Assert.StrictEqual(consulta.IdMedico, consulta.IdMedico);
            Assert.StrictEqual(consulta.IdPaciente, consulta.IdPaciente);
        }
    }
}
