using AutoMapper;
using MagicEye2.Services.BackEndAPI.Data;
using MagicEye2.Services.BackEndAPI.Models.Dto;
using MagicEye2.Services.BackEndAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicEye2.Services.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public TestAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }
        [HttpPost]
        //public async Task<IActionResult> Post([FromBody] CoberturaDto coberturaDto, EntregaDto entregaDto,
        //    Hcu053Dto hcu053Dto, ResultadoDto resultadoDto, ValidacionDto validacionDto,
        //    ExpedienteDto expedienteDto)
        public async Task<IActionResult> Post([FromBody] ExpedienteDto expedienteDto)
        {
            Expediente obj = _mapper.Map<Expediente>(expedienteDto);
            _db.Expedientes.Add(obj);
            await _db.SaveChangesAsync();
            //_response.Result = _mapper.Map<ExpedienteDto>(obj);
            return Ok(_response);
            
            //using (var transaction = _db.Database.BeginTransaction())
            //{

            //try
            //{
            //    Expediente obj = _mapper.Map<Expediente>(expedienteDto);
            //_db.Expedientes.Add(obj);
            //await _db.SaveChangesAsync();
            //    _response.Result = _mapper.Map<ExpedienteDto>(obj);
            //}
            //catch (Exception ex)
            //{
            //    await transaction.RollbackAsync();
            //    // Aquí se debería hacer un log del error.
            //    return StatusCode(500, "Internal server error");
            //}
            //}
        }
    }
}
