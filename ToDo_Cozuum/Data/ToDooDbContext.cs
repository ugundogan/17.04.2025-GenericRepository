using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDo_Cozuum.Models;

namespace ToDo_Cozuum.Data
{
    public class ToDooDbContext : IdentityDbContext
    {
        public ToDooDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ToDooDbContext()
        {
        }

        public DbSet<Eylem> Eylemler{ get; set; }
        public DbSet<Kategori> Kategoriler{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
