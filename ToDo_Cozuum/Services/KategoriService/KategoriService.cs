using ToDo_Cozuum.Models;
using ToDo_Cozuum.Repositories;

namespace ToDo_Cozuum.Services.KategoriService
{
    public class KategoriService : IKategoriService
    {
        private readonly KategoriRepository _kategoriRepository;

        public KategoriService(KategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }

        public List<Kategori> TumKategoriler()
        {
            return _kategoriRepository.Listele();
        }
    }
}
