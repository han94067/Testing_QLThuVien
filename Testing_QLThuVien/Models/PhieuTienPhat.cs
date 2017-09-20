namespace Testing_QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuTienPhat")]
    public partial class PhieuTienPhat
    {
        [Key]
        [StringLength(10)]
        public string MaPhieuTienPhat { get; set; }

        [StringLength(10)]
        public string MaDocGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThang { get; set; }

        public int? TienThu { get; set; }

        public virtual DocGia DocGia { get; set; }
    }
}
