using Microsoft.EntityFrameworkCore;
using T2_Salazar_Renzo.Models;

namespace T2_Salazar_Renzo.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Este método sólo se llama si OnConfiguring no ha sido configurado externamente
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Proporciona una cadena de conexión de fallback si no está configurada externamente.
                optionsBuilder.UseSqlServer("Server=localhost;Database=BD_Salazar_Renzo_t2;Trusted_Connection=True;");
            }
        }

        public DbSet<Distribuidor> Distribuidores { get; set; }
    }
}
