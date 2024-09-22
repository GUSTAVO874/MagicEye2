using MagicEye2.Services.BackEndAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicEye2.Services.BackEndAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Prestacion> Prestaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación muchos a muchos
            modelBuilder.Entity<Paciente>()
                .HasMany(p => p.Prestaciones)
                .WithMany(p => p.Pacientes)
                .UsingEntity<Dictionary<string, object>>(
                    "PacientePrestacion",  // Nombre de la tabla intermedia
                    j => j.HasOne<Prestacion>().WithMany().HasForeignKey("PrestacionId"),
                    j => j.HasOne<Paciente>().WithMany().HasForeignKey("PacienteId"));


            base.OnModelCreating(modelBuilder);
        }
    }
}
