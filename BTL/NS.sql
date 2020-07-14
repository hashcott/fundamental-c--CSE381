create database QuanLyNhanSu;

use QuanLyNhanSu;
create table NghiepVu (
	idNV varchar(255) primary key,
	tenNV nvarchar(255)
)
create table CongTrinh (
	idCT varchar(255) primary key,
	tenCT nvarchar(255),
	diaDiem nvarchar(255),
	ngayBD date,
	ngayKTDuKien date,
	soLuongNS int
)
create table NhanSu(
	idNS varchar(255) primary key,
	hoTen nvarchar(255) null,
	gioiTinh bit null,
	diaChi nvarchar(255) null,
	sdt varchar(255) null,
	email varchar(255) null,
	cmnd varchar(255) null,
	idNghiepVu varchar(255) foreign key references NghiepVu(idNV)
)
create table CongTrinh_NhanSu (
	idNS varchar(255) foreign key references NhanSu(idNS),
	idCT varchar(255) foreign key references CongTrinh(idCT),
	ngayBDLam date null,
	ngayKTLam date null,
)

create table ChamCong(
	idNS varchar(255) foreign key references NhanSu(idNS),
	ngayChamCong date
)

alter table NghiepVu add mucluongDeNghi int

alter table NhanSu alter column gioiTinh nvarchar(255)

select NS.idNS,NS.hoTen, NS.gioiTinh,NS.diaChi,NS.sdt,NS.email,NS.cmnd,NV.tenNV from NhanSu as NS inner join NghiepVu as NV on NV.idNV=NS.idNghiepVu

alter table CongTrinh alter column ngayKTDuKien datetime

select * from NhanSu where idNS not in (select idNS from CongTrinh_NhanSu)

alter table CongTrinh_NhanSu add status bit
select NS.idNS,NS.hoTen, NS.gioiTinh,NS.diaChi,NS.sdt,NS.email,NS.cmnd,NV.tenNV from NhanSu as NS inner join NghiepVu as NV on NV.idNV=NS.idNghiepVu where NS.idNS not in (select idNS from CongTrinh_NhanSu where status='True')
select NS.idNS,NS.hoTen,NV.tenNV,CT.tenCT from NhanSu as NS, NghiepVu as NV, CongTrinh as CT , CongTrinh_NhanSu as CT_NS where NS.idNS = CT_NS.idNS and CT.idCT = CT_NS.idCT and NV.idNV=NS.idNghiepVu and NS.idNS in (select idNS from CongTrinh_NhanSu where status='True') and NS.idNS not in (select idNS from ChamCong where day(ngayChamCong) = 14 and month(ngayChamCong) = 07)
select idNS from ChamCong where day(ngayChamCong) = 14 and month(ngayChamCong) = 07

alter table ChamCong add idCT VARCHAR(255) foreign key references CongTrinh(idCT)

alter table ChamCong add status bit


select NS.idNS,NS.hoTen,COUNT(NS.idNS), month(CC.ngayChamCong) from NhanSu as NS , CongTrinh as CT , ChamCong  as CC where NS.idNS = CC.idNS and CT.idCT = CC.idCT and NS.idNS in (select idNS from ChamCong where month(ngayChamCong) = '7' and year(ngayChamCong) = '2020') GROUP BY NS.idNS;
TRUNCATE TABLE ChamCong