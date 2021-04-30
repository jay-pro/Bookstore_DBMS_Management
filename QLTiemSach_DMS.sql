--Tạo database
create database QLTiemSach_DMS

use QLTiemSach_DMS
go

--Tạo bảng Quản lý
create table dbo.QUANLY(
	MaQL int primary key,
	TenQL nvarchar(50) not NULL,
	Email varchar(50) not NULL,
	Tuoi int not NULL,
	DiaChi nvarchar(100) not NULL,
	SDT char(10) not NULL,
	Luong int not NULL
);

insert into QUANLY values(18110168,N'Bùi Hà Nhi','18110168@gmail.com',20,N'Việt Nam','0908259937',10000000)--10 triệu

--Tạo bảng Chi Nhánh
create table dbo.CHINHANH(
	MaCN int primary key,
	TenCN nvarchar(50) not NULL,
	DiaChi nvarchar(100) not NULL,
	SDT char(10) not NULL,
	MaQL int references QUANLY(MaQL)
);

insert into CHINHANH values(101,N'Little BookStore Cở Sở Thủ Đức',N'Quận Thủ Đức','0111222333',18110168)
insert into CHINHANH values(102,N'Little BookStore Cở Sở Bình Thạnh',N'Quận Bình Thuận','0222111333',18110168)


--Tạo bảng loại menu
create table dbo.LOAIMENU(
	MaLoai int primary key,
	TenLoai nvarchar(100) not NULL
);

insert into LOAIMENU values(1,N'Sách Trong Nước')
insert into LOAIMENU values(2,N'Sách Nước Ngoài')
insert into LOAIMENU values(3,N'Văn Phòng Phẩm')

--Tạo bảng Tác Gỉa
create table dbo.TACGIA(
	MaTacGia nvarchar(100),											--TG001
	TenTacGia nvarchar(100),									--Margery Williams
	QuocGia	nvarchar(100),											--United State
	primary key(MaTacGia)	
);

insert into	TACGIA values ('TG001','Margery Williams','My')
insert into	TACGIA values ('TG002','21st Century','Viet Nam')
insert into	TACGIA values ('TG003','Fuijiko F Fujio','Nhat Ban')
insert into	TACGIA values ('TG004','Ngoc Linh','Viet Nam')
insert into	TACGIA values ('TG005','Julia Cook','Duc')
insert into	TACGIA values ('TG006','Hungazit','Bi')
insert into	TACGIA values ('TG007','Nhieu Tac Gia','')
insert into	TACGIA values ('TG008','First News','Viet Nam')
insert into	TACGIA values ('TG009','Thuy Oanh','Viet Nam')
insert into	TACGIA values ('TG010','Trieu Thi Choi','Viet Nam')
insert into	TACGIA values ('TG011','Kamoshida Hajime','Nhat Ban')
insert into	TACGIA values ('TG012','Mieu Cong Tu','Trung Quoc')
insert into	TACGIA values ('TG013','Lan Rua','Viet Nam')
insert into	TACGIA values ('TG014','Shinkai Makoto','Nhat Ban')
insert into	TACGIA values ('TG015','J.K.Rowling','Anh')
insert into	TACGIA values ('TG016','Kozakura','Nhat Ban')
insert into	TACGIA values ('TG017','Tuan Kiet','Trung Quoc')
insert into	TACGIA values ('TG018','The Windy','Viet Nam')
insert into	TACGIA values ('TG019','Nguyen Van Hiep','Viet Nam')
insert into	TACGIA values ('TG020','TS Le Minh Toan','Viet Nam')
insert into	TACGIA values ('TG021','NGregory Mankiw','Bi')
insert into	TACGIA values ('TG022','Truong Ngoc Anh','Viet Nam')
insert into	TACGIA values ('TG023','TS Nguyen Thi Minh Hong','Viet Nam')
insert into	TACGIA values ('TG024','Bae Jin Yong','Han Quoc')
insert into	TACGIA values ('TG025','Andre Aciman','Duc')
insert into	TACGIA values ('TG026','Haemin Sunim','Han Quoc')
insert into	TACGIA values ('TG027','Stephen King','My')
insert into	TACGIA values ('TG028','Jojo Moyes','Bi')
insert into	TACGIA values ('TG029','Kevin Kwan','Anh')
insert into	TACGIA values ('TG030','Adrea Quynhgiao Nguyen','Viet Nam')
insert into	TACGIA values ('TG031','Karen Sullivan','Duc')
insert into	TACGIA values ('TG032','Robert Ashton','My')
insert into	TACGIA values ('TG033','Amy Webb','Bi')
insert into	TACGIA values ('TG034','Lawrence D Burns','Duc')
insert into	TACGIA values ('TG035','John C Havens','Phap')
insert into TACGIA values ('TG036','Khuong Le Binh','Trung Quoc')

--Tạo bảng Menu
create table dbo.MENU(
	MaLoai int references LOAIMENU(MaLoai),
	MaSP nvarchar(100) primary key,
	TenSP nvarchar(100) not NULL,
	Gia int not NULL,
	MaTacGia nvarchar(100) references TACGIA(MaTacGia),
	SoLuongDaBan int not NULL default(0)
);

insert into MENU values (1,'TN001','Chu Tho Nhung',99000,'TG001',10)
insert into MENU values (1,'TN002','Kich thich phat trien thi giac cho be',30000,'TG002',10)
insert into MENU values (1,'TN003','Doraemon Hoat Hinh Mau - Tap 1 (Tai Ban 2020)',33250,'TG003',50)
insert into MENU values (1,'TN004','Bo Sach Ky Nang Song (Danh Cho Tre 4-10 Tuoi)',57600,'TG004',15)
insert into MENU values (1,'TN005','Con xin loi, con da quen le phep!',39200,'TG005',15)
insert into MENU values (1,'NC001','Dau Bep Tu Do',199750,'TG006',10)
insert into MENU values (1,'NC002','Origami Gap Giay Thu Cong - Tro Choi Gap Giay',22750,'TG007',10)
insert into MENU values (1,'NC003','Bi Quyet Pha Che Sinh To & Nuoc Ep Trai Cay (Tai Ban)',86400,'TG008',50)
insert into MENU values (1,'NC004','An Chay Trong Yoga - Tai Tao Nguon Nang Luong Tich Cuc',99000,'TG009',50)
insert into MENU values (1,'NC005','Thiet Ke Thoi Trang Nu Xuan He',85800,'TG010',10)
insert into MENU values (1,'VH001','Just Because!',99000,'TG011',15)
insert into MENU values (1,'VH002','999 La Thu Gui Cho Chinh Minh - Mong Ban Tro Thanh Phien Ban Hoan Hao Nhat (Tai Ban 2020)',79200,'TG012',50)
insert into MENU values (1,'VH003','Le Nao Em Khong Biet (Tai Ban 2019)',85600,'TG013',50)
insert into MENU values (1,'VH004','Nho Ai Do Den Kiet Que (Tai Ban 2019)',87200,'TG013',50)
insert into MENU values (1,'VH005','Em La Nha',63700,'TG013',18)
insert into MENU values (1,'VH007','Your Name',46500,'TG014',50)
insert into MENU values (1,'VH008','Harry Potter Va Hon Da Phu Thuy - Tap 1 (Tai Ban 2017)',108000,'TG015',50)
insert into MENU values (1,'VH009','Harry Potter Va Phong Chua Bi Mat - Tap 2 (Tai Ban 2017)',119250,'TG015',50)
insert into MENU values (1,'VH010','Harry Potter Va Ten Tu Nhan Nguc Azkaban - Tap 3 (Tai Ban 2017)',147600,'TG015',40)
insert into MENU values (1,'VH011','Harry Potter Va Chiec Coc Lua - Tap 4 (Tai Ban 2017)',221400,'TG015',40)
insert into MENU values (1,'VH012','Harry Potter Va Hoi Phuong Hoang - Tap 5 (Tai Ban 2017)',291100,'TG015',35)
insert into MENU values (1,'VH013','Harry Potter Va Hoang Tu Lai - Tap 6 (Tai Ban 2017)',176300,'TG015',34)
insert into MENU values (1,'VH014','Harry Potter Va Bao Boi Tu Than - Tap 7 (Tai Ban 2017)',210700,'TG015',54)
insert into MENU values (1,'SNN001','Combo Chinh Phuc Tieng Nhat (Bo 2 Cuon)',233640,'TG016',50)
insert into MENU values (1,'SNN002','Cam Nang Huong Dan Tu Hoc Tieng Duc Trinh Do So Cap - Trung Cap',96000,'TG017',10)
insert into MENU values (1,'SNN003','Giai Thich Ngu Phap Tieng Anh (Tai Ban 2020)',15400,'TG018',16)
insert into MENU values (1,'SNN004','Hack Nao Ngu Phap',276250,'TG019',50)
insert into MENU values (1,'SNN005','Tu Hoc 2000 Tu Vung Tieng Anh Theo Chu De (Tai Ban)',52000,'TG018',35)
insert into MENU values (1,'GT001','Phap Luat Dai Cuong',108000,'TG020',0)
insert into MENU values (1,'GT002','Kinh Te Hoc Vi Mo',261000,'TG021',0)
insert into MENU values (1,'GT003','Giao Trinh Vi Dieu Khien PC - Ly Thuyet Va Thuc Hanh',90720,'TG022',9)
insert into MENU values (1,'GT004','Giao Trinh Chuan HSK 1',168300,'TG023',9)
insert into MENU values (1,'GT005','Restart Your English - Basic Grammar - Yeu Lai Tieng Anh Tu Dau',229000,'TG024',18)

insert into MENU values (2,'FT001','Call Me By Your Name',316200,'TG025',50)
insert into MENU values (2,'FT002','The Things You Can See Only When You Slow Down',296650,'TG026',50)
insert into MENU values (2,'FT003','IT',175950,'TG027',40)
insert into MENU values (2,'FT004','Me Before You',177650,'TG028',50)
insert into MENU values (2,'FT005','Crazy Rich Asians',158100,'TG029',35)
insert into MENU values (2,'FD001','The Banh Mi HandBook: Recipes for Crazy-Delicious Vietnamese Sandwiches',271150,'TG030',35)
insert into MENU values (2,'FD002','Step-by-Step Cake Decorating',335750,'TG031',20)
insert into MENU values (2,'CPT001','Writing for the Web: Teach Yourself',299200,'TG032',70)
insert into MENU values (2,'CPT002','The Big Nine',268600,'TG033',13)
insert into MENU values (2,'CPT003','Autonomy: The Quest to Build the Driverless',249900,'TG034',8)
insert into MENU values (2,'CPT004','Hacking Happiness',230350,'TG035',10)

insert into MENU values (3,'BV001','But Bi Cao Cap Parker Sonnet SLM Đ-ST Silver GT GB-1931493',6997700,'TG007',9)
insert into MENU values (3,'BV002','Viet Long Baoke MP2913-36',429300,'TG007',10)
insert into MENU values (3,'BV003','But Bi Van CEO-775',302100,'TG007',10)
insert into MENU values (3,'BV004','But Gel Thien Long Gel-08 Sunbeam',6500,'TG007',10)
insert into MENU values (3,'BV005','Hop But Bi TL-097 - Muc Xanh',58900,'TG007',1000)
insert into MENU values (3,'SPDT001','May Tinh Casio FX 580 VN X',624150,'TG007',100)
insert into MENU values (3,'SPDT002','May Tinh Vinacal 570 ES Plus II Xanh La',464400,'TG007',101)
insert into MENU values (3,'BG001','Balo Chong Gu Lop Hoc Mat Ngu Milita Red F1 - A-BL10000',990000,'TG007',24)
insert into MENU values (3,'BG002','Balo Chong Gu Lop Hoc Mat Ngu Koola Green Thunder Power - A-BL10011',990000,'TG007',10)
insert into MENU values (3,'BG003','Balo Thoi Trang Trip Talk! Lost Lake - BLMS00105',306180,'TG007',1)
insert into MENU values (3,'BG004','Balo Thoi Trang Lolli Talk! Ocean - BLMS00305',85000,'TG007',0)
insert into MENU values (3,'BG005','Tui Deo Cheo Simple Talk! Orange And Grey - TDMS00103 ',179820,'TG007',1)
insert into MENU values (3,'SPK001','Sticker Trai Tim Nhieu Mau Apli 13898',27200,'TG007',50)
insert into MENU values (3,'SPK002','LEGO Clasic 10696 - Thung Gach Trung Classic Sang Tao',761400,'TG007',9)

--Tạo bảng Nhân Viên
create table dbo.NHANVIEN(
	MaNV int primary key,
	TenNV nvarchar(50) not NULL,
	Email varchar(50) not NULL,
	Tuoi int not NULL,
	ChucVu nvarchar(20) NULL,
	SDT char(10) not NULL,
	DiaChi nvarchar(100) not NULL,
	MaCN int references CHINHANH(MACN),
	Luong int not NULL
);

insert into NHANVIEN values(1001,N'Kim Seok Jin','kimseokjin@gmail.com',29,N'Thu Ngân','0101010101',N'Quận Thủ Đức',101,1500000)
insert into NHANVIEN values(1002,N'Min Yoongi','minyoongi@gmail.com',28,N'Thu Ngân','0202020202',N'Quận Bình Thạnh',102,12000000)
insert into NHANVIEN values(1003,N'Jung Hoseok','junghoseok@gmail.com',27,N'Kiểm Kê','0303030303',N'Quận Thủ Đức',101,12000000)
insert into NHANVIEN values(1004,N'Kim Nam Joon','kimnamjoon@gmail.com',27,N'Bảo Vệ','0404040404',N'Quận Thủ Đức',101,10000000)
insert into NHANVIEN values(1005,N'Park Jimin','parkjimin@gmail.com',26,N'Kiểm Kê','0405050505',N'Quận Bình Thạnh',102,10000000)
insert into NHANVIEN values(1006,N'Kim Taehuyng','kimtaehuyng@gmail.com',26,N'Kiểm Kê','0975',N'Quận Thủ Đức',101,8000000)
insert into NHANVIEN values(1007,N'Jeon Jungkook','jeonjungkook@gmail.com',24,N'Bảo Vệ','0907070707',N'Quận Bình Thạnh',102,7000000)


--Tạo bảng khách hàng
create table dbo.KHACHHANG(
	MaKH int primary key,
	TenKH nvarchar(50) not NULL,
	Email varchar(50) not NULL,
	Tuoi int NULL,
	SDT char(10) NULL,
	DiaChi nvarchar(100) NULL,
	TongChiTieu int NULL default(0),
	CapThanhVien int NULL default(0),
);

insert into KHACHHANG values(1, N'Doraemon', 'doraemon@gmail.com',13,'0912312312', N'Nhật Bản', 2102000, 3)
insert into KHACHHANG values(2, N'Nobita','nobita@gmail.com',13,'0912312333', N'Nhật Bản', 1560000, 2)
insert into KHACHHANG values(3,N'Shizuka','shizuka@gmail.com',13,'0123456678',N'Nhật Bản',3200000,4)
insert into KHACHHANG values(4,N'Suneo','suneo@gmail.com',13,'0123466754',N'Nhật Bản',9000000,5)
insert into KHACHHANG values(5,N'Jaian','jaian@gmail.com',13,'023445776',N'Nhật Bản',200000,1)

--Tạo bảng Tài khoản
create table dbo.TAIKHOANQL(
	UserName varchar(50) not NULL,
	Pass varchar(20) not null default(0),
	MaQL int references QUANLY(MaQL),
	primary key(MaQL)
);

insert into TAIKHOANQL values('buihanhi','buihanhi',18110168)

create table dbo.TAIKHOANKH(
	UserName varchar(50) not NULL,
	Pass varchar(20) not null default(0),
	MaKH int references KHACHHANG(MaKH) not null,
	primary key (MaKH)
);

insert into TAIKHOANKH values('doraemon','doraemon',1)
insert into TAIKHOANKH values('nobita','nobita',2)
insert into TAIKHOANKH values('shizuka','shizuka',3)
insert into TAIKHOANKH values('suneo','suneo',4)
insert into TAIKHOANKH values('jaian','jaian',5)

create table dbo.TAIKHOANNV(
	UserName varchar(50) not NULL,
	Pass varchar(20) not null default(0),
	MaNV int references NHANVIEN(MaNV),
	primary key(MaNV)
);

insert into TAIKHOANNV values('NV01','1234567890',1001)
insert into TAIKHOANNV values('NV02','1234567890',1002)
insert into TAIKHOANNV values('NV03','1234567890',1003)
insert into TAIKHOANNV values('NV04','1234567890',1004)
insert into TAIKHOANNV values('NV05','1234567890',1005)
insert into TAIKHOANNV values('NV06','1234567890',1006)
insert into TAIKHOANNV values('NV07','1234567890',1007)

--Tạo bảng Hóa đơn
create table dbo.HOADON(
	MaHD int primary key,
	MaKH int references KHACHHANG(MaKH),
	MaCN int references CHINHANH(MaCN),
	NgayXuatHD datetime not NULL,
	TongGia int not NULL
);

--Tạo bảng Chi Tiết Hóa Đơn
create table dbo.CHITIETHD(
	MaHD int references HOADON(MaHD),
	MaSP nvarchar(100) references MENU(MaSP),
	Loai varchar(10) not NULL,
	SoLuong int not null,
	Gia int not NULL,
	primary key(MaHD, MaSP)
);

------------------------------------------Function------------------------------------------
--Hàm Tính Tổng Lương của 1 chi nhánh
create function f_TongLuongChiNhanh (@MaCN int)
returns numeric(18,0)
as
begin
	declare @sum numeric(18,0)
	select @sum = Sum(NHANVIEN.Luong)
	from NHANVIEN
	where @MaCN = MaCN
	return @sum
end;

select dbo.f_TongLuongChiNhanh(101)		--Xem lương chi nhánh 101
select * from NHANVIEN					--Xem toàn bộ bảng nhân viên để đối chiếu

--Hàm Tính Lương Trung Bình của 1 chi nhánh
create function f_TrungBinhLuongChiNhanh (@MaCN int)
returns numeric(18,0)
as
begin
	declare @average numeric(18,0)
	select @average = AVG(NHANVIEN.Luong)
	from NHANVIEN
	where @MaCN = MaCN
	return @average
end;
go

select dbo.f_TrungBinhLuongChiNhanh(101)	--Xem lương trung bình chi nhánh 101
select * from NHANVIEN						--Xem toàn bộ bảng nhân viên để đối chiếu

--Hàm In ra các thông tin của Nhân Viên theo Mã Chi Nhánh
create function f_ThongTinNhanVienTheoMaChiNhanh(@machinhanh int) 
returns table     
as 
return(select NHANVIEN.MaNV, NHANVIEN.TenNV, NHANVIEN.Email, NHANVIEN.Tuoi, NHANVIEN.ChucVu, NHANVIEN.SDT, NHANVIEN.DiaChi, NHANVIEN.MaCN, NHANVIEN.Luong 
		from NHANVIEN join CHINHANH on NHANVIEN.MaCN = CHINHANH.MaCN
		where CHINHANH.MaCN = @machinhanh)

select * from dbo.f_ThongTinNhanVienTheoMaChiNhanh(101)		--Xem thông tin tất cả nhân viên của chi nhánh 101
select * from NHANVIEN										--Xem toàn bộ bảng nhân viên để đối chiếu

--Hàm In ra thông tin của Khách Hàng với Mã Khách Hàng
create function f_ThongTinKhachHangTheoMaKhachHang(@makhachhang nvarchar(50)) 
returns table
as
return (select *
		from KHACHHANG
		where KHACHHANG.MaKH like N'%'+@makhachhang+'%')

--Hàm In ra thông tin của Khách Hàng với Tên Khách Hàng
create function f_ThongTinKhachHangTheoTenKhachHang(@tenkhachhang nvarchar(50)) 
returns table
as
return (select *
		from KHACHHANG
		where KHACHHANG.TenKH like N'%'+@tenkhachhang+'%')

--Hàm In ra thông tin của Khách Hàng với Email Khách Hàng
create function f_ThongTinKhachHangTheoEmailKhachHang(@email nvarchar(50)) 
returns table
as
return (select *
		from KHACHHANG
		where KHACHHANG.Email like N'%'+@email+'%')

--Hàm In ra thông tin của Khách Hàng với Số điện thoại Khách Hàng
create function f_ThongTinKhachHangTheoSDTKhachHang(@sdt nvarchar(50)) 
returns table
as
return (select *
		from KHACHHANG
		where KHACHHANG.SDT like N'%'+@sdt+'%')

--Hàm In ra thông tin của Khách Hàng với Địa Chỉ Khách Hàng
create function f_ThongTinKhachHangTheoDiaChiKhachHang(@diachi nvarchar(50)) 
returns table
as
return (select *
		from KHACHHANG
		where KHACHHANG.DiaChi like N'%'+@diachi+'%')

--Hàm in ra 10 sản phẩm bán chạy nhất
create function f_Top10BestSellers()
returns table
as
return (select Top(10) *
		from MENU
		order by SoLuongDaBan desc)

select * from dbo.f_Top10BestSellers()		--Top 10 best seller
select * from MENU							--In ra bảng MENU để đối chiếu

--Function top 3 khách hàng mua nhiều nhất
create function f_Top3KhachHangThanThiet()
returns table
as
return (select Top(3) *
		from KHACHHANG
		order by TongChiTieu desc)

SELECT * from f_Top3KhachHangThanThiet()		--Top 3 khách hàng thân thiết
select * from MENU								--In ra bảng MENU để đối chiếu

------------------------------------------Trigger------------------------------------------
--trigger tăng lương người quản lý khi tăng lương nhân viên thuộc chi nhánh(+=50% lượng tiền được tăng của nhân viên)
create trigger TangLuongQL on NHANVIEN
after update
as
declare @new int, @old int, @MaNV int
select @MaNV = ol.MaNV, @new = ne.Luong, @old = ol.Luong
from inserted as ne, deleted as ol
where ne.MaNV = ol.MaNV
if(@new > @old)
begin
	declare @MaQL int
	select @MaQL = CN.MaQL
	from CHINHANH as CN, NHANVIEN as NV
	where NV.MaCN = CN.MaCN and NV.MaNV = @MaNV

	update QUANLY set Luong = Luong + 0.5 * (@new - @old) where MaQL = @MaQL
end
go

--trigger tăng lương người quản lý khi có thêm nhân viên mới vào chi nhánh (+=10% lương của nhân viên mới)
create trigger TangLuongQLnew on NHANVIEN
after insert
as
declare @new int, @MaNV int
select @MaNV = ne.MaNV, @new = ne.Luong
from inserted as ne
begin
	declare @MaQL int
	select @MaQL = CN.MaQL
	from CHINHANH as CN, NHANVIEN as NV
	where NV.MaCN = CN.MaCN and NV.MaNV = @MaNV

	update QUANLY set Luong = Luong + 0.1 * @new where MaQL = @MaQL
end
go

--trigger bảng TAIKHOANQL
create trigger KiemtraTKQL on TAIKHOANQL
after insert
as
declare @newtk varchar(50), @maql int
select @newtk = UserName, @maql = MaQL
from inserted
begin
	declare @ma int
	set @ma = 0

	select @ma = MaKH
	from TAIKHOANKH
	where UserName = @newtk

	select @ma = MaNV
	from TAIKHOANNV
	where UserName = @newtk

	if(@ma != 0)
	begin
		delete from TAIKHOANQL where MaQL = @maql
		delete from QUANLY where MaQL = @maql
	end
end
go

--Kiểm tra
--select * from TAIKHOANQL
--select * from QUANLY
--insert into QUANLY values(123,N'noname','abc@gmail.com',20,N'Quận Bình Thuận','0123456789',50000000)
--insert into TAIKHOANQL values('hanhi','12345', 123)
--drop trigger KiemtraTKQL
--delete from TAIKHOANQL where MaQL = 123

--trigger bảng TAIKHOANNV
create trigger KiemtraTKNV on TAIKHOANNV
after insert
as
declare @newtk varchar(50), @manv int
select @newtk = UserName, @manv = MaNV
from inserted
begin
	declare @ma int
	set @ma = 0

	select @ma = MaQL
	from TAIKHOANQL
	where UserName = @newtk

	select @ma = MaKH
	from TAIKHOANKH
	where UserName = @newtk

	if(@ma != 0)
	begin
		delete from TAIKHOANNV where MaNV = @manv
		delete from NHANVIEN where MaNV = @manv
	end
end
go

--trigger bảng TAIKHOANKH
create trigger KiemtraTKKH on TAIKHOANKH
after insert
as
declare @newtk varchar(50), @makh int
select @newtk = UserName, @makh = MaKH
from inserted
begin
	declare @ma int
	set @ma = 0

	select @ma = MaQL
	from TAIKHOANQL
	where UserName = @newtk

	select @ma = MaNV
	from TAIKHOANNV
	where UserName = @newtk

	if(@ma != 0)
	begin
		delete from TAIKHOANKH where MaKH = @makh
		delete from KHACHHANG where MaKH = @makh
	end
end
go
--------------------------------------------Tạo ràng buộc username là unique để không bị trùng username------------------------------------
--bảng TAIKHOANQL
alter table TAIKHOANQL
add constraint RB_Unique_QL unique(UserName)
go
--bảng TAIKHOANKH
alter table TAIKHOANKH
add constraint RB_Unique_KH unique(UserName)
go

--bảng TAIKHOANNV
alter table TAIKHOANNV
add constraint RB_Unique_NV unique(UserName)
go

------------------------------------------Procedure------------------------------------------
--Thủ Tục Tìm Sản Phẩm có giá dưới ...
create procedure TimSanPhamCoGiaDuoi
@gia int
as
begin	
	select * 
	from MENU
	where MENU.Gia <= @gia
end;

execute TimSanPhamCoGiaDuoi 100000		--Tìm Thử
select * from MENU						--Đối chiếu

--Thủ Tục Tìm Nhân Viên có lương dưới...
create procedure TimNhanVienCoLuongDuoi
@luong int
as
begin	
	select * 
	from NHANVIEN
	where NHANVIEN.Luong <= @luong
end;

execute TimNhanVienCoLuongDuoi 10000000

--Thủ Tục Tìm Nhân Viên có lương trên...
create procedure TimNhanVienCoLuongTren
@luong int
as
begin
	select *
	from NHANVIEN
	where NHANVIEN.Luong >= @luong
end;

execute TimNhanVienCoLuongTren 10000000

--Thủ Tục Tìm Khách Hàng Có Tổng Chi Tiêu Dưới ...
create procedure TimKhachHangCoTongChiTieuDuoi
@tongchitieu int
as
begin	
	select * 
	from KHACHHANG
	where KHACHHANG.TongChiTieu <= @tongchitieu
end;

execute TimKhachHangCoTongChiTieuDuoi 10000000

--Thủ Tục Tìm Khách Hàng Có Tổng Chi Tiêu Trên ...
create procedure TimKhachHangCoTongChiTieuTren
@tongchitieu int
as
begin	
	select * 
	from KHACHHANG
	where KHACHHANG.TongChiTieu >= @tongchitieu
end;

execute TimKhachHangCoTongChiTieuTren 100000

--PROCEDURE kết hợp TRANSACTION xóa quản lý
create procedure XoaQuanLy
@maql int
as
begin
	Set XACT_ABORT ON
	begin TRANSACTION
		update CHINHANH set MaQL = NULL where MaQL = @maql
		delete from TAIKHOANQL where MaQL = @maql
		delete from QUANLY where MaQL = @maql
	COMMIT
end;

--exec XoaQuanLy 123
 
--Procedure Thêm Khách Hàng
create procedure ThemKhachHang 
@makh int,@tenkh nvarchar(50),@email varchar(50),@tuoi int,@sdt char(10),@diachi nvarchar(50), @tongchitieu int, @capthanhvien int
as
begin
	insert into KhachHang values(@makh,@tenkh,@email,@tuoi,@sdt,@diachi,@tongchitieu,@capthanhvien)
end

--Procedure Thêm tài khoản Khách Hàng
create procedure ThemTaiKhoanKhachHang 
@taikhoan varchar(50),@matkhau varchar(20),@makh int
as
begin
	insert into TAIKHOANKH values(@taikhoan,@matkhau,@makh)
end

--execute ThemTaiKhoanKhachHang 'taikhoan','12345',6
--insert into TAIKHOANKH values('bhn','12345',1)
--execute ThemKhachHang 3,'Hà Nhi Bùi','bhn@gmail.com',20,'0908259937',N'Sao Thổ',0,0
--drop procedure ThemKhachHang

--Procedure xuất hóa đơn
create proc XuatHoaDon 
@MaHD int
as
select * from CTHoaDon where Ma_Hoa_Don = @MaHD
go

-------------------------------------VIEW----------------------------------
--view hiện Danh sách hóa đơn
CREATE VIEW DSHD
AS
SELECT *
FROM HOADON
go

--tạo view chi tiết hóa đơn
Create View CTHoaDon
as
select CT.MaHD as Ma_Hoa_Don, 
	   CT.MaSP as Ma_San_Pham, 
	   M.TenSP as Ten_San_Pham, 
	   CT.SoLuong as So_Luong, 
	   CT.Gia as Gia, 
	   HD.MaCN as Ma_Chi_Nhanh, 
	   HD.NgayXuatHD as Ngay_xuat_Hoa_don
from MENU as M, CHITIETHD as CT, HOADON as HD
where CT.MaSP = M.TenSP and CT.MaHD = HD.MaHD
go

select * from CTHoaDon


------------------------------------------Phân Quyền------------------------------------------
--Tạo role quản lý
create role QuanLy
--grant all to QuanLy with grant option
--for tables
grant select, alter, control, insert, delete, update, references on CHINHANH to QuanLy with grant option
grant select, alter, control, insert, delete, update, references on CHITIETHD to QuanLy with grant option
grant select, alter, control, insert, delete, update, references on HOADON to QuanLy with grant option
grant select, alter, control, insert, delete, update, references on KHACHHANG to QuanLy with grant option
grant select, alter, control, insert, delete, update, references on LOAIMENU to QuanLy with grant option
grant select, alter, control, insert, delete, update, references on MENU to QuanLy with grant option
grant select, alter, control, insert, delete, update, references on NHANVIEN to QuanLy with grant option
grant select, alter, control, insert, delete, update, references on QUANLY to QuanLy with grant option
grant select, alter, control, insert, delete, update, references on TACGIA to QuanLy with grant option
grant select, alter, control, insert, delete, update, references on TAIKHOANKH to QuanLy with grant option
grant select, alter, control, insert, delete, update, references on TAIKHOANNV to QuanLy with grant option
grant select, alter, control, insert, delete, update, references on TAIKHOANQL to QuanLy with grant option
--for system stored procedures
grant execute on dbo.ThemKhachHang to QuanLy with grant option
grant execute on dbo.ThemTaiKhoanKhachHang to QuanLy with grant option
grant execute on dbo.TimKhachHangCoTongChiTieuDuoi to QuanLy with grant option
grant execute on dbo.TimKhachHangCoTongChiTieuTren to QuanLy with grant option
grant execute on dbo.TimNhanVienCoLuongTren to QuanLy with grant option
grant execute on dbo.TimNhanVienCoLuongDuoi to QuanLy with grant option
grant execute on dbo.TimSanPhamCoGiaDuoi to QuanLy with grant option
grant execute on dbo.XoaQuanLy to QuanLy with grant option		--Transaction + procedure
grant execute on dbo.XuatHoaDon to QuanLy with grant option
--for table-valued functions
grant select on dbo.f_ThongTinKhachHangTheoEmailKhachHang to QuanLy with grant option
grant select on dbo.f_ThongTinKhachHangTheoMaKhachHang to QuanLy with grant option
grant select on dbo.f_ThongTinKhachHangTheoSDTKhachHang to QuanLy with grant option
grant select on dbo.f_ThongTinKhachHangTheoDiaChiKhachHang to QuanLy with grant option
grant select on dbo.f_ThongTinKhachHangTheoTenKhachHang to QuanLy with grant option
grant select on dbo.f_ThongTinNhanVienTheoMaChiNhanh to QuanLy with grant option
grant select on dbo.f_Top10BestSellers to QuanLy with grant option
grant select on dbo.f_Top3KhachHangThanThiet to QuanLy with grant option
--for scalar-valued functions
grant execute on dbo.f_TongLuongChiNhanh to QuanLy with grant option
grant execute on dbo.f_TrungBinhLuongChiNhanh to QuanLy with grant option
--for views
grant select, alter, control, insert, delete, update, references on DSHD to QuanLy with grant option
grant select, alter, control, insert, delete, update, references on CTHoaDon to QuanLy with grant option


--Tạo role nhân viên
create role NhanVien
--grant all to NhanVien with grant option
--for tables
grant select, insert, delete, update on KHACHHANG to NhanVien with grant option
grant select, insert, delete, update on HOADON to NhanVien with grant option
grant select, insert, delete, update on CHITIETHD to NhanVien with grant option
grant select, insert, delete, update on MENU to NhanVien with grant option
--for system stored procedures
grant execute on dbo.ThemKhachHang to NhanVien with grant option
grant execute on dbo.ThemTaiKhoanKhachHang to NhanVien with grant option
grant execute on dbo.TimKhachHangCoTongChiTieuDuoi to NhanVien with grant option
grant execute on dbo.TimKhachHangCoTongChiTieuTren to NhanVien with grant option
grant execute on dbo.TimSanPhamCoGiaDuoi to NhanVien with grant option
grant execute on dbo.XuatHoaDon to NhanVien with grant option
--for table-valued functions
grant select on dbo.f_ThongTinKhachHangTheoEmailKhachHang to NhanVien with grant option
grant select on dbo.f_ThongTinKhachHangTheoMaKhachHang to NhanVien with grant option
grant select on dbo.f_ThongTinKhachHangTheoSDTKhachHang to NhanVien with grant option
grant select on dbo.f_ThongTinKhachHangTheoDiaChiKhachHang to NhanVien with grant option
grant select on dbo.f_ThongTinKhachHangTheoTenKhachHang to NhanVien with grant option
grant select on dbo.f_Top10BestSellers to NhanVien with grant option
grant select on dbo.f_Top3KhachHangThanThiet to NhanVien with grant option
--for scalar-valued functions
--nô
--for views
grant select, alter, control, insert, delete, update, references on DSHD to NhanVien with grant option
grant select, alter, control, insert, delete, update, references on CTHoaDon to NhanVien with grant option


---------------------Tạo login cho Quản lý
create login QL with password= 'buihanhi'
---------------------Tạo user cho Quản lý
create user buihanhi for login QL
---------------------Thêm member vào role QuanLy
execute sp_addrolemember'QuanLy','buihanhi'


---------------------Tạo login cho Nhân viên
create login NV01 with password= 'buihanhi'
create login NV02 with password= 'buihanhi'
create login NV03 with password= 'buihanhi'
create login NV04 with password= 'buihanhi'
create login NV05 with password= 'buihanhi'
create login NV06 with password= 'buihanhi'
create login NV07 with password= 'buihanhi'
-----------------------Tạo user cho Nhân viên
create user NV01 for login NV01
create user NV02 for login NV02
create user NV03 for login NV03
create user NV04 for login NV04
create user NV05 for login NV05
create user NV06 for login NV06
create user NV07 for login NV07
-----------------------Thêm member vào role NhanVien
exec sp_addrolemember'NhanVien','NV01'
exec sp_addrolemember'NhanVien','NV02'
exec sp_addrolemember'NhanVien','NV03'
exec sp_addrolemember'NhanVien','NV04'
exec sp_addrolemember'NhanVien','NV05'
exec sp_addrolemember'NhanVien','NV06'
exec sp_addrolemember'NhanVien','NV07'
