using AutoMapper;
using MagicEye2.Services.BackEndAPI.Data;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MagicEye2.Services.BackEndAPI.Models.Dto;
using MagicEye2.Services.BackEndAPI.Models;
using static Azure.Core.HttpHeader;
using Microsoft.AspNetCore.Authorization;

namespace MagicEye2.Services.BackEndAPI.Controllers
{
    [Route("api/maestrotbeneficiario")]
    [ApiController]
    [Authorize]
    public class MaestroTBeneficiarioAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public MaestroTBeneficiarioAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }
        //PLANTILLA
        [HttpPost("x")]
        public async Task<ResponseDto> PlantillaPost([FromBody] MaestroTBeneficiarioDto maestroTBeneficiarioDto)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {

                    await transaction.CommitAsync();
                    _response.Result = maestroTBeneficiarioDto;
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
        [HttpPost("maestrotbenef")]
        public async Task<ResponseDto> PostMB([FromBody] MaestroTBeneficiarioDto maestroTBeneficiarioDto)
        {
            //save de una sola entidad (sin claves foráneas)
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    // Map DTOs to domain models
                    MaestroTBeneficiario maestroTBeneficiario = _mapper.Map<MaestroTBeneficiario>(maestroTBeneficiarioDto);
                    _db.MaestroTBeneficiarios.Add(maestroTBeneficiario);
                    await _db.SaveChangesAsync();

                    await transaction.CommitAsync();
                    _response.Result = maestroTBeneficiarioDto;
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
        [HttpGet]
        [Authorize(Roles = "CUSTOMER")]
		public ResponseDto Get()
		{
			try
			{
				IEnumerable<MaestroTBeneficiario> objList = _db.MaestroTBeneficiarios.ToList();
				_response.Result = _mapper.Map<IEnumerable<MaestroTBeneficiarioDto>>(objList);
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
