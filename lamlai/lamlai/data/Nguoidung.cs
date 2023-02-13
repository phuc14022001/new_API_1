using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lamlai.data
{
    [Table("NguoiDung")]
    public class Nguoidung
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string UseName { get; set; }
        [Required]
        [MaxLength(20)]
        public string passWord { get; set; }
        public string hoTen { get; set; }
        [Required]
        [MaxLength(50)]
        public string email { get; set; }
    }
}
