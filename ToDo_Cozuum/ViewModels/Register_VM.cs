using System.ComponentModel.DataAnnotations;

namespace ToDo_Cozuum.ViewModels
{
    public class Register_VM
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
