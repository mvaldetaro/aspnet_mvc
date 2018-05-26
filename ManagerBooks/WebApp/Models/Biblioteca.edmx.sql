
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/26/2018 09:44:05
-- Generated from EDMX file: D:\GitHub\aspnet_mvc\ManagerBooks\WebApp\Models\Biblioteca.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Biblioteca];
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

-- Creating table 'BookSet'
CREATE TABLE [dbo].[BookSet] (
    [BookId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Isbn] nvarchar(max)  NOT NULL,
    [Ano] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AuthorSet'
CREATE TABLE [dbo].[AuthorSet] (
    [AuthorId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Birthday] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BookAuthor'
CREATE TABLE [dbo].[BookAuthor] (
    [Books_BookId] int  NOT NULL,
    [Authors_AuthorId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BookId] in table 'BookSet'
ALTER TABLE [dbo].[BookSet]
ADD CONSTRAINT [PK_BookSet]
    PRIMARY KEY CLUSTERED ([BookId] ASC);
GO

-- Creating primary key on [AuthorId] in table 'AuthorSet'
ALTER TABLE [dbo].[AuthorSet]
ADD CONSTRAINT [PK_AuthorSet]
    PRIMARY KEY CLUSTERED ([AuthorId] ASC);
GO

-- Creating primary key on [Books_BookId], [Authors_AuthorId] in table 'BookAuthor'
ALTER TABLE [dbo].[BookAuthor]
ADD CONSTRAINT [PK_BookAuthor]
    PRIMARY KEY CLUSTERED ([Books_BookId], [Authors_AuthorId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Books_BookId] in table 'BookAuthor'
ALTER TABLE [dbo].[BookAuthor]
ADD CONSTRAINT [FK_BookAuthor_Book]
    FOREIGN KEY ([Books_BookId])
    REFERENCES [dbo].[BookSet]
        ([BookId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Authors_AuthorId] in table 'BookAuthor'
ALTER TABLE [dbo].[BookAuthor]
ADD CONSTRAINT [FK_BookAuthor_Author]
    FOREIGN KEY ([Authors_AuthorId])
    REFERENCES [dbo].[AuthorSet]
        ([AuthorId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookAuthor_Author'
CREATE INDEX [IX_FK_BookAuthor_Author]
ON [dbo].[BookAuthor]
    ([Authors_AuthorId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------