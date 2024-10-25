using MagicEye2.Web.Models;

namespace MagicEye2.Web.Service.IService
{
    public interface IBaseService
    {

        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
    }
}
