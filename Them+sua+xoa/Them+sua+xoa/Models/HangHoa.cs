using System;

namespace Them_sua_xoa.Models
{
    public class HangHoaVN
    {
        public string tenHang { get; set; }
        public double donGia { get; set; }
    }

    public class HangHoa : HangHoaVN
    {
        public Guid maHang { get; set; }
    }
}
