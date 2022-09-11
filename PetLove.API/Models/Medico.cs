using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetLove.API.Models
{
    public class Medico 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CRM { get; set; }

        [ForeignKey("Especialidade")]
        public int IdEspecialidade { get; set; }
        public Especialidade Especialidade { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
        
    }
}
