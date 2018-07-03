drop database if exists CinemaTicketingSystemDB;
create database if not exists CinemaTicketingSystemDB char set 'utf8';
	
use CinemaTicketingSystemDB;

create table if not exists Cinemas(
	cine_id int primary key auto_increment,
    cine_address char(255) not null,
    cine_name char(50) not null unique,
    cine_phone char(11) not null
);
    insert into Cinemas(cine_address, cine_name, cine_phone) values
		('Tầng 8 của TTTM Vincom, số 2 Phạm Ngọc Thạch, Đống Đa, Hà Nội','BHD Star Phạm Ngọc Thạch','0861231654'),
        ('Tầng 5, TTTM Vincom Center, 159 Xa Lộ Hà Nội, Quận 2, TP.HCM', 'BHD Star Thảo Điền','0862645820'),
        ('Lầu 5, Siêu Thị Vincom 3/2, 3C Đường 3/2, Quận 10, TPHCM', 'BHD STAR 3/2','0862315489'),
        ('Tầng B1&B2, TTTM Vincom, số 190 Quang Trung, Gò Vấp, Tp.HCM','BHD STAR QUANG TRUNG','0893123548'),
        ('Vincom Huế, 50A Hùng Vương tổ 10, Phú Nhuận, Thành phố Huế, Thừa Thiên Huế ','BHD STAR HUẾ','0863124896');
create table if not exists Movies(
	movie_id int primary key auto_increment,
    movie_name char(100) unique,
    movie_description text,
    movie_author char(50),
    movie_actor char(255),
    movie_category char(50),
    movie_time int default 0,
    movie_dateStart date not null,
    movie_dateEnd date not null
);
    insert into Movies( movie_name, movie_description, movie_author, movie_actor, movie_category, movie_time, movie_dateStart, movie_dateEnd) values
	('Gia đình siêu nhân 2', 'Gia Đình Siêu Nhân 2 đánh dấu những chuyến phiêu lưu anh hùng đầy hấp dẫn với sự đổi vai đầy táo bạo. 
    Lần này, mẹ dẻo Helen (Elastigirl) sẽ đi thực chiến giải cứu thế giới 
    trong khi bố khỏe Bob (Mr. Incredible) lùi về hậu phương trông nom những đứa con siêu nhân láu lỉnh gồm: 
    con gái Violet ( siêu năng lực tàng hình và tạo ra từ trường làm chắn bảo vệ), 
    con trai Dash (chạy siêu nhanh) và cậu út Jack-Jack với sức mạnh chưa được khám phá. 
    Một ác nhân bí ẩn xuất hiện với một âm mưu đáng sợ khiến cho gia đình siêu nhân phải “tái xuất giang hồ”.
    Liệu gia đình siêu nhân sẽ vượt qua khó khăn này như thế nào?'
    ,'Brad Bird','Holly Hunter, Samuel L. Jackson, Sarah Vowell','Hành Động, Hoạt Hình',132,'2018-06-15','2018-12-15'),
    ('Băng Cướp Thế Kỷ: Đẳng Cấp Quý Cô','Bà hoàng trộm cướp Debbie Ocean (Sandra Bullock) đã tái xuất bên cạnh cô bạn Lou (Cate Blanchett) 
    cùng dàn “đả nữ “ gồm Amita (Mindy Kaling) – chuyên gia trang sức, Constance (Awkwafina) – kẻ chuyên móc túi, 
    Tammy (Sarah Paulson) – bà mẹ hoàn lương, Nine Ball (Rihana) - nữ hacker cực đỉnh và 
    Rose (Helena Bonham Carter) - nhà thiết kế nổi tiếng trong vụ cướp có giá trị triệu đô tại buổi tiệc thường niên Met Gala.
    Liệu những “nữ quái” của chúng ta có thành công trong phi vụ đánh cắp đầy khó khăn này không? Hãy theo chân băng cướp thế kỷ nhé','Gary Ross',
    'Samantha Cocozza, Olivia Munn, Cate Blanchett','Hành Động, Hồi hộp',110,'2018-06-22','2018-12-22')
    ,('Thế Giới Khủng Long: Vương Quốc Sụp Đổ','4 năm sau thảm họa Công Viên kỷ Jura bị phá hủy bởi những con khủng long. 
    Một vài con khủng long vẫn còn sống sót trong rừng trong khi Isla Nublar bị con người bỏ hoang. 
    Owen (Chris Pratt) và Claire (Bryce Dallas Howard) đã tiến hành chiến dịch giải cứu những con khủng long còn sống sót khỏi sự tuyệt chủng 
    khi ngọn núi lửa tại khu vực này bắt đầu hoạt động trở lại. Họ vô tình khám phá ra một âm mưu 
    có thể khiến toàn bộ hành tinh đối mặt với một hiểm họa to lớn chưa từng thấy kể từ thời tiền sử.','J.A. Bayona'
    ,'Bryce Dallas Howard, Chris Pratt, Jeff Goldblum','Hành Động, Phiêu Lưu',128,'2018-06-08','2018-12-08')
    ,('Biệt Đội Cún Cưng', 'Đặc vụ FBI Frank bất đắc dĩ phải trở thành cộng sự với chú chó Max để cùng triệt phá đường dây buôn lậu động vật. 
    Cùng với sự giúp sức của biệt đội cún cưng, họ đã cùng nhau trải qua những tình huống dở khóc dở cười. 
    Liệu bọn họ có hoàn thành nhiệm vụ một cách thành công? Hãy cùng theo dõi hành trình phá án của Frank và các chú chó này nhé'
    ,'Raja Gosnell','Will Arnett, Stanley Tucci, Chris "Ludacris" Bridges, Natasha Lyonne','Gia đình, Hài',90,'2018-06-08','2018-12-08')
    ,('Kẻ Trộm Mặt Trăng 3','Kẻ Trộm Mặt Trăng 3 tiếp tục được thực hiện bởi đội ngũ sản xuất uy tín của các phần trước, 
    có sự tham gia lồng tiếng của Jenny Slate, Kristen Wiig, Steve Carell... Với câu chuyện mới vui nhộn và hấp dẫn hơn 
    cùng sự trở lại của các nhân vật được yêu thích, tác phẩm hứa hẹn sẽ làm thỏa mãn người hâm mộ của series phim đình đám này.'
    ,'Pierre Coffin, Kyle Balda, Eric Guillon', 'Steve Carell, Kristen Wiig, Trey Parker, Miranda Cosgrove, Dana Gaier, Nev Scharrel, Steve Coogan, 
    Jenny Slate, Julie Andrews','Gia đình, Hài', 90, '2018-06-30', '2018-12-30');
create table if not exists Shows(
	movie_id int not null,
    cine_id int not null,
    constraint pk_ShowTable primary key (movie_id, cine_id),
    constraint fk_Movies_ShowTable foreign key (movie_id) references Movies(movie_id),
    constraint fk_Cinemas_ShowTable foreign key (cine_id) references Cinemas(cine_id)
);
    insert into Shows(movie_id, cine_id) values
	(1,1), (1,2), (1,3), (1,4), (1,5),
    (2,1), (2,2), (2,3), (2,4), (2,5),
    (3,1), (3,2), (3,3), (3,4), (3,5),
    (4,1), (4,2), (4,3), (4,4), (4,5),
    (5,1), (5,2), (5,3), (5,4), (5,5);

create table if not exists RoomTypes(
	rt_name char(20) primary key,
    rt_description text
);
    insert into RoomTypes(rt_name, rt_description) values
	('2D','Phụ đề việt'),
    ('IMAX2D','Phụ đề việt'),
    ('3D','Phụ đề việt'),
    ('4DX2D','Phụ đề việt'),
    ('Lamour','Thuyết minh');
create table if not exists Rooms(
	room_id int primary key auto_increment,
    cine_id int not null ,
    rt_name char(20) not null,
    room_name char(50) not null unique,
    room_seats text not null,
    constraint fk_Cinemas_Rooms foreign key (cine_id) references Cinemas(cine_id),
    constraint fk_RoomType_Rooms foreign key (rt_name) references RoomTypes(rt_name)
);
    insert into Rooms(cine_id, rt_name, room_name, room_seats) values
    (1,'3D','Room 01','_________________________________________________________n_________________________________________________________nN:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10nN:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10nN:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10nN:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10nN:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10nN:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10nN:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10nN:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10nN:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10nN:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10nN:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10n'),
    (2,'IMAX2D','Room 02','_________________________________________________________n_________________________________________________________nN:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10nN:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10nN:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10nN:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10nN:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10nN:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10nN:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10nN:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10nN:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10nN:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10nN:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10n'),
    (3,'2D','Room 03','_________________________________________________________n_________________________________________________________nN:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10nN:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10nN:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10nN:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10nN:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10nN:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10nN:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10nN:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10nN:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10nN:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10nN:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10n'),
    (4,'Lamour','Room 04','_________________________________________________________n_________________________________________________________nN:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10nN:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10nN:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10nN:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10nN:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10nN:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10nN:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10nN:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10nN:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10nN:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10nN:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10n'),
    (5,'4DX2D','Room 05','_________________________________________________________n_________________________________________________________nN:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10nN:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10nN:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10nN:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10nN:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10nN:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10nN:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10nN:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10nN:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10nN:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10nN:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10n');
create table if not exists SeatTypes(
	st_type char(10) primary key,
    st_description text
);
    insert into SeatTypes (st_type, st_description) values
	('N','Ghế thường'),
    ('V','Ghế Vip'),
    ('D','Ghế đôi');
create table if not exists Schedules(
	sche_id int primary key auto_increment,
    room_id int not null,
    movie_id int not null,
    sche_status tinyint not null,
    sche_weekdays text,
    sche_timeline text,
    constraint fk_Rooms_Schedules foreign key (room_id) references Rooms(room_id),
    constraint fk_Movies_Schedules foreign key (movie_id) references Movies(movie_id)
);

    insert into Schedules(room_id, movie_id, sche_status, sche_weekdays, sche_timeline) values
	(1,1,0,'','07:00'),
    (2,2,0,'','09:00'),
    (3,3,0,'','11:00'),
    (4,4,0,'','14:00'),
    (5,5,0,'','16:00');
create table if not exists PriceSeatsOfRoomTypes(
	rt_name char(20),
    st_type char(20),
    price decimal(20, 0),
    constraint pk_PSORT primary key (rt_name, st_type),
    constraint fk_RoomTypes_PSORT foreign key (rt_name) references RoomTypes(rt_name),
    constraint fk_SeatTypes_PSORT foreign key (st_type) references SeatTypes(st_type)
);

insert into PriceSeatsOfRoomTypes(rt_name, st_type, price) values
	('3D','N',60000.00),
    ('3D','D',100000.00),
    ('3D','V',80000.00),
    ('2D','N',50000.00),
    ('2D','D',90000.00),
    ('2D','V',70000.00),
    ('Lamour','N',80000.00),
    ('Lamour','D',150000.00),
    ('Lamour','V',120000.00),
    ('4DX2D','N',100000.00),
    ('4DX2D','D',180000.00),
    ('4DX2D','V',150000.00),
    ('IMAX2D','N',70000.00),
    ('IMAX2D','D',120000.00),
    ('IMAX2D','V',100000.00);

create table if not exists SchedulesTime(
	sched_id int primary key ,
    sche_id int ,
    sched_dateShow date not null,
    sched_timeStart time not null,
    sched_timeEnd time not null,
    sched_roomSeats text not null,
    constraint fk_Schedules_ST foreign key (sche_id) references Schedules(sche_id)
);
insert into SchedulesDetails(sche_id, sched_dateShow, sched_timeStart, sched_timeEnd, sched_roomSeats) values
	(1,'2018-08-01','07:00:00','09:12:00','_________________________________________________________n_________________________________________________________nN:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10nN:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10nN:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10nN:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10nN:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10nN:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10nN:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10nN:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10nN:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10nN:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10nN:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10n'),
    (2,'2018-08-01','09:00:00','10:50:00','_________________________________________________________n_________________________________________________________nN:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10nN:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10nN:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10nN:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10nN:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10nN:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10nN:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10nN:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10nN:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10nN:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10nN:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10n'),
    (3,'2018-08-01','11:00:00','13:08:00','_________________________________________________________n_________________________________________________________nN:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10nN:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10nN:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10nN:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10nN:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10nN:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10nN:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10nN:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10nN:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10nN:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10nN:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10n'),
    (4,'2018-08-01','14:00:00','15:30:00','_________________________________________________________n_________________________________________________________nN:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10nN:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10nN:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10nN:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10nN:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10nN:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10nN:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10nN:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10nN:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10nN:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10nN:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10n'),
    (5,'2018-08-01','16:00:00','17:30:00','_________________________________________________________n_________________________________________________________nN:A1 N:A2 . V:A3 V:A4 V:A5 V:A6 V:A7 V:A8 . N:A9 N:A10nN:B1 N:B2 . V:B3 V:B4 V:B5 V:B6 V:B7 V:B8 . N:B9 N:B10nN:C1 N:C2 . V:C3 V:C4 V:C5 V:C6 V:C7 V:C8 . N:C9 N:C10nN:D1 N:D2 . V:D3 V:D4 V:D5 V:D6 V:D7 V:D8 . N:D9 N:D10nN:E1 N:E2 . V:E3 V:E4 V:E5 V:E6 V:E7 V:E8 . N:E9 N:E10nN:F1 N:F2 . V:F3 V:F4 V:F5 V:F6 V:F7 V:F8 . N:F9 N:F10nN:G1 N:G2 . V:G3 V:G4 V:G5 V:G6 V:G7 V:G8 . N:G9 N:G10nN:H1 N:H2 . V:H3 V:H4 V:H5 V:H6 V:H7 V:H8 . N:H9 N:H10nN:I1 N:I2 . V:I3 V:I4 V:I5 V:I6 V:I7 V:I8 . N:I9 N:I10nN:J1 N:J2 . V:J3 V:J4 V:J5 V:J6 V:J7 V:J8 . N:J9 N:J10nN:K1 N:K2 . V:K3 V:K4 V:K5 V:K6 V:K7 V:K8 . N:K9 N:K10n');

create table if not exists Accounts (
	acc_username char(20) primary key,
    cine_id int not null,
    acc_password char(20) not null,
    acc_type char(20) not null,
    constraint fk_Cinemas_Accounts foreign key (cine_id) references Cinemas(cine_id)
);
insert into Accounts(acc_username, cine_id, acc_password, acc_type) values
	('manager_01',1,'123456','m'),
    ('staff_01',1,'123456','s');

drop user if exists 'CTSUser'@'localhost';
create user if not exists 'CTSUser'@'localhost' identified by '123456';
    grant all on Cinemas to 'CTSUser'@'localhost';
    grant all on Movies to 'CTSUser'@'localhost';
    grant all on Shows to 'CTSUser'@'localhost';
    grant all on Rooms to 'CTSUser'@'localhost';
    grant all on Schedules to 'CTSUser'@'localhost';
    grant all on Accounts to 'CTSUser'@'localhost';
    grant all on RoomTypes to 'CTSUser'@'localhost';
    grant all on SeatTypes to 'CTSUser'@'localhost';
    grant all on PriceSeatsOfRoomTypes to 'CTSUser'@'localhost';
    grant all on SchedulesDetails to 'CTSUser'@'localhost';
select * from movies;