
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/05/2022 14:05:14
-- Generated from EDMX file: C:\Users\mbhan\source\repos\HotelManagement\HotelManagement.Entities\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HotelManagement];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserName] nvarchar(50)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [MobileNumber] nvarchar(max)  NOT NULL,
    [UserRole] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderId] uniqueidentifier  NOT NULL,
    [TotalCost] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [OrderStatus] nvarchar(max)  NOT NULL,
    [UserUserName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'MenuItems'
CREATE TABLE [dbo].[MenuItems] (
    [ItemName] nvarchar(50)  NOT NULL,
    [Cost] nvarchar(max)  NOT NULL,
    [Category] nvarchar(max)  NOT NULL,
    [Availability] nvarchar(max)  NOT NULL,
    [Image] nvarchar(max)  NOT NULL,
    [Item_ItemId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Items'
CREATE TABLE [dbo].[Items] (
    [ItemId] uniqueidentifier  NOT NULL,
    [Quantity] nvarchar(max)  NOT NULL,
    [OrderOrderId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserName] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserName] ASC);
GO

-- Creating primary key on [OrderId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderId] ASC);
GO

-- Creating primary key on [ItemName] in table 'MenuItems'
ALTER TABLE [dbo].[MenuItems]
ADD CONSTRAINT [PK_MenuItems]
    PRIMARY KEY CLUSTERED ([ItemName] ASC);
GO

-- Creating primary key on [ItemId] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([ItemId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserUserName] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_UserOrder]
    FOREIGN KEY ([UserUserName])
    REFERENCES [dbo].[Users]
        ([UserName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserOrder'
CREATE INDEX [IX_FK_UserOrder]
ON [dbo].[Orders]
    ([UserUserName]);
GO

-- Creating foreign key on [Item_ItemId] in table 'MenuItems'
ALTER TABLE [dbo].[MenuItems]
ADD CONSTRAINT [FK_MenuItemItem]
    FOREIGN KEY ([Item_ItemId])
    REFERENCES [dbo].[Items]
        ([ItemId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenuItemItem'
CREATE INDEX [IX_FK_MenuItemItem]
ON [dbo].[MenuItems]
    ([Item_ItemId]);
GO

-- Creating foreign key on [OrderOrderId] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [FK_OrderItem]
    FOREIGN KEY ([OrderOrderId])
    REFERENCES [dbo].[Orders]
        ([OrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderItem'
CREATE INDEX [IX_FK_OrderItem]
ON [dbo].[Items]
    ([OrderOrderId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------