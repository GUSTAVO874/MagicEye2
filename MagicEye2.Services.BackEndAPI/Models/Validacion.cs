namespace MagicEye2.Services.BackEndAPI.Models
{
    public class Validacion
    {
        public int ValidacionId { get; set; }
        public int NumSecDerivac {  get; set; }
        public string UnidadqueDeriva { get; set; }
        public string Unidad_A_queDerivan {  get; set; }
        public string C6Nombres { get; set; }
        public int C5Identificacion { get; set; }
        public string C4TipoSeguro { get; set; }  
        public int C9Edad {  get; set; }
        public string C7Genero { get; set; }
        public string TipoAfiliacion { get; set; }
        public string C13Cie {  get; set; }
        public string C11CodTarifario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Observacion { get; set; }

    }
}
