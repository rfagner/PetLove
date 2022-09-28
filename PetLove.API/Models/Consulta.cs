using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetLove.API.Models
{
    public class Consulta
    {
        [Key]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int Id { get; set; }    
        
        [Required]
        public DateTime DataHora { get; set; } = DateTime.Now;

        [ForeignKey("Medico")]
        public int IdMedico { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public Medico Medico { get; set; }

        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public Paciente Paciente { get; set; }

    }
}
