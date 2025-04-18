using AutoMapper;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.MapperClasses
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Yapilacak, YapilacakListe_VM>().ForMember(x => x.KategoriAd, y => y.MapFrom(z => z.Kategori.KategoriAd)).ReverseMap();
            CreateMap<Yapilacak, YapilacakEkle_VM>().ReverseMap();
            CreateMap<Yapilacak, YapilacakDetay_VM>().ForMember(x => x.KategoriAd, y => y.MapFrom(z => z.Kategori.KategoriAd)).ReverseMap();
            CreateMap<Yapilacak, YapilacakGuncelle_VM>().ReverseMap();

        }
    }
}
