
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/31/2020 22:01:35
-- Generated from EDMX file: C:\Users\DELL\source\repos\SmartGym\SmartGym\Models\SmartGymModels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SmartGym];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[SmartGymModelStoreContainer].[FK__Designati__activ__08B54D69]', 'F') IS NOT NULL
    ALTER TABLE [SmartGymModelStoreContainer].[Designation] DROP CONSTRAINT [FK__Designati__activ__08B54D69];
GO
IF OBJECT_ID(N'[SmartGymModelStoreContainer].[FK__Designation__id__07C12930]', 'F') IS NOT NULL
    ALTER TABLE [SmartGymModelStoreContainer].[Designation] DROP CONSTRAINT [FK__Designation__id__07C12930];
GO
IF OBJECT_ID(N'[dbo].[FK__Employee__role__29221CFB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK__Employee__role__29221CFB];
GO
IF OBJECT_ID(N'[dbo].[FK__Health__healthSt__17036CC0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Health] DROP CONSTRAINT [FK__Health__healthSt__17036CC0];
GO
IF OBJECT_ID(N'[dbo].[FK__Members__trainer__09A971A2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Members] DROP CONSTRAINT [FK__Members__trainer__09A971A2];
GO
IF OBJECT_ID(N'[dbo].[FK_Account_Members]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FK_Account_Members];
GO
IF OBJECT_ID(N'[dbo].[FK_Health_Members]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Health] DROP CONSTRAINT [FK_Health_Members];
GO
IF OBJECT_ID(N'[dbo].[FK_Invoice_Members]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT [FK_Invoice_Members];
GO
IF OBJECT_ID(N'[dbo].[FK_Members_MemberShip]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Members] DROP CONSTRAINT [FK_Members_MemberShip];
GO
IF OBJECT_ID(N'[dbo].[FK_Session_Activity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Session] DROP CONSTRAINT [FK_Session_Activity];
GO
IF OBJECT_ID(N'[dbo].[FK_Session_Members]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Session] DROP CONSTRAINT [FK_Session_Members];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Account]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Account];
GO
IF OBJECT_ID(N'[dbo].[Activity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activity];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[Health]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Health];
GO
IF OBJECT_ID(N'[dbo].[HealthRange]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HealthRange];
GO
IF OBJECT_ID(N'[dbo].[Invoice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Invoice];
GO
IF OBJECT_ID(N'[dbo].[Logs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Logs];
GO
IF OBJECT_ID(N'[dbo].[Members]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Members];
GO
IF OBJECT_ID(N'[dbo].[MemberShip]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MemberShip];
GO
IF OBJECT_ID(N'[dbo].[Session]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Session];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TrainerType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrainerType];
GO
IF OBJECT_ID(N'[SmartGymModelStoreContainer].[Designation]', 'U') IS NOT NULL
    DROP TABLE [SmartGymModelStoreContainer].[Designation];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [accno] int  NOT NULL,
    [memId] varchar(8)  NOT NULL,
    [bank] varchar(30)  NOT NULL,
    [cardType] varchar(30)  NOT NULL
);
GO

-- Creating table 'Activities'
CREATE TABLE [dbo].[Activities] (
    [code] varchar(4)  NOT NULL,
    [description] varchar(500)  NULL,
    [name] varchar(50)  NULL,
    [include] varchar(800)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(50)  NOT NULL,
    [surname] varchar(50)  NOT NULL,
    [email] varchar(100)  NOT NULL,
    [phone] varchar(10)  NOT NULL,
    [address] varchar(200)  NOT NULL,
    [postalCode] varchar(4)  NOT NULL,
    [salary] float  NOT NULL,
    [hireDate] datetime  NOT NULL,
    [password] varchar(50)  NOT NULL,
    [role] int  NULL
);
GO

-- Creating table 'Healths'
CREATE TABLE [dbo].[Healths] (
    [memId] varchar(8)  NULL,
    [height] float  NOT NULL,
    [weight] float  NOT NULL,
    [BMI] float  NOT NULL,
    [imageUrl] varchar(500)  NOT NULL,
    [updated] datetime  NULL,
    [id] int IDENTITY(1,1) NOT NULL,
    [healthStatus] int  NULL
);
GO

-- Creating table 'HealthRanges'
CREATE TABLE [dbo].[HealthRanges] (
    [name] varchar(80)  NOT NULL,
    [minimum] float  NOT NULL,
    [maximum] float  NOT NULL,
    [id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Invoices'
CREATE TABLE [dbo].[Invoices] (
    [invoiceNo] int IDENTITY(1,1) NOT NULL,
    [invoiceDate] datetime  NOT NULL,
    [description] varchar(80)  NOT NULL,
    [memID] varchar(8)  NOT NULL,
    [total] float  NOT NULL,
    [status] bit  NULL
);
GO

-- Creating table 'Logs'
CREATE TABLE [dbo].[Logs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [errorMsg] varchar(500)  NULL,
    [errorDate] datetime  NOT NULL,
    [path] varchar(1000)  NULL
);
GO

-- Creating table 'Members'
CREATE TABLE [dbo].[Members] (
    [memId] varchar(8)  NOT NULL,
    [name] varchar(50)  NOT NULL,
    [surname] varchar(50)  NOT NULL,
    [sa_id] varchar(13)  NOT NULL,
    [email] varchar(50)  NOT NULL,
    [phone] varchar(10)  NOT NULL,
    [address] varchar(100)  NULL,
    [memberShip] varchar(4)  NOT NULL,
    [joinDate] datetime  NOT NULL,
    [trainer] int  NULL,
    [terminateDate] datetime  NULL
);
GO

-- Creating table 'MemberShips'
CREATE TABLE [dbo].[MemberShips] (
    [code] varchar(4)  NOT NULL,
    [name] varchar(80)  NOT NULL,
    [fee] float  NOT NULL,
    [level] int  NOT NULL
);
GO

-- Creating table 'Sessions'
CREATE TABLE [dbo].[Sessions] (
    [memId] varchar(8)  NOT NULL,
    [activityCode] varchar(4)  NOT NULL,
    [sessionDate] datetime  NOT NULL,
    [satisfaction] int  NULL,
    [usage] int  NULL,
    [id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TrainerTypes'
CREATE TABLE [dbo].[TrainerTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(500)  NOT NULL,
    [description] varchar(500)  NOT NULL
);
GO

-- Creating table 'Designations'
CREATE TABLE [dbo].[Designations] (
    [id] int  NOT NULL,
    [activityCode] varchar(4)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [accno] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([accno] ASC);
GO

-- Creating primary key on [code] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [PK_Activities]
    PRIMARY KEY CLUSTERED ([code] ASC);
GO

-- Creating primary key on [id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Healths'
ALTER TABLE [dbo].[Healths]
ADD CONSTRAINT [PK_Healths]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'HealthRanges'
ALTER TABLE [dbo].[HealthRanges]
ADD CONSTRAINT [PK_HealthRanges]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [invoiceNo] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [PK_Invoices]
    PRIMARY KEY CLUSTERED ([invoiceNo] ASC);
GO

-- Creating primary key on [id] in table 'Logs'
ALTER TABLE [dbo].[Logs]
ADD CONSTRAINT [PK_Logs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [memId] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [PK_Members]
    PRIMARY KEY CLUSTERED ([memId] ASC);
GO

-- Creating primary key on [code] in table 'MemberShips'
ALTER TABLE [dbo].[MemberShips]
ADD CONSTRAINT [PK_MemberShips]
    PRIMARY KEY CLUSTERED ([code] ASC);
GO

-- Creating primary key on [id] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [PK_Sessions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id] in table 'TrainerTypes'
ALTER TABLE [dbo].[TrainerTypes]
ADD CONSTRAINT [PK_TrainerTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Designations'
ALTER TABLE [dbo].[Designations]
ADD CONSTRAINT [PK_Designations]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [memId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_Account_Members]
    FOREIGN KEY ([memId])
    REFERENCES [dbo].[Members]
        ([memId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Account_Members'
CREATE INDEX [IX_FK_Account_Members]
ON [dbo].[Accounts]
    ([memId]);
GO

-- Creating foreign key on [activityCode] in table 'Designations'
ALTER TABLE [dbo].[Designations]
ADD CONSTRAINT [FK__Designati__activ__08B54D69]
    FOREIGN KEY ([activityCode])
    REFERENCES [dbo].[Activities]
        ([code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Designati__activ__08B54D69'
CREATE INDEX [IX_FK__Designati__activ__08B54D69]
ON [dbo].[Designations]
    ([activityCode]);
GO

-- Creating foreign key on [activityCode] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [FK_Session_Activity]
    FOREIGN KEY ([activityCode])
    REFERENCES [dbo].[Activities]
        ([code])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Session_Activity'
CREATE INDEX [IX_FK_Session_Activity]
ON [dbo].[Sessions]
    ([activityCode]);
GO

-- Creating foreign key on [id] in table 'Designations'
ALTER TABLE [dbo].[Designations]
ADD CONSTRAINT [FK__Designation__id__07C12930]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Employees]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [role] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK__Employee__role__29221CFB]
    FOREIGN KEY ([role])
    REFERENCES [dbo].[TrainerTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Employee__role__29221CFB'
CREATE INDEX [IX_FK__Employee__role__29221CFB]
ON [dbo].[Employees]
    ([role]);
GO

-- Creating foreign key on [trainer] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [FK__Members__trainer__09A971A2]
    FOREIGN KEY ([trainer])
    REFERENCES [dbo].[Employees]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Members__trainer__09A971A2'
CREATE INDEX [IX_FK__Members__trainer__09A971A2]
ON [dbo].[Members]
    ([trainer]);
GO

-- Creating foreign key on [healthStatus] in table 'Healths'
ALTER TABLE [dbo].[Healths]
ADD CONSTRAINT [FK__Health__healthSt__17036CC0]
    FOREIGN KEY ([healthStatus])
    REFERENCES [dbo].[HealthRanges]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Health__healthSt__17036CC0'
CREATE INDEX [IX_FK__Health__healthSt__17036CC0]
ON [dbo].[Healths]
    ([healthStatus]);
GO

-- Creating foreign key on [memId] in table 'Healths'
ALTER TABLE [dbo].[Healths]
ADD CONSTRAINT [FK_Health_Members]
    FOREIGN KEY ([memId])
    REFERENCES [dbo].[Members]
        ([memId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Health_Members'
CREATE INDEX [IX_FK_Health_Members]
ON [dbo].[Healths]
    ([memId]);
GO

-- Creating foreign key on [memID] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [FK_Invoice_Members]
    FOREIGN KEY ([memID])
    REFERENCES [dbo].[Members]
        ([memId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Invoice_Members'
CREATE INDEX [IX_FK_Invoice_Members]
ON [dbo].[Invoices]
    ([memID]);
GO

-- Creating foreign key on [memberShip] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [FK_Members_MemberShip]
    FOREIGN KEY ([memberShip])
    REFERENCES [dbo].[MemberShips]
        ([code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Members_MemberShip'
CREATE INDEX [IX_FK_Members_MemberShip]
ON [dbo].[Members]
    ([memberShip]);
GO

-- Creating foreign key on [memId] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [FK_Session_Members]
    FOREIGN KEY ([memId])
    REFERENCES [dbo].[Members]
        ([memId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Session_Members'
CREATE INDEX [IX_FK_Session_Members]
ON [dbo].[Sessions]
    ([memId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------