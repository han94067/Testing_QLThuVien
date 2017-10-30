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
            ChiTietPhieuNhapSaches = new HashSet<ChiTietPhieuNhapSach>();
            CTMuonTras = new HashSet<CTMuonTra>();
        }

        [Key]
        [StringLength(5)]
        public string IDSach { get; set; }

        [Required]
        [StringLength(5)]
        public string IDTheLoai { get; set; }

        [StringLength(5)]
        public string IDTacGia { get; set; }

        [StringLength(5)]
        public string IDNhaXuatBan { get; set; }

        [StringLength(50)]
        public string TenSach { get; set; }

        [StringLength(200)]
        public string HinhAnh { get; set; }

        public int? NamXuatBan { get; set; }

        public int? SoLuong { get; set; }

        public int? SoLuongTon { get; set; }

        public decimal? TriGia { get; set; }

        public int? TinhTrang { get; set; }

        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhapSach> ChiTietPhieuNhapSaches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTMuonTra> CTMuonTras { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        public virtual TacGia TacGia { get; set; }

        public virtual TheLoai TheLoai { get; set; }
    }
}
