using System;
using System.Collections.Generic;

namespace LAB5_HUYNHHUUNGHIA.Models;

public partial class Loainhanvien
{
    public int MaLoaiNv { get; set; }

    public string? TenLoaiNv { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}
