namespace lamlai.Models
{
    public class HangHoaVN
    {
        public string tenhanghoa { get; set; }
        public double dongia { get; set; }

    }
    public class HangHoa : HangHoaVN
    {
        public Guid Mahanghoa { get; set; }
    }
    public class HangHoaModel
    {
        public Guid Mahanghoa { get; set; }
        public string tenhanghoa { get; set; }
        public double dongia { get; set; }
        public string tenloai { get; set; }
    }
}
