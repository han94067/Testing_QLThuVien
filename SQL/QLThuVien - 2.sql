Create database QLTVien2
go
Use QLTVien2
go

Create table [Sach] (
	[IDSach] Char(5) NOT NULL,
	[IDTheLoai] Char(5) NOT NULL,
	[IDTacGia] Char(5) NULL,
	[IDNhaXuatBan] Char(5) NULL,
	[TenSach] NVarchar(50) NULL,
	[HinhAnh] Varchar(200) NULL,
	[NamXuatBan] Integer NULL,
	[SoLuong] Integer DEFAULT 0,
	[SoLuongTon] Integer DEFAULT 0,
	[TriGia] Decimal(9,0) DEFAULT 0,
	[TinhTrang] Integer DEFAULT 0,
	[MoTa] NVarchar(MAX) NULL,
Primary Key  ([IDSach])
)
go

Create table [NhaXuatBan] (
	[IDNhaXuatBan] Char(5) NOT NULL,
	[TenNhaXuatBan] NVarchar(50) NULL,
Primary Key  ([IDNhaXuatBan])
) 
go

Create table [TacGia] (
	[IDTacGia] Char(5) NOT NULL,
	[TenTacGia] NVarchar(50) NULL,
Primary Key  ([IDTacGia])
) 
go

Create table [TheLoai] (
	[IDTheLoai] Char(5) NOT NULL,
	[TenTheLoai] NVarchar(50) NULL,
Primary Key  ([IDTheLoai])
) 
go

Create table [ChiTietPhieuNhapSach] (
	[IDPhieuNhapSach] Char(5) NOT NULL,
	[IDSach] Char(5) NOT NULL,
	[SoLuong] Integer DEFAULT 0,
	[DonGia] Decimal(9,0) DEFAULT 0,
Primary Key  ([IDPhieuNhapSach],[IDSach])
) 
go

Create table [PhieuNhapSach] (
	[IDPhieuNhapSach] Char(5) NOT NULL,
	[IDNhanVien] Char(5) NULL,
	[NgayNhap] Datetime NULL,
	[TongSoLuong] Integer DEFAULT 0,
	[TongDongia] Decimal(9,0) DEFAULT 0,
Primary Key  ([IDPhieuNhapSach])
) 
go

Create table [NhanVien] (
	[IDNhanVien] Char(5) NOT NULL,
	[IDChucVu] Char(5) NOT NULL,
	[TenNhanVien] NVarchar(50) NULL,
	[GioiTinh] Integer NULL,
	[DiaChi] NVarchar(100) NULL,
	[SoDienThoai] Char(12) NULL,
	[Email] Varchar(50) NULL,
	[CMND] Char(11) NULL,
	[NgayVaoLam] Date NULL,
	[MatKhau] Varchar(100) NULL,
Primary Key  ([IDNhanVien])
) 
go

Create table [BangRangBuoc] (
	[IDRangBuoc] Char(5) NOT NULL,
	[GiaTri] Integer NULL,
	[NgayHieuLuc] Date NULL,
	[GhiChu] NVarchar(100) NULL,
Primary Key  ([IDRangBuoc])
) 
go

Create table [DocGia] (
	[IDDocGia] Char(5) NOT NULL,
	[SoDienThoai] Varchar(11) NULL,
	[MatKhau] Varchar(100) NULL,
	[TenDocGia] NVarchar(50) NULL,
	[DiaChi] NVarchar(100) NULL,
	[Email] Varchar(50) NULL,
	[CMND] Char(11) NULL,
	[NgayLap] Date NULL,
	[NgayHetHan] Date NULL,
	[NgaySinh] Date NULL,
	[TinhTrang] Integer NULL,
	[TongTienPhat] Decimal(9,0) DEFAULT 0,
Primary Key  ([IDDocGia])
) 
go

Create table [CTMuonTra] (
	[STT] Char(5) NOT NULL,
	[IDSach] Char(5) NOT NULL,
	[IDDocGia] Char(5) NOT NULL,
	[NgayMuon] Datetime NULL,
	[NgayTraQuyDinh] Datetime NULL,
	[NgayTraThucTe] Datetime NULL,
	[NgayQuaHan] Integer DEFAULT 0,
	[TinhTrangMuon] Integer DEFAULT 0,
	[SoLuongThue] Integer DEFAULT 0,
	[TriGia] Decimal(9,0) DEFAULT 0,
	[TienCoc] Decimal(9,0) DEFAULT 0,
	[TienThue] Decimal(9,0) DEFAULT 0,
	[TienPhat] Decimal(9,0) DEFAULT 0,
	[TongTien] Decimal(9,0) DEFAULT 0,
Primary Key  ([STT],[IDSach],[IDDocGia])
) 
go

Create table [ChucVu] (
	[IDChucVu] Char(5) NOT NULL,
	[TenChucVu] NVarchar(20) NULL,
Primary Key  ([IDChucVu])
) 
go

Create table [PhieuThuTienPhat] (
	[IDPhieuThuTienPhat] Char(5) NOT NULL,
	[IDDocGia] Char(5) NOT NULL,
	[NgayThang] Date NULL,
	[TienThu] Decimal(9,0) DEFAULT 0,
Primary Key  ([IDPhieuThuTienPhat])
)
go


Alter table [ChiTietPhieuNhapSach] add  foreign key([IDSach]) references [Sach] ([IDSach]) 
go
Alter table [CTMuonTra] add  foreign key([IDSach]) references [Sach] ([IDSach]) 
go
Alter table [Sach] add  foreign key([IDNhaXuatBan]) references [NhaXuatBan] ([IDNhaXuatBan]) 
go
Alter table [Sach] add  foreign key([IDTacGia]) references [TacGia] ([IDTacGia]) 
go
Alter table [Sach] add  foreign key([IDTheLoai]) references [TheLoai] ([IDTheLoai]) 
go
Alter table [ChiTietPhieuNhapSach] add  foreign key([IDPhieuNhapSach]) references [PhieuNhapSach] ([IDPhieuNhapSach]) 
go
Alter table [CTMuonTra] add  foreign key([IDDocGia]) references [DocGia] ([IDDocGia]) 
go
Alter table [PhieuThuTienPhat] add  foreign key([IDDocGia]) references [DocGia] ([IDDocGia]) 
go
Alter table [NhanVien] add  foreign key([IDChucVu]) references [ChucVu] ([IDChucVu]) 






--------------Trigger-------------------
go
create function func_ThemTuDong(@Ma char(10),@prefix char(2),@size int)
	returns char(5)
	as
		begin
		if(@Ma='')
			set @Ma = @prefix +REPLICATE (0,@size - LEN(@prefix))
			declare @num_nextMa int, @nextMa char(5)
			set @Ma = LTRIM(RTRIM(@Ma))
			set @num_nextMa = REPLACE(@Ma,@prefix,'')+1
			set @size = @size - LEN(@prefix)
			set @nextMa = @prefix + REPLICATE (0,@size - LEN(@prefix))
			set @nextMa = @prefix + RIGHT(REPLICATE(0, @size)+CONVERT(varchar(max),@num_nextMa),@size)
			return @nextMa
		end

go
create trigger ThemSach
on Sach
for insert
as
	begin
		declare @Ma char(5)
		set @Ma=(select top 1 IDSach from Sach order by IDSach desc)
		update Sach set IDSach = dbo.func_ThemTuDong(@Ma,'MS',5) where IDSach =''
	end

go
create trigger ThemTacGia
on TacGia
for insert
as
	begin
		declare @Ma char(5)
		set @Ma=(select top 1 IDTacGia from TacGia order by IDTacGia desc)
		update TacGia set IDTacGia = dbo.func_ThemTuDong(@Ma,'TG',5) where IDTacGia =''
	end

go
create trigger ThemTheLoai
on TheLoai
for insert
as
	begin
		declare @Ma char(5)
		set @Ma=(select top 1 IDTheLoai from TheLoai order by IDTheLoai desc)
		update TheLoai set IDTheLoai = dbo.func_ThemTuDong(@Ma,'TL',5) where IDTheLoai =''
	end

go
create trigger ThemNhaXuatBan
on NhaXuatBan
for insert
as
	begin
		declare @Ma char(5)
		set @Ma=(select top 1 IDNhaXuatBan from NhaXuatBan order by IDNhaXuatBan desc)
		update NhaXuatBan set IDNhaXuatBan = dbo.func_ThemTuDong(@Ma,'XB',5) where IDNhaXuatBan =''
	end

go
create trigger ThemDocGia
on DocGia
for insert
as
	begin
		declare @Ma char(5)
		set @Ma=(select top 1 IDDocGia from DocGia order by IDDocGia desc)
		update DocGia set IDDocGia = dbo.func_ThemTuDong(@Ma,'DG',5) where IDDocGia =''
	end

go
create trigger ThemPhieuNhapSach
on PhieuNhapSach
for insert
as
	begin
		declare @Ma char(5)
		set @Ma=(select top 1 IDPhieuNhapSach from PhieuNhapSach order by IDPhieuNhapSach desc)
		update PhieuNhapSach set IDPhieuNhapSach = dbo.func_ThemTuDong(@Ma,'PN',5) where IDPhieuNhapSach =''
	end

go
create trigger ThemPhieuPhat
on PhieuThuTienPhat
for insert
as
	begin
		declare @Ma char(5)
		set @Ma=(select top 1 IDPhieuThuTienPhat from PhieuThuTienPhat order by IDPhieuThuTienPhat desc)
		update PhieuThuTienPhat set IDPhieuThuTienPhat = dbo.func_ThemTuDong(@Ma,'PP',5) where IDPhieuThuTienPhat =''
	end

	go
	create trigger ThemSTTMuonSach
on CTMuonTra
for insert
as
	begin
		declare @Ma char(5)
		set @Ma=(select top 1 STT from CTMuonTra order by STT desc)
		update CTMuonTra set STT = dbo.func_ThemTuDong(@Ma,'ST',5) where STT =''
	end

