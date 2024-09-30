USE [AllegroManager];
GO

/****** Object:  Table [offers].[AllegroOffers]    Script Date: 28.09.2024 13:53:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
	PRINT 'Creating [offers].[AllegroOffers] table';

CREATE TABLE [offers].[AllegroOffers](
	[AllegroOfferId] [uniqueidentifier] NOT NULL,
	[OfferId] [nvarchar](max) NOT NULL,
	[CategoryId] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Stock] [int] NOT NULL,
	[PriceGross] [nvarchar](max) NULL,
	[PublicationStatus] [nvarchar](max) NOT NULL,
	[EAN] [nvarchar](max) NOT NULL,
	[BuyPriceGross] [float] NOT NULL,
	[AllegroFee] [float] NOT NULL,
	[Margin] [float] NOT NULL,
	[Income] [float] NOT NULL,
	[PackageFee] [float] NOT NULL,
 CONSTRAINT [PK_AllegroOffers] PRIMARY KEY CLUSTERED 
(
	[AllegroOfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [offers].[AllegroOffers] ADD  DEFAULT (N'') FOR [PublicationStatus]
GO

ALTER TABLE [offers].[AllegroOffers] ADD  DEFAULT (N'') FOR [EAN]
GO

ALTER TABLE [offers].[AllegroOffers] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [BuyPriceGross]
GO

ALTER TABLE [offers].[AllegroOffers] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [AllegroFee]
GO

ALTER TABLE [offers].[AllegroOffers] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Margin]
GO

ALTER TABLE [offers].[AllegroOffers] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Income]
GO

ALTER TABLE [offers].[AllegroOffers] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [PackageFee]
GO