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

            //using (var transaction = _db.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        var expediente = new Expediente
            //        {
            //            // Set properties from DTO
            //            DtosImprescindiblesOK = true,
            //        };

            //        _db.Expedientes.Add(expediente);
            //        await _db.SaveChangesAsync();

            //        var validacion = new Validacion
            //        {
            //            ExpedienteId = expediente.ExpedienteId,
            //            // Set other properties from DTO
            //            NombreDto = "asdf",
            //        };

            //        _db.Validacions.Add(validacion);

            //        var cobertura = new Cobertura
            //        {
            //            ExpedienteId = expediente.ExpedienteId,
            //            // Set other properties from DTO
            //            RecognitionProcessOK = true,
            //        };

            //        _db.Coberturas.Add(cobertura);

            //        await _db.SaveChangesAsync();
            //        await transaction.CommitAsync();

            //        return Ok(new { expediente.ExpedienteId });
            //    }
            //    catch (Exception ex)
            //    {
            //        await transaction.RollbackAsync();
            //        // Log the exception (ex)
            //        return StatusCode(500, "Internal server error");
            //    }
            //}
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var expediente = new Expediente
                    {
                        // Inicializa las propiedades del Expediente desde el DTO
                        DtosImprescindiblesOK = true,
                    };

                    _db.Expedientes.Add(expediente);
                    await _db.SaveChangesAsync();

                    var validacion = new Validacion
                    {
                        ExpedienteId = expediente.ExpedienteId,
                        // Inicializa las demás propiedades de Validacion desde el DTO
                        NombreDto = "asdf",
                    };

                    _db.Validacions.Add(validacion);

                    var cobertura = new Cobertura
                    {
                        ExpedienteId = expediente.ExpedienteId,
                        // Inicializa las demás propiedades de Cobertura desde el DTO
                        RecognitionProcessOK = true,
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
