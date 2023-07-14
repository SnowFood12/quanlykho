create database WINFORM

GO 
CREATE TABLE TAIKHOAN(
	TenDangNhap varchar(30) primary key , 
	MatKhau varchar(30) , 
	SoDienThoai varchar(11) 
);	
select * from TAIKHOAN where 