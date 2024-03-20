using MagicEye2.Services.BackEndAPI.Models.Insumos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicEye2.Services.BackEndAPI.Models
{
    public class Expediente
    {
        [Key]
        public int ExpedienteId { get; set; }

        // FK para Proceso
        public int ProcesoId { get; set; }

        [ForeignKey("ProcesoId")]
        public Proceso Proceso { get; set; }


        //Validación
        public int? ValidacionId { get; set; } // FK.

        // Navegación hacia Validacion. 
        public Validacion Validacion { get; set; }

        //Cobertura
        public int? CoberturaId { get; set; } //FK.

        //Navegación hacia Cobertura
        public Cobertura Cobertura { get; set; }
        
        //Entrega
        public int? EntregaId { get; set; } //FK.

        //Navegación hacia Entrega
        public Entrega Entrega { get; set; }
        
        //Hcu053
        public int? Hcu053Id { get; set; } //FK.

        //Navegación hacia Hcu053
        public Hcu053 Hcu053 { get; set; }

        //Resultado
        public Resultado ResultadoId { get; set; } //FK

        //Navegación hacia Resultado
        public Resultado Resultado { get; set; }
                
        public int? CoberturaMadre { get; set; }
        public int? CoberturaPadre { get; set; }
        
        public int? NombreExpediente { get; set; }//carpetas numeradas
        public bool? DtosImprescindiblesOK { get; set; }
        public int? NumerodeDocumentos { get; set; }
        public bool? Ignorar { get; set; }

        public bool? ExpedienteRecognitionOK { get; set; }
    }
}
