using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class TodoDbContext : IdentityDbContext<Uye, Rol, int>
    {
        public TodoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected TodoDbContext()
        {
        }

        public DbSet<Yapilacak> Yapilacaklar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
