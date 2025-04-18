using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class KategoriRepository : BaseRepository<Kategori>
    {
        public KategoriRepository(TodoDbContext context) : base(context)
        {
        }
    }
}
