using MagicEye2.Web.Models.Dto.Communications;
using MagicEye2.Web.Models.Dto.Expedientes;

namespace MagicEye2.Web.Service.ServicioExpediente
{
    public interface IExpedienteService
    {
        Task<ResponseDto?> CreateExpedienteAsync(ExpedienteDto expedienteDto);
    }
}
