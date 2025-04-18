
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Repositories
{
    public abstract class BaseRepository<TEntity> : ICRUD<TEntity> where TEntity : class

    {
        protected readonly SahafDbContext _context;
        protected readonly DbSet<TEntity> _table;

        protected BaseRepository(SahafDbContext context)
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

        public virtual List<TEntity> Listele()
        {
            return _table.ToList();
        }

        public void Sil(int id)
        {
            _table.Remove(Bul(id));
            _context.SaveChanges();
        }
    }
}
