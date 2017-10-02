namespace Testing_QLThuVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChucVu", "TenChucVu", c => c.String(maxLength: 15, fixedLength: true));
            AlterColumn("dbo.NhanVien", "TenNV", c => c.String(maxLength: 50));
            AlterColumn("dbo.Sach", "TenSach", c => c.String(maxLength: 50));
            AlterColumn("dbo.DocGia", "TenDocGia", c => c.String(maxLength: 50));
            AlterColumn("dbo.DocGia", "DiaChi", c => c.String(maxLength: 50));
            AlterColumn("dbo.NhaXuatBan", "TenNhaXuatBan", c => c.String(maxLength: 50));
            AlterColumn("dbo.TacGia", "TenTacGia", c => c.String(maxLength: 50));
            AlterColumn("dbo.TheLoai", "TenTheLoai", c => c.String(maxLength: 30));
            DropTable("dbo.sysdiagrams");
        }
        
        public override void Down()
        {
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
            
            AlterColumn("dbo.TheLoai", "TenTheLoai", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.TacGia", "TenTacGia", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.NhaXuatBan", "TenNhaXuatBan", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.DocGia", "DiaChi", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.DocGia", "TenDocGia", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Sach", "TenSach", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.NhanVien", "TenNV", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.ChucVu", "TenChucVu", c => c.String(maxLength: 15, fixedLength: true, unicode: false));
        }
    }
}
