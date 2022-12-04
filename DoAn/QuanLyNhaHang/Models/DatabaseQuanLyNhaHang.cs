using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyNhaHang.Models
{
    public partial class DatabaseQuanLyNhaHang : DbContext
    {
        public DatabaseQuanLyNhaHang()
            : base("name=DatabaseQuanLyNhaHang")
        {
        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
        public virtual DbSet<ChiTietSanPham> ChiTietSanPham { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<HoanTra> HoanTra { get; set; }
        public virtual DbSet<Khu> Khu { get; set; }
        public virtual DbSet<LichSuGoiMon> LichSuGoiMon { get; set; }
        public virtual DbSet<LoaiMonAn> LoaiMonAn { get; set; }
        public virtual DbSet<LoaiNguyenLieu> LoaiNguyenLieu { get; set; }
        public virtual DbSet<MonAn> MonAn { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieu { get; set; }
        public virtual DbSet<NguyenLieuTra> NguyenLieuTra { get; set; }
        public virtual DbSet<NguyenLieuXuat> NguyenLieuXuat { get; set; }
        public virtual DbSet<NhaCC> NhaCC { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<NhanVienChayBan> NhanVienChayBan { get; set; }
        public virtual DbSet<NhomMonAn> NhomMonAn { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhap { get; set; }
        public virtual DbSet<Quyen> Quyen { get; set; }
        public virtual DbSet<Tang> Tang { get; set; }
        public virtual DbSet<XuatKho> XuatKho { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDon>()
                .Property(e => e.SDTKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDon)
                .WithRequired(e => e.HoaDon)
                .HasForeignKey(e => e.MaHoaDon_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.LichSuGoiMon)
                .WithOptional(e => e.HoaDon)
                .HasForeignKey(e => e.MaHoaDon_id);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.NhanVienChayBan)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoanTra>()
                .HasMany(e => e.NguyenLieuTra)
                .WithRequired(e => e.HoanTra)
                .HasForeignKey(e => e.MaHoanTra_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Khu>()
                .HasMany(e => e.Tang)
                .WithOptional(e => e.Khu)
                .HasForeignKey(e => e.MaTang_id);

            modelBuilder.Entity<LoaiMonAn>()
                .HasMany(e => e.MonAn)
                .WithOptional(e => e.LoaiMonAn)
                .HasForeignKey(e => e.MaLMA_id);

            modelBuilder.Entity<LoaiNguyenLieu>()
                .HasMany(e => e.NguyenLieu)
                .WithOptional(e => e.LoaiNguyenLieu)
                .HasForeignKey(e => e.MaLNL_id);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.ChiTietHoaDon)
                .WithRequired(e => e.MonAn)
                .HasForeignKey(e => e.MaMonAn_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.ChiTietSanPham)
                .WithRequired(e => e.MonAn)
                .HasForeignKey(e => e.MaMonAn_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonAn>()
                .HasMany(e => e.LichSuGoiMon)
                .WithOptional(e => e.MonAn)
                .HasForeignKey(e => e.MaMonAn_id);

            modelBuilder.Entity<NguyenLieu>()
                .HasMany(e => e.ChiTietPhieuNhap)
                .WithRequired(e => e.NguyenLieu)
                .HasForeignKey(e => e.MaNguyenLieu_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguyenLieu>()
                .HasMany(e => e.ChiTietSanPham)
                .WithRequired(e => e.NguyenLieu)
                .HasForeignKey(e => e.MaNguyenLieu_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguyenLieu>()
                .HasMany(e => e.NguyenLieuXuat)
                .WithRequired(e => e.NguyenLieu)
                .HasForeignKey(e => e.MaNguyenLieu_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguyenLieu>()
                .HasMany(e => e.NguyenLieuTra)
                .WithRequired(e => e.NguyenLieu)
                .HasForeignKey(e => e.MaNguyenLieu_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCC>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCC>()
                .HasMany(e => e.PhieuNhap)
                .WithOptional(e => e.NhaCC)
                .HasForeignKey(e => e.MaNCC_id);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.TaiKhoanNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhauNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.NhanVienChayBan)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhieuNhap)
                .WithOptional(e => e.NhanVien)
                .HasForeignKey(e => e.TaiKhoanNV_id);

            modelBuilder.Entity<NhanVienChayBan>()
                .Property(e => e.TaiKhoanNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhomMonAn>()
                .HasMany(e => e.MonAn)
                .WithOptional(e => e.NhomMonAn)
                .HasForeignKey(e => e.MaNMA_id);

            modelBuilder.Entity<PhieuNhap>()
                .Property(e => e.TaiKhoanNV_id)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhap>()
                .HasMany(e => e.ChiTietPhieuNhap)
                .WithRequired(e => e.PhieuNhap)
                .HasForeignKey(e => e.MaPhieuNhap_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.NhanVien)
                .WithOptional(e => e.Quyen)
                .HasForeignKey(e => e.MaQuyen_id);

            modelBuilder.Entity<Tang>()
                .HasMany(e => e.HoaDon)
                .WithOptional(e => e.Tang)
                .HasForeignKey(e => e.MaBan_id);

            modelBuilder.Entity<XuatKho>()
                .HasMany(e => e.NguyenLieuXuat)
                .WithRequired(e => e.XuatKho)
                .HasForeignKey(e => e.MaXuatKho_id)
                .WillCascadeOnDelete(false);
        }
    }
}
