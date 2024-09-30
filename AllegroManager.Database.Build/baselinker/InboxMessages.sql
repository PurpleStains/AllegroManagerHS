USE [AllegroManager];
GO

-- check to see if table exists in INFORMATION_SCHEMA.TABLES - ignore DROP TABLE if it does not
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'InboxMessages' AND TABLE_SCHEMA = 'baselinker')
BEGIN
	PRINT 'Creating [baselinker].InboxMessages table';
	CREATE TABLE [baselinker].InboxMessages
	(
		[Id] UNIQUEIDENTIFIER NOT NULL,
		[OccurredOn] DATETIME2 NOT NULL,
		[Type] VARCHAR(255) NOT NULL,
		[Data] VARCHAR(MAX) NOT NULL,
		[ProcessedDate] DATETIME2 NULL,
		CONSTRAINT [PK_baselinker_InboxMessages_Id] PRIMARY KEY ([Id] ASC)
	)
END;

