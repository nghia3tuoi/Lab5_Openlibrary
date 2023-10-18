using System;
using System.Collections.Generic;

namespace LAB5_HUYNHHUUNGHIA.Models;

public partial class Chuyennganh
{
    public int MaCn { get; set; }

    public string? TenCn { get; set; }

    public virtual ICollection<Dausach> Dausaches { get; set; } = new List<Dausach>();
}
