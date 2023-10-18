using System;
using System.Collections.Generic;

namespace LAB5_HUYNHHUUNGHIA.Models;

public partial class Nhanvien
{
    public int MaNv { get; set; }

    public string? HoTenNv { get; set; }

    public string? Cmnd { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public byte[]? HinhAnh { get; set; }

    public int? MaCn { get; set; }

    public int? MaLoaiNv { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public virtual Chinhanh? MaCnNavigation { get; set; }

    public virtual Loainhanvien? MaLoaiNvNavigation { get; set; }
}
