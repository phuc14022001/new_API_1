using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Them_sua_xoa.Models;

namespace Them_sua_xoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();
        [HttpGet]//lấy
        public IActionResult HienThi()
        {
            return Ok(hangHoas);
        }
        [HttpPost ]//thêm
        public IActionResult Create(HangHoaVN hangHoaVN)
        {
            var hangHoa = new HangHoa
            {
                maHang = Guid.NewGuid(),
                tenHang = hangHoaVN.tenHang,
                donGia= hangHoaVN.donGia
            };
            hangHoas.Add(hangHoa);
            return Ok(new{
                Success = true,Data = hangHoa
            });
        }
        [HttpGet("{id}")]
        public IActionResult TimKiem(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.maHang == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]//sửa
        public IActionResult sua(string id,HangHoa hanghoasua)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.maHang == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                if(id != hangHoa.maHang.ToString())
                {
                    return BadRequest();
                }
                hangHoa.tenHang = hanghoasua.tenHang;
                hangHoa.donGia = hanghoasua.donGia;
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]//xóa
        public IActionResult Xoa(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.maHang == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                hangHoas.Remove(hangHoa);
                return Ok(hangHoas);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
