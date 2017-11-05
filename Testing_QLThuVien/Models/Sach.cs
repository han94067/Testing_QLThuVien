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

        [StringLength(50, ErrorMessage = "Tên sách không được vượt quá 50 kí tự.")]
        [Required(ErrorMessage = "Xin mời nhập Tên Sách.")]
        public string TenSach { get; set; }

        [StringLength(200)]
        public string HinhAnh { get; set; }

        [Required(ErrorMessage = "Xin mời nhập Năm Xuất Bản và không được nhập chữ hoặc ký tự đặc biệt.")]
        [Range(2000, 2017, ErrorMessage = "Năm Xuất Bản từ năm 2000 đến năm 2017.")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Không được nhập chữ và ký tự đặc biệt.")]
        public int? NamXuatBan { get; set; }

        public int? SoLuong { get; set; }

        public int? SoLuongTon { get; set; }

        [Required(ErrorMessage = "Xin mời nhập Trị Giá.")]
        [Range(1000, 10000000, ErrorMessage = "Trị Giá từ năm 1.000 đến năm 10.000.000")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Không được nhập chữ và ký tự đặc biệt.")]
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
