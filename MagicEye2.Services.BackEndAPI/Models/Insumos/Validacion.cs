using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicEye2.Services.BackEndAPI.Models.Insumos
{
    public class Validacion
    {
        [Key]
        public int ValidacionId { get; set; }
        
        public int ExpedienteId { get; set; } // FK .

        [ForeignKey("ExpedienteId")]
        public Expediente Expediente { get; set; }
        

        public string? NombreDto { get; set; }
        public int? ConfidenceDto { get; set; }
        public bool? RecognitionProcessOK { get; set; } = false;
        public int? NumSecDerivac { get; set; }
        public int? NumSecDerivacConfidence { get; set; }
        public string? UnidadqueDeriva { get; set; }
        public int? UnidadqueDerivaConfidence { get; set; }
        public string? Unidad_A_queDerivan { get; set; }
        public int? Unidad_A_queDerivanConfidence { get; set; }
        public string? C6Nombres { get; set; }
        public int? C6NombresConfidence { get; set; }
        public int? C5Identificacion { get; set; }
        public int? C5IdentificacionConfidence { get; set; }
        public string? C4TipoSeguro { get; set; }
        public int? C4TipoSeguroConfidence { get; set; }
        public int? C9Edad { get; set; }
        public int? C9EdadConfidence { get; set; }
        public string? C7Genero { get; set; }
        public int? C7GeneroConfidence { get; set; }
        public string? TipoAfiliacion { get; set; }
        public int? TipoAfiliacionConfidence { get; set; }
        public string? C13Cie { get; set; }
        public int? C13CieConfidence { get; set; }
        public string? C11CodTarifario { get; set; }
        public int? C11CodTarifarioConfidence { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Observacion { get; set; }
        public string? Pdf { get; set; } // es la dirección donde se almacenará el pdf en azure

    }
}
