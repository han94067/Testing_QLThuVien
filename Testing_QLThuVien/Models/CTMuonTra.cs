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
        [Column(Order = 0, TypeName = "date")]
        public DateTime NgayMuon { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string MaDocGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTraQuyDinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTraThucTe { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayQuaHan { get; set; }

        public int? SoLuongThue { get; set; }

        public int? TriGia { get; set; }

        public int? TienCoc { get; set; }

        public int? TienThue { get; set; }

        public int? TienPhat { get; set; }

        public int? TongTien { get; set; }

        public int? TinhTrang { get; set; }

        public virtual DocGia DocGia { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
