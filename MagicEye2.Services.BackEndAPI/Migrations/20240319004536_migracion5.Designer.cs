﻿// <auto-generated />
using System;
using MagicEye2.Services.BackEndAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicEye2.Services.BackEndAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240319004536_migracion5")]
    partial class migracion5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicEye2.Services.BackEndAPI.Models.Expediente", b =>
                {
                    b.Property<int>("ExpedienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpedienteId"));

                    b.Property<int?>("CoberturaId")
                        .HasColumnType("int");

                    b.Property<int?>("CoberturaMadre")
                        .HasColumnType("int");

                    b.Property<int?>("CoberturaPadre")
                        .HasColumnType("int");

                    b.Property<bool?>("DtosImprescindiblesOK")
                        .HasColumnType("bit");

                    b.Property<int?>("EntregaId")
                        .HasColumnType("int");

                    b.Property<bool?>("ExpedienteRecognitionOK")
                        .HasColumnType("bit");

                    b.Property<int?>("Hcu053Id")
                        .HasColumnType("int");

                    b.Property<bool?>("Ignorar")
                        .HasColumnType("bit");

                    b.Property<int?>("NombreExpediente")
                        .HasColumnType("int");

                    b.Property<int?>("NumerodeDocumentos")
                        .HasColumnType("int");

                    b.Property<int?>("ProcesoId")
                        .HasColumnType("int");

                    b.Property<int?>("ResultadoId")
                        .HasColumnType("int");

                    b.Property<int?>("ValidacionId")
                        .HasColumnType("int");

                    b.HasKey("ExpedienteId");

                    b.ToTable("Expedientes");
                });

            modelBuilder.Entity("MagicEye2.Services.BackEndAPI.Models.Insumos.Cobertura", b =>
                {
                    b.Property<int>("CoberturaId")
                        .HasColumnType("int");

                    b.Property<int?>("ConfidenceDto")
                        .HasColumnType("int");

                    b.Property<int>("ExpedienteId")
                        .HasColumnType("int");

                    b.Property<int?>("Identificacion")
                        .HasColumnType("int");

                    b.Property<int?>("IdentificacionConfidence")
                        .HasColumnType("int");

                    b.Property<string>("NombreDto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("RecognitionProcessOK")
                        .HasColumnType("bit");

                    b.HasKey("CoberturaId");

                    b.ToTable("Cobertura");
                });

            modelBuilder.Entity("MagicEye2.Services.BackEndAPI.Models.Insumos.Validacion", b =>
                {
                    b.Property<int>("ValidacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ValidacionId"));

                    b.Property<string>("C11CodTarifario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("C11CodTarifarioConfidence")
                        .HasColumnType("int");

                    b.Property<string>("C13Cie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("C13CieConfidence")
                        .HasColumnType("int");

                    b.Property<string>("C4TipoSeguro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("C4TipoSeguroConfidence")
                        .HasColumnType("int");

                    b.Property<int?>("C5Identificacion")
                        .HasColumnType("int");

                    b.Property<int?>("C5IdentificacionConfidence")
                        .HasColumnType("int");

                    b.Property<string>("C6Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("C6NombresConfidence")
                        .HasColumnType("int");

                    b.Property<string>("C7Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("C7GeneroConfidence")
                        .HasColumnType("int");

                    b.Property<int?>("C9Edad")
                        .HasColumnType("int");

                    b.Property<int?>("C9EdadConfidence")
                        .HasColumnType("int");

                    b.Property<int?>("ConfidenceDto")
                        .HasColumnType("int");

                    b.Property<int>("ExpedienteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreDto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumSecDerivac")
                        .HasColumnType("int");

                    b.Property<int?>("NumSecDerivacConfidence")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("RecognitionProcessOK")
                        .HasColumnType("bit");

                    b.Property<string>("TipoAfiliacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoAfiliacionConfidence")
                        .HasColumnType("int");

                    b.Property<string>("Unidad_A_queDerivan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Unidad_A_queDerivanConfidence")
                        .HasColumnType("int");

                    b.Property<string>("UnidadqueDeriva")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UnidadqueDerivaConfidence")
                        .HasColumnType("int");

                    b.HasKey("ValidacionId");

                    b.HasIndex("ExpedienteId")
                        .IsUnique();

                    b.ToTable("Validacions");
                });

            modelBuilder.Entity("MagicEye2.Services.BackEndAPI.Models.Proceso", b =>
                {
                    b.Property<int>("ProcesoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProcesoId"));

                    b.Property<bool>("ExpedientesOrdYNumeradosOK")
                        .HasColumnType("bit");

                    b.Property<string>("MesAnioProceso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("ProcesoId");

                    b.HasIndex("VersionId");

                    b.ToTable("Procesos");
                });

            modelBuilder.Entity("MagicEye2.Services.BackEndAPI.Models.VersionSecaf", b =>
                {
                    b.Property<int>("VersionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VersionId"));

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VersionId");

                    b.ToTable("VersionSecafs");
                });

            modelBuilder.Entity("MagicEye2.Services.BackEndAPI.Models.Insumos.Cobertura", b =>
                {
                    b.HasOne("MagicEye2.Services.BackEndAPI.Models.Expediente", "Expediente")
                        .WithOne("Cobertura")
                        .HasForeignKey("MagicEye2.Services.BackEndAPI.Models.Insumos.Cobertura", "CoberturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expediente");
                });

            modelBuilder.Entity("MagicEye2.Services.BackEndAPI.Models.Insumos.Validacion", b =>
                {
                    b.HasOne("MagicEye2.Services.BackEndAPI.Models.Expediente", "Expediente")
                        .WithOne("Validacion")
                        .HasForeignKey("MagicEye2.Services.BackEndAPI.Models.Insumos.Validacion", "ExpedienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expediente");
                });

            modelBuilder.Entity("MagicEye2.Services.BackEndAPI.Models.Proceso", b =>
                {
                    b.HasOne("MagicEye2.Services.BackEndAPI.Models.VersionSecaf", "VersionSecaf")
                        .WithMany("Procesos")
                        .HasForeignKey("VersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VersionSecaf");
                });

            modelBuilder.Entity("MagicEye2.Services.BackEndAPI.Models.Expediente", b =>
                {
                    b.Navigation("Cobertura")
                        .IsRequired();

                    b.Navigation("Validacion")
                        .IsRequired();
                });

            modelBuilder.Entity("MagicEye2.Services.BackEndAPI.Models.VersionSecaf", b =>
                {
                    b.Navigation("Procesos");
                });
#pragma warning restore 612, 618
        }
    }
}
