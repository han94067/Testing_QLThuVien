namespace Testing_QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            PhieuNhapSaches = new HashSet<PhieuNhapSach>();
        }

        [Key]
        [StringLength(10)]
        public string MaNhanVien { get; set; }

        [StringLength(10)]
        public string MaChucVu { get; set; }

        [StringLength(50)]
        public string TenNV { get; set; }

        public int? GioiTinh { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(10)]
        public string CMND { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayVaoLam { get; set; }

        [StringLength(30)]
        public string MatKhau { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapSach> PhieuNhapSaches { get; set; }
    }
}
