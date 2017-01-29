DROP DATABASE MeasurementDatabase;

USE master;

GO

CREATE DATABASE MeasurementsDatabase
ON
(
	NAME = MeasurementsDatabase,
	FILENAME = 'C:\Users\Karamela\Documents\SQL Server Management Studio',
	SIZE = 10MB,
	MAXSIZE = 50MB,
	FILEGROWTH = 5MB
);

CREATE TABLE Locations
(
	Id INT PRIMARY KEY,
	LocationName NVARCHAR(20)
)

CREATE TABLE RTUs
(
	Id INT PRIMARY KEY,
	RTUId NVARCHAR(20) UNIQUE,
	LocationId INT, 
	Foreign Key (LocationId) REFERENCES RTUs(Id)
)

CREATE TABLE Measurements
(
	Id INT PRIMARY KEY,
	RTUId INT,
	Value INT,
	Type NVARCHAR(10),
	Time DATETIME,
	Foreign Key (RTUId) REFERENCES RTUs(Id)
)

INSERT INTO Locations(LocationName) VALUES
('Liman'),
('Centar'),
('Adice');

INSERT INTO RTUs(RTUId, LocationId) VALUES
('Liman01', 1),
('Adice01', 3),
('Centar01', 2);