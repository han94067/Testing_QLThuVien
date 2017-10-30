namespace Testing_QLThuVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BangRangBuoc",
                c => new
                    {
                        IDRangBuoc = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        GiaTri = c.Int(),
                        NgayHieuLuc = c.DateTime(storeType: "date"),
                        GhiChu = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.IDRangBuoc);
            
            CreateTable(
                "dbo.ChiTietPhieuNhapSach",
                c => new
                    {
                        IDPhieuNhapSach = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        IDSach = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        SoLuong = c.Int(),
                        DonGia = c.Decimal(precision: 9, scale: 0),
                    })
                .PrimaryKey(t => new { t.IDPhieuNhapSach, t.IDSach })
                .ForeignKey("dbo.PhieuNhapSach", t => t.IDPhieuNhapSach)
                .ForeignKey("dbo.Sach", t => t.IDSach)
                .Index(t => t.IDPhieuNhapSach)
                .Index(t => t.IDSach);
            
            CreateTable(
                "dbo.PhieuNhapSach",
                c => new
                    {
                        IDPhieuNhapSach = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        IDNhanVien = c.String(maxLength: 5, fixedLength: true, unicode: false),
                        NgayNhap = c.DateTime(),
                        TongSoLuong = c.Int(),
                        TongDongia = c.Decimal(precision: 9, scale: 0),
                    })
                .PrimaryKey(t => t.IDPhieuNhapSach);
            
            CreateTable(
                "dbo.Sach",
                c => new
                    {
                        IDSach = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        IDTheLoai = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        IDTacGia = c.String(maxLength: 5, fixedLength: true, unicode: false),
                        IDNhaXuatBan = c.String(maxLength: 5, fixedLength: true, unicode: false),
                        TenSach = c.String(maxLength: 50),
                        HinhAnh = c.String(maxLength: 200, unicode: false),
                        NamXuatBan = c.Int(),
                        SoLuong = c.Int(),
                        SoLuongTon = c.Int(),
                        TriGia = c.Decimal(precision: 9, scale: 0),
                        TinhTrang = c.Int(),
                        MoTa = c.String(),
                    })
                .PrimaryKey(t => t.IDSach)
                .ForeignKey("dbo.NhaXuatBan", t => t.IDNhaXuatBan)
                .ForeignKey("dbo.TacGia", t => t.IDTacGia)
                .ForeignKey("dbo.TheLoai", t => t.IDTheLoai)
                .Index(t => t.IDTheLoai)
                .Index(t => t.IDTacGia)
                .Index(t => t.IDNhaXuatBan);
            
            CreateTable(
                "dbo.CTMuonTra",
                c => new
                    {
                        STT = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        IDSach = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        IDDocGia = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        NgayMuon = c.DateTime(),
                        NgayTraQuyDinh = c.DateTime(),
                        NgayTraThucTe = c.DateTime(),
                        NgayQuaHan = c.Int(),
                        TinhTrangMuon = c.Int(),
                        SoLuongThue = c.Int(),
                        TriGia = c.Decimal(precision: 9, scale: 0),
                        TienCoc = c.Decimal(precision: 9, scale: 0),
                        TienThue = c.Decimal(precision: 9, scale: 0),
                        TienPhat = c.Decimal(precision: 9, scale: 0),
                        TongTien = c.Decimal(precision: 9, scale: 0),
                    })
                .PrimaryKey(t => new { t.STT, t.IDSach, t.IDDocGia })
                .ForeignKey("dbo.DocGia", t => t.IDDocGia)
                .ForeignKey("dbo.Sach", t => t.IDSach)
                .Index(t => t.IDSach)
                .Index(t => t.IDDocGia);
            
            CreateTable(
                "dbo.DocGia",
                c => new
                    {
                        IDDocGia = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        SoDienThoai = c.String(maxLength: 11, unicode: false),
                        MatKhau = c.String(maxLength: 100, unicode: false),
                        TenDocGia = c.String(maxLength: 50),
                        DiaChi = c.String(maxLength: 100),
                        Email = c.String(maxLength: 50, unicode: false),
                        CMND = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        NgayLap = c.DateTime(storeType: "date"),
                        NgayHetHan = c.DateTime(storeType: "date"),
                        NgaySinh = c.DateTime(storeType: "date"),
                        TinhTrang = c.Int(),
                        TongTienPhat = c.Decimal(precision: 9, scale: 0),
                    })
                .PrimaryKey(t => t.IDDocGia);
            
            CreateTable(
                "dbo.PhieuThuTienPhat",
                c => new
                    {
                        IDPhieuThuTienPhat = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        IDDocGia = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        NgayThang = c.DateTime(storeType: "date"),
                        TienThu = c.Decimal(precision: 9, scale: 0),
                    })
                .PrimaryKey(t => t.IDPhieuThuTienPhat)
                .ForeignKey("dbo.DocGia", t => t.IDDocGia)
                .Index(t => t.IDDocGia);
            
            CreateTable(
                "dbo.NhaXuatBan",
                c => new
                    {
                        IDNhaXuatBan = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        TenNhaXuatBan = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IDNhaXuatBan);
            
            CreateTable(
                "dbo.TacGia",
                c => new
                    {
                        IDTacGia = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        TenTacGia = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IDTacGia);
            
            CreateTable(
                "dbo.TheLoai",
                c => new
                    {
                        IDTheLoai = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        TenTheLoai = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IDTheLoai);
            
            CreateTable(
                "dbo.ChucVu",
                c => new
                    {
                        IDChucVu = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        TenChucVu = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IDChucVu);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        IDNhanVien = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        IDChucVu = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        TenNhanVien = c.String(maxLength: 50),
                        GioiTinh = c.Int(),
                        DiaChi = c.String(maxLength: 100),
                        SoDienThoai = c.String(maxLength: 12, fixedLength: true, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        CMND = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        NgayVaoLam = c.DateTime(storeType: "date"),
                        MatKhau = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.IDNhanVien)
                .ForeignKey("dbo.ChucVu", t => t.IDChucVu)
                .Index(t => t.IDChucVu);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NhanVien", "IDChucVu", "dbo.ChucVu");
            DropForeignKey("dbo.Sach", "IDTheLoai", "dbo.TheLoai");
            DropForeignKey("dbo.Sach", "IDTacGia", "dbo.TacGia");
            DropForeignKey("dbo.Sach", "IDNhaXuatBan", "dbo.NhaXuatBan");
            DropForeignKey("dbo.CTMuonTra", "IDSach", "dbo.Sach");
            DropForeignKey("dbo.PhieuThuTienPhat", "IDDocGia", "dbo.DocGia");
            DropForeignKey("dbo.CTMuonTra", "IDDocGia", "dbo.DocGia");
            DropForeignKey("dbo.ChiTietPhieuNhapSach", "IDSach", "dbo.Sach");
            DropForeignKey("dbo.ChiTietPhieuNhapSach", "IDPhieuNhapSach", "dbo.PhieuNhapSach");
            DropIndex("dbo.NhanVien", new[] { "IDChucVu" });
            DropIndex("dbo.PhieuThuTienPhat", new[] { "IDDocGia" });
            DropIndex("dbo.CTMuonTra", new[] { "IDDocGia" });
            DropIndex("dbo.CTMuonTra", new[] { "IDSach" });
            DropIndex("dbo.Sach", new[] { "IDNhaXuatBan" });
            DropIndex("dbo.Sach", new[] { "IDTacGia" });
            DropIndex("dbo.Sach", new[] { "IDTheLoai" });
            DropIndex("dbo.ChiTietPhieuNhapSach", new[] { "IDSach" });
            DropIndex("dbo.ChiTietPhieuNhapSach", new[] { "IDPhieuNhapSach" });
            DropTable("dbo.NhanVien");
            DropTable("dbo.ChucVu");
            DropTable("dbo.TheLoai");
            DropTable("dbo.TacGia");
            DropTable("dbo.NhaXuatBan");
            DropTable("dbo.PhieuThuTienPhat");
            DropTable("dbo.DocGia");
            DropTable("dbo.CTMuonTra");
            DropTable("dbo.Sach");
            DropTable("dbo.PhieuNhapSach");
            DropTable("dbo.ChiTietPhieuNhapSach");
            DropTable("dbo.BangRangBuoc");
        }
    }
}
