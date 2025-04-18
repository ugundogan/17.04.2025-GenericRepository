﻿using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class KategoriRepository : BaseRepository<Kategori>
    {
        public KategoriRepository(SahafDbContext context) : base(context)
        {
        }
    }
}
