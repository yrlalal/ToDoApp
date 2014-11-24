USE [master]
GO

IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'TaskDB')
DROP DATABASE [TaskDB]
GO

CREATE DATABASE [TaskDB]
GO
--------------------------------------------------------------------------------------
USE [TaskDB]
GO

IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'history')
DROP SCHEMA [history]
GO

CREATE SCHEMA [history] AUTHORIZATION [dbo]
GO
--------------------------------------------------------------------------------------
USE TaskDB
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Credentials]') AND type in (N'U'))
DROP TABLE [dbo].[Credentials]
GO

CREATE TABLE [dbo].[Credentials](
	[CredentialsId] [BIGINT] IDENTITY NOT NULL,
	[UserId] [VARCHAR](50) NOT NULL,
	[Password] [VARCHAR](50) NOT NULL,
	[Email] [VARCHAR](50) NOT NULL,
	[LastName] [VARCHAR](50) NOT NULL,
	[FirstName] [VARCHAR](50) NOT NULL,
	[LastUpdateDateTime] [SMALLDATETIME] NOT NULL,
	[AddDateTime] [SMALLDATETIME] NOT NULL,
 CONSTRAINT [PK_Credentials] PRIMARY KEY CLUSTERED 
(
	[CredentialsId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR=80)
)
GO

ALTER TABLE [dbo].[Credentials]
	ADD CONSTRAINT [UK_Credentials_UserId] UNIQUE 
	(
		[UserId]
	)
GO
--------------------------------------------------------------------------------------
USE TaskDB
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Priority]') AND type in (N'U'))
DROP TABLE [dbo].[Priority]
GO

CREATE TABLE [dbo].[Priority](
	[PriorityId] [SMALLINT] IDENTITY NOT NULL,
	[PriorityText] [VARCHAR](20) NOT NULL,
	[LastUpdateDateTime] [SMALLDATETIME] NOT NULL,
	[AddDateTime] [SMALLDATETIME] NOT NULL,
 CONSTRAINT [PK_Priority] PRIMARY KEY CLUSTERED 
(
	[PriorityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR=80)
)
GO

ALTER TABLE [dbo].[Priority]
	ADD CONSTRAINT [UK_Priority_PriorityText] UNIQUE 
	(
		[PriorityText]
	)
GO
--------------------------------------------------------------------------------------
USE TaskDB
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO

CREATE TABLE [dbo].[Category](
	[CategoryId] [SMALLINT] IDENTITY NOT NULL,
	[CategoryText] [VARCHAR](20) NOT NULL,
	[LastUpdateDateTime] [SMALLDATETIME] NOT NULL,
	[AddDateTime] [SMALLDATETIME] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR=80)
)
GO

ALTER TABLE [dbo].[Category]
	ADD CONSTRAINT [UK_Category_CategoryText] UNIQUE 
	(
		[CategoryText]
	)
GO
--------------------------------------------------------------------------------------
USE TaskDB
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Status]') AND type in (N'U'))
DROP TABLE [dbo].[Status]
GO

CREATE TABLE [dbo].[Status](
	[StatusId] [SMALLINT] IDENTITY NOT NULL,
	[StatusText] [VARCHAR](20) NOT NULL,
	[LastUpdateDateTime] [SMALLDATETIME] NOT NULL,
	[AddDateTime] [SMALLDATETIME] NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR=80)
)
GO

ALTER TABLE [dbo].[Status]
	ADD CONSTRAINT [UK_Status_StatusText] UNIQUE 
	(
		[StatusText]
	)
GO
--------------------------------------------------------------------------------------
USE TaskDB
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Task]') AND type in (N'U'))
DROP TABLE [dbo].[Task]
GO

CREATE TABLE [dbo].[Task](
	[TaskId] [BIGINT] IDENTITY NOT NULL,
	[CredentialsId] [BIGINT] NOT NULL,
	[Description] [VARCHAR](100) NOT NULL,
	[CategoryId] [SMALLINT] NULL,
	[StatusId] [SMALLINT] NULL,
	[PriorityId] [SMALLINT] NULL,
	[DueDate] [SMALLDATETIME] NULL,
	[LastUpdateDateTime] [SMALLDATETIME] NOT NULL,
	[AddDateTime] [SMALLDATETIME] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR=80)
)
GO

ALTER TABLE [dbo].[Task]
	ADD CONSTRAINT FK_Task_Credentials FOREIGN KEY (CredentialsId)
		REFERENCES [dbo].[Credentials](CredentialsId)
GO

ALTER TABLE [dbo].[Task]
	ADD CONSTRAINT FK_Task_Status FOREIGN KEY (StatusId)
		REFERENCES [dbo].[Status](StatusId)
GO

ALTER TABLE [dbo].[Task]
	ADD CONSTRAINT FK_Task_Category FOREIGN KEY (CategoryId)
		REFERENCES [dbo].[Category](CategoryId)
GO

ALTER TABLE [dbo].[Task]
	ADD CONSTRAINT FK_Task_Priority FOREIGN KEY (PriorityId)
		REFERENCES [dbo].[Priority](PriorityId)
GO
--------------------------------------------------------------------------------------
USE TaskDB
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[history].[Task]') AND type in (N'U'))
DROP TABLE [history].[Task]
GO

CREATE TABLE [history].[Task](
	[TaskId] [BIGINT] IDENTITY NOT NULL,
	[CredentialsId] [BIGINT] NOT NULL,
	[Description] [VARCHAR](100) NOT NULL,
	[CategoryId] [SMALLINT] NULL,
	[StatusId] [SMALLINT] NULL,
	[PriorityId] [SMALLINT] NULL,
	[DueDate] [SMALLDATETIME] NULL,
	[LastUpdateDateTime] [SMALLDATETIME] NOT NULL,
	[AddDateTime] [SMALLDATETIME] NOT NULL,
	[TransactionDateTime] [SMALLDATETIME] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR=80)
)
GO

ALTER TABLE [history].[Task]
	ADD CONSTRAINT FK_HistoryTask_Credentials FOREIGN KEY (CredentialsId)
		REFERENCES [dbo].[Credentials](CredentialsId)
GO

ALTER TABLE [history].[Task]
	ADD CONSTRAINT FK_HistoryTask_Status FOREIGN KEY (StatusId)
		REFERENCES [dbo].[Status](StatusId)
GO

ALTER TABLE [history].[Task]
	ADD CONSTRAINT FK_HistoryTask_Category FOREIGN KEY (CategoryId)
		REFERENCES [dbo].[Category](CategoryId)
GO

ALTER TABLE [history].[Task]
	ADD CONSTRAINT FK_HistoryTask_Priority FOREIGN KEY (PriorityId)
		REFERENCES [dbo].[Priority](PriorityId)
GO
--------------------------------------------------------------------------------------
USE [TaskDB]
GO

IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[TaskTrigger]'))
DROP TRIGGER [dbo].[TaskTrigger]
GO

CREATE TRIGGER 	[dbo].[TaskTrigger]
ON 				[dbo].[Task]
FOR DELETE
AS
BEGIN	   
	 INSERT INTO 	[history].[Task]
		SELECT 		[CredentialsId]
					,[Description]
					  ,[CategoryId]
					  ,[StatusId]
					  ,[PriorityId]
					  ,[DueDate]
					  ,[LastUpdateDateTime]
					  ,[AddDateTime]
					  , GETDATE()
		FROM 		DELETED
END
GO
--------------------------------------------------------------------------------------
USE TaskDB
GO

INSERT INTO dbo.Category VALUES ('Personal', GETDATE(), GETDATE())
INSERT INTO dbo.Category VALUES ('Office', GETDATE(), GETDATE())
INSERT INTO dbo.Category VALUES ('Shopping', GETDATE(), GETDATE())
INSERT INTO dbo.Category VALUES ('Groceries', GETDATE(), GETDATE())
INSERT INTO dbo.Category VALUES ('Other', GETDATE(), GETDATE())
GO
--------------------------------------------------------------------------------------
USE TaskDB
GO

INSERT INTO dbo.Priority VALUES ('Low', GETDATE(), GETDATE())
INSERT INTO dbo.Priority VALUES ('Medium', GETDATE(), GETDATE())
INSERT INTO dbo.Priority VALUES ('High', GETDATE(), GETDATE())
INSERT INTO dbo.Priority VALUES ('Urgent', GETDATE(), GETDATE())
GO
--------------------------------------------------------------------------------------
USE TaskDB
GO

INSERT INTO dbo.Status VALUES ('Not Started', GETDATE(), GETDATE())
INSERT INTO dbo.Status VALUES ('In Process', GETDATE(), GETDATE())
INSERT INTO dbo.Status VALUES ('Completed', GETDATE(), GETDATE())
GO