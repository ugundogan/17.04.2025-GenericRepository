using ToDo_Cozuum.ViewModels;

namespace ToDo_Cozuum.Services.EylemService
{
    public interface IEylemService
    {
        void EylemEkle(EylemEkle_VM eylem);
        List<Eylem_VM> TumEylemler(string id);
    }
}
