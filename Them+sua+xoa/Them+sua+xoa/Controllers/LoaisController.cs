using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Expressions;
using Them_sua_xoa.Data;
using Them_sua_xoa.Models;

namespace Them_sua_xoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDbContext _context;
        public LoaisController (MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult hienthi()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }
        [HttpPost]
        public IActionResult Createnew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    tenLoai = model.tenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
                }
            catch
            {
                return BadRequest();
            }
            
        }
        [HttpGet("id")]
        public IActionResult tim(int id)
        {
            try
            {
                var loai = _context.Loais.SingleOrDefault(l => l.maLoai == id);
                if(loai != null)
                {
                    return Ok(loai);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("id")]
        public IActionResult sua(int id, LoaiModel model)
        {
            try
            {
                var loai = _context.Loais.SingleOrDefault(l => l.maLoai == id);
                if (loai != null)
                {
                    loai.tenLoai = model.tenLoai;
                    return Ok(loai);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("id")]
        public IActionResult xoa(int id)
        {
            try
            {
                var loai = _context.Loais.SingleOrDefault(l => l.maLoai == id);
                if (loai != null)
                {
                    _context.Remove(loai);
                    return Ok(_context);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
