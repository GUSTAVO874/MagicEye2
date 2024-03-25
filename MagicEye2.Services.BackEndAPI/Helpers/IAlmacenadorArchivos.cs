namespace MagicEye2.Services.BackEndAPI.Helpers
{
    public interface IAlmacenadorArchivos
    {
        //devuelve la url del archivo
        Task<string> GuardarArchivo(byte[] contenido, string extension, string nombreContenedor);
        Task EliminarArchivo(string ruta, string nombreContenedor);
        //Task<string> EditarArchivo(byte[] contenido, string extension, string nombreContenedor, string ruta);
        //async Task<string> EditarArchivo(byte[] contenido, string extension, string nombreContenedor, string ruta)
        //{
        //    if (ruta is not null)
        //    { 
        //        await EliminarArchivo(ruta,nombreContenedor);
                
        //    }
        //    return await GuardarArchivo(contenido, extension, nombreContenedor);
        //}
    }
}
