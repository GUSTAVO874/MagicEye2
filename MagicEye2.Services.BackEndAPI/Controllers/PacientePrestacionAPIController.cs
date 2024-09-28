using AutoMapper;
using MagicEye2.Services.BackEndAPI.Data;
using MagicEye2.Services.BackEndAPI.Models;
using MagicEye2.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace MagicEye2.Services.BackEndAPI.Controllers
{
    [Route("api/pacienteprestacion")]
    [ApiController]
    public class PacientePrestacionAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public PacientePrestacionAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }
        
        //[HttpPost]
        //public ResponseDto Post([FromBody] PacientePrestacionDto pacienteprestacionDto)
        //{
            //try
            //{
            //    Coupon obj = _mapper.Map<Coupon>(couponDto);
            //    _db.Coupons.Add(obj);
            //    _db.SaveChanges();
            //    _response.Result = _mapper.Map<CouponDto>(obj);
            //}
            //catch (Exception ex)
            //{
            //    _response.IsSuccess = false;
            //    _response.Message = ex.Message;
            //}
            //return _response;
        //}
    }
}
