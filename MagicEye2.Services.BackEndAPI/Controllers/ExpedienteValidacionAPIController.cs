using MagicEye2.Services.BackEndAPI.Data;
using MagicEye2.Services.BackEndAPI.Models.Insumos;
using MagicEye2.Services.BackEndAPI.Models;
using MagicEye2.Services.BackEndAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace MagicEye2.Services.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedienteValidacionAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public ExpedienteValidacionAPIController(AppDbContext db, IMapper mapper) 
        { 
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
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
                        // Inicializa las propiedades del Expediente desde el DTO
                        ProcesoId = expedienteDto.ProcesoId,
                        DtosImprescindiblesOK = expedienteDto.DtosImprescindiblesOK,
                    };

                    _db.Expedientes.Add(expediente);
                    await _db.SaveChangesAsync();

                    var validacion = new Validacion
                    {
                        ExpedienteId = expediente.ExpedienteId,
                        // Inicializa las demás propiedades de Validacion desde el DTO
                        NombreDto = expedienteDto.NombreDto,
                    };

                    _db.Validacions.Add(validacion);

                    var cobertura = new Cobertura
                    {
                        ExpedienteId = expediente.ExpedienteId,
                        // Inicializa las demás propiedades de Cobertura desde el DTO
                        RecognitionProcessOK = expedienteDto.RecognitionProcessOK,
                    };

                    _db.Coberturas.Add(cobertura);

                    // Primero guardamos las entidades Validacion y Cobertura para que se generen los IDs.
                    await _db.SaveChangesAsync();

                    // Ahora, actualizamos el Expediente con los IDs generados.
                    expediente.ValidacionId = validacion.ValidacionId;
                    expediente.CoberturaId = cobertura.CoberturaId;

                    // Guardamos de nuevo para actualizar el Expediente con los IDs de Validacion y Cobertura.
                    await _db.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return Ok(new { expediente.ExpedienteId });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    // Aquí se debería hacer un log del error.
                    return StatusCode(500, "Internal server error");
                }
            }

        }
    }
}
