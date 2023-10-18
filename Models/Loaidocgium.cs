using System;
using System.Collections.Generic;

namespace LAB5_HUYNHHUUNGHIA.Models;

public partial class Loaidocgium
{
    public int MaLoaiDg { get; set; }

    public string? TenLoaiDg { get; set; }

    public virtual ICollection<Docgium> Docgia { get; set; } = new List<Docgium>();
}
