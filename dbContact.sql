use master

--DROP DATABASE IF EXiSTS dbContact
--CREATE DATABASE dbContact
--GO
USE dbContact

DROP TABLE IF EXiSTS Contact
DROP TABLE IF EXiSTS Log_In

CREATE TABLE Log_In
(
	ID  varchar(15) PRIMARY KEY CLUSTERED,
	MDP varchar(15) UNIQUE

)

CREATE TABLE Contact
(
	Nom varchar(25) NOT NULL,
	Prenom varchar(25) NOT NULL,
	Adresse varchar(30),
	Tel1 varchar(13) NOT NULL,
	Tel2 varchar(13),
	Note varchar(50),
	CHECK (Tel1 LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
	Code_Id varchar(15) NOT NULL FOREIGN KEY REFERENCES Log_In (ID),
	ID_Contact int IDENTITY(1,1) PRIMARY KEY CLUSTERED NOT NULL

)
go
INSERT Log_In VALUES('louis','456')
INSERT Log_In VALUES('sarvenaz','123')

INSERT Contact(Nom,Prenom,Tel1,Code_Id) VALUES('sarvenaz','souri','(514)123-4567','sarvenaz')
INSERT Contact(Nom,Prenom,Tel1,Code_Id) VALUES('louis','richard','(514)123-7896','louis')
INSERT Contact(Nom,Prenom,Tel1,Code_Id) VALUES('idy','sadr','(514)254-5874','louis')
INSERT Contact VALUES('fgp','djfs','','(514)254-5454','','','louis')
go


