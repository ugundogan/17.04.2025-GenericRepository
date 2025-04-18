using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class YayinEviRepository : BaseRepository<YayinEvi>
    {
        public YayinEviRepository(SahafDbContext context) : base(context)
        {
        }
    }
}
