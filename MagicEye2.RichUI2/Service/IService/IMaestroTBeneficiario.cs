using MagicEye2.RichUI2;
using MagicEye2.RichUI2.Models;

namespace MagicEye2.RichUI2.Service.IService
{
    public interface IMaestroTBeneficiario
    {
        Task<ResponseDto?> CreateMaestroTBeneficiarioAsync(MaestroTBeneficiarioDto maestroTBeneficiarioDto);
        Task<ResponseDto?> GetAllMaestroTBeneficiariosAsync();
    }
}
