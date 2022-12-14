Build started...
Build succeeded.
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 6.0.10 initialized 'DBauthenticon' using provider 'Microsoft.EntityFrameworkCore.SqlServer:6.0.10' with options: None
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categories] (
    [CategoryID] int NOT NULL IDENTITY,
    [Name] nvarchar(40) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID])
);
GO

CREATE TABLE [Collections] (
    [CollectionID] int NOT NULL IDENTITY,
    [Name] nvarchar(40) NULL,
    CONSTRAINT [PK_Collections] PRIMARY KEY ([CollectionID])
);
GO

CREATE TABLE [People] (
    [UserID] int NOT NULL IDENTITY,
    [Name] nvarchar(60) NULL,
    [Email] nvarchar(100) NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_People] PRIMARY KEY ([UserID])
);
GO

CREATE TABLE [Administrators] (
    [UserID] int NOT NULL,
    [Password] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_Administrators] PRIMARY KEY ([UserID]),
    CONSTRAINT [FK_Administrators_People_UserID] FOREIGN KEY ([UserID]) REFERENCES [People] ([UserID])
);
GO

CREATE TABLE [Customers] (
    [UserID] int NOT NULL,
    [CPF] nvarchar(11) NULL,
    [Password] nvarchar(20) NOT NULL,
    [Gender] nvarchar(1) NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([UserID]),
    CONSTRAINT [FK_Customers_People_UserID] FOREIGN KEY ([UserID]) REFERENCES [People] ([UserID])
);
GO

CREATE TABLE [Phone] (
    [Number] nvarchar(15) NOT NULL,
    [PersonID] int NOT NULL,
    CONSTRAINT [PK_Phone] PRIMARY KEY ([PersonID], [Number]),
    CONSTRAINT [FK_Phone_People_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [People] ([UserID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Products] (
    [ProductID] int NOT NULL IDENTITY,
    [Name] nvarchar(60) NOT NULL,
    [Description] nvarchar(100) NOT NULL,
    [Color] nvarchar(20) NOT NULL,
    [Size] nvarchar(5) NOT NULL,
    [UnitPrice] decimal(9,2) NOT NULL,
    [StockQuantity] int NOT NULL,
    [Gender] nvarchar(1) NOT NULL,
    [Status] int NOT NULL,
    [ImageUrl] nvarchar(max) NULL,
    [AdministratorID] int NOT NULL,
    [CollectionID] int NOT NULL,
    [CategoryID] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductID]),
    CONSTRAINT [FK_Products_Administrators_AdministratorID] FOREIGN KEY ([AdministratorID]) REFERENCES [Administrators] ([UserID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Products_Categories_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [Categories] ([CategoryID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Products_Collections_CollectionID] FOREIGN KEY ([CollectionID]) REFERENCES [Collections] ([CollectionID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Addresses] (
    [AddressID] int NOT NULL IDENTITY,
    [AddressName] nvarchar(100) NOT NULL,
    [Number] nvarchar(6) NOT NULL,
    [ZipCode] nvarchar(8) NOT NULL,
    [AddressComplement] nvarchar(100) NOT NULL,
    [CustomerID] int NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY ([AddressID]),
    CONSTRAINT [FK_Addresses_Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customers] ([UserID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Orders] (
    [OrderID] int NOT NULL IDENTITY,
    [OrderDate] datetime2(3) NOT NULL,
    [DeliveryDate] datetime2 NOT NULL,
    [Freight] decimal(6,2) NOT NULL,
    [TotalPriceOrder] decimal(11,2) NOT NULL,
    [Status] int NOT NULL,
    [CustomerID] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderID]),
    CONSTRAINT [FK_Orders_Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customers] ([UserID]) ON DELETE CASCADE
);
GO

CREATE TABLE [OrderProducts] (
    [OrderID] int NOT NULL,
    [ProductID] int NOT NULL,
    [QuantityOrdered] int NOT NULL,
    [TotalPriceProduct] decimal(9,2) NOT NULL,
    CONSTRAINT [PK_OrderProducts] PRIMARY KEY ([OrderID], [ProductID]),
    CONSTRAINT [FK_OrderProducts_Orders_OrderID] FOREIGN KEY ([OrderID]) REFERENCES [Orders] ([OrderID]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderProducts_Products_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [Products] ([ProductID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Addresses_CustomerID] ON [Addresses] ([CustomerID]);
GO

CREATE INDEX [IX_OrderProducts_ProductID] ON [OrderProducts] ([ProductID]);
GO

CREATE INDEX [IX_Orders_CustomerID] ON [Orders] ([CustomerID]);
GO

CREATE INDEX [IX_Products_AdministratorID] ON [Products] ([AdministratorID]);
GO

CREATE INDEX [IX_Products_CategoryID] ON [Products] ([CategoryID]);
GO

CREATE INDEX [IX_Products_CollectionID] ON [Products] ([CollectionID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221125162014_Origin', N'6.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'Gender');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Customers] ALTER COLUMN [Gender] nvarchar(1) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221127191738_Update Customer Table', N'6.0.10');
GO

COMMIT;
GO


