using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.Models.Configurations
{
    public class Kategori_CFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasData(
                    new Kategori { KategoriID = 1, KategoriAd = "İş" },
                    new Kategori { KategoriID = 2, KategoriAd = "Ev" },
                    new Kategori { KategoriID = 3, KategoriAd = "HaftaSonu" }
                );
        }
    }
}
