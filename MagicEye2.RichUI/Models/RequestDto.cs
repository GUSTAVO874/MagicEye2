
using static MagicEye2.RichUI.Utility.SD;

namespace MagicEye2.RichUI.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data {  get; set; }
        public string AccesToken { get; set; }
    }
}
