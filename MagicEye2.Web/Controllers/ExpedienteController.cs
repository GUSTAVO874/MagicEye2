using MagicEye2.Web.Models.Dto.Communications;
using MagicEye2.Web.Models.Dto.Expedientes;
using MagicEye2.Web.Service.ServicioExpediente;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace MagicEye2.Web.Controllers
{
    public class ExpedienteController : Controller
    {
        private readonly IExpedienteService _expedienteService;
        public ExpedienteController(IExpedienteService expedienteService)
        {
            _expedienteService = expedienteService;
        }
        //[HttpPost]
        //public async Task<IActionResult> ExpedienteCreate(ExpedienteDto expedienteDto) 
        //{
        //if (ModelState.IsValid)
        //{
        //    ResponseDto? response = await _expedienteService.CreateExpedienteAsync(expedienteDto);

        //    if (response != null && response.IsSuccess)
        //    {
        //        TempData["success"] = "Expediente creado";
        //        //return RedirectToAction(nameof(CouponIndex));
        //    }
        //    else
        //    {
        //        TempData["error"] = response?.Message;
        //    }
        //}
        //return View(expedienteDto);
        //return View();
        //}
        [HttpGet] // To show the form for creation
        public IActionResult ExpedienteCreate()
        {
            return View(new ExpedienteDto());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
