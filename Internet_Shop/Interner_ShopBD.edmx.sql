
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/20/2023 22:17:48
-- Generated from EDMX file: C:\Users\admin\Desktop\курсач\Internet_Shop\Internet_Shop\Interner_ShopBD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Internet_Shop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Client_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Client] DROP CONSTRAINT [FK_Client_Order];
GO
IF OBJECT_ID(N'[dbo].[FK_Client_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Client] DROP CONSTRAINT [FK_Client_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Role_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Role] DROP CONSTRAINT [FK_User_Role_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Role_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Role] DROP CONSTRAINT [FK_User_Role_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Client];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[User_Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_Role];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Client'
CREATE TABLE [dbo].[Client] (
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(50)  NOT NULL,
    [PhoneNumber] nvarchar(50)  NOT NULL,
    [ProductID] decimal(18,0)  NULL,
    [FullName] nvarchar(50)  NOT NULL,
    [OrderID] decimal(18,0)  NULL
);
GO

-- Creating table 'Employee'
CREATE TABLE [dbo].[Employee] (
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(50)  NOT NULL,
    [Position] nvarchar(50)  NOT NULL,
    [Gender] nvarchar(50)  NOT NULL,
    [Salary] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Order'
CREATE TABLE [dbo].[Order] (
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Number] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(50)  NOT NULL,
    [Price] nvarchar(50)  NOT NULL,
    [Amount] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [ID] decimal(18,0) IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Login] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'User_Role'
CREATE TABLE [dbo].[User_Role] (
    [Role_ID] decimal(18,0)  NOT NULL,
    [User_Login] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [PK_Client]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [PK_Employee]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Login] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Login] ASC);
GO

-- Creating primary key on [Role_ID], [User_Login] in table 'User_Role'
ALTER TABLE [dbo].[User_Role]
ADD CONSTRAINT [PK_User_Role]
    PRIMARY KEY CLUSTERED ([Role_ID], [User_Login] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProductID] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [FK_Client_Product]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Product]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Client_Product'
CREATE INDEX [IX_FK_Client_Product]
ON [dbo].[Client]
    ([ProductID]);
GO

-- Creating foreign key on [Role_ID] in table 'User_Role'
ALTER TABLE [dbo].[User_Role]
ADD CONSTRAINT [FK_User_Role_Role]
    FOREIGN KEY ([Role_ID])
    REFERENCES [dbo].[Role]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [User_Login] in table 'User_Role'
ALTER TABLE [dbo].[User_Role]
ADD CONSTRAINT [FK_User_Role_User]
    FOREIGN KEY ([User_Login])
    REFERENCES [dbo].[User]
        ([Login])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Role_User'
CREATE INDEX [IX_FK_User_Role_User]
ON [dbo].[User_Role]
    ([User_Login]);
GO

-- Creating foreign key on [OrderID] in table 'Client'
ALTER TABLE [dbo].[Client]
ADD CONSTRAINT [FK_Client_Order]
    FOREIGN KEY ([OrderID])
    REFERENCES [dbo].[Order]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Client_Order'
CREATE INDEX [IX_FK_Client_Order]
ON [dbo].[Client]
    ([OrderID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------