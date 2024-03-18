using MagicEye2.Services.BackEndAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicEye2.Services.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedienteValidacionAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ExpedienteValidacionAPIController(AppDbContext db) 
        { 
            _db = db;
        }
        
        //[HttpPost]
    }
}
