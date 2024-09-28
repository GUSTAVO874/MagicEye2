using MagicEye2.Services.BackEndAPI.Models;

namespace MagicEye2.Services.BackEndAPI.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Name { get; set; }

        // Navigation property for ExpedienteCliente
        public ICollection<ExpedienteCliente> ExpedienteClientes { get; set; }
    }

}
