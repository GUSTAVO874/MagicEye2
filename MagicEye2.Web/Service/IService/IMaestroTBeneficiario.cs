using MagicEye2.Web.Models;

namespace MagicEye2.Web.Service.IService
{
    public interface IMaestroTBeneficiario
    {
        Task<ResponseDto?> CreateMaestroTBeneficiarioAsync(MaestroTBeneficiarioDto maestroTBeneficiarioDto);
        Task<ResponseDto?> GetAllMaestroTBeneficiariosAsync();
    }
}
