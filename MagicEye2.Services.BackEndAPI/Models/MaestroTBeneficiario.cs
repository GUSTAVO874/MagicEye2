namespace MagicEye2.Services.BackEndAPI.Models
{
    public class MaestroTBeneficiario
    {
        public int MaestroTBeneficiarioId { get; set; }

        public string? Codigo { get; set; }

        //navegación - - ¿Quién va a tener muchos Pacientes? Pues MaestroTBeneficiario entonces aquí
        //va la colección de Pacientes
        public IEnumerable<Paciente>? Pacientes { get; set; }
    }
}
