
Create Database QLThuVien
go
Use QLThuVien

go
Create Table ChucVu
(
	MaChucVu	char(10)	primary key,
	TenChucVu	nchar(15),
);

go
Create Table NhanVien
(
	MaNhanVien	char(10)	primary key,
	MaChucVu	char(10),
	TenNV		nvarchar(50),
	GioiTinh	int,
	SDT			char(15),
	Email		varchar(30),
	CMND		char(10),
	NgayVaoLam	date,
	MatKhau		char(30),
	Constraint FK_MaChucVu Foreign Key(MaChucVu) references ChucVu(MaChucVu),
);

go
Create Table TacGia
(
	MaTacGia	char(10)	primary key,
	TenTacGia	nvarchar(50),
);

go
Create Table NhaXuatBan
(
	MaNhaXuatBan	char(10)	primary key,
	TenNhaXuatBan	nvarchar(50),
);

go
Create Table TheLoai
(
	MaTheLoai	char(10)	primary key,
	TenTheLoai	nvarchar(30),
);

go
Create Table Sach
(
	MaSach			char(10)	primary key,
	MaTacGia		char(10),
	MaNhaXuatBan	char(10),
	MaTheLoai		char(10),
	TenSach			nvarchar(50),
	HinhAnh			char(15),
	NamXuatBan		int,
	SoLuong			int,
	SoLuongTon		int,
	TriGia			int,
	TinhTrang		int,
	Constraint FK_MaTacGia Foreign Key(MaTacGia) references TacGia(MaTacGia),
	Constraint FK_MaNhaXuatBan Foreign Key(MaNhaXuatBan) references NhaXuatBan(MaNhaXuatBan),
	Constraint FK_MaTheLoai Foreign Key(MaTheLoai) references TheLoai(MaTheLoai),
);

go
Create Table DocGia
(
	MaDocGia		char(10)	primary key,
	TenDocGia		nvarchar(50),
	DiaChi			nvarchar(50),
	NgaySinh		date,
	SDT				char(15),
	Email			varchar(30),
	CMND			char(10),
	NgayLap			date,
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
	NgayMuon		date,
	MaSach			char(10),
	MaDocGia		char(10),
	NgayTraQuyDinh	date,
	NgayTraThucTe	date,
	NgayQuaHan		date,
	SoLuongThue		int,
	TriGia			int,
	TienCoc			int,
	TienThue		int,
	TienPhat		int,
	TongTien		int,
	TinhTrang		int,
	Constraint PK_NgayMuon_MaSach_MaDocGia Primary key(NgayMuon, MaSach, MaDocGia),
	Constraint FK_MaSach Foreign key(MaSach) references Sach(MaSach),
	Constraint FK_MaDocGia Foreign key(MaDocGia) references DocGia(MaDocGia),
);

go
Create Table PhieuTienPhat
(
	MaPhieuTienPhat		char(10)	primary key,
	MaDocGia			char(10),
	NgayThang			date,
	TienThu				int,
	Constraint FK_MaDocGia_1 Foreign key(MaDocGia) references DocGia(MaDocGia),
);

go
Create Table PhieuNhapSach
(
	MaPhieuNhapSach		char(10)	primary key,
	MaNhanVien			char(10),
	NgayNhap			date,
	TongSoLuong			int,
	TongDonGia			int,
	Constraint FK_MaNhanVien Foreign key(MaNhanVien) references NhanVien(MaNhanVien),
);

go
Create Table CTPhieuNhap
(
	MaPhieuNhapSach		char(10),
	MaSach				char(10),
	SoLuong				int,
	DonGia				int,
	Constraint PK_MaPhieu_MaSach Primary key(MaPhieuNhapSach, MaSach),
	Constraint FK_MaPhieuNhapSach Foreign key(MaPhieuNhapSach) references PhieuNhapSach(MaPhieuNhapSach),
	Constraint FK_MaSach_1 Foreign key(MaSach) references Sach(MaSach),
);



--------------Trigger-------------------
go
create function func_ThemTuDong(@Ma char(10),@prefix char(3),@size int)
	returns char(10)
	as
		begin
		if(@Ma='')
			set @Ma = @prefix +REPLICATE (0,@size - LEN(@prefix))
			declare @num_nextMa int, @nextMa char(10)
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
		declare @Ma char(10)
		set @Ma=(select top 1 MaSach from Sach order by MaSach desc)
		update Sach set MaSach = dbo.func_ThemTuDong(@Ma,'MS_',10) where MaSach =''
	end

go
create trigger ThemTacGia
on TacGia
for insert
as
	begin
		declare @Ma char(10)
		set @Ma=(select top 1 MaTacGia from TacGia order by MaTacGia desc)
		update TacGia set MaTacGia = dbo.func_ThemTuDong(@Ma,'TG_',10) where MaTacGia =''
	end

go
create trigger ThemTheLoai
on TheLoai
for insert
as
	begin
		declare @Ma char(10)
		set @Ma=(select top 1 MaTheLoai from TheLoai order by MaTheLoai desc)
		update TheLoai set MaTheLoai = dbo.func_ThemTuDong(@Ma,'TL_',10) where MaTheLoai =''
	end

go
create trigger ThemNhaXuatBan
on NhaXuatBan
for insert
as
	begin
		declare @Ma char(10)
		set @Ma=(select top 1 MaNhaXuatBan from NhaXuatBan order by MaNhaXuatBan desc)
		update NhaXuatBan set MaNhaXuatBan = dbo.func_ThemTuDong(@Ma,'XB_',10) where MaNhaXuatBan =''
	end

go
create trigger ThemDocGia
on DocGia
for insert
as
	begin
		declare @Ma char(10)
		set @Ma=(select top 1 MaDocGia from DocGia order by MaDocGia desc)
		update DocGia set MaDocGia = dbo.func_ThemTuDong(@Ma,'DG_',10) where MaDocGia =''
	end

go
create trigger ThemPhieuNhapSach
on PhieuNhapSach
for insert
as
	begin
		declare @Ma char(10)
		set @Ma=(select top 1 MaPhieuNhapSach from PhieuNhapSach order by MaPhieuNhapSach desc)
		update PhieuNhapSach set MaPhieuNhapSach = dbo.func_ThemTuDong(@Ma,'PN_',10) where MaPhieuNhapSach =''
	end

go
create trigger ThemPhieuPhat
on PhieuTienPhat
for insert
as
	begin
		declare @Ma char(10)
		set @Ma=(select top 1 MaPhieuTienPhat from PhieuTienPhat order by MaPhieuTienPhat desc)
		update PhieuTienPhat set MaPhieuTienPhat = dbo.func_ThemTuDong(@Ma,'PP_',10) where MaPhieuTienPhat =''
	end