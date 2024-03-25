﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicEye2.Services.BackEndAPI.Models.Insumos
{
    public class Hcu053
    {
        [Key]
        public int Hcu53Id { get; set; }
        
        public int ExpedienteId { get; set; } // FK 

        [ForeignKey("ExpedienteId")]
        public Expediente Expediente { get; set; }

        public string? NombreDto { get; set; }
        public int? ConfidenceDto { get; set; }
        public bool? RecognitionProcessOK { get; set; } = false;
        public string? Nombres { get; set; } //mano alzada no los lee reentrenar, no los necesito
        public int? Identificacion { get; set; }
        public int? IdentificacionConfidence { get; set; }
        public DateTime? C8FechaNacimiento { get; set; } //mano alzada, limpiar
        public int? Telefono { get; set; }
        public string? Pdf {  get; set; }
    }
}
