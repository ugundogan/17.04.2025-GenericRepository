using AutoMapper;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.MapperClasses
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Kitap, KitapEkle_VM>().ReverseMap();
            CreateMap<Kitap, KitapDetay_VM>().ReverseMap();
            CreateMap<Kitap, KitapListe_VM>().ReverseMap();
        }
    }
}
