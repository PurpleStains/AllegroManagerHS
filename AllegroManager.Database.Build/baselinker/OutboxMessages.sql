USE [AllegroManager];


-- check to see if table exists in INFORMATION_SCHEMA.TABLES - ignore DROP TABLE if it does not
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'OutboxMessages' AND TABLE_SCHEMA = 'baselinker')
BEGIN
	PRINT 'Creating [baselinker].OutboxMessages table';
   CREATE TABLE [baselinker].OutboxMessages
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[OccurredOn] DATETIME2 NOT NULL,
	[Type] VARCHAR(255) NOT NULL,
	[Data] VARCHAR(MAX) NOT NULL,
	[ProcessedDate] DATETIME2 NULL,
	CONSTRAINT [PK_baselinker_OutboxMessages_Id] PRIMARY KEY ([Id] ASC)
)
END;