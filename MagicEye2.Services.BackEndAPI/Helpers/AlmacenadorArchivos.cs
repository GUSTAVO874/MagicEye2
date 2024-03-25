
using Azure.Storage.Blobs;

namespace MagicEye2.Services.BackEndAPI.Helpers
{
    public class AlmacenadorArchivos : IAlmacenadorArchivos
    {
        private string connectionString;
        public AlmacenadorArchivos(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorage")!;
        }
        public Task EliminarArchivo(string ruta, string nombreContenedor)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GuardarArchivo(byte[] contenido, string extension, string nombreContenedor)
        {
            var cliente = new BlobContainerClient(connectionString, nombreContenedor);
            await cliente.CreateIfNotExistsAsync();
            cliente.SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

            var archivoNombre = "A_ENTREGA";
            var blob = cliente.GetBlobClient(archivoNombre);
            using (var ms = new MemoryStream(contenido)) 
            { 
                await blob.UploadAsync(ms);
            }
            return blob.Uri.ToString();
        }
    }
}
