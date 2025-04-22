using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDo_Cozuum.ViewModels
{
    public class EylemEkleForm_VM
    {
        public SelectList Kategoriler{ get; set; }
        public EylemEkle_VM Eylem{ get; set; }
    }
}
