using MagicEye2.Services.BackEndAPI.Models;
using MagicEye2.Services.BackEndAPI.Models.Insumos;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace MagicEye2.Services.BackEndAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<VersionSecaf> VersionSecafs { get; set; }
        public DbSet<Proceso> Procesos {  get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<Validacion> Validacions { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //base.OnModelCreating(modelBuilder);

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//dejar esta línea para que luego funcione el Identity

            // Configuración de la relación uno a muchos entre VersionSecaf y Proceso
            modelBuilder.Entity<VersionSecaf>()
                .HasMany(v => v.Procesos) // Una VersionSecaf tiene muchos Proceso
                .WithOne(p => p.VersionSecaf) // Cada Proceso tiene una VersionSecaf
                .HasForeignKey(p => p.VersionId); // La FK en Proceso es VersionId

            // No es necesario configurar la clave primaria si solo usas [Key] y nombres de propiedades convencionales
            // EF Core puede inferirlo automáticamente.

            ////////////////////////
            // Configuración uno a uno para Expediente y Validacion
            //modelBuilder.Entity<Expediente>()
            //    .HasOne(e => e.Validacion)
            //    .WithOne(v => v.Expediente)
            //    .HasForeignKey<Validacion>(v => v.ExpedienteId);

            //// Asegurarse de que ValidacionId es una clave primaria en Validacion
            //modelBuilder.Entity<Validacion>()
            //    .HasKey(v => v.ValidacionId);

            //Configuración uno a uno para Expediente y Validacion
            modelBuilder.Entity<Expediente>()
            .HasOne(e => e.Validacion)
            .WithOne(v => v.Expediente)
            .HasForeignKey<Validacion>(v => v.ExpedienteId)
            .OnDelete(DeleteBehavior.Cascade); // Asegura la eliminación en cascada

            //Configuración uno a uno para Expediente y Cobertura
            modelBuilder.Entity<Expediente>()
            .HasOne(e => e.Cobertura)
            .WithOne(v => v.Expediente)
            .HasForeignKey<Cobertura>(v => v.CoberturaId)
            .OnDelete(DeleteBehavior.Cascade); // Asegura la eliminación en cascada.


        }


    }
}
