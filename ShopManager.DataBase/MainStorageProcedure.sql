use ShopManagerDB
go

--GetAll
CREATE PROCEDURE spGetAllProduct
AS
BEGIN
	SELECT 
		[Id],
		[Name],
		[Code],
		[ActualPrice],
		[Quantity],
		[CategoryId],
		[SubCategoryId]
	FROM [dbo].[Product]
END
GO

CREATE PROCEDURE spGetAllEmployee
AS
BEGIN
	SELECT  
		[Id]
      ,[FirstName]
      ,[LastName]
      ,[MiddleName]
      ,[Position]
	  ,[Salary]
      ,[Phone]
      ,[Address]
      ,[Mail]
      ,[Login]
      ,[Password]
      ,[Priority]
	FROM [dbo].[Employee] as emp
	WHERE emp.IsActive =1
END
GO

CREATE PROCEDURE spGetAllCategory
AS
BEGIN
	SELECT [Id]
			,[Name]
	FROM [dbo].[Category]
END
GO

CREATE PROCEDURE spGetAllSubCategory
AS
BEGIN
	SELECT [Id]
			,[Name]
			,[CategoryId]
	FROM [dbo].[SubCategory]
END
GO

CREATE PROCEDURE spGetAllSubCategory
AS
BEGIN
	SELECT [Id]
			,[Name]
			,[CategoryId]
	FROM [dbo].[SubCategory]
END
GO

CREATE PROCEDURE spGetAllSupplier
AS
BEGIN
	SELECT [Id]
			,[Name]
			,[Phone]
			,[Mail]
			,[Address]
	FROM [dbo].[Supplier]
END
GO

CREATE PROCEDURE spGetAllSupply
AS
BEGIN
	SELECT [Id]
			,[Date]
			,[ProductId]
			,[Quantity]
			,[Price]
			,[SupplierId]
	FROM [dbo].[Supply]
END
Go

CREATE PROCEDURE spGetAllRealization
AS
BEGIN
	SELECT [Id]
			,[Date]
			,[ProductId]
			,[Quantity]
			,[Income]
			,[EmployeeId]
	FROM [dbo].[Realization]
END
GO

CREATE PROCEDURE spGetAllReturningProduct
AS
BEGIN
	SELECT [Id]
			,[ProductId]
			,[RealizationId]
			,[ReturningDate]
			,[IsDefect]
			,[EmployeeId]
	FROM [dbo].[ReturningProduct]
END
GO

CREATE PROCEDURE spGetAllDefectedProduct
AS
BEGIN
	SELECT [Id]
			,[ProductId]
			,[RealizationId]
			,[Quantity]
	FROM [dbo].[DefectedProduct]
END
GO

---GetById
CREATE PROCEDURE spGetRealizationById
(
	@Id UNIQUEIDENTIFIER
)
AS
BEGIN
	SELECT [Id],[Date],[ProductId],[Quantity],[Income],[EmployeeId]
	FROM [dbo].[Realization]
	WHERE @Id=Id
END
GO

CREATE PROCEDURE spGetProductById
(
	@Id UNIQUEIDENTIFIER
)
AS
BEGIN
	SELECT [Id],[Name],[Code],[ActualPrice],[Quantity],[CategoryId],[SubCategoryId]
	FROM [dbo].[Product]
	WHERE @Id=Id
END
GO

CREATE PROCEDURE spGetEmployeeById
(
	@Id UNIQUEIDENTIFIER 
)
AS
BEGIN
	SELECT [Id],[FirstName],[LastName],[MiddleName],[Position],[Salary],[Phone],[Address],[Mail],[Login],[Password],[Priority]
	FROM [dbo].[Employee]
	WHERE @Id=Id AND IsActive=1
END
GO

CREATE PROCEDURE spGetSubCategoriesByCategoryId
(
	@CategoryId UNIQUEIDENTIFIER
)
AS
BEGIN
SELECT	[Id]
		,[CategoryId]
		,[Name]
  FROM [dbo].[SubCategory]
  WHERE [CategoryId]=@CategoryId;
END
GO

CREATE PROCEDURE spGetCategoryById
(
	@Id UNIQUEIDENTIFIER 
)
AS
BEGIN
	SELECT [Id],[Name]
	FROM [dbo].[Category]
	WHERE @Id=Id;
END
GO

CREATE PROCEDURE spGetCategoryByName
(
	@Name NVARCHAR(50)
)
AS
BEGIN
	SELECT [Id],[Name]
	FROM [dbo].[Category]
	WHERE @Name=Name;
END
GO

CREATE PROCEDURE spGetSupplierByName
(
	@Name NVARCHAR(50)
)
AS
BEGIN
	SELECT [Id],[Name],[Phone],[Mail],[Address]
	FROM [dbo].[Supplier]
	WHERE @Name=Name;
END
GO

CREATE PROCEDURE spGetSubCategoryById
(
	@Id UNIQUEIDENTIFIER 
)
AS
BEGIN
	SELECT [Id],[CategoryId],[Name]
	FROM [dbo].[SubCategory]
	WHERE @Id=Id;
END
GO



--GetOneColumn
CREATE PROCEDURE spGetAllCategoryName
AS
Begin
	SELECT [Name]
	FROM [dbo].[Category]
End
Go

CREATE PROCEDURE spGetAllSubCategoryName
(
	@CategoryName nvarchar(50)
)
AS
SET NOCOUNT ON
	DECLARE 
		@CategoryId UNIQUEIDENTIFIER
	SELECT @CategoryId = cat.Id
			FROM [dbo].[Category] as cat
			WHERE @CategoryName = cat.Name
		IF @@ERROR<>0 RETURN -100

		IF @CategoryId IS NULL 
		BEGIN
			RAISERROR ('Product Category: ''%s'' not found', 15,1,@CategoryName)
			RETURN -100
		END
Begin
	SELECT [Name]
		FROM [dbo].[SubCategory] as subcat
		WHERE subcat.CategoryId=@CategoryId
End
Go

CREATE PROCEDURE spGetAllProductsCode
AS
BEGIN
	SELECT 
		[Code]
	FROM [dbo].[Product]
END
GO

CREATE PROCEDURE spGetAllSupplierName
AS
BEGIN
	SELECT 
		[Name]
	FROM [dbo].[Supplier]
END
GO


---

CREATE PROCEDURE spGetProductByCode
(
	@Code NVARCHAR(15)
)
AS
BEGIN
	SELECT 
		[Id],
		[Name],
		[Code],
		[ActualPrice],
		[Quantity],
		[CategoryId],
		[SubCategoryId]
	FROM [dbo].[Product] as prod
	WHERE prod.Code = @Code
END
GO

CREATE PROCEDURE spGetProductByCategory
(
	@CategoryName NVARCHAR(50)
)
AS
	DECLARE @CategoryId UNIQUEIDENTIFIER
	SELECT @CategoryId=cat.Id
		FROM [dbo].[Category] as cat
		WHERE @CategoryName=cat.Name
BEGIN
	SELECT 
		[Id],
		[Name],
		[Code],
		[ActualPrice],
		[Quantity],
		[CategoryId],
		[SubCategoryId]
	FROM [dbo].[Product] as prod
	WHERE prod.CategoryId = @CategoryId
END
GO

CREATE PROCEDURE spGetProductBySubCategory
(
	@SubCategoryName NVARCHAR(50)
)
AS
	DECLARE @SubCategoryId UNIQUEIDENTIFIER
	SELECT @SubCategoryId=scat.Id
		FROM [dbo].[SubCategory] as scat
		WHERE @SubCategoryName=scat.Name
BEGIN
	SELECT 
		[Id],
		[Name],
		[Code],
		[ActualPrice],
		[Quantity],
		[CategoryId],
		[SubCategoryId]
	FROM [dbo].[Product] as prod
	WHERE prod.SubCategoryId = @SubCategoryId
END
GO

CREATE PROCEDURE spGetUserByLogin
(
	@Login varchar(30),
	@Password varchar(30)
)
AS
BEGIN
	SELECT 
		[Id],
		[Salary],
		[Position],
		[FirstName],
		[LastName],
		[MiddleName],
		[Phone],
		[Address],
		[Mail],
		[Login],
		[Password],
		[Priority]
	FROM [dbo].[Employee] as emp
	WHERE emp.Login = @Login AND emp.Password = @Password;
END
Go

CREATE PROCEDURE spGetCategoryByCode
(
	@Code NVARCHAR(15)
)
AS
BEGIN
	SELECT 
		[Id],
		[Name],
		[Code],
		[ActualPrice],
		[Quantity],
		[CategoryId],
		[SubCategoryId]
	FROM [dbo].[Product] as prod
	WHERE prod.Code = @Code
END
GO
----
CREATE PROCEDURE spGetSubCategoryName
(
	@CategoryName nvarchar(50)
)
AS
SET NOCOUNT ON
	DECLARE 
		@CategoryId UNIQUEIDENTIFIER
	SELECT @CategoryId = cat.Id
			FROM [dbo].[Category] as cat
			WHERE @CategoryName = cat.Name
		IF @@ERROR<>0 RETURN -100

		IF @CategoryId IS NULL 
		BEGIN
			RAISERROR ('Product Category: ''%s'' not found', 15,1,@CategoryName)
			RETURN -100
		END
Begin
	SELECT [Name]
		FROM [dbo].[SubCategory] as subcat
		WHERE subcat.CategoryId=@CategoryId;
End
Go

CREATE PROCEDURE spGetSales
(
	@SalesDate DATE = null ,
	@ProductCode nvarchar(15) =null
)
AS
BEGIN
	IF (@SalesDate IS NULL) AND (@ProductCode IS NULL)
	BEGIN
		SELECT	reliz.Id as RealizationId,
				prod.Code as ProductCode,
				prod.Name as ProductName,
				reliz.Quantity as Quontity,
				reliz.Income as Income,
				reliz.Date as Date,
				emp.LastName+' '+emp.FirstName as Seller
		FROM [dbo].[Realization] as reliz
			INNER JOIN [dbo].[Product] as prod
				ON reliz.ProductId=prod.Id
			INNER JOIN [dbo].[Employee] as emp
				ON reliz.EmployeeId = emp.Id;
	END

	ELSE IF @ProductCode IS NULL
	BEGIN
		SELECT	reliz.Id as RealizationId,
				prod.Code as ProductCode,
				prod.Name as ProductName,
				reliz.Quantity as Quontity,
				reliz.Income as Income,
				reliz.Date as Date,
				emp.LastName+' '+emp.FirstName as Seller
		FROM [dbo].[Realization] as reliz
			INNER JOIN [dbo].[Product] as prod
				ON reliz.ProductId=prod.Id
			INNER JOIN [dbo].[Employee] as emp
				ON reliz.EmployeeId = emp.Id
		WHERE CAST( reliz.Date as DATE)=@SalesDate;
	END

	ELSE IF @SalesDate IS NULL
	BEGIN
		SELECT	reliz.Id as RealizationId,
				prod.Code as ProductCode,
				prod.Name as ProductName,
				reliz.Quantity as Quontity,
				reliz.Income as Income,
				reliz.Date as Date,
				emp.LastName+' '+emp.FirstName as Seller
		FROM [dbo].[Realization] as reliz
			INNER JOIN [dbo].[Product] as prod
				ON reliz.ProductId=prod.Id
			INNER JOIN [dbo].[Employee] as emp
				ON reliz.EmployeeId = emp.Id
		WHERE prod.Code=@ProductCode;
	END

	ELSE
	BEGIN
		SELECT	reliz.Id as RealizationId,
				prod.Code as ProductCode,
				prod.Name as ProductName,
				reliz.Quantity as Quontity,
				reliz.Income as Income,
				reliz.Date as Date,
				emp.LastName+' '+emp.FirstName as Seller
		FROM [dbo].[Realization] as reliz
			INNER JOIN [dbo].[Product] as prod
				ON reliz.ProductId=prod.Id
			INNER JOIN [dbo].[Employee] as emp
				ON reliz.EmployeeId = emp.Id
		WHERE CAST( reliz.Date as DATE)=@SalesDate AND prod.Code=@ProductCode
	END
END
GO

CREATE PROCEDURE spDeleteEmployee
(
	@EmployeeId UNIQUEIDENTIFIER
)
AS
BEGIN
	UPDATE [dbo].[Employee]
	SET [IsActive] = 0
	WHERE [Id]=@EmployeeId
END
GO


CREATE PROCEDURE spChangeProductCNP
(
	@ProductId UNIQUEIDENTIFIER,
	@Code nvarchar(15),
	@Name nvarchar(50),
	@ActualPrice money
)
AS
BEGIN
	UPDATE [dbo].[Product]
	SET [Name]=@Name,[Code]=@Code,[ActualPrice]=@ActualPrice
	WHERE @ProductId=[Id]
END
go

CREATE PROCEDURE spChangeProductComplete
(
	@ProductId UNIQUEIDENTIFIER,
	@Code nvarchar(15),
	@Name nvarchar(50),
	@ActualPrice money,
	@CategoryId UNIQUEIDENTIFIER,
	@SubCategoryId UNIQUEIDENTIFIER
)
AS
BEGIN
	UPDATE [dbo].[Product]
	SET [Name]=@Name,[Code]=@Code,[ActualPrice]=@ActualPrice,[CategoryId]=@CategoryId,[SubCategoryId]=@SubCategoryId
	WHERE @ProductId=[Id]
END
go

CREATE PROCEDURE spGetSupplierById
(
	@SupplierId UNIQUEIDENTIFIER
)
AS
BEGIN
	Select*
	from [dbo].[Supplier]
	WHERE @SupplierId=[Id]
END
go

CREATE PROCEDURE spUpdateEmployee
(
	@Id UNIQUEIDENTIFIER,
	@NewPassword nvarchar(50),
	@NewLogin nvarchar(50)
)
AS
BEGIN
	UPDATE [dbo].[Employee]
	SET [Login]=@NewLogin,[Password]=@NewPassword
	WHERE [Id] = @Id
END
go