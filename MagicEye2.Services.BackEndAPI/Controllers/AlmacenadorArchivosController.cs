using AutoMapper;
using MagicEye2.Services.BackEndAPI.Data;
using MagicEye2.Services.BackEndAPI.Helpers;
using MagicEye2.Services.BackEndAPI.Models.Dto;
using MagicEye2.Services.BackEndAPI.Models.Insumos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicEye2.Services.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenadorArchivosController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IAlmacenadorArchivos _almacenadorArchivos;
        private ResponseDto _response;
        private IMapper _mapper;
        public AlmacenadorArchivosController(AppDbContext db, IAlmacenadorArchivos almacenadorArchivos, 
            IMapper mapper) 
        { 
            _db = db;
            _almacenadorArchivos = almacenadorArchivos;
            _mapper = mapper;
        }
        //[HttpPost]
        //public async Task<ResponseDto> Post([FromBody]
        //EntregaDto entregaDto)
        //{
        //    if (!string.IsNullOrWhiteSpace(entregaDto.Pdf)) 
        //    { 
        //        var pdf = Convert.FromBase64String(entregaDto.Pdf);
        //        entregaDto.Pdf = await _almacenadorArchivos.GuardarArchivo(pdf, ".pdf", "test");
        //    }
        //    Entrega obj = _mapper.Map<Entrega>(entregaDto);
        //    _db.Entregas.Add(obj);
        //    await _db.SaveChangesAsync();
        //    _response.Result = _mapper.Map<EntregaDto>(obj);

        //    return _response;
        //}
        //[HttpPost]
        //public async Task<IActionResult> Post([FromForm] EntregaDto entregaDto, [FromForm] IFormFile archivoPdf)
        //{
        //    if (archivoPdf != null && archivoPdf.Length > 0)
        //    {
        //        var extension = Path.GetExtension(archivoPdf.FileName);
        //        using (var stream = new MemoryStream())
        //        {
        //            await archivoPdf.CopyToAsync(stream);
        //            var content = stream.ToArray();
        //            entregaDto.Pdf = await _almacenadorArchivos.GuardarArchivo(content, extension, "nombreContenedor");
        //        }
        //    }

        //    // Este es el código que agregué aparte del que tu me diste
        //    Entrega obj = _mapper.Map<Entrega>(entregaDto);
        //    _db.Entregas.Add(obj);
        //    await _db.SaveChangesAsync();
        //    _response.Result = _mapper.Map<EntregaDto>(obj);

        //    return Ok();
        //}
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Post([FromForm] EntregaDto entregaDto, [FromForm] IFormFile archivoPdf)
        {
            try
            {
                if (archivoPdf != null && archivoPdf.Length > 0)
                {
                    var extension = Path.GetExtension(archivoPdf.FileName);
                    using (var stream = new MemoryStream())
                    {
                        await archivoPdf.CopyToAsync(stream);
                        var content = stream.ToArray();
                        entregaDto.Pdf = await _almacenadorArchivos.GuardarArchivo(content, extension, "nombreContenedor");
                    }
                }

                Entrega obj = _mapper.Map<Entrega>(entregaDto);
                _db.Entregas.Add(obj);
                await _db.SaveChangesAsync();
                var resultDto = _mapper.Map<EntregaDto>(obj);

                return Ok(new { Message = "Archivo y datos guardados con éxito.", Result = resultDto });
            }
            catch (Exception ex)
            {
                // Log the exception details here using your logging framework
                return StatusCode(500, "Un error ocurrió al procesar su solicitud.");
            }
        }

    }
}
