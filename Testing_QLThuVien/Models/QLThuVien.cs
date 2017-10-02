namespace Testing_QLThuVien.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLThuVien : DbContext
    {
        public QLThuVien()
            : base("name=QLThuVien")
        {
        }

        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<CTMuonTra> CTMuonTras { get; set; }
        public virtual DbSet<CTPhieuNhap> CTPhieuNhaps { get; set; }
        public virtual DbSet<DocGia> DocGias { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<PhieuNhapSach> PhieuNhapSaches { get; set; }
        public virtual DbSet<PhieuTienPhat> PhieuTienPhats { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVu>()
                .Property(e => e.MaChucVu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChucVu>()
                .Property(e => e.TenChucVu)
                .IsFixedLength();

            modelBuilder.Entity<CTMuonTra>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTMuonTra>()
                .Property(e => e.MaDocGia)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTPhieuNhap>()
                .Property(e => e.MaPhieuNhapSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTPhieuNhap>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocGia>()
                .Property(e => e.MaDocGia)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocGia>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocGia>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<DocGia>()
                .Property(e => e.CMND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocGia>()
                .HasMany(e => e.CTMuonTras)
                .WithRequired(e => e.DocGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaChucVu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.CMND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhaXuatBan>()
                .Property(e => e.MaNhaXuatBan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapSach>()
                .Property(e => e.MaPhieuNhapSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapSach>()
                .Property(e => e.MaNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuNhapSach>()
                .HasMany(e => e.CTPhieuNhaps)
                .WithRequired(e => e.PhieuNhapSach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuTienPhat>()
                .Property(e => e.MaPhieuTienPhat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuTienPhat>()
                .Property(e => e.MaDocGia)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaTacGia)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaNhaXuatBan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaTheLoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.HinhAnh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.CTMuonTras)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.CTPhieuNhaps)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TacGia>()
                .Property(e => e.MaTacGia)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.MaTheLoai)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
