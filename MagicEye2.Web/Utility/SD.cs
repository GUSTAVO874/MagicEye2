namespace MagicEye2.Web.Utility
{
    public class SD
    {
        public static string ExpedienteAPIBase { get; set; }// url
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
        public enum TipoContent
        {
            Json,
            MultipartFormData,
        }
    }
}
