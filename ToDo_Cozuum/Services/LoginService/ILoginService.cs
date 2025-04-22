using Microsoft.AspNetCore.Identity;
using ToDo_Cozuum.ViewModels;

namespace ToDo_Cozuum.Services.LoginService
{
    public interface ILoginService
    {
        void Register(Register_VM register);
        IdentityUser Login(Login_VM login);
    }
}
