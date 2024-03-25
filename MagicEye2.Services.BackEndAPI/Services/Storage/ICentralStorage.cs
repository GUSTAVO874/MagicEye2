using MagicEye2.Services.BackEndAPI.Models.Dto.Storage;
using Microsoft.AspNetCore.Mvc;

namespace MagicEye2.Services.BackEndAPI.Services.Storage
{
    public interface ICentralStorage
    {
        Task<List<BlobDto>> ListAllBlobs();
        Task<IActionResult> Upload(IFormFile file);
        Task<IActionResult> Download(string filename);
        Task<IActionResult> Delete(string filename);
    }
}
