namespace MagicEye2.Services.BackEndAPI.Models.Dto
{
    public class ExpedienteConDocumentosDto
    {
        // Propiedades de Expediente
        public bool DtosImprescindiblesOK { get; set; }
        //public string Propiedad2 { get; set; }
        // ...

        // Propiedades de Validacion
        public string NombreDto { get; set; }
        //public string ValidacionPropiedad2 { get; set; }
        // ...

        // Propiedades de Cobertura
        public bool RecognitionProcessOK { get; set; }
        //public string CoberturaPropiedad2 { get; set; }
    }
}
