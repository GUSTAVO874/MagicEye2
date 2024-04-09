using MagicEye2.Web.Models.Dto.Communications;
using MagicEye2.Web.Models.Dto.Expedientes;
using MagicEye2.Web.Service.ServicioBase;
using MagicEye2.Web.Utility;

namespace MagicEye2.Web.Service.ServicioExpediente
{
    public class ExpedienteService : IExpedienteService
    {
        private readonly IBaseService _baseService;
        public ExpedienteService(IBaseService baseService) 
        {
            _baseService = baseService;
        }  
        public async Task<ResponseDto?> CreateExpedienteAsync(ExpedienteDto expedienteDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = expedienteDto,
                Url = SD.ExpedienteAPIBase + "api/expediente"
            });
            //throw new NotImplementedException();
        }
    }
}
