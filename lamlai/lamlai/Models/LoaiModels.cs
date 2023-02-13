using System.ComponentModel.DataAnnotations;

namespace lamlai.Models
{
    public class LoaiModels
    {
        [Required]
        [MaxLength(100)]
        public string matenloai { get; set; }
    }
}
