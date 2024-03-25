using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Extensions.Msal;
using MagicEye2.Services.BackEndAPI.Services.Storage;
//using MagicEye2.Services.BackEndAPI.Models.Dto.Storage;

namespace MagicEye2.Services.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentralStorageController : ControllerBase
    {
        private readonly ICentralStorage _storage;
        public CentralStorageController(ICentralStorage storage)
        {
            _storage = storage;
        }

        [HttpGet]
        public async Task<IActionResult> ListAllAsync() 
        {
            var result = await _storage.ListAllBlobs();
            return Ok(result);
        }
    }
}
