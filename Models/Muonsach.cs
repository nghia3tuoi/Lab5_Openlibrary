using System;
using System.Collections.Generic;

namespace LAB5_HUYNHHUUNGHIA.Models;

public partial class Muonsach
{
    public string MaDg { get; set; } = null!;

    public string MaSach { get; set; } = null!;

    public DateTime NgayMuon { get; set; }

    public DateTime? NgayDenHanTra { get; set; }

    public string? TinhTrang { get; set; }

    public virtual Docgium MaDgNavigation { get; set; } = null!;

    public virtual Sach MaSachNavigation { get; set; } = null!;
}
