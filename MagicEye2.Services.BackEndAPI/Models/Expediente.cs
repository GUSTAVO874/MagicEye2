using System.ComponentModel.DataAnnotations;
namespace MagicEye2.Services.BackEndAPI.Models
{
    public class Expediente
    {
        public int ExpedienteId { get; set; }

        [Required]
        public DateTime Fechaexp { get; set; }

        // Navigation property for ExpedienteCliente
        public ICollection<ExpedienteCliente> ExpedienteClientes { get; set; }
    }

}
