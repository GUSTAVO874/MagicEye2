using AutoMapper;
using MagicEye2.Services.BackEndAPI.Data;
using MagicEye2.Services.BackEndAPI.Models;
using MagicEye2.Services.BackEndAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicEye2.Services.BackEndAPI.Controllers
{
    [Route("api/expedientecliente")]
    [ApiController]
    public class ExpedienteClienteAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public ExpedienteClienteAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }
        [HttpPost("operacioncompleta")]
        public async Task<ResponseDto> PostAsync([FromBody] ExpedienteClienteDto expedienteclienteDto)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    //post muchos a muchos incluyendo tabla intermedia en una sola operación
                    
                    // Map DTOs to domain models
                    Expediente expediente = _mapper.Map<Expediente>(expedienteclienteDto.Expediente);
                    Cliente cliente = _mapper.Map<Cliente>(expedienteclienteDto.Cliente);

                    // Add Expediente and Cliente to the context
                    _db.Expedientes.Add(expediente);
                    _db.Clientes.Add(cliente);
                    await _db.SaveChangesAsync();

                    // Create the ExpedienteCliente link
                    ExpedienteCliente expedienteCliente = new ExpedienteCliente
                    {
                        ExpedienteId = expediente.ExpedienteId,
                        ClienteId = cliente.ClienteId
                    };
                    _db.ExpedienteClientes.Add(expedienteCliente);
                    await _db.SaveChangesAsync();

                    await transaction.CommitAsync();

                    _response.Result = expedienteclienteDto;
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

        [HttpPost("relacionar")]
        public async Task<ResponseDto> RelateAsync([FromBody] ExpedienteClienteDto expedienteClienteDto)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                //post para solamente relacionar dos entidades de una relación muchos a 
                //muchos proveyendo los Ids, guarda los Ids en tabla intermedia
                //útil cuando las entidades a relacionarse se crean por separado en tiempos diferentes
                try
                {
                    // Check if Expediente and Cliente exist
                    var expedienteExists = await _db.Expedientes.AnyAsync(e => e.ExpedienteId == expedienteClienteDto.Expediente.ExpedienteId);
                    var clienteExists = await _db.Clientes.AnyAsync(c => c.ClienteId == expedienteClienteDto.Cliente.ClienteId);

                    if (!expedienteExists || !clienteExists)
                    {
                        _response.IsSuccess = false;
                        _response.Message = "Expediente or Cliente does not exist.";
                        return _response;
                    }

                    // Create the ExpedienteCliente link
                    var expedienteCliente = new ExpedienteCliente
                    {
                        ExpedienteId = expedienteClienteDto.Expediente.ExpedienteId,
                        ClienteId = expedienteClienteDto.Cliente.ClienteId
                    };
                    _db.ExpedienteClientes.Add(expedienteCliente);
                    await _db.SaveChangesAsync();

                    await transaction.CommitAsync();

                    _response.Result = expedienteClienteDto;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _response.Message = ex.Message;
                    _response.IsSuccess = false;
                }
                return _response;
            }
        }
    }
}