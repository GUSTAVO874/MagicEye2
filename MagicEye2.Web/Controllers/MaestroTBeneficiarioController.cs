using MagicEye2.Web.Models;
using MagicEye2.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicEye2.Web.Controllers
{
    public class MaestroTBeneficiarioController : Controller
    {
        private readonly IMaestroTBeneficiario _maestroTBeneficiario;
        public MaestroTBeneficiarioController(IMaestroTBeneficiario maestroTBeneficiario)
        {
            _maestroTBeneficiario = maestroTBeneficiario;
        }
        [HttpPost]
        public async Task<IActionResult> MaestroTBeneficiarioCreate(MaestroTBeneficiarioDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _maestroTBeneficiario.CreateMaestroTBeneficiarioAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Coupon created successfully";
                    return RedirectToAction(nameof(MaestroTBeneficiarioIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }
        public async Task<IActionResult> MaestroTBeneficiarioIndex()
        {
            List<MaestroTBeneficiarioDto>? list = new();

            ResponseDto? response = await _maestroTBeneficiario.GetAllMaestroTBeneficiariosAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<MaestroTBeneficiarioDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
