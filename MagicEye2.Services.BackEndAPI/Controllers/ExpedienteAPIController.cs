using AutoMapper;
//using MagicEye2.Services.BackEndAPI.Communications;
using MagicEye2.Services.BackEndAPI.Data;
using MagicEye2.Services.BackEndAPI.Models;
using MagicEye2.Services.BackEndAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicEye2.Services.BackEndAPI.Controllers
{
    [Route("api/expediente")]
    [ApiController]
    public class ExpedienteAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public ExpedienteAPIController(AppDbContext db, ResponseDto response, IMapper mapper)
        {
            _db = db;
            _response = response;
            _mapper = mapper;
        }
        [HttpPost]
        public ResponseDto Post([FromBody] ExpedienteDto expedienteDto)
        {
            try
            {
                Expediente obj = _mapper.Map<Expediente>(expedienteDto);
                _db.Expedientes.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<ExpedienteDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }
        
    }
}
