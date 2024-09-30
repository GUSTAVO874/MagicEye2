using MagicEye2.Web.Models;
using MagicEye2.Web.Service.IService;
using MagicEye2.Web.Utility;

namespace MagicEye2.Web.Service
{
    public class MaestroTBeneficiarioService : IMaestroTBeneficiario
    {
        private readonly IBaseService _baseService;
        public MaestroTBeneficiarioService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateMaestroTBeneficiarioAsync(MaestroTBeneficiarioDto maestroTBeneficiarioDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = maestroTBeneficiarioDto,
                Url = SD.MaestroTBeneficiarioAPIBase + "/api/maestrotbeneficiario"
            });
        }

        public async Task<ResponseDto?> GetAllMaestroTBeneficiariosAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.MaestroTBeneficiarioAPIBase + "/api/maestrotbeneficiario"
            });
        }
    }
}
