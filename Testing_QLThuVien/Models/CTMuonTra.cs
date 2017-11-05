namespace Testing_QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTMuonTra")]
    public partial class CTMuonTra
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string STT { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string IDSach { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string IDDocGia { get; set; }

        public DateTime? NgayMuon { get; set; }

        public DateTime? NgayTraQuyDinh { get; set; }

        public DateTime? NgayTraThucTe { get; set; }

        public int? NgayQuaHan { get; set; }

        public int? TinhTrangMuon { get; set; }

        [Required(ErrorMessage = "Xin nhâp vào số lượng.")]
        [Range(1, 10, ErrorMessage = "Số lượng phải từ 1 đến 10.")]
        public int? SoLuongThue { get; set; }

        public decimal? TriGia { get; set; }

        public decimal? TienCoc { get; set; }

        public decimal? TienThue { get; set; }

        public decimal? TienPhat { get; set; }

        public decimal? TongTien { get; set; }

        public virtual DocGia DocGia { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
