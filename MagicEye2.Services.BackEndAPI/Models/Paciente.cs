namespace MagicEye2.Services.BackEndAPI.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string PacienteName { get; set; }

        // Propiedad de navegación para Prestaciones
        public IEnumerable<Prestacion> Prestaciones { get; set; }
    }
}
