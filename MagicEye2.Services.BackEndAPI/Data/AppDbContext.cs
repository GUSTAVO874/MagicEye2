using MagicEye2.Services.BackEndAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace MagicEye2.Services.BackEndAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<Cliente> Clientes{ get; set; }

        public DbSet<ExpedienteCliente> ExpedienteClientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación muchos a muchos Expediente Cliente
            //modelBuilder.Entity<Expediente>()
            //    .HasMany(p => p.Clientes)
            //    .WithMany(p => p.Expedientes)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "ExpedienteCliente",  // Nombre de la tabla intermedia
            //        j => j.HasOne<Cliente>().WithMany().HasForeignKey("ClienteId"),
            //        j => j.HasOne<Expediente>().WithMany().HasForeignKey("ExpedienteId"));
            // Composite primary key
            modelBuilder.Entity<ExpedienteCliente>()
                .HasKey(ec => new { ec.ExpedienteId, ec.ClienteId });

            // Relationships
            modelBuilder.Entity<ExpedienteCliente>()
                .HasOne(ec => ec.Expediente)
                .WithMany(e => e.ExpedienteClientes)
                .HasForeignKey(ec => ec.ExpedienteId);

            modelBuilder.Entity<ExpedienteCliente>()
                .HasOne(ec => ec.Cliente)
                .WithMany(c => c.ExpedienteClientes)
                .HasForeignKey(ec => ec.ClienteId);

            


            base.OnModelCreating(modelBuilder);
        }
    }
}
