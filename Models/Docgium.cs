using System;
using System.Collections.Generic;

namespace LAB5_HUYNHHUUNGHIA.Models;

public partial class Docgium
{
    public string MaDg { get; set; } = null!;

    public string? HoTenDg { get; set; }

    public string? Cmnd { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public string? UserName { get; set; }

    public string? HashPass { get; set; }

    public int? MaLoaiDg { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<Binhluan> Binhluans { get; set; } = new List<Binhluan>();

    public virtual Loaidocgium? MaLoaiDgNavigation { get; set; }

    public virtual ICollection<Muonsach> Muonsaches { get; set; } = new List<Muonsach>();

    public virtual ICollection<Yeucau> Yeucaus { get; set; } = new List<Yeucau>();
}
