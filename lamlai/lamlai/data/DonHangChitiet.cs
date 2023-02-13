namespace lamlai.data
{
    public class DonHangChitiet
    {
        public Guid MaDH { get; set; }
        public Guid Mahh { get; set; }
        public int Soluongton { get; set; }
        public double Dongia { get; set; }
        public byte giamgia { get; set; }
        //relationship
        public DonHang DonHang { get; set; }
        public HangHoa HangHoa { get; set; }

    }
}
