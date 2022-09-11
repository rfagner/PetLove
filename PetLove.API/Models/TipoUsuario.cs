using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetLove.API.Models
{
    public class TipoUsuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public UsuarioTipo Tipo { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }

    public enum UsuarioTipo
    {
        Paciente,
        Medico
    }
}
