CREATE DATABASE ShopManagerDB;

USE ShopManagerDB
go



----------------------------------------------Create Tables------------------------------------------------------------
CREATE TABLE [dbo].[Product]
(
	[Id]  uniqueidentifier  ROWGUIDCOL  NOT NULL DEFAULT (newid()),
	[Name] NVARCHAR(50) not null,
	[Code] NVARCHAR(15) not null,
	[ActualPrice] MONEY NOT NULL,
	[Quantity] INT NOT NULL,
	[CategoryId] UNIQUEIDENTIFIER NOT NULL,
	[SubCategoryId] UNIQUEIDENTIFIER,
	CONSTRAINT PK_tblProduct_Id PRIMARY KEY(Id),
	CONSTRAINT UQ_tblProduct_Name UNIQUE([Name]),
	CONSTRAINT UQ_tblProduct_Code UNIQUE([Code]),
	CONSTRAINT Check_tblProduct_Quontity Check([Quantity]>=0)
)
GO

CREATE TABLE [dbo].[Category]
(
	[Id]   UNIQUEIDENTIFIER   ROWGUIDCOL  NOT NULL DEFAULT (newid()),
	[Name] NVARCHAR (50) NOT NULL,
	CONSTRAINT PK_tblCategory_Id PRIMARY KEY([Id]),
	CONSTRAINT UQ_tblCategory_Name UNIQUE([Name])
)
GO

CREATE TABLE [dbo].[SubCategory]
(
	[Id]  UNIQUEIDENTIFIER  ROWGUIDCOL  NOT NULL DEFAULT (newid()),
	[Name] NVARCHAR(50) NOT NULL,
	[CategoryId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_tblSubCategory_Id PRIMARY KEY([Id]),
	CONSTRAINT UQ_tblSubCategory_Name UNIQUE([Name])
)
GO

CREATE TABLE [dbo].[PriceHistory]
(
	[Id]  UNIQUEIDENTIFIER  ROWGUIDCOL  NOT NULL DEFAULT (newid()),
	[ChangeDate] DATETIME NOT NULL,
	[PriceValue] MONEY Not NULL,
	[ProductId]  UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT  PK_tblPriceHistory_Id PRIMARY KEY([Id]),
)
GO

CREATE TABLE [dbo].[Supplier]
(
	[Id] UNIQUEIDENTIFIER  ROWGUIDCOL  NOT NULL DEFAULT (newid()),
	[Name] NVARCHAR(50) NOT NULL UNIQUE,
	[Phone] NVARCHAR(14) NOT NULL,
	[Mail] NVARCHAR(30) NOT NULL,
	[Address] NVARCHAR(50),
	CONSTRAINT PK_tblSupplier_Id PRIMARY KEY ([Id]),
	CONSTRAINT Chek_tblSupplier_Phone CHECK([Phone] LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]')
)
GO

CREATE TABLE [dbo].[Supply]
(
	[Id] UNIQUEIDENTIFIER   ROWGUIDCOL  NOT NULL DEFAULT (newid()),
	[Date] DATETIME NOT NULL ,
	[ProductId] UNIQUEIDENTIFIER  NOT NULL,
	[Quantity] INT NOT NULL,
	[Price] MONEY NOT NULL,
	[SupplierId] UNIQUEIDENTIFIER NOT NULL ,
	CONSTRAINT PK_tblSupply_Id PRIMARY KEY([Id]),
)
GO

CREATE TABLE [dbo].[Realization]
(
	[Id] UNIQUEIDENTIFIER  ROWGUIDCOL  NOT NULL DEFAULT (newid()),
	[Date] DATETIME NOT NULL,
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[Quantity] INT NOT NULL,
	[Income]  MONEY NOT NULL,
	[EmployeeId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_tblRealization_Id PRIMARY KEY ([Id])
)
GO

CREATE TABLE [dbo].[Employee]
(
	[Id] UNIQUEIDENTIFIER  ROWGUIDCOL  NOT NULL DEFAULT (newid()),
	[FirstName] NVARCHAR(30)  NOT NULL,
	[LastName] NVARCHAR(30)  NOT NULL,
	[MiddleName] NVARCHAR(30)  NOT NULL,
	[Position] NVARCHAR(50) NOT NULL,
	[Salary]	MONEY  NOT NULL,
	[Phone] NVARCHAR(14) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	[Mail] NVARCHAR(30) NOT NULL,
	[Login] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[IsActive] BIT NOT NULL,
	[Priority] INT NOT NULL,
	CONSTRAINT PK_tblEmployee_Id PRIMARY KEY ([Id]),
	CONSTRAINT Chek_tblEmployee_Phone CHECK([Phone] LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]' ),
	CONSTRAINT Check_tblEmployee_Mail CHECK([Mail] LIKE '%@%.%'),
	CONSTRAINT Check_tblEmployee_Priority Check([Priority] = 1 OR [Priority] = 2 ),
	CONSTRAINT UQ_tblEmployee_Login UNIQUE ([Login])
)
GO
CREATE TABLE [dbo].[ReturningProduct]
(
	[Id] UNIQUEIDENTIFIER  ROWGUIDCOL  NOT NULL DEFAULT (newid()),
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[RealizationId] UNIQUEIDENTIFIER NOT NULL,
	[ReturningDate] DATETIME NOT NULL,
	[IsDefect] BIT NOT NULL, 
	[EmployeeId]  UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_tblReturningProduct_Id PRIMARY KEY ([Id]),
	CONSTRAINT UQ_tblReturningProduct_RealizationId UNIQUE ([RealizationId])
)
GO

CREATE TABLE [dbo].[DefectedProduct]
(
	[Id] UNIQUEIDENTIFIER  ROWGUIDCOL  NOT NULL DEFAULT (newid()),
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[RealizationId] UNIQUEIDENTIFIER NOT NULL,
	[Quantity]  INT NOT NULL,
	CONSTRAINT PK_tblDefectProduct_Id PRIMARY KEY ([Id]),
	CONSTRAINT  UQ_tblDefectedProduct_RealizationId UNIQUE([RealizationId])
)
GO
-------------------------------------------------------------------------------------------------------------------

----------------------------------------------Alter Tables(Add relationship)---------------------------------------
ALTER TABLE [dbo].[Product]
ADD 
	CONSTRAINT FK_tblProduct_CategoryId FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]),
	CONSTRAINT FK_tblProduct_SubCategoryId FOREIGN KEY ([SubCategoryId]) REFERENCES [SubCategory]([Id])
GO
ALTER TABLE [dbo].[SubCategory]
ADD 
	CONSTRAINT FK_tblSubCategory_CategoryId FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
GO
ALTER TABLE [dbo].[PriceHistory]
ADD 
	CONSTRAINT FK_tblPriceHistory_Product FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
GO
ALTER TABLE [dbo].[Supply]
ADD 
	CONSTRAINT FK_tblSupply_ProductId FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]),
	CONSTRAINT FK_tblSupply_SupplierId FOREIGN KEY ([SupplierId]) REFERENCES [Supplier]([Id])
GO
ALTER TABLE [dbo].[Realization]
ADD
	CONSTRAINT FK_tblRealization_ProductId FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]),
	CONSTRAINT FK_tblRealization_EmployeeId FOREIGN KEY ([EmployeeId]) REFERENCES [Employee]([Id])
GO
ALTER TABLE [dbo].[ReturningProduct]
ADD
	CONSTRAINT FK_tblReturningProduct_ProductId FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]),
	CONSTRAINT FK_tblReturning_RealizationId FOREIGN KEY ([RealizationId]) REFERENCES [Realization]([Id]),
	CONSTRAINT FK_tblReturning_EmployeeId FOREIGN KEY ([EmployeeId]) REFERENCES [Employee]([Id])
GO
ALTER TABLE [dbo].[DefectedProduct]
ADD
	CONSTRAINT FK_tblDefectedProduct_ProductId FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]),
	CONSTRAINT FK_tblDefectedProduct_RealizationId FOREIGN KEY ([RealizationId]) REFERENCES [Realization]([Id])
GO
-------------------------------------------------------------------------------------------------------------------

----------------------------------------------Create Trigers------------------------------------------------------------
CREATE TRIGGER trgProduct_Insert
	ON [dbo].[Product]
	FOR INSERT
AS
	SET NOCOUNT OFF
	DECLARE 
			@Price MONEY,
			@ProductId UNIQUEIDENTIFIER 
	SELECT @Price=ins.ActualPrice,@ProductId=Id
		FROM inserted as ins
BEGIN
	INSERT [dbo].[PriceHistory]([ChangeDate],[PriceValue],[ProductId])
	VALUES (SYSDATETIME(),@Price,@ProductId)
END
GO



CREATE TRIGGER trgSupply_Insert
	ON [dbo].[Supply]
	FOR INSERT
AS
	SET NOCOUNT OFF
	DECLARE @Quantity INT, 
			@ProductId UNIQUEIDENTIFIER
	SELECT @Quantity = ins.Quantity , @ProductId=ins.ProductId
	FROM inserted as ins 
BEGIN
	UPDATE [dbo].[Product] 
	SET [Quantity] = [Quantity]+ @Quantity
	WHERE  [Id] = @ProductId
END
GO

CREATE PROCEDURE spInsertDefectedProduct
(
	@ProductId UNIQUEIDENTIFIER,
	@RealizationId UNIQUEIDENTIFIER,
	@Quantity INT
)
AS
BEGIN
	INSERT [dbo].[DefectedProduct]([ProductId],[RealizationId],[Quantity])
		VALUES (@ProductId,@RealizationId,@Quantity)
END
GO

CREATE TRIGGER trgReturningProduct_Insert
	ON [dbo].[ReturningProduct]
	FOR INSERT
AS
	SET NOCOUNT OFF
	DECLARE @ProductId UNIQUEIDENTIFIER,
			@IsDefected bit,
			@RealizationId UNIQUEIDENTIFIER,
			@Quantity INT
	SELECT @ProductId = ins.ProductId,@IsDefected = ins.IsDefect,@RealizationId=ins.RealizationId
		FROM inserted as ins;
	SELECT @Quantity = reliz.Quantity
		FROM [dbo].[Realization] as reliz;
BEGIN
	IF(@IsDefected=1)
	BEGIN
		EXEC [dbo].[spInsertDefectedProduct] @ProductId,@RealizationId,@Quantity
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Product]
			SET [Quantity]=[Quantity]+@Quantity
			WHERE Id=@ProductId
	END
END
GO

CREATE TRIGGER trgProduct_Update
	ON [dbo].[Product]
	FOR Update
AS
	SET NOCOUNT OFF
	DECLARE 
			@Price MONEY,
			@ProductId UNIQUEIDENTIFIER 
	SELECT @Price=ins.ActualPrice,@ProductId=Id
		FROM inserted as ins
BEGIN
	INSERT [dbo].[PriceHistory]([ChangeDate],[PriceValue],[ProductId])
	VALUES (SYSDATETIME(),@Price,@ProductId)
END
GO

