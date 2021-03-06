/****** Object:  Table [dbo].[Clients]    Script Date: 12/9/2021 4:08:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[surname] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[piva] [varchar](50) NULL,
	[businessname] [varchar](50) NULL,
	[cf] [varchar](16) NULL,
	[address] [varchar](50) NOT NULL,
	[year] [numeric](4, 0) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/9/2021 4:08:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [uniqueidentifier] NOT NULL,
	[clientid] [int] NOT NULL,
	[totalprice] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK__Orders__3213E83F61A7A6DD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF__Orders__id__7B5B524B]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Clients] FOREIGN KEY([clientid])
REFERENCES [dbo].[Clients] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Clients]
GO
