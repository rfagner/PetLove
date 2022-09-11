using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetLove.API.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Carteirinha { get; set; }
        
        [Required]
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
       
    }
}
