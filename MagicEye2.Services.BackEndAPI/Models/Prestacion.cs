namespace MagicEye2.Services.BackEndAPI.Models
{
    public class Prestacion
    {
        public int Id { get; set; }
        public DateOnly Fecha { get; set; }

        // Propiedad de navegación para Pacientes
        public ICollection<Paciente> Pacientes { get; set; }
    }
}
