drop database if exists CinemaTicketingSystemDB;
create database if not exists CinemaTicketingSystemDB;
	
use CinemaTicketingSystemDB;

create table if not exists Cinemas(
	cine_id int primary key auto_increment,
    cine_address char(255) not null,
    cine_name char(50) not null unique,
    cine_phone char(11) not null
);
    
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

create table if not exists Shows(
	movie_id int not null,
    cine_id int not null,
    constraint pk_ShowTable primary key (movie_id, cine_id),
    constraint fk_Movies_ShowTable foreign key (movie_id) references Movies(movie_id),
    constraint fk_Cinemas_ShowTable foreign key (cine_id) references Cinemas(cine_id)
);

create table if not exists RoomTypes(
	rt_name char(20) primary key,
    rt_description text
);

create table if not exists Rooms(
	room_id int primary key auto_increment,
    cine_id int not null ,
    rt_name char(20) not null,
    room_name char(50) not null unique,
    room_seats text not null,
    constraint fk_Cinemas_Rooms foreign key (cine_id) references Cinemas(cine_id),
    constraint fk_RoomType_Rooms foreign key (rt_name) references RoomTypes(rt_name)
);

create table if not exists SeatTypes(
	st_type char(10) primary key,
    st_description text
);

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

create table if not exists PriceSeatsOfRoomTypes(
	rt_name char(20),
    st_type char(20),
    price decimal(20, 0),
    constraint pk_PSORT primary key (rt_name, st_type),
    constraint fk_RoomTypes_PSORT foreign key (rt_name) references RoomTypes(rt_name),
    constraint fk_SeatTypes_PSORT foreign key (st_type) references SeatTypes(st_type)
);

create table if not exists SchedulesTime(
	sched_id int primary key ,
    sche_id int ,
    sched_dateShow date not null,
    sched_timeStart time not null,
    sched_timeEnd time not null,
    sched_roomSeats text not null,
    constraint fk_Schedules_ST foreign key (sche_id) references Schedules(sche_id)
);

create table if not exists Accounts (
	acc_name char(20) primary key,
    cine_id int not null,
    acc_password char(20) not null,
    acc_type char(20) not null,
    constraint fk_Cinemas_Accounts foreign key (cine_id) references Cinemas(cine_id)
);
