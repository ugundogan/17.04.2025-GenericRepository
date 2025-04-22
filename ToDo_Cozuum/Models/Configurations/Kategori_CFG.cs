using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDo_Cozuum.Models.Configurations
{
    public class Kategori_CFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasData(
                    new Kategori { KategoriID = 1, KategoriAdi = "İş"},
                    new Kategori { KategoriID = 2, KategoriAdi = "Ev"},
                    new Kategori { KategoriID = 3, KategoriAdi = "HaftaSonu"}
                );
        }
    }
}
