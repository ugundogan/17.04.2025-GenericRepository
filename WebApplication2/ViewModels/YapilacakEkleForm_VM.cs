using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.ViewModels
{
    public class YapilacakEkleForm_VM
    {
        public SelectList Kategoriler { get; set; }
        public YapilacakEkle_VM Yapilacak { get; set; }
    }
}
