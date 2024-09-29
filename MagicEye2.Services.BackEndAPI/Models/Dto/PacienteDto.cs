namespace MagicEye2.Services.BackEndAPI.Models.Dto
{
    public class PacienteDto
    {
        public int PacienteId { get; set; }
        public string PacienteName { get; set; }
        public int MaestroTBeneficiarioId { get; set; }

        //public MaestroTBeneficiario MaestroTBeneficiario { get; set; }
    }
}
