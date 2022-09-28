using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetLove.API.Models
{
    public class Usuario
    {
        [Key]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe seu nome")]
        [MinLength(3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [MinLength(8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres")]
        public string Senha { get; set; }       
       

        [ForeignKey("TipoUsuario")]
        
        public int IdTipoUsuario { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public TipoUsuario TipoUsuario { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public ICollection<Paciente> Pacientes { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public ICollection<Medico> Medicos { get; set; }

               


        
    }
}
