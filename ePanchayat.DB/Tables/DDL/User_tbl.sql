USE [ePanchayat]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('dbo.User_tbl') IS NOT NULL
BEGIN
	DROP TABLE dbo.User_tbl
END

CREATE TABLE dbo.User_tbl
(
	UserId INT IDENTITY(1,1) NOT NULL,
	UserLogin VARCHAR(50) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MobileNo VARCHAR(15) NOT NULL,
	Email VARCHAR(50) NULL,
	ProfilePhoto VARBINARY(MAX),
	Address VARCHAR(500) NULL,
	LastModifiedOn DATETIME NOT NULL,
	LastModifiedBy INT NOT NULL,
	IsActive BIT NOT NULL
)
GO

ALTER TABLE dbo.User_tbl
ADD CONSTRAINT PK_User_UserId PRIMARY KEY (UserId)
GO

ALTER TABLE dbo.User_tbl
ADD CONSTRAINT UK_User_UserLogin UNIQUE (UserLogin)
GO

ALTER TABLE dbo.User_tbl
ADD CONSTRAINT UK_User_MobileNo UNIQUE (MobileNo)
GO

ALTER TABLE dbo.User_tbl
ADD CONSTRAINT UK_User_Email UNIQUE (Email)
GO

ALTER TABLE dbo.User_tbl
ADD CONSTRAINT DF_User_Date DEFAULT GETDATE() FOR LastModifiedOn
GO

ALTER TABLE dbo.User_tbl
ADD CONSTRAINT DF_User_IsActive DEFAULT 1 FOR IsActive
GO