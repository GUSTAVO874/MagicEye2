namespace MagicEye2.Services.BackEndAPI.Models
{
    public class ExpedienteCliente
    {
        //public int ClienteId { get; set; }
        //public int ExpedienteId { get; set; }
            public int ExpedienteId { get; set; }
            public Expediente Expediente { get; set; }

            public int ClienteId { get; set; }
            public Cliente Cliente { get; set; }
        
    }
}
