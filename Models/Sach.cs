using System;
using System.Collections.Generic;

namespace LAB5_HUYNHHUUNGHIA.Models;

public partial class Sach
{
    public string MaSach { get; set; } = null!;

    public int MaDs { get; set; }

    public int MaCn { get; set; }

    public string? TrangThai { get; set; }

    public virtual Chinhanh MaCnNavigation { get; set; } = null!;

    public virtual Dausach MaDsNavigation { get; set; } = null!;

    public virtual ICollection<Muonsach> Muonsaches { get; set; } = new List<Muonsach>();
}
