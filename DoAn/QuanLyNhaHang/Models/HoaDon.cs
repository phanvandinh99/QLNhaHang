namespace QuanLyNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietHoaDon = new HashSet<ChiTietHoaDon>();
            LichSuGoiMon = new HashSet<LichSuGoiMon>();
            NhanVienChayBan = new HashSet<NhanVienChayBan>();
        }

        [Key]
        public int MaHoaDon { get; set; }

        [StringLength(100)]
        public string TenKhachHang { get; set; }

        [StringLength(10)]
        public string SDTKhachHang { get; set; }

        public int? TongHoaDon { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayThanhToan { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public double TongTien { get; set; }

        public int? TrangThai { get; set; }

        public int? MaBan_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }

        public virtual Tang Tang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuGoiMon> LichSuGoiMon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVienChayBan> NhanVienChayBan { get; set; }
    }
}
