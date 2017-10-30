drop database QLThuVien
use master
Create Database QLThuVien
go
Use QLThuVien

go
Create Table ChucVu
(
	IDChucVu	char(10)	primary key,
	TenChucVu	nvarchar(20),
);

go
Create Table NhanVien
(
	IDNhanVien		char(10)	primary key,
	IDChucVu		char(10),
	TenNhanVien		nvarchar(50),
	GioiTinh		int,
	DiaChi			nvarchar(100),
	SoDienThoai		char(12),
	Email		varchar(50),
	CMND		char(11),
	NgayVaoLam	date,
	MatKhau		varchar(100),
	Constraint FK_MaChucVu Foreign Key(IDChucVu) references ChucVu(IDChucVu),
);

go
Create Table TacGia
(
	IDTacGia	char(10)	primary key,
	TenTacGia	nvarchar(50),
);

go
Create Table NhaXuatBan
(
	IDNhaXuatBan	char(10)	primary key,
	TenNhaXuatBan	nvarchar(50),
);

go
Create Table TheLoai
(
	IDTheLoai	char(10)	primary key,
	TenTheLoai	nvarchar(50),
);

go
Create Table Sach
(
	IDSach			char(10)	primary key,
	IDTacGia		char(10),
	IDNhaXuatBan	char(10),
	IDTheLoai		char(10),
	TenSach			nvarchar(50),
	HinhAnh			varchar(200),
	NamXuatBan		int,
	SoLuong			int,
	SoLuongTon		int,
	TriGia			int,
	TinhTrang		int,
	MoTa			nvarchar(max),
	Constraint FK_MaTacGia Foreign Key(IDTacGia) references TacGia(IDTacGia),
	Constraint FK_MaNhaXuatBan Foreign Key(IDNhaXuatBan) references NhaXuatBan(IDNhaXuatBan),
	Constraint FK_MaTheLoai Foreign Key(IDTheLoai) references TheLoai(IDTheLoai),
);

go
Create Table DocGia
(
	IDDocGia		char(10)	primary key,
	TenDocGia		nvarchar(50),
	MatKhau			varchar(100),
	DiaChi			nvarchar(100),
	NgaySinh		date,
	SoDienThoai		varchar(11),
	Email			varchar(50),
	CMND			char(11),
	NgayLap			date,
	NgayHetHan		date,
	TinhTrang		int,
	TongTienPhat	int,
);

--go
--Create Table MuonTra
--(
--	MaMuonTra		char(10),
--	MaDocGia		char(10),
--	NgayMuon		date,
--	TongSoLuong		int,
--	TongTienCoc		int,
--	TongTienThue	int,
--	TinhTrang		int,
--	Constraint FK_MaDocGia Foreign Key(MaDocGia) references DocGia(MaDocGia),
--);

--go
--Create Table CTMuonTra
--(
--	MaSach			char(10),
--	MaMuonTra		char(10),
--	NgayTraQuyDinh	date,
--	NgayTraThucTe	date,
--	NgayQuaHan		date,
--	SoLuongThue		int,
--	TienCoc			int,
--	TienThue		int,
--	TienPhat		int,
--	TongTien		int,
--	TinhTrang		int,
--);

go
Create Table CTMuonTra
(
	STT				char(10),
	NgayMuon		date,
	IDSach			char(10),
	IDDocGia		char(10),
	NgayTraQuyDinh	date,
	NgayTraThucTe	date,
	NgayQuaHan		int,
	SoLuongThue		int,
	TriGia			int,
	TienCoc			int,
	TienThue		int,
	TienPhat		int,
	TongTien		int,
	TinhTrangMuon	int,
	Constraint PK_NgayMuon_MaSach_MaDocGia Primary key(STT, IDSach, IDDocGia),
	Constraint FK_MaSach Foreign key(IDSach) references Sach(IDSach),
	Constraint FK_MaDocGia Foreign key(IDDocGia) references DocGia(IDDocGia),
);

go
Create Table PhieuThuTienPhat
(
	IDPhieuThuTienPhat	char(10)	primary key,
	IDDocGia			char(10),
	NgayThang			date,
	TienThu				int,
	Constraint FK_MaDocGia_1 Foreign key(IDDocGia) references DocGia(IDDocGia),
);

go
Create Table PhieuNhapSach
(
	IDPhieuNhapSach		char(10)	primary key,
	IDNhanVien			char(10),
	NgayNhap			date,
	TongSoLuong			int,
	TongDongia			int,
	Constraint FK_MaNhanVien Foreign key(IDNhanVien) references NhanVien(IDNhanVien),
);

go
Create Table ChiTietPhieuNhapSach
(
	IDPhieuNhapSach		char(10),
	IDSach				char(10),
	SoLuong				int,
	DonGia				int,
	Constraint PK_MaPhieu_MaSach Primary key(IDPhieuNhapSach, IDSach),
	Constraint FK_MaPhieuNhapSach Foreign key(IDPhieuNhapSach) references PhieuNhapSach(IDPhieuNhapSach),
	Constraint FK_MaSach_1 Foreign key(IDSach) references Sach(IDSach),
);



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



