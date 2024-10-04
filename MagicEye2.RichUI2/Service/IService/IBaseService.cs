//using MagicEye2.RichUI2;

//using MagicEye2.RichUI2;
using MagicEye2.RichUI2.Models;

namespace MagicEye2.RichUI2.Service.IService
{
    public interface IBaseService
    {

        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
