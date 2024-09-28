using Microsoft.AspNetCore.Mvc;
using static MagicEye2.Web.Utility.SD;

namespace MagicEye2.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data {  get; set; }
        public string AccesToken { get; set; }
    }
}
