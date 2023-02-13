
using lamlai.Models;

namespace lamlai.Service
{
    public interface IHangHoaReponsitory
    {
        List<HangHoaModel> GetAll(string search);
    }
}
