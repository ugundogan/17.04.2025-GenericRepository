using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.ViewModels
{
    public class KitapEkleForm_VM
    {
        public SelectList Kategoriler{ get; set; }
        public SelectList Yazarlar{ get; set; }
        public SelectList YayinEvleri{ get; set; }
        public KitapEkle_VM Kitap { get; set; }
    }
}
