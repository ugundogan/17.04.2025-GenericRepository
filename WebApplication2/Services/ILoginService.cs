using WebApplication2.ViewModels;

namespace WebApplication2.Services
{
    public interface ILoginService
    {
        Task<bool> Login(Login_VM login);
        Task<bool> Register(Register_VM register);
        Task LogOut();
    }
}
