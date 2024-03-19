using MagicEye2.Services.BackEndAPI.Models.Insumos;
using System.ComponentModel.DataAnnotations;

namespace MagicEye2.Services.BackEndAPI.Models
{
    public class Expediente
    {
        [Key]
        public int ExpedienteId { get; set; }
        public int? ValidacionId { get; set; } // FK.
<<<<<<< HEAD
        
=======

>>>>>>> b5b9e8fc5a86c84104a98e989013429c1cfa4c63
        // Navegación hacia Validacion. 
        public Validacion Validacion { get; set; }
        
        public int? CoberturaId { get; set; } //FK.
        
        //Navegación hacia Cobertura
        public Cobertura Cobertura {  get; set; }


<<<<<<< HEAD



        public int? ProcesoId { get; set; } // Suponiendo que esto es otra relación o propiedad
=======
        public int? ProcesoId { get; set; } // Suponiendo que esto es otra relación o propiedad
        public int? CoberturaId { get; set; }
>>>>>>> b5b9e8fc5a86c84104a98e989013429c1cfa4c63
        public int? CoberturaMadre {  get; set; }
        public int? CoberturaPadre { get; set; }
        public int? Hcu053Id {  get; set; }
        public int? ResultadoId { get; set; }
        public int? EntregaId { get; set; }
        public int? NombreExpediente {  get; set; }//carpetas numeradas
        public bool? DtosImprescindiblesOK { get; set; }
        public int? NumerodeDocumentos {  get; set; }
        public bool? Ignorar {  get; set; }

        public bool? ExpedienteRecognitionOK { get; set; }
    }
}
