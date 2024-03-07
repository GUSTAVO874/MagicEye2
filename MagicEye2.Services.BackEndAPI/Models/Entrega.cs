namespace MagicEye2.Services.BackEndAPI.Models
{
    public class Entrega
    {
        public int EntregaId { get; set; }
        public string Nombres { get; set; }
        public int Identificacion { get; set; }
        public string Parentesco {  get; set; }
        public DateTime C3FechaAtencion { get; set; }
    }
}
