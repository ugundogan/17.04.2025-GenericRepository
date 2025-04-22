using Microsoft.EntityFrameworkCore;
using ToDo_Cozuum.Abstracts;
using ToDo_Cozuum.Data;

namespace ToDo_Cozuum.Repositories
{
    public abstract class BaseRepository<TEntity> : ICRUD<TEntity> where TEntity : class
    {
        protected readonly ToDooDbContext _context;
        protected readonly DbSet<TEntity> _table;

        public BaseRepository(ToDooDbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public TEntity Bul(int id)
        {
            return _table.Find(id);
        }

        public void Ekle(TEntity entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Guncelle(TEntity entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
        }

        public List<TEntity> Listele()
        {
            return _table.ToList();
        }

        

        public void Sil(int id)
        {
            _table.Remove(Bul(id));
        }
    }
}
