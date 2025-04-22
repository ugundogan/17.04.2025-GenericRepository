using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ToDo_Cozuum.ViewModels;

namespace ToDo_Cozuum.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public LoginService(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public IdentityUser Login(Login_VM login)
        {
            var user = _userManager.FindByNameAsync(login.UserName).Result;
            if (user != null)
            {
                if (_userManager.CheckPasswordAsync(user, login.Password).Result)
                {
                    return user;
                }
            }
            return null;
        }

        public void Register(Register_VM register)
        {
            IdentityUser newUser = new IdentityUser();
            _mapper.Map(register, newUser);
            var result = _userManager.CreateAsync(newUser, register.Password).Result;

        }
    }
}
