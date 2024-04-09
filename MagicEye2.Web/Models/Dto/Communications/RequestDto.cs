using System.Net.Mime;
using System.Security.AccessControl;
using static MagicEye2.Web.Utility.SD;

namespace MagicEye2.Web.Models.Dto.Communications
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

        public TipoContent TipoContent { get; set; } = TipoContent.Json;
    }
}
