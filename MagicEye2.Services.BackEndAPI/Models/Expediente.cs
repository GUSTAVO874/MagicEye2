using MagicEye2.Services.BackEndAPI.Models.Insumos;
using System.ComponentModel.DataAnnotations;

namespace MagicEye2.Services.BackEndAPI.Models
{
    public class Expediente
    {
        [Key]
        public int ExpedienteId { get; set; }
        public int ValidacionId { get; set; } // FK.

        // Navegación hacia Validacion. 
        public Validacion Validacion { get; set; }


        public int ProcesoId { get; set; } // Suponiendo que esto es otra relación o propiedad
        public int CoberturaId { get; set; }
        public int? CoberturaMadre {  get; set; }
        public int? CoberturaPadre { get; set; }
        public int Hcu053Id {  get; set; }
        public int ResultadoId { get; set; }
        public int EntregaId { get; set; }
        public int NombreExpediente {  get; set; }//carpetas numeradas
        public bool DtosImprescindiblesOK { get; set; }
        public int NumerodeDocumentos {  get; set; }
        public bool Ignorar {  get; set; }

        public bool ExpedienteRecognitionOK { get; set; }
    }
}
