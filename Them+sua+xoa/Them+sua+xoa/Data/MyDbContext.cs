using Microsoft.EntityFrameworkCore;

namespace Them_sua_xoa.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        #endregion
        public DbSet<Loai> Loais { get; set; }
    }
}
