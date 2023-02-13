using lamlai.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lamlai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IHangHoaReponsitory _hangHoaReponsitory;

        public ProductController(IHangHoaReponsitory hangHoaReponsitory) 
        {
            _hangHoaReponsitory = hangHoaReponsitory;
        }
        [HttpGet("{search}")]
        public IActionResult timkiem(string search)
        {
            try
            {
                var Resual = _hangHoaReponsitory.GetAll(search);
                return Ok(Resual);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
