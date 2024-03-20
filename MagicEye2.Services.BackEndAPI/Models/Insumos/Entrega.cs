using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicEye2.Services.BackEndAPI.Models.Insumos
{
    public class Entrega
    {
        [Key]
        public int EntregaId { get; set; }
        
        public int ExpedienteId { get; set; } // FK 

        [ForeignKey("ExpedienteId")]
        public Expediente Expediente { get; set; }
        
        public string NombreDto { get; set; }
        public int ConfidenceDto { get; set; }
        public bool RecognitionProcessOK { get; set; } = false;
        public string Nombres { get; set; }
        public int Identificacion { get; set; }
        public int IdentificacionConfidence { get; set; }
        public string? Parentesco { get; set; } //mano alzada, lipiar
        public DateTime C3FechaAtencion { get; set; } // mano alzada, limpiar
    }
}
