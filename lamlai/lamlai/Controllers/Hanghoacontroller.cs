using lamlai.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lamlai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Hanghoacontroller : ControllerBase
    {
        public static List<HangHoa> hanghoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult hienthi()
        {
            return Ok(hanghoas);
        }
        [HttpPost]
        public IActionResult them(HangHoaVN hangHoaVN)
        {
            var hanghoa = new HangHoa
            {
                Mahanghoa = Guid.NewGuid(),
                tenhanghoa = hangHoaVN.tenhanghoa,
                dongia = hangHoaVN.dongia
            };

            hanghoas.Add(hanghoa);
            return Ok(hanghoas);
        }
        [HttpGet("{id}")]
        public IActionResult timkiem(string id)
        {
            try {
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.Mahanghoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult sua(string id, HangHoa suahanghoa)
        {
            try
            {
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.Mahanghoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                else
                {
                    hanghoa.tenhanghoa= suahanghoa.tenhanghoa;
                    hanghoa.dongia = suahanghoa.dongia;
                    return Ok(hanghoa);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("id")]
        public IActionResult delete(string id)
        {
            try
            {
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.Mahanghoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                hanghoas.Remove(hanghoa);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }



    }
}
