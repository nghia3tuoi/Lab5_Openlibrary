using System;
using System.Collections.Generic;

namespace LAB5_HUYNHHUUNGHIA.Models;

public partial class Dausach
{
    public int MaDs { get; set; }

    public string? TenDs { get; set; }

    public string? Mota { get; set; }

    public int? SoLuong { get; set; }

    public string? TacGia { get; set; }

    public string? Nxb { get; set; }

    public int? NamXb { get; set; }

    public int? MaCn { get; set; }

    public virtual ICollection<Binhluan> Binhluans { get; set; } = new List<Binhluan>();

    public virtual Chuyennganh? MaCnNavigation { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
