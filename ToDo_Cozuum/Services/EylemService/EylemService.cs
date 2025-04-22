using AutoMapper;
using System.Runtime.InteropServices;
using ToDo_Cozuum.Models;
using ToDo_Cozuum.Repositories;
using ToDo_Cozuum.ViewModels;

namespace ToDo_Cozuum.Services.EylemService
{
    public class EylemService : IEylemService
    {
        private readonly EylemRepository _eylemRepository;
        private readonly IMapper _mapper;

        public EylemService(EylemRepository eylemRepository)
        {
            _eylemRepository = eylemRepository;
        }

        public void EylemEkle(EylemEkle_VM eylem)
        {
            Eylem yeniEylem = _mapper.Map<Eylem>(eylem);
            _eylemRepository.Ekle(yeniEylem);
        }

        public List<Eylem_VM> TumEylemler(string id)
        {
            return _eylemRepository.Listele(id);
        }
    }
}
