namespace Testing_QLThuVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChucVu",
                c => new
                    {
                        MaChucVu = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        TenChucVu = c.String(maxLength: 15, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.MaChucVu);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNhanVien = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        MaChucVu = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        TenNV = c.String(maxLength: 50, unicode: false),
                        GioiTinh = c.Int(),
                        SDT = c.String(maxLength: 15, fixedLength: true, unicode: false),
                        Email = c.String(maxLength: 30, unicode: false),
                        CMND = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        NgayVaoLam = c.DateTime(storeType: "date"),
                        MatKhau = c.String(maxLength: 30, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.MaNhanVien)
                .ForeignKey("dbo.ChucVu", t => t.MaChucVu)
                .Index(t => t.MaChucVu);
            
            CreateTable(
                "dbo.PhieuNhapSach",
                c => new
                    {
                        MaPhieuNhapSach = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        MaNhanVien = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        NgayNhap = c.DateTime(storeType: "date"),
                        TongSoLuong = c.Int(),
                        TongDonGia = c.Int(),
                    })
                .PrimaryKey(t => t.MaPhieuNhapSach)
                .ForeignKey("dbo.NhanVien", t => t.MaNhanVien)
                .Index(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.CTPhieuNhap",
                c => new
                    {
                        MaPhieuNhapSach = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        MaSach = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        SoLuong = c.Int(),
                        DonGia = c.Int(),
                    })
                .PrimaryKey(t => new { t.MaPhieuNhapSach, t.MaSach })
                .ForeignKey("dbo.Sach", t => t.MaSach)
                .ForeignKey("dbo.PhieuNhapSach", t => t.MaPhieuNhapSach)
                .Index(t => t.MaPhieuNhapSach)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.Sach",
                c => new
                    {
                        MaSach = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        MaTacGia = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        MaNhaXuatBan = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        MaTheLoai = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        TenSach = c.String(maxLength: 50, unicode: false),
                        HinhAnh = c.String(maxLength: 15, fixedLength: true, unicode: false),
                        NamXuatBan = c.Int(),
                        SoLuong = c.Int(),
                        SoLuongTon = c.Int(),
                        TriGia = c.Int(),
                        TinhTrang = c.Int(),
                    })
                .PrimaryKey(t => t.MaSach)
                .ForeignKey("dbo.NhaXuatBan", t => t.MaNhaXuatBan)
                .ForeignKey("dbo.TacGia", t => t.MaTacGia)
                .ForeignKey("dbo.TheLoai", t => t.MaTheLoai)
                .Index(t => t.MaTacGia)
                .Index(t => t.MaNhaXuatBan)
                .Index(t => t.MaTheLoai);
            
            CreateTable(
                "dbo.CTMuonTra",
                c => new
                    {
                        NgayMuon = c.DateTime(nullable: false, storeType: "date"),
                        MaSach = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        MaDocGia = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        NgayTraQuyDinh = c.DateTime(storeType: "date"),
                        NgayTraThucTe = c.DateTime(storeType: "date"),
                        NgayQuaHan = c.DateTime(storeType: "date"),
                        SoLuongThue = c.Int(),
                        TriGia = c.Int(),
                        TienCoc = c.Int(),
                        TienThue = c.Int(),
                        TienPhat = c.Int(),
                        TongTien = c.Int(),
                        TinhTrang = c.Int(),
                    })
                .PrimaryKey(t => new { t.NgayMuon, t.MaSach, t.MaDocGia })
                .ForeignKey("dbo.DocGia", t => t.MaDocGia)
                .ForeignKey("dbo.Sach", t => t.MaSach)
                .Index(t => t.MaSach)
                .Index(t => t.MaDocGia);
            
            CreateTable(
                "dbo.DocGia",
                c => new
                    {
                        MaDocGia = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        TenDocGia = c.String(maxLength: 50, unicode: false),
                        DiaChi = c.String(maxLength: 50, unicode: false),
                        NgaySinh = c.DateTime(storeType: "date"),
                        SDT = c.String(maxLength: 15, fixedLength: true, unicode: false),
                        Email = c.String(maxLength: 30, unicode: false),
                        CMND = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        NgayLap = c.DateTime(storeType: "date"),
                        TinhTrang = c.Int(),
                        TongTienPhat = c.Int(),
                    })
                .PrimaryKey(t => t.MaDocGia);
            
            CreateTable(
                "dbo.PhieuTienPhat",
                c => new
                    {
                        MaPhieuTienPhat = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        MaDocGia = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        NgayThang = c.DateTime(storeType: "date"),
                        TienThu = c.Int(),
                    })
                .PrimaryKey(t => t.MaPhieuTienPhat)
                .ForeignKey("dbo.DocGia", t => t.MaDocGia)
                .Index(t => t.MaDocGia);
            
            CreateTable(
                "dbo.NhaXuatBan",
                c => new
                    {
                        MaNhaXuatBan = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        TenNhaXuatBan = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaNhaXuatBan);
            
            CreateTable(
                "dbo.TacGia",
                c => new
                    {
                        MaTacGia = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        TenTacGia = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaTacGia);
            
            CreateTable(
                "dbo.TheLoai",
                c => new
                    {
                        MaTheLoai = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        TenTheLoai = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.MaTheLoai);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuNhapSach", "MaNhanVien", "dbo.NhanVien");
            DropForeignKey("dbo.CTPhieuNhap", "MaPhieuNhapSach", "dbo.PhieuNhapSach");
            DropForeignKey("dbo.Sach", "MaTheLoai", "dbo.TheLoai");
            DropForeignKey("dbo.Sach", "MaTacGia", "dbo.TacGia");
            DropForeignKey("dbo.Sach", "MaNhaXuatBan", "dbo.NhaXuatBan");
            DropForeignKey("dbo.CTPhieuNhap", "MaSach", "dbo.Sach");
            DropForeignKey("dbo.CTMuonTra", "MaSach", "dbo.Sach");
            DropForeignKey("dbo.PhieuTienPhat", "MaDocGia", "dbo.DocGia");
            DropForeignKey("dbo.CTMuonTra", "MaDocGia", "dbo.DocGia");
            DropForeignKey("dbo.NhanVien", "MaChucVu", "dbo.ChucVu");
            DropIndex("dbo.PhieuTienPhat", new[] { "MaDocGia" });
            DropIndex("dbo.CTMuonTra", new[] { "MaDocGia" });
            DropIndex("dbo.CTMuonTra", new[] { "MaSach" });
            DropIndex("dbo.Sach", new[] { "MaTheLoai" });
            DropIndex("dbo.Sach", new[] { "MaNhaXuatBan" });
            DropIndex("dbo.Sach", new[] { "MaTacGia" });
            DropIndex("dbo.CTPhieuNhap", new[] { "MaSach" });
            DropIndex("dbo.CTPhieuNhap", new[] { "MaPhieuNhapSach" });
            DropIndex("dbo.PhieuNhapSach", new[] { "MaNhanVien" });
            DropIndex("dbo.NhanVien", new[] { "MaChucVu" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.TheLoai");
            DropTable("dbo.TacGia");
            DropTable("dbo.NhaXuatBan");
            DropTable("dbo.PhieuTienPhat");
            DropTable("dbo.DocGia");
            DropTable("dbo.CTMuonTra");
            DropTable("dbo.Sach");
            DropTable("dbo.CTPhieuNhap");
            DropTable("dbo.PhieuNhapSach");
            DropTable("dbo.NhanVien");
            DropTable("dbo.ChucVu");
        }
    }
}
