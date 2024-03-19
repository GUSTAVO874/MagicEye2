using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicEye2.Services.BackEndAPI.Models.Insumos
{
    public class Cobertura
    {
        [Key]
        public int CoberturaId { get; set; }
        public int ExpedienteId { get; set; } // FK 

        [ForeignKey("ExpedienteId")]
        public Expediente Expediente { get; set; }

        public string? NombreDto { get; set; }
        public int? ConfidenceDto { get; set; }
        public bool? RecognitionProcessOK { get; set; } = false;
        public string? Nombres { get; set; } //puede ser del padre o madre
        public int? Identificacion { get; set; } //cédula
        public int? IdentificacionConfidence { get; set; }

    }
}
