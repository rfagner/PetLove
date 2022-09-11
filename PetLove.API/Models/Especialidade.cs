using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetLove.API.Models
{
    public class Especialidade
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Categoria { get; set; }
        public ICollection<Medico> Medicos { get; set; }
    }
}
