USE [AllegroManager];
GO

/****** Object:  Table [baselinker].[Product]    Script Date: 28.09.2024 13:51:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
	PRINT 'Creating [baselinker].[Product] table';

CREATE TABLE [baselinker].[Product](
	[Ean] [nvarchar](13) NOT NULL,
	[Sku] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Stock] [int] NOT NULL,
	[AveragePrice] [real] NOT NULL,
	[AverageGrossPriceBuy] [real] NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [baselinker].[Product] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [AverageGrossPriceBuy]
GO

ALTER TABLE [baselinker].[Product] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [Id]
GO

ALTER TABLE [baselinker].[Product] ADD  DEFAULT ((0)) FOR [ProductId]
GO
