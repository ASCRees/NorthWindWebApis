
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/04/2020 12:49:01
-- Generated from EDMX file: C:\Projects\NorthWindWebApis\NorthWindWebApis.DataLayer\NorthWind.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProductDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Order_Details_Orders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order Details] DROP CONSTRAINT [FK_Order_Details_Orders];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Details_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order Details] DROP CONSTRAINT [FK_Order_Details_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_Orders_Customers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Customers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Order Details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order Details];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [ProductName] nvarchar(40)  NOT NULL,
    [SupplierID] int  NULL,
    [CategoryID] int  NULL,
    [QuantityPerUnit] nvarchar(20)  NULL,
    [UnitPrice] decimal(19,4)  NULL,
    [UnitsInStock] smallint  NULL,
    [UnitsOnOrder] smallint  NULL,
    [ReorderLevel] smallint  NULL,
    [Discontinued] bit  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerID] nchar(5)  NOT NULL,
    [CompanyName] nvarchar(40)  NOT NULL,
    [ContactName] nvarchar(30)  NULL,
    [ContactTitle] nvarchar(30)  NULL,
    [Address] nvarchar(60)  NULL,
    [City] nvarchar(15)  NULL,
    [Region] nvarchar(15)  NULL,
    [PostalCode] nvarchar(10)  NULL,
    [Country] nvarchar(15)  NULL,
    [Phone] nvarchar(24)  NULL,
    [Fax] nvarchar(24)  NULL
);
GO

-- Creating table 'Order_Details'
CREATE TABLE [dbo].[Order_Details] (
    [OrderID] int  NOT NULL,
    [ProductID] int  NOT NULL,
    [UnitPrice] decimal(19,4)  NOT NULL,
    [Quantity] smallint  NOT NULL,
    [Discount] real  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderID] int IDENTITY(1,1) NOT NULL,
    [CustomerID] nchar(5)  NULL,
    [EmployeeID] int  NULL,
    [OrderDate] datetime  NULL,
    [RequiredDate] datetime  NULL,
    [ShippedDate] datetime  NULL,
    [ShipVia] int  NULL,
    [Freight] decimal(19,4)  NULL,
    [ShipName] nvarchar(40)  NULL,
    [ShipAddress] nvarchar(60)  NULL,
    [ShipCity] nvarchar(15)  NULL,
    [ShipRegion] nvarchar(15)  NULL,
    [ShipPostalCode] nvarchar(10)  NULL,
    [ShipCountry] nvarchar(15)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ProductID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- Creating primary key on [CustomerID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerID] ASC);
GO

-- Creating primary key on [OrderID], [ProductID] in table 'Order_Details'
ALTER TABLE [dbo].[Order_Details]
ADD CONSTRAINT [PK_Order_Details]
    PRIMARY KEY CLUSTERED ([OrderID], [ProductID] ASC);
GO

-- Creating primary key on [OrderID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Customers]
    FOREIGN KEY ([CustomerID])
    REFERENCES [dbo].[Customers]
        ([CustomerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Customers'
CREATE INDEX [IX_FK_Orders_Customers]
ON [dbo].[Orders]
    ([CustomerID]);
GO

-- Creating foreign key on [OrderID] in table 'Order_Details'
ALTER TABLE [dbo].[Order_Details]
ADD CONSTRAINT [FK_Order_Details_Orders]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[Orders]
        ([OrderID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductID] in table 'Order_Details'
ALTER TABLE [dbo].[Order_Details]
ADD CONSTRAINT [FK_Order_Details_Products]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Products]
        ([ProductID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Details_Products'
CREATE INDEX [IX_FK_Order_Details_Products]
ON [dbo].[Order_Details]
    ([ProductID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------