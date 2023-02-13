using lamlai.data;
using lamlai.Models;

namespace lamlai.Service
{
    public class LoaireponsitoryinMemory : Iloai
    {
        static List<LoaiVN> loaiVNs = new List<LoaiVN> {
            new LoaiVN { maloai = 1, matenloai = "tivi" },
            new LoaiVN { maloai = 2, matenloai = "tu lanh" },
            new LoaiVN { maloai = 3, matenloai = "máy giặt" },
            new LoaiVN { maloai = 4, matenloai = "điều hòa" }
        };
        public LoaiVN Add(LoaiModels loai)
        {
            var _loai = new LoaiVN
            {
                maloai = loaiVNs.Max(lo => lo.maloai),
                matenloai = loai.matenloai
            };
            loaiVNs.Add(_loai);
            return _loai;
        }


        public LoaiVN GetById(int id)
        {
            return loaiVNs.SingleOrDefault(lo => lo.maloai == id);
        }


        public void Remote(int id)
        {
            var _loai = loaiVNs.SingleOrDefault(lo => lo.maloai == id);
            loaiVNs.Remove(_loai);
        }

        public void Update(LoaiVN loai)
        {
           var _loai = loaiVNs.SingleOrDefault(lo => lo.maloai == loai.maloai);
            if(_loai != null)
            {
                _loai.matenloai=loai.matenloai;

            }
        }

        public List<LoaiVN> GetAll()
        {
            return loaiVNs;
        }
    }
}
