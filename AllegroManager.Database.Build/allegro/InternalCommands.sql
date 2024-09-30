USE [AllegroManager];
GO

-- check to see if table exists in INFORMATION_SCHEMA.TABLES - ignore DROP TABLE if it does not
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'InternalCommands' AND TABLE_SCHEMA = 'allegro')
BEGIN
	PRINT 'Creating [allegro].InternalCommands table';
   CREATE TABLE [allegro].InternalCommands
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[EnqueueDate] DATETIME2 NOT NULL,
	[Type] VARCHAR(255) NOT NULL,
	[Data] VARCHAR(MAX) NOT NULL,
	[ProcessedDate] DATETIME2 NULL,
	[Error] NVARCHAR(MAX) NULL,
	CONSTRAINT [PK_allegro_InternalCommands_Id] PRIMARY KEY ([Id] ASC)
)
END;
