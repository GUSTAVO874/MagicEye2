using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicEye2.Services.BackEndAPI.Models
{
    public class Proceso
    {
        [Key]
        public int ProcesoId { get; set; }
        public int VersionId { get; set; } // FK para VersionSecaf

        [ForeignKey("VersionId")]
        public VersionSecaf VersionSecaf { get; set; }

        public string MesAnioProceso { get; set; }
        public bool ExpedientesOrdYNumeradosOK { get; set; }
    }
}
