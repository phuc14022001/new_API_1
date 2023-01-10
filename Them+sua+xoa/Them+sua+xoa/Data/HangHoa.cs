using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Them_sua_xoa.Data
{
    public class HangHoa
    {
        [Key]
        public Guid maHang { get; set; }
        [Required]
        [MaxLength(100)]
        public string tenHang { get; set; }

        public string moTa { get; set; }

        [Range(0,double.MaxValue)] 
        public double donGia { get; set; }
        public byte giamGia { get; set; }
        public int? maLoai { get; set; }
        [ForeignKey("maLoai")]
        public Loai Loai { get; set; }
    }
}
