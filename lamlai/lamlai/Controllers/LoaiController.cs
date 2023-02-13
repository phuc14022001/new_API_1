using lamlai.data;
using lamlai.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace lamlai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly myDBcontext _context;

        public LoaiController(myDBcontext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult hienthi()
        {
            try
            {
                var dsloai = _context.loais.ToList();
                return Ok(dsloai);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult tim(int id)
        {
            try
            {
                var loai = _context.loais.SingleOrDefault(lo => lo.maloai == id);
                if (loai == null)
                {
                    return NotFound();
                }
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult them(LoaiModels model)
        {
            try
            {
                var loai = new Loai
                {
                    matenloai = model.matenloai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, loai);
            }
            catch
            {
                return BadRequest();
            }               
        }
        [HttpPut("{id}")]
        public IActionResult sua(int id,LoaiModels model)
        {
            try
            {
                var loai = _context.loais.SingleOrDefault(lo => lo.maloai == id);
                if (loai == null)
                {
                    return NotFound();
                }
                loai.matenloai = model.matenloai;
                
                _context.SaveChanges();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
       [HttpDelete("{id}")]
        public IActionResult xoa(int id)
        {
            try
            {
                var loai = _context.loais.SingleOrDefault(lo => lo.maloai == id);
                if (loai == null)
                {
                    return NotFound();
                }
                _context.Remove(loai);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
