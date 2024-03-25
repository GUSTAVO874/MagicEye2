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
        [HttpPost]
        public async Task<ResponseDto> Post([FromBody]
        EntregaDto entregaDto)
        {
            //if(!string.IsNullOrWhiteSpace(entregaDto.))
            Entrega obj = _mapper.Map<Entrega>(entregaDto);
            _db.Entregas.Add(obj);
            await _db.SaveChangesAsync();
            _response.Result = _mapper.Map<EntregaDto>(obj);
            
            return _response;
        }
    }
}
