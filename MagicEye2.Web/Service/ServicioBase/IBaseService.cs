using MagicEye2.Web.Models.Dto.Communications;

namespace MagicEye2.Web.Service.ServicioBase
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
