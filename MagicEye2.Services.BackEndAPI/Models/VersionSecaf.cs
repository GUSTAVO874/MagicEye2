using System.ComponentModel.DataAnnotations;

namespace MagicEye2.Services.BackEndAPI.Models
{
    public class VersionSecaf
    {
        [Key]
        public int VersionId { get; set; }
        public string Version { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaRevision { get; set; }
        public string ElaboradoPor {  get; set; }
        public string RevisadoPor { get; set; }


        // Colección para representar la relación uno a muchos con Proceso
        public ICollection<Proceso> Procesos { get; set; }
    }
}
