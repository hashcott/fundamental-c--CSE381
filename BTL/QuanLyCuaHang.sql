create database QuanLyCuaHangBanDo;
go
use QuanLyCuaHangBanDo;
go
create table LoaiDoDung(
	idLDD varchar(255) primary key,
	tenLDD nvarchar(255)
)
go
create table NhaSanXuat (
	idNSX varchar(255) primary key,
	tenNSX nvarchar(255)
)
go
create table ChatLieu(
	idCL varchar(255) primary key,
	tenCL nvarchar(255)
)
go
create table DoDung(
	idDD varchar(255) primary key,
	tenDD nvarchar(255),
	soLuong int,
	donGia int,
	idLDD varchar(255) foreign key references LoaiDoDung(idLDD),
	idNSX varchar(255) foreign key references NhaSanXuat(idNSX),
	idCL varchar(255) foreign key references ChatLieu(idCL)
)
go
create table KhachHang(
	idKH varchar(255) primary key,
	tenKH nvarchar(255),
	diaChi nvarchar(255),
	sdt nvarchar(255)
)
go
create table HoaDon(
	idHD varchar(255) primary key,
	idKH varchar(255) foreign key references KhachHang(idKH),
	ngayHD date
)
go
create table HD_DD (
	idHD varchar(255) foreign key references HoaDon(idHD),
	idDD varchar(255) foreign key references DoDung(idDD),
	soLuong int
)
go

alter table HoaDon add thanhTien int

truncate table HoaDon

select TK.idLDD, LoaiDoDung.tenLDD, TK.total_sl from (select LoaiDoDung.idLDD,sum(HD_DD.soLuong) as total_sl from HD_DD, DoDung, LoaiDoDung where HD_DD.idDD = DoDung.idDD and DoDung.idLDD = LoaiDoDung.idLDD group by LoaiDoDung.idLDD) as TK inner join LoaiDoDung on LoaiDoDung.idLDD = TK.idLDD order by TK.total_sl DESC;
select TK.idKH,KhachHang.tenKH,TK.total_sl from (select KhachHang.idKH, sum(HD_DD.soLuong) as total_sl from HD_DD, KhachHang, HoaDon where HD_DD.idHD = HoaDon.idHD and HoaDon.idKH = KhachHang.idKH group by KhachHang.idKH) as TK inner join KhachHang on TK.idKH = KhachHang.idKH order by TK.total_sl desc;

select DoDung.tenDD , HD_DD.soLuong from HoaDon, HD_DD, DoDung where HoaDon.idHD = HD_DD.idHD and HoaDon.idKH = "" and HD_DD.idDD = DoDung.idDD
select * from LoaiDoDung inner join DoDung on LoaiDoDung.idLDD = DoDung.idLDD