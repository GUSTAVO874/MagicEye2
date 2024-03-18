namespace MagicEye2.Services.BackEndAPI.Models
{
    public class Proceso
    {
        public int ProcesoId { get; set; }
        public int VersionId {  get; set; }

        public string MesAnioProceso {get; set; }
        public bool ExpedientesOrdyNumeradosOK { get; set; }
    }
}
