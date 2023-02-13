namespace lamlai.data
{
    public enum TinhtrangĐonathang
    {
        tao= 0, DTT = 1, complete=2, cancel=-1
    }
    public class DonHang
    {
        public Guid MaDH { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime? NgayDatGiao { get;}
        public TinhtrangĐonathang Tinhtrang { get; set; }
        public string nguoinhan { get; set; }
        public string diachi { get; set; }
        public string SoDT { get; set; }
        public ICollection<DonHangChitiet> DonHangChitiets { get; set; }
        public DonHang()
        {
            DonHangChitiets = new HashSet<DonHangChitiet>();
        }
    }
}
