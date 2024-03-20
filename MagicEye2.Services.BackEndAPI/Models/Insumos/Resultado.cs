using System.ComponentModel.DataAnnotations.Schema;

namespace MagicEye2.Services.BackEndAPI.Models.Insumos
{
    public class Resultado
    {
        public int ResultadoId { get; set; }

        public int ExpedienteId { get; set; } // FK 

        [ForeignKey("ExpedienteId")]
        public Expediente Expediente { get; set; }

        public string NombreDto { get; set; }
        public int ConfidenceDto { get; set; }
        public bool RecognitionProcessOK { get; set; } = false;
        public string Nombres { get; set; }
        public string Estudio { get; set; }
        public string? Insumos { get; set; }
        public string? InsumosConfidence { get; set; }
        public string? Conclusiones { get; set; }
        public string? ConclusionesConfidence { get; set; }

    }
}
