using AutoMapper;
using Azure;
using MagicEye2.Services.BackEndAPI.Data;
using MagicEye2.Services.BackEndAPI.Models;
using MagicEye2.Services.BackEndAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicEye2.Services.BackEndAPI.Controllers
{
    [Route("api/paciente")]
    [ApiController]
    public class PacienteAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public PacienteAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }
        [HttpPost("paciente")]
        public async Task<ResponseDto> PostPaciente([FromBody] PacienteDto pacienteDto)
        {
            //ejemplo relación uno a muchos, este post guarda una entidad con clave foránea
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    // Map DTOs to domain models
                    Paciente paciente = _mapper.Map<Paciente>(pacienteDto);
                    _db.Pacientes.Add(paciente);
                    
                    await _db.SaveChangesAsync();

                    await transaction.CommitAsync();
                    
                    _response.Result = pacienteDto;
                }
                catch (Exception ex)
                {
                    // Si ocurre un error, revertimos todas las operaciones
                    await transaction.RollbackAsync();
                    _response.Message = ex.Message.ToString();
                    _response.IsSuccess = false;
                }
                return _response;
            }
        }
    }
}
