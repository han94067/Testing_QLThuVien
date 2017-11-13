namespace Testing_QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DocGia")]
    public partial class DocGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocGia()
        {
            CTMuonTras = new HashSet<CTMuonTra>();
            PhieuThuTienPhats = new HashSet<PhieuThuTienPhat>();
        }

        [Key]
        [StringLength(5)]
        public string IDDocGia { get; set; }

        [StringLength(11, ErrorMessage = "Số Điện Thoại không chính xác.")]
        [Required(ErrorMessage = "Xin mời nhập Số Điện Thoại.")]
        [MinLength(9, ErrorMessage = "Số Điện Thoại không chính xác.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Số Điện Thoại không chính xác.")]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Không được để trống tên độc giả.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Không được nhập số và ký tự đặc biệt.")]
        public string TenDocGia { get; set; }

        [StringLength(100, ErrorMessage = "Địa chỉ không được vượt quá 100 ký tự.")]
        [Required(ErrorMessage = "Không được để trông địa chỉ.")]
        public string DiaChi { get; set; }

        [StringLength(50, ErrorMessage = "Email không được vượt quá 50 ký tự.")]
        [Required(ErrorMessage = "Không được đê trống Email.")]
        [EmailAddress(ErrorMessage = "Email không chính xác.")]
        public string Email { get; set; }

        [StringLength(9, ErrorMessage = "Số Chứng Minh Nhân Dân không chính xác.")]
        [Required(ErrorMessage = "Xin mời nhập số Chứng Minh Nhân Dân.")]
        [MinLength(9, ErrorMessage = "Số Chứng Minh Nhân Dân không chính xác.")]
        public string CMND { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHetHan { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Không được để trống ngày sinh.")]
        public DateTime? NgaySinh { get; set; }

        public int? TinhTrang { get; set; }

        public decimal? TongTienPhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTMuonTra> CTMuonTras { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThuTienPhat> PhieuThuTienPhats { get; set; }
    }
}
