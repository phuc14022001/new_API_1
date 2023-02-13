using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lamlai.data
{
    [Table("loai")]
    public class Loai
    {
        [Key]
        public int maloai { get; set; }
        [Required]
        [MaxLength(100)]
        public string matenloai { get; set; }
        public virtual ICollection<HangHoa> HangHoas { get; set; } // để tạo ra quan hệ 1-n
        
    }
}
