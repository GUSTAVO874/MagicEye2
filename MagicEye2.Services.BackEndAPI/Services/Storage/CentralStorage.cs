using Azure.Storage.Blobs;
using MagicEye2.Services.BackEndAPI.Models.Dto.Storage;
using Microsoft.AspNetCore.Mvc;

namespace MagicEye2.Services.BackEndAPI.Services.Storage
{
    public class CentralStorage : ICentralStorage
    {
        private string connectionString;
        public CentralStorage(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorage")!;
        }
        public Task<IActionResult> Delete(string filename)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Download(string filename)
        {
            throw new NotImplementedException();
        }

        
        public async Task<List<BlobDto>> ListAllBlobs()
        {
            var cliente = new BlobContainerClient(connectionString, "diciembre-2023-iess-general");
            List<BlobDto> files = new List<BlobDto>();

            await foreach (var file in cliente.GetBlobsAsync())
            {
                string uri = cliente.Uri.ToString();
                var name = file.Name;
                var fullUri = $"{uri}/{name}";

                files.Add(new BlobDto
                {
                    Uri = fullUri,
                    Name = name,
                    ContentType = file.Properties.ContentType
                });
            }

            return files;
            //throw new NotImplementedException();
        }

        public Task<IActionResult> Upload(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
