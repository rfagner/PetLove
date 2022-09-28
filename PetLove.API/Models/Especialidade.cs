using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PetLove.API.Models
{
    public class Especialidade
    {
        [Key]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int Id { get; set; }
        
        [Required]
        public string Categoria { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public ICollection<Medico> Medicos { get; set; }
    }
}
