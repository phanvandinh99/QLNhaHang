namespace QuanLyNhaHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tang")]
    public partial class Tang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tang()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        [Key]
        public int MaBan { get; set; }

        [Required]
        [StringLength(50)]
        public string TenBan { get; set; }

        public int SoGhe { get; set; }

        public int? Vip { get; set; }

        public int? TinhTrang { get; set; }

        public int? MaTang_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDon { get; set; }

        public virtual Khu Khu { get; set; }
    }
}
