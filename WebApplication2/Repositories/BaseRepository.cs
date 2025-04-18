
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

namespace WebApplication2.Repositories
{
    public abstract class BaseRepository<TEntity> : ICRUD<TEntity> where TEntity : class
    {
        protected readonly TodoDbContext _context;
        protected readonly DbSet<TEntity> _table;

        protected BaseRepository(TodoDbContext context)
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

        public IQueryable<TEntity> ListeleQuery()
        {
            return _table;
        }

        public void Sil(int id)
        {
            _table.Remove(Bul(id));
            _context.SaveChanges();

        }
    }
}
