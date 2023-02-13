using Microsoft.EntityFrameworkCore;

namespace lamlai.data
{
    public class myDBcontext:DbContext
    {
        public myDBcontext(DbContextOptions<myDBcontext> options) : base(options) { }

        #region DBset
        public DbSet<Nguoidung> nguoidungs { get; set; }
        public DbSet<HangHoa> hangHoas { get; set; }
        public DbSet<Loai> loais { get; set; }
        public DbSet<DonHang> donHang { get; set; }
        public DbSet<DonHangChitiet> DonHangChitiets { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDH);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
            });
            modelBuilder.Entity<DonHangChitiet>(Entity =>
            {
                Entity.ToTable("ChitietDonHang");
                Entity.HasKey(e => new { e.MaDH, e.Mahh });

                Entity.HasOne(e => e.DonHang)
                        .WithMany(e => e.DonHangChitiets)
                        .HasForeignKey(e => e.MaDH)
                        .HasConstraintName("FK_DonHangCT_DonHang");
                Entity.HasOne(e => e.HangHoa)
                          .WithMany(e => e.DonHangChitiets)
                         .HasForeignKey(e => e.Mahh)
                          .HasConstraintName("FK_DonHangCT_HangHoa");
            });
            modelBuilder.Entity<Nguoidung>(e =>
            {
                e.ToTable("NguoiDung");
                e.HasIndex(e => e.UseName).IsUnique();
                e.Property(e => e.hoTen).IsRequired().HasMaxLength(150);
            });
        }
    }
}
