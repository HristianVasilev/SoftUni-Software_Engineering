create database Hotel;
go
use Hotel;
go

--•	Employees (Id, FirstName, LastName, Title, Notes)
create table Employees
(
	Id int identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Title nvarchar(50) not null,
	Notes nvarchar(500)
);

--•	Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
create table Customers
(
	AccountNumber int identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	PhoneNumber char(10) not null, 
	EmergencyName nvarchar(50),
	EmergencyNumber char(10) , 
	Notes nvarchar(500),

	check (SUBSTRING(PhoneNumber,1,3) in ('088', '087', '089'))
);

--•	RoomStatus (RoomStatus, Notes)
create table RoomStatus
(
	RoomStatus nvarchar(50) primary key,
	Notes nvarchar(500)
);

--•	RoomTypes (RoomType, Notes)
create table RoomTypes
(
	RoomType nvarchar(50) primary key,
	Notes nvarchar(500)
);

--•	BedTypes (BedTypes, Notes)
create table BedTypes
(
	BedType nvarchar(50) primary key,
	Notes nvarchar(500)
);

--•	Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
create table Rooms
(
	RoomNumber int identity primary key,
	RoomType nvarchar(50) foreign key references RoomTypes(RoomType),
	BedType nvarchar(50) foreign key references BedTypes(BedType),
	Rate int,
	RoomStatus nvarchar(50) foreign key references RoomStatus(RoomStatus),
	Notes nvarchar(500)
);

--•	Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
create table Payments
(
	Id int identity primary key,
	EmployeeId int foreign key references Employees(Id),
	PaymentDate datetime not null,
	AccountNumber int foreign key references Customers(AccountNumber),
	FirstDateOccupied datetime not null,
	LastDateOccupied datetime not null,
	TotalDays int,
	AmountCharged money not null,
	TaxRate int,
	TaxAmount money not null,
	PaymentTotal money not null,
	Notes nvarchar(500)
);

--•	Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
create table Occupancies
(
	Id int identity primary key,
	EmployeeId int foreign key references Employees(Id),
	DateOccupied datetime,
	AccountNumber int foreign key references Customers(AccountNumber),
	RoomNumber int foreign key references Rooms(RoomNumber),
	RateApplied int,
	PhoneCharge int,
	Notes nvarchar(500)
);


INSERT INTO Employees
	    (FirstName, LastName, Title, Notes)
VALUES	    
	    ('Kiro', 'Kirov', 'employee1', NULL),
	    ('Ivan', 'Ivanov', 'employee2', NULL),
	    ('Pesho', 'Peshev', 'employee3', NULL);


INSERT INTO Customers
	    (FirstName, LastName, PhoneNumber,
	    EmergencyName, EmergencyNumber, Notes)
VALUES	    
	    ('Toshko', 'Toshkov', '0886808070', NULL, NULL, NULL),
	    ('Stamat', 'Stamatov', '0896808110', NULL, NULL, NULL),
	    ('Gosho', 'Goshov', '0876819070', NULL, NULL, NULL);

INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES	    ('Status1', NULL),
	    ('Status2', NULL),
	    ('Status3', NULL);

INSERT INTO RoomTypes(RoomType, Notes)
VALUES	    ('Type1', NULL),
	    ('Type2', NULL),
	    ('Type3', NULL);

INSERT INTO BedTypes(BedType, Notes)
VALUES	    ('Bed1', NULL),
	    ('Bed2', NULL),
	    ('Bed3', NULL);

INSERT INTO Rooms
	    (RoomType, BedType, Rate, RoomStatus, Notes)
VALUES     
	    ('Type1', 'Bed1', 7.25, 'Status1', NULL),
	    ('Type2', 'Bed2', 8.30, 'Status2', NULL),
	    ('Type3', 'Bed3', 9.20, 'Status3', NULL);

INSERT INTO Payments
            (EmployeeId, PaymentDate, AccountNumber, 
            FirstDateOccupied, LastDateOccupied, 
            TotalDays, AmountCharged, TaxRate, 
            TaxAmount, PaymentTotal, Notes)
VALUES            
            (1, '2005-05-10', 1, '2005-05-05', '2005-05-10', 5, 305.50, 5.5, 35.72, 341.22, NULL),
            (2, '2007-07-15', 2, '2007-07-21', '2007-07-15', 6, 301.00, 6.5, 15.20, 316.20, NULL),
            (3, '2012-02-09', 3, '2012-02-16', '2012-02-09', 7, 450.25, 8.3, 25.20, 475.45, NULL)

INSERT INTO Occupancies
	    (EmployeeId, DateOccupied, AccountNumber,
	     RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES    
	    (1, '2019-09-15', 1, 1, NULL, 15.90, NULL),
	    (3, '2015-07-16', 3, 3, 7.50, 16.20, NULL),
	    (2, '1999-05-16', 2, 2, 8.32, 12.35, NULL)
