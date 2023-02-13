using lamlai.data;
using lamlai.Models;
using lamlai.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace lamlai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly Iloai _Iloai;

        public LoaisController(Iloai Iloai) {
            _Iloai = Iloai;
        }
        [HttpGet] 
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_Iloai.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")] 
        public IActionResult GetById(int id) 
        {
            try
            {
                var data = _Iloai.GetById(id);
                if(data == null) { return NotFound(); }
                return Ok(_Iloai.GetById(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,LoaiVN loaiVN)
        {
            if (id != loaiVN.maloai) return BadRequest();
            try
            {
                 _Iloai.Update(loaiVN);
                return NoContent(); // thông báo thành công và trả về kết quả ( 204 )
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            } 
        }
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            try
            {
                _Iloai.Remote(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
                public IActionResult Add(LoaiModels loai)
        {
            try
            {
                
                return Ok(_Iloai.Add(loai)); 
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
