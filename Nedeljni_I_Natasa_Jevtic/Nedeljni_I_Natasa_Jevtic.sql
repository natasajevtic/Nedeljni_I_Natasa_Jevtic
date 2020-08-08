IF DB_ID('EmployeeManagement') IS NULL
    create database EmployeeManagement;
GO	
use EmployeeManagement
--Deleting tables and views, if they exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblProject')
	drop table tblProject;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblEmployee')
	drop table tblEmployee;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblManager')
	drop table tblManager;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblAdministrator')
	drop table tblAdministrator;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblUser')
	drop table tblUser;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblPosition')
	drop table tblPosition;
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblSector')
	drop table tblSector;
IF EXISTS(select * FROM sys.views where name = 'vwProject')
	drop view vwProject;
IF EXISTS(select * FROM sys.views where name = 'vwEmployee')
	drop view vwEmployee;
IF EXISTS(select * FROM sys.views where name = 'vwManager')
	drop view vwManager;
IF EXISTS(select * FROM sys.views where name = 'vwAdministrator')
	drop view vwAdministrator;
IF EXISTS(select * FROM sys.views where name = 'vwUser')
	drop view vwUser;
IF EXISTS(select * FROM sys.views where name = 'vwPosition')
	drop view vwPosition;
IF EXISTS(select * FROM sys.views where name = 'vwSector')
	drop view vwSector;
GO
--Creating tables
create table tblSector(
SectorId int identity(1,1) PRIMARY KEY,
SectorName varchar(100) UNIQUE NOT NULL,
SectorDescription varchar(255)
);
create table tblPosition(
PositionId int identity(1,1) PRIMARY KEY,
PositionName varchar(100) UNIQUE NOT NULL,
PositionDescription varchar(255) NOT NULL
);
create table tblUser(
UserId int identity(1,1) PRIMARY KEY,
Name varchar(50) NOT NULL,
Surname varchar(50) NOT NULL,
JMBG varchar(13) NOT NULL,
Gender char NOT NULL,
Residence varchar(100) NOT NULL,
MarriageStatus varchar(20) NOT NULL,
Username varchar(40) UNIQUE NOT NULL,
Password varchar(40) NOT NULL
);
create table tblAdministrator(
AdministratorId int identity(1,1) PRIMARY KEY,
UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL,
AccountExpirationDate date NOT NULL,
TypeOfAdministrator varchar(20) NOT NULL
);
create table tblManager(
ManagerId int identity(1,1) PRIMARY KEY,
UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL,
Email varchar(40) UNIQUE NOT NULL,
BackupPassword varchar(40) NOT NULL,
LevelOfResponsibility char,
NumberOfSuccessfulProjects int DEFAULT 0,
Salary numeric(8,2),
OfficeNumber int NOT NULL
);
create table tblEmployee(
EmployeeId int identity(1,1) PRIMARY KEY,
UserId int FOREIGN KEY REFERENCES tblUser(UserId) NOT NULL,
SectorID int FOREIGN KEY REFERENCES tblSector(SectorId),
PositionId int FOREIGN KEY REFERENCES tblPosition(PositionId),
WorkExperience int DEFAULT 0,
Salary numeric(8,2),
EducationDegree varchar(3) NOT NULL,
SuperiorManagerId int FOREIGN KEY REFERENCES tblManager(ManagerId)
);
create table tblProject(
ProjectId int identity(1,1) PRIMARY KEY,
ProjectName varchar(50) NOT NULL,
ProjectDescription varchar (255),
ClientName varchar(50) NOT NULL,
ContractDate date NOT NULL,
ContractManager int FOREIGN KEY REFERENCES tblManager(ManagerId) NOT NULL,
ProjectStartDate date NOT NULL,
ProjectDeadline date NOT NULL,
HourlyRate numeric(8,2) NOT NULL,
Realization char NOT NULL,
LeaderId int FOREIGN KEY REFERENCES tblManager(ManagerId) NOT NULL
);
--Inserting default sector
insert into tblSector(SectorName) values('Default');
--Creating views
GO
create view vwSector as
select *
from tblSector;
GO
create view vwPosition as
select *
from tblPosition;
GO
create view vwEmployee as
select u.* , e.EmployeeId , e.PositionId, e.EducationDegree, e.Salary, e.WorkExperience , p.PositionName, 
p.PositionDescription, s.SectorName , s.SectorDescription, s.SectorId, e.SuperiorManagerId
from tblUser u
INNER JOIN tblEmployee e
ON u.UserId = e.UserId
INNER JOIN tblSector s
ON e.SectorID = s.SectorId
INNER JOIN tblPosition p
ON p.PositionId = p.PositionId
GO
create view vwManager as
select u.* , m.ManagerId, m.Email, m.BackupPassword, m.LevelOfResponsibility, m.NumberOfSuccessfulProjects,
m.OfficeNumber, m.Salary
from tblUser u
INNER JOIN tblManager m
ON u.UserId = m.UserId;
GO
create view vwAdministrator as
select u.* , a.AdministratorId, a.AccountExpirationDate, a.TypeOfAdministrator
from tblUser u
INNER JOIN tblAdministrator a
ON u.UserId = a.UserId;
GO
create view vwProject as
select *
from tblProject;



