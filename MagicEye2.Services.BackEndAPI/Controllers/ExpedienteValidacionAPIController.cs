using MagicEye2.Services.BackEndAPI.Data;
using MagicEye2.Services.BackEndAPI.Models.Insumos;
using MagicEye2.Services.BackEndAPI.Models;
using MagicEye2.Services.BackEndAPI.Models.Dto;
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
        
        [HttpPost]
        public async Task<IActionResult> PostExpedienteConDocumentos([FromBody] ExpedienteConDocumentosDto expedienteDto)
        {
            if (expedienteDto == null)
            {
                return BadRequest();
            }

            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var expediente = new Expediente
                    {
                        // Set properties from DTO
                    };

                    _db.Expedientes.Add(expediente);
                    await _db.SaveChangesAsync();

                    var validacion = new Validacion
                    {
                        ExpedienteId = expediente.ExpedienteId,
                        // Set other properties from DTO
                    };

                    _db.Validacions.Add(validacion);

                    var cobertura = new Cobertura
                    {
                        ExpedienteId = expediente.ExpedienteId,
                        // Set other properties from DTO
                    };

                    _db.Coberturas.Add(cobertura);

                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return Ok(new { expediente.ExpedienteId });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    // Log the exception (ex)
                    return StatusCode(500, "Internal server error");
                }
            }
        }
    }
}
