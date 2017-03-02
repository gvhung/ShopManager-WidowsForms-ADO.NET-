use ShopManagerDB
go
--
CREATE PROCEDURE spInsertCategory
(
	@Name nvarchar(50)
)
AS
BEGIN TRY   
	INSERT [dbo].[Category]([Name])
		VALUES (@Name)
END TRY 
BEGIN CATCH
		RAISERROR ('Unable to insert new product', 15,1)
		RETURN -100
END CATCH
GO
--
CREATE PROCEDURE spInsertSubCategory
(	
	@CategoryName nvarchar(50),
	@Name nvarchar(50)
)
AS
	SET NOCOUNT ON
	DECLARE 
	@ProductCategoryId UNIQUEIDENTIFIER
		SELECT @ProductCategoryId = cat.Id
			FROM [dbo].[Category] as cat
				WHERE Name = @CategoryName
		IF @@ERROR<>0 RETURN -100

		IF @ProductCategoryId IS NULL
		BEGIN
			RAISERROR ('Product Category: ''%s'' not found', 15,1,@CategoryName)
			RETURN -100
		END
BEGIN TRY   
	INSERT [dbo].[SubCategory]([Name],[CategoryId])
		VALUES (@Name,@ProductCategoryId)
END TRY 
BEGIN CATCH
		RAISERROR ('Unable to insert new product', 15,1)
		RETURN -100
END CATCH
GO
--
CREATE PROCEDURE spInsertProduct
(
	@Name nvarchar(50),
	@Code char(15),
	@ActualPrice money,
	@CategoryName nvarchar(50),
	@SubCategoryName nvarchar(50) = NULL
)
AS
	SET NOCOUNT ON
	DECLARE 
    @CategoryId UNIQUEIDENTIFIER,
	@SubCategoryId UNIQUEIDENTIFIER

		SELECT @CategoryId = cat.Id, @SubCategoryId = subcat.Id
			FROM [dbo].[Category] as cat
				INNER JOIN [dbo].[SubCategory] as subcat
					ON cat.Id=subcat.CategoryId
				WHERE cat.Name = @CategoryName AND subcat.Name=@SubCategoryName
		IF @@ERROR<>0 RETURN -100

		IF @CategoryId IS NULL OR @SubCategoryId IS NULL
		BEGIN
			RAISERROR ('Product Category: ''%s'' not found', 15,1,@CategoryName)
			RETURN -100
		END

BEGIN TRY   
	INSERT dbo.Product ([Name],[Code],[ActualPrice],[Quantity],[CategoryId],[SubCategoryId])
		VALUES (@Name, @Code,@ActualPrice,0,@CategoryId,@SubCategoryId)
END TRY 
BEGIN CATCH
		RAISERROR ('Unable to insert new product', 15,1)
		RETURN -100
END CATCH
GO
--
CREATE PROCEDURE spInsertEmployee
(
		@FName NVARCHAR(25),
		@LName NVARCHAR(25),
		@MName NVARCHAR(25),
		@Position NVARCHAR(50),
        @Salary MONEY,
		@Phone NVARCHAR(14),
		@Address NVARCHAR(100),
		@Mail NVARCHAR(30),
		@Login NVARCHAR(50),
		@Password NVARCHAR(50),
		@IsActive BIT = 1,
		@Priority INT
)
AS
BEGIN
	INSERT [dbo].[Employee]([FirstName],[LastName],[MiddleName],[Position],[Salary],[Phone],[Address],[Mail],[Login],[Password],[IsActive],[Priority])
		VALUES (@FName,@LName,@MName,@Position,@Salary,@Phone,@Address,@Mail,@Login,@Password,@IsActive,@Priority)
END
GO
--
CREATE PROCEDURE sqInsertSupplier
(
	@Name NVARCHAR(50),
	@Phone NVARCHAR(14),
	@Mail NVARCHAR(30),
	@Address NVARCHAR(50) = NULL
)
AS
BEGIN   
	INSERT [dbo].[Supplier]([Name],[Phone],[Mail],[Address])
		VALUES (@Name,@Phone,@Mail,@Address)
END
GO
--
CREATE PROCEDURE spInsertSupply
(
	@ProductId UNIQUEIDENTIFIER,
	@Quantity INT,
	@Price MONEY,
	@SupplierId UNIQUEIDENTIFIER
)
AS
SET NOCOUNT ON
	
BEGIN TRY   
	INSERT [dbo].[Supply]([Date],[ProductId],[Quantity],[Price],[SupplierId])
		VALUES (SYSDATETIME(),@ProductId,@Quantity,@Price,@SupplierId)
END TRY 
BEGIN CATCH
		RAISERROR ('Unable to insert new realization', 15,1)
		RETURN -100
END CATCH
GO

CREATE PROCEDURE spInsertRealization
(
	@EmployeeId UNIQUEIDENTIFIER,
	@ProductId UNIQUEIDENTIFIER,
	@Quantity INT,
	@Income MONEY
)
AS
BEGIN
	UPDATE [dbo].[Product]
	SET [Quantity] = [Quantity] - @Quantity
	WHERE  [Id] = @ProductId;  
	INSERT [dbo].[Realization]([Date],[ProductId],[Quantity],[Income],[EmployeeId])
		VALUES (SYSDATETIME(),@ProductId,@Quantity,@Income,@EmployeeId);
END 
GO

CREATE PROCEDURE spInsertReturning
(
	@ProductId UNIQUEIDENTIFIER,
	@RealizationId UNIQUEIDENTIFIER,
	@EmployeeId UNIQUEIDENTIFIER,
	@IsDefect BIT
)
AS
BEGIN
	INSERT [dbo].[ReturningProduct]([ProductId],[RealizationId],[ReturningDate],[IsDefect],[EmployeeId])
		VALUES (@ProductId,@RealizationId,SYSDATETIME(),@IsDefect,@EmployeeId)
END
GO