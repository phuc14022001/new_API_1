
using lamlai.data;
using lamlai.Models;

namespace lamlai.Service
{
    public class HangHoaRepositormemor : IHangHoaReponsitory
    {
        private myDBcontext _context;

        public HangHoaRepositormemor(myDBcontext context) 
        { 
            _context= context;
        }

        public List<HangHoaModel> GetAll(string search)
        {
            var all = _context.hangHoas.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                all = all.Where(hh => hh.tenhh.Contains(search));
            }
            var resual = all.Select(hh => new HangHoaModel
            {
                Mahanghoa= hh.Mahh,
                tenhanghoa= hh.tenhh,
                dongia=hh.dongia,
                tenloai=hh.loai.matenloai
            });
            return resual.ToList();
        }
    }
}
