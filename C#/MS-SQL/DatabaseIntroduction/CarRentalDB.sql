create database CarRental;
go
use CarRental;
go

--•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
create table Categories
(
	Id int identity primary key,
	CategoryName nvarchar(50),
	DailyRate smallint,
	MonthlyRate smallint,
	WeekendRate smallint
);

--•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
create table Cars
(
	Id int identity primary key,
	PlateNumber smallint,
	Manufacturer nvarchar(100),
	Model nvarchar(20),
	CarYear smallint,
	CategoryId int,
	Doors nvarchar(50),
	Picture image,
	Condition nvarchar(30),
	Available bit,
);

--•	Employees (Id, FirstName, LastName, Title, Notes)
create table Employees
(
	Id int identity primary key,
	FirstName nvarchar(30),
	LastName nvarchar(30),
	Title nvarchar(50),
	Notes nvarchar(100),
);

--•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
create table Customers
(
	Id int identity primary key,
	DriverLicenceNumber int not null,
	FullName nvarchar(60) not null,
	[Address] nvarchar(60) not null,
	City nvarchar(60) not null,
	ZIPCode varchar(1000) not null,
	Notes nvarchar(100)
);

--•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
create table RentalOrders
(
	Id int identity primary key,
	EmployeeId int foreign key references Employees(Id),
	CustomerId int foreign key references Customers(Id),
	CarId int foreign key references Cars(Id),
	TankLevel int not null,
	KilometrageStart int default 0,
	KilometrageEnd int not null,
	TotalKilometrage int not null,
	StartDate datetime not null,
	EndDate datetime not null,
	TotalDays int not null,
	RateApplied bit default 1,
	TaxRate bit default 1,
	OrderStatus bit default 1,
	Notes nvarchar(100) default null
);



insert into Categories
values
	('SEDAN',4,70,16),
	('COUPE',6,80,18),
	('HATCHBACK',14,143,45);

insert into Cars
values
	(2151, 'Opel', 'Astra', 1998, 1, 'manual', 'dfggfhgh345456dfgf23456754fgh', null, 1),
	(5271, 'Mercedes', 'Benz', 2018, 2, 'manual', 'dfggfhgh345456dfgf23456754fgh', null, 1),
	(9578, 'Renault', 'Clio', 2017, 3, 'manual', 'dfggfhgh345456dfgf23456754fgh', null, 1);

insert into Employees
values 
	('Mincho', 'Minchev', 'cardealer', null),
	('Kuncho', 'Kurtev', null, null),
	('Veselin', 'Dzhambazov', 'dzambaz', null);

insert into Customers
values
	(105050,'asadasd','fgghgfhh','sth', 'sdfg23456t',null),
	(405015,'dfhgfg','dfgdf','hgfjgh', 'adsvfdf32454tgdf',null),
	(435657,'jhgkhgj','fgghgfhh','fdgjh', 'dfsgfd3454gdf',null);

insert into RentalOrders
values
	(1, 1, 1, 50, 4, 14, 5545, '2021-01-01', GETDATE(), ABS(DAY('2021-01-01') - DAY(GETDATE())),1,1,1,null ),
	(2, 2, 2, 50, 4, 14, 5545, '2021-01-01', GETDATE(), ABS(DAY('2021-01-01') - DAY(GETDATE())),1,1,1,null ),
	(3, 3, 3, 50, 4, 14, 5545, '2021-01-01', GETDATE(), ABS(DAY('2021-01-01') - DAY(GETDATE())),1,1,1,null );