using System.ComponentModel.DataAnnotations;

namespace Them_sua_xoa.Models
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(50)]
        public string tenLoai { get; set; }
    }
}
