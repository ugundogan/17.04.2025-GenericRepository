
using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Models
{
    public class Uye : IdentityUser<int>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public ICollection<Yapilacak>? Yapilacaklar { get; set; }
    }
}
