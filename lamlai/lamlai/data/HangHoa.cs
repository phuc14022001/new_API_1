using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lamlai.data
{
    [Table("hangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid Mahh { get; set; }
        [Required]  //bat buoc phai nhap
        [MaxLength(100)]
        public string tenhh { get; set; }
        public string Mota { get; set;}
        [Range(0, double.MaxValue)]
        public double dongia { get; set; }
        public byte giamgia { get; set; }

        public int? maloai { get; set; }
        [ForeignKey("maloai")]
        public Loai loai { get; set; }  //sau để đứng bên hàng có thể lấy ra mã loại
        public ICollection<DonHangChitiet> DonHangChitiets { get; set; }
        public HangHoa()
        {
            DonHangChitiets= new HashSet<DonHangChitiet>();
        }
    }
}
