namespace MagicEye2.Services.BackEndAPI.Models
{
    public class Paciente
    {
        //un paciente puede tener un tipo de beneficio (tabla MaestroTBeneficiario),
        //el mismo beneficio lo pueden
        //tener muchos pacientes
        public int PacienteId { get; set; }
        public int MaestroTBeneficiarioId {  get; set; }
        public string PacienteName { get; set; }
        
        //navegación - Paciente solo puede estar relacionado con un MaestroTBeneficiario
        public MaestroTBeneficiario MaestroTBeneficiario { get; set; }
    }
}
