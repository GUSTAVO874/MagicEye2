using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicEye2.Services.BackEndAPI.Models
{
    public class Proceso
    {
        [Key]
        public int ProcesoId { get; set; }

        // FK para VersionSecaf
        public int VersionId { get; set; } 

        [ForeignKey("VersionId")]
        public VersionSecaf VersionSecaf { get; set; }
        
        // Colección para representar la relación uno a muchos con Expediente
        public ICollection<Expediente> Expedientes { get; set; }

        public string MesAnioProceso { get; set; }
        public bool? ExpedientesOrdYNumeradosOK { get; set; }
    }
}
