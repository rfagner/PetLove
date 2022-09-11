using Microsoft.EntityFrameworkCore;
using PetLove.API.Models;

namespace PetLove.API.Contexts
{
    public class PetLoveContext : DbContext
    {
        public PetLoveContext(DbContextOptions<PetLoveContext> options) : base(options)
        {

        }
        

        // Apontamento das classes que serão mapeadas
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
