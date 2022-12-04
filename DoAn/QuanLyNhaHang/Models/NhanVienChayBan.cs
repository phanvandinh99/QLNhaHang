namespace QuanLyNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVienChayBan")]
    public partial class NhanVienChayBan
    {
        [Key]
        [Column(Order = 0)]
        public int MaNhanVienChayBan { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TaiKhoanNV { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHoaDon { get; set; }

        public int? TrangThai { get; set; }

        public double? TienHuHong { get; set; }

        public DateTime? GioBatDau { get; set; }

        public DateTime? GioKetThucDuKien { get; set; }

        public double? TienLuong { get; set; }

        public double? TienThuong { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
