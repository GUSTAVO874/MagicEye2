namespace MagicEye2.Web.Models.Dto.Expedientes
{
    public class ExpedienteDto
    {
        public int ExpedienteId { get; set; }
        // FK para Proceso
        public int ProcesoId { get; set; }
        //Validación
        public int? ValidacionId { get; set; } // FK.
        //Cobertura
        public int? CoberturaId { get; set; } //FK.
        //Entrega
        public int? EntregaId { get; set; } //FK.
        //Hcu053
        public int? Hcu053Id { get; set; } //FK.
        //Resultado
        public int? ResultadoId { get; set; } //FK
        public int? CoberturaMadre { get; set; }
        public int? CoberturaPadre { get; set; }

        public int? NombreExpediente { get; set; }//carpetas numeradas
        public bool? DtosImprescindiblesOK { get; set; }
        public int? NumerodeDocumentos { get; set; }
        public bool? Ignorar { get; set; }

        public bool? ExpedienteRecognitionOK { get; set; }
    }
}
