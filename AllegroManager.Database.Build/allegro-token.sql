USE AllegroManager


/****** Object:  Table [dbo].[AllegroOAuthTokens]    Script Date: 09.10.2024 09:01:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

PRINT 'Creating AllegroOAuthTokens table';

CREATE TABLE AllegroOAuthTokens(
	[Id] [uniqueidentifier] NOT NULL,
	[DateTimeStamp] [datetimeoffset](7) NOT NULL,
	[AccessToken] [nvarchar](max) NOT NULL,
	[TokenType] [nvarchar](max) NOT NULL,
	[RefreshToken] [nvarchar](max) NOT NULL,
	[Scope] [nvarchar](max) NOT NULL,
	[Jti] [nvarchar](max) NOT NULL,
	[ExpiresIn] [datetime2](7) NULL,
 CONSTRAINT [PK_AllegroOAuthTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO