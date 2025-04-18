using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Yazar
{
    public int YazarId { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string Biyografi { get; set; } = null!;

    public virtual ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
}
