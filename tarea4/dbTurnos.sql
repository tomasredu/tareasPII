USE [PELUQUERIA]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/30/2024 10:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_servicios]    Script Date: 9/30/2024 10:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_servicios](
	[id_servicio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[costo] [float] NOT NULL,
	[en_promocion] [bit] NOT NULL,
	[fecha_baja] [datetime2](7) NULL,
	[motivo_baja] [nvarchar](max) NULL,
 CONSTRAINT [PK_T_servicios] PRIMARY KEY CLUSTERED 
(
	[id_servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240930230521_fistMigration', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240930235150_eraseFix', N'8.0.8')
GO
SET IDENTITY_INSERT [dbo].[T_servicios] ON 

INSERT [dbo].[T_servicios] ([id_servicio], [nombre], [costo], [en_promocion], [fecha_baja], [motivo_baja]) VALUES (1, N'Corte', 1123, 1, CAST(N'2024-09-30T23:59:15.3770000' AS DateTime2), N'string')
INSERT [dbo].[T_servicios] ([id_servicio], [nombre], [costo], [en_promocion], [fecha_baja], [motivo_baja]) VALUES (2, N'Baño', 412, 1, NULL, NULL)
INSERT [dbo].[T_servicios] ([id_servicio], [nombre], [costo], [en_promocion], [fecha_baja], [motivo_baja]) VALUES (3, N'Uñas', 544, 1, CAST(N'2024-09-30T21:23:24.2369842' AS DateTime2), N'Porque si')
INSERT [dbo].[T_servicios] ([id_servicio], [nombre], [costo], [en_promocion], [fecha_baja], [motivo_baja]) VALUES (4, N'Paseo', 321, 1, CAST(N'2024-09-30T22:06:07.5124233' AS DateTime2), N'Y por que no?')
INSERT [dbo].[T_servicios] ([id_servicio], [nombre], [costo], [en_promocion], [fecha_baja], [motivo_baja]) VALUES (5, N'TestFiltroBaja', 9999, 1, CAST(N'2024-01-01T01:12:02.3770000' AS DateTime2), N'Test')
SET IDENTITY_INSERT [dbo].[T_servicios] OFF
GO
