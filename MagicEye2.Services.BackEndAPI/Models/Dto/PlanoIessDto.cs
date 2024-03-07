using System.ComponentModel.DataAnnotations.Schema;

namespace MagicEye2.Services.BackEndAPI.Models
{
    public class PlanoIessDto
    {
        public int PlanoiessId { get; set; }
        public int VersionId { get; set; }
        [ForeignKey("VersionId")]
        public VersionSecaf VersionSecaf { get; set; }
        
        public string C1CodEspec { get; set; } = "0000000316";//imagenología
        public int C2Numeración { get; set; }
        public DateTime C3FechaAtencion { get; set; } //Entrega
        public string C4TipoSeguro { get; set; } //Validación
        public int C5Identificacion { get; set; } //Validación
        public string C6Nombres { get; set; } //Validación
        public string C7Genero { get; set; } //Validación
        public DateTime C8FechaNacimiento { get; set; } //053
        public int C9Edad { get; set; } //Validación
        public string C10TipoServicio { get; set; } = "IMAGEN";
        public string C11CodTarifario { get; set; } //Validación
        
        //consulta a archivo según cod tarifario, además si hay insumos 
        //deben listarse aquí
        public string C12Descripcion { get; set; } 
        public string C13CieDiagnPrincipal { get; set; } //Validación
        public string C14CieDiagn1 { get; set; } //mismo de c12
        public string C15CieDiagn2 { get; set; } //mismo de c12
        public string C16Cantidad { get; set; } = "00001";
        public decimal C17ValorUnitario { get; set; } //separado debe ser coma
        public int C18DuracionCons { get; set; } = 30;
        public string C19Parentesco {  get; set; } //Entrega, hacer match

        //si paciente es titular va lo mismo (Validacion)
        //caso contrario va el padre, madre, etc (Cobertura)
        public int C20dentificacion { get; set; }

        //si paciente es titular va lo mismo (Validacion)
        //caso contrario va el padre, madre, etc (Cobertura)
        public string C21Nombres { get; set; }
        public string C22CodDerivacion { get; set; } = "CVAF"; //Validación
        public int C23NumSecDerivac {  get; set; } //Validación
        public int C24ContingCub { get; set; } = 1;

        //D definitivo P presuntivo, poner todos en P
        //Navila lo tiene como TipoPrestación pero así no esta en el secaf
        public char C25TipoDiagnost { get; set; } 
        public int C26TiempoAnest {  get; set; } //vacío
        public string C27Diagnost3 { get; set; } //vacío
        public string C28Diagnost4 { get; set; } //vacío
        public string C29Diagnost5 { get; set; } //vacío
        public int C30PorcentajeIva {  get; set; }//vacío
        public int C31ValorIvaUnit {  get; set; }//vacío
        public decimal C32ValorTotal { get; set; }// mismo de columna 17
        public decimal C33GastoGest {  get; set; }// vacío
        public DateTime C34FechaIngreso { get; set; }//Entrega
        public DateTime C35FechaEgreso { get; set; }//mismo de fecha ingreso
        public int C36MotivoEgreso { get; set; } //fijo en 1
        public bool C37CobertCompart { get; set; } //fijo en no
        public string C38TipoCobert {  get; set; } //vacío

        //poner fijo en no, no tengo ejemplos de si, posiblemente
        //adjuntarán un certificado  
        public bool C39DiscapacidadCert {  get; set; }

        //secaf indica P,M,I
        //Si Resultados indica insumos poner I, además en la col12 descripción
        //se debe poner los insumos uno por línea con el mismo numero secuencial
        //, caso contrario P, biolab no tiene en ningún registro M
        public char C40TipoPrest { get; set; } //Resultados
        public int C41TipoMedico {  get; set; } //fijo en 8
        public string C42Observ {  get; set; } //vacío
        public char C43Marca { get; set; }  //fijo en f


    }
}
