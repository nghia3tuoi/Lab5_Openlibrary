using System;
using System.Collections.Generic;

namespace LAB5_HUYNHHUUNGHIA.Models;

public partial class Yeucau
{
    public int MaYc { get; set; }

    public string? TenSach { get; set; }

    public string? TacGia { get; set; }

    public string? MaDg { get; set; }

    public virtual Docgium? MaDgNavigation { get; set; }
}
