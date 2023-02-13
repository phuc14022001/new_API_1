using lamlai.data;
using lamlai.Models;

namespace lamlai.Service
{
    public class LoaiRepository : Iloai
    {
        private myDBcontext _context;

        public LoaiRepository(myDBcontext context)
        {
            _context = context;
        }
        
        public LoaiVN Add(LoaiModels loai)
        {
            var _loai = new Loai {

                matenloai = loai.matenloai
            };
            _context.Add(loai);
            _context.SaveChanges();
            return new LoaiVN
            {
                maloai=_loai.maloai,
                matenloai=_loai.matenloai
            };
        }

        public List<LoaiVN> GetAll()
        {
            var loais = _context.loais.Select(lo => new LoaiVN
            {
                maloai = lo.maloai,
                matenloai= lo.matenloai
            });

            return loais.ToList();
        }

        public LoaiVN GetById(int id)
        {
            var loai = _context.loais.SingleOrDefault(lo => lo.maloai== id);
            if(loai != null) { return new LoaiVN{
                    maloai = loai.maloai,
                    matenloai= loai.matenloai
                };
            }
            return null;
        }

        public void Remote(int id)
        {
            var loai = _context.loais.SingleOrDefault(lo => lo.maloai == id);
            if (loai != null)
            {
         
                _context.Remove(loai);
                _context.SaveChanges();
            }
            
        }

        public void Update(LoaiVN loai)
        {
            var _loai = _context.loais.SingleOrDefault(lo => lo.maloai == loai.maloai);
            loai.matenloai = loai.matenloai;
            _context.SaveChanges();
            
        }
    }
}
