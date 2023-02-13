using lamlai.Models;

namespace lamlai.Service
{
    public interface Iloai
    {
        List<LoaiVN> GetAll();
        LoaiVN GetById(int id);
        LoaiVN Add (LoaiModels loai);
        void Update(LoaiVN loai);
        void Remote(int id);
    }
}
