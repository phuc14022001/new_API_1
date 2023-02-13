using System.ComponentModel.DataAnnotations;

namespace lamlai.Models
{
    public class loginmodel
    {
        [Required]
        [MaxLength(100)]
        public string UseName { get; set; }
        [Required]
        [MaxLength(20)]
        public string passWord { get; set; }
    }
}
