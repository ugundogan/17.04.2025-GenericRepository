using ToDo_Cozuum.Data;
using ToDo_Cozuum.Models;

namespace ToDo_Cozuum.Repositories
{
    public class KategoriRepository : BaseRepository<Kategori>
    {
        public KategoriRepository(ToDooDbContext context) : base(context)
        {
        }
    }
}
