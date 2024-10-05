
using MagicEye2.RichUI.Models;

namespace MagicEye2.RichUI.Service.IService
{
    public interface IBaseService
    {

        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
