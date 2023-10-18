using System;
using System.Collections.Generic;

namespace LAB5_HUYNHHUUNGHIA.Models;

public partial class Chinhanh
{
    public int MaCn { get; set; }

    public string? TenCn { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
