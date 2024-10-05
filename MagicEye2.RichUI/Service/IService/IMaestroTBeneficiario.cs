using MagicEye2.RichUI.Models;

namespace MagicEye2.RichUI.Service.IService
{
    public interface IMaestroTBeneficiario
    {
        Task<ResponseDto?> CreateMaestroTBeneficiarioAsync(MaestroTBeneficiarioDto maestroTBeneficiarioDto);
        Task<ResponseDto?> GetAllMaestroTBeneficiariosAsync();
    }
}
