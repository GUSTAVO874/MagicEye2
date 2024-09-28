using AutoMapper;
using MagicEye2.Services.BackEndAPI.Data;
using MagicEye2.Services.BackEndAPI.Models;
using MagicEye2.Services.BackEndAPI.Models.Dto;
//using MagicEye2.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public async Task<ResponseDto> PostAsync([FromBody] ExpedienteClienteDto expedienteclienteDto)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    //Expediente obj1 = _mapper.Map<Expediente>(expedienteclienteDto.Expediente);
                    //_db.Expedientes.Add(obj1);
                    //await _db.SaveChangesAsync();

                    //Cliente obj2 = _mapper.Map<Cliente>(expedienteclienteDto.Cliente);
                    //_db.Clientes.Add(obj2);
                    //await _db.SaveChangesAsync(); // Usa la versión asíncrona

                    //ExpedienteCliente obj3 = _mapper.Map<ExpedienteCliente>(expedienteclienteDto.ExpedienteCliente);
                    //_db.ExpedienteClientes.Add(obj3);
                    //await _db.SaveChangesAsync();

                    //await transaction.CommitAsync(); // Confirma la transacción


                    //_response.Result = expedienteclienteDto;
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
        
    }
}
