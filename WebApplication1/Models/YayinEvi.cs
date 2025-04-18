using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class YayinEvi
{
    public int YayinEviId { get; set; }

    public string YayinEviAdi { get; set; } = null!;

    public virtual ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
}
