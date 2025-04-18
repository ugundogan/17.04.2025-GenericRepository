using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class YapilacakGuncelleForm_VM
    {
        public SelectList Kategoriler { get; set; }
        public YapilacakGuncelle_VM Yapilacak { get; set; }
    }
}
