using System;
using System.Collections.Generic;

namespace LAB5_HUYNHHUUNGHIA.Models;

public partial class Binhluan
{
    public string MaDg { get; set; } = null!;

    public int MaSach { get; set; }

    public string? NoiDung { get; set; }

    public int? Rating { get; set; }

    public virtual Docgium MaDgNavigation { get; set; } = null!;

    public virtual Dausach MaSachNavigation { get; set; } = null!;
}
