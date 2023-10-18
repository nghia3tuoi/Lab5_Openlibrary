using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LAB5_HUYNHHUUNGHIA.Models;

public partial class OpenlibraryContext : DbContext
{
    public OpenlibraryContext()
    {
    }

    public OpenlibraryContext(DbContextOptions<OpenlibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Binhluan> Binhluans { get; set; }

    public virtual DbSet<Chinhanh> Chinhanhs { get; set; }

    public virtual DbSet<Chuyennganh> Chuyennganhs { get; set; }

    public virtual DbSet<Dausach> Dausaches { get; set; }

    public virtual DbSet<Docgium> Docgia { get; set; }

    public virtual DbSet<Loaidocgium> Loaidocgia { get; set; }

    public virtual DbSet<Loainhanvien> Loainhanviens { get; set; }

    public virtual DbSet<Muonsach> Muonsaches { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<Yeucau> Yeucaus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=./;Initial Catalog=OPENLIBRARY;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Binhluan>(entity =>
        {
            entity.HasKey(e => new { e.MaDg, e.MaSach });

            entity.ToTable("BINHLUAN");

            entity.Property(e => e.MaDg)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaDG");
            entity.Property(e => e.NoiDung).HasMaxLength(50);

            entity.HasOne(d => d.MaDgNavigation).WithMany(p => p.Binhluans)
                .HasForeignKey(d => d.MaDg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BINHLUAN_DOCGIA");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.Binhluans)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BINHLUAN_SACH");
        });

        modelBuilder.Entity<Chinhanh>(entity =>
        {
            entity.HasKey(e => e.MaCn);

            entity.ToTable("CHINHANH");

            entity.Property(e => e.MaCn).HasColumnName("MaCN");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.TenCn)
                .HasMaxLength(50)
                .HasColumnName("TenCN");
        });

        modelBuilder.Entity<Chuyennganh>(entity =>
        {
            entity.HasKey(e => e.MaCn).HasName("PK_LOAISACH");

            entity.ToTable("CHUYENNGANH");

            entity.Property(e => e.MaCn).HasColumnName("MaCN");
            entity.Property(e => e.TenCn)
                .HasMaxLength(50)
                .HasColumnName("TenCN");
        });

        modelBuilder.Entity<Dausach>(entity =>
        {
            entity.HasKey(e => e.MaDs).HasName("PK_SACH");

            entity.ToTable("DAUSACH");

            entity.Property(e => e.MaDs).HasColumnName("MaDS");
            entity.Property(e => e.MaCn).HasColumnName("MaCN");
            entity.Property(e => e.Mota).HasMaxLength(50);
            entity.Property(e => e.NamXb).HasColumnName("NamXB");
            entity.Property(e => e.Nxb)
                .HasMaxLength(50)
                .HasColumnName("NXB");
            entity.Property(e => e.TacGia).HasMaxLength(50);
            entity.Property(e => e.TenDs)
                .HasMaxLength(50)
                .HasColumnName("TenDS");

            entity.HasOne(d => d.MaCnNavigation).WithMany(p => p.Dausaches)
                .HasForeignKey(d => d.MaCn)
                .HasConstraintName("FK_SACH_LOAISACH");
        });

        modelBuilder.Entity<Docgium>(entity =>
        {
            entity.HasKey(e => e.MaDg);

            entity.ToTable("DOCGIA");

            entity.Property(e => e.MaDg)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaDG");
            entity.Property(e => e.Cmnd)
                .HasMaxLength(50)
                .HasColumnName("CMND");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HashPass).HasMaxLength(50);
            entity.Property(e => e.HoTenDg)
                .HasMaxLength(50)
                .HasColumnName("HoTenDG");
            entity.Property(e => e.MaLoaiDg).HasColumnName("MaLoaiDG");
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
            entity.Property(e => e.TrangThai).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.MaLoaiDgNavigation).WithMany(p => p.Docgia)
                .HasForeignKey(d => d.MaLoaiDg)
                .HasConstraintName("FK_DOCGIA_LOAIDOCGIA1");
        });

        modelBuilder.Entity<Loaidocgium>(entity =>
        {
            entity.HasKey(e => e.MaLoaiDg);

            entity.ToTable("LOAIDOCGIA");

            entity.Property(e => e.MaLoaiDg).HasColumnName("MaLoaiDG");
            entity.Property(e => e.TenLoaiDg)
                .HasMaxLength(50)
                .HasColumnName("TenLoaiDG");
        });

        modelBuilder.Entity<Loainhanvien>(entity =>
        {
            entity.HasKey(e => e.MaLoaiNv);

            entity.ToTable("LOAINHANVIEN");

            entity.Property(e => e.MaLoaiNv).HasColumnName("MaLoaiNV");
            entity.Property(e => e.TenLoaiNv)
                .HasMaxLength(50)
                .HasColumnName("TenLoaiNV");
        });

        modelBuilder.Entity<Muonsach>(entity =>
        {
            entity.HasKey(e => new { e.MaDg, e.MaSach, e.NgayMuon });

            entity.ToTable("MUONSACH");

            entity.Property(e => e.MaDg)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaDG");
            entity.Property(e => e.MaSach)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.NgayMuon).HasColumnType("datetime");
            entity.Property(e => e.NgayDenHanTra).HasColumnType("datetime");
            entity.Property(e => e.TinhTrang).HasMaxLength(50);

            entity.HasOne(d => d.MaDgNavigation).WithMany(p => p.Muonsaches)
                .HasForeignKey(d => d.MaDg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MUONSACH_DOCGIA");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.Muonsaches)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MUONSACH_SACHCHINHANH");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.MaNv);

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.Cmnd)
                .HasMaxLength(50)
                .HasColumnName("CMND");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HinhAnh).HasColumnType("image");
            entity.Property(e => e.HoTenNv)
                .HasMaxLength(50)
                .HasColumnName("HoTenNV");
            entity.Property(e => e.MaCn).HasColumnName("MaCN");
            entity.Property(e => e.MaLoaiNv).HasColumnName("MaLoaiNV");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.MaCnNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.MaCn)
                .HasConstraintName("FK_NHANVIEN_CHINHANH");

            entity.HasOne(d => d.MaLoaiNvNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.MaLoaiNv)
                .HasConstraintName("FK_NHANVIEN_LOAINHANVIEN");
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.MaSach).HasName("PK_SACHCHINHANH_1");

            entity.ToTable("SACH");

            entity.Property(e => e.MaSach)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.MaCn).HasColumnName("MaCN");
            entity.Property(e => e.MaDs).HasColumnName("MaDS");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaCnNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaCn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DAUSACH_CHINHANH");

            entity.HasOne(d => d.MaDsNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaDs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DAUSACH_SACH");
        });

        modelBuilder.Entity<Yeucau>(entity =>
        {
            entity.HasKey(e => e.MaYc).HasName("PK_YEUCAU_1");

            entity.ToTable("YEUCAU");

            entity.Property(e => e.MaYc).HasColumnName("MaYC");
            entity.Property(e => e.MaDg)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MaDG");
            entity.Property(e => e.TacGia).HasMaxLength(50);
            entity.Property(e => e.TenSach).HasMaxLength(50);

            entity.HasOne(d => d.MaDgNavigation).WithMany(p => p.Yeucaus)
                .HasForeignKey(d => d.MaDg)
                .HasConstraintName("FK_YEUCAU_DOCGIA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
