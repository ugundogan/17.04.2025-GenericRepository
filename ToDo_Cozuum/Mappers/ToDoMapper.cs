using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ToDo_Cozuum.Models;
using ToDo_Cozuum.ViewModels;

namespace ToDo_Cozuum.Mappers
{
    public class ToDoMapper : Profile
    {
        public ToDoMapper()
        {
            CreateMap<IdentityUser, Register_VM>().ReverseMap();
            CreateMap<Eylem, EylemEkle_VM>().ReverseMap();
            CreateMap<Eylem, Eylem_VM>().ForMember(x => x.KategoriAdi, y => y.MapFrom(y => y.Kategori.KategoriAdi)).ReverseMap();
        }
    }
}
