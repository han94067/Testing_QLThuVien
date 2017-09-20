namespace Testing_QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            CTMuonTras = new HashSet<CTMuonTra>();
            CTPhieuNhaps = new HashSet<CTPhieuNhap>();
        }

        [Key]
        [StringLength(10)]
        public string MaSach { get; set; }

        [StringLength(10)]
        public string MaTacGia { get; set; }

        [StringLength(10)]
        public string MaNhaXuatBan { get; set; }

        [StringLength(10)]
        public string MaTheLoai { get; set; }

        [StringLength(50)]
        public string TenSach { get; set; }

        [StringLength(15)]
        public string HinhAnh { get; set; }

        public int? NamXuatBan { get; set; }

        public int? SoLuong { get; set; }

        public int? SoLuongTon { get; set; }

        public int? TriGia { get; set; }

        public int? TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTMuonTra> CTMuonTras { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPhieuNhap> CTPhieuNhaps { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        public virtual TacGia TacGia { get; set; }

        public virtual TheLoai TheLoai { get; set; }
    }
}
