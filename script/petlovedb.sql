USE [petlovedb]
GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 01/11/2022 20:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consulta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataHora] [datetime2](7) NOT NULL,
	[IdMedico] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
 CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especialidade]    Script Date: 01/11/2022 20:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Especialidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medico]    Script Date: 01/11/2022 20:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medico](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CRM] [nvarchar](max) NOT NULL,
	[IdEspecialidade] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Medico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 01/11/2022 20:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Carteirinha] [nvarchar](max) NOT NULL,
	[DataNascimento] [datetime2](7) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 01/11/2022 20:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TipoUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 01/11/2022 20:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Senha] [nvarchar](max) NOT NULL,
	[IdTipoUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Consulta] ON 

INSERT [dbo].[Consulta] ([Id], [DataHora], [IdMedico], [IdPaciente]) VALUES (1, CAST(N'2022-09-05T08:30:00.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[Consulta] ([Id], [DataHora], [IdMedico], [IdPaciente]) VALUES (2, CAST(N'2022-10-10T08:50:00.0000000' AS DateTime2), 2, 2)
INSERT [dbo].[Consulta] ([Id], [DataHora], [IdMedico], [IdPaciente]) VALUES (3, CAST(N'2022-01-14T09:30:00.0000000' AS DateTime2), 3, 3)
INSERT [dbo].[Consulta] ([Id], [DataHora], [IdMedico], [IdPaciente]) VALUES (4, CAST(N'2022-05-11T10:30:00.0000000' AS DateTime2), 4, 4)
INSERT [dbo].[Consulta] ([Id], [DataHora], [IdMedico], [IdPaciente]) VALUES (5, CAST(N'2022-08-01T15:00:00.0000000' AS DateTime2), 5, 5)
SET IDENTITY_INSERT [dbo].[Consulta] OFF
GO
SET IDENTITY_INSERT [dbo].[Especialidade] ON 

INSERT [dbo].[Especialidade] ([Id], [Categoria]) VALUES (1, N'Clínico Geral')
INSERT [dbo].[Especialidade] ([Id], [Categoria]) VALUES (2, N'Radiologia')
INSERT [dbo].[Especialidade] ([Id], [Categoria]) VALUES (3, N'Cardiologia')
INSERT [dbo].[Especialidade] ([Id], [Categoria]) VALUES (4, N'Dermatologia')
INSERT [dbo].[Especialidade] ([Id], [Categoria]) VALUES (5, N'Ginecologia e Obstetrícia')
INSERT [dbo].[Especialidade] ([Id], [Categoria]) VALUES (6, N'Ortopedia')
INSERT [dbo].[Especialidade] ([Id], [Categoria]) VALUES (7, N'Pediatria')
INSERT [dbo].[Especialidade] ([Id], [Categoria]) VALUES (8, N'Oftalmologia')
INSERT [dbo].[Especialidade] ([Id], [Categoria]) VALUES (9, N'Oncologia')
INSERT [dbo].[Especialidade] ([Id], [Categoria]) VALUES (10, N'Anestesiologia')
SET IDENTITY_INSERT [dbo].[Especialidade] OFF
GO
SET IDENTITY_INSERT [dbo].[Medico] ON 

INSERT [dbo].[Medico] ([Id], [CRM], [IdEspecialidade], [IdUsuario]) VALUES (1, N'CRM12345', 1, 4)
INSERT [dbo].[Medico] ([Id], [CRM], [IdEspecialidade], [IdUsuario]) VALUES (2, N'CRM45678', 2, 5)
INSERT [dbo].[Medico] ([Id], [CRM], [IdEspecialidade], [IdUsuario]) VALUES (3, N'CRM45698', 3, 6)
INSERT [dbo].[Medico] ([Id], [CRM], [IdEspecialidade], [IdUsuario]) VALUES (4, N'CRM78963', 4, 7)
INSERT [dbo].[Medico] ([Id], [CRM], [IdEspecialidade], [IdUsuario]) VALUES (5, N'CRM20225', 5, 8)
SET IDENTITY_INSERT [dbo].[Medico] OFF
GO
SET IDENTITY_INSERT [dbo].[Paciente] ON 

INSERT [dbo].[Paciente] ([Id], [Carteirinha], [DataNascimento], [Ativo], [IdUsuario]) VALUES (1, N'SUS12345', CAST(N'2000-09-05T00:00:00.0000000' AS DateTime2), 1, 9)
INSERT [dbo].[Paciente] ([Id], [Carteirinha], [DataNascimento], [Ativo], [IdUsuario]) VALUES (2, N'SUS45678', CAST(N'1998-10-10T00:00:00.0000000' AS DateTime2), 1, 10)
INSERT [dbo].[Paciente] ([Id], [Carteirinha], [DataNascimento], [Ativo], [IdUsuario]) VALUES (3, N'SUS45698', CAST(N'1993-01-14T00:00:00.0000000' AS DateTime2), 1, 11)
INSERT [dbo].[Paciente] ([Id], [Carteirinha], [DataNascimento], [Ativo], [IdUsuario]) VALUES (4, N'SUS78963', CAST(N'1973-05-11T00:00:00.0000000' AS DateTime2), 1, 12)
INSERT [dbo].[Paciente] ([Id], [Carteirinha], [DataNascimento], [Ativo], [IdUsuario]) VALUES (5, N'SUS20225', CAST(N'1997-08-01T00:00:00.0000000' AS DateTime2), 1, 13)
SET IDENTITY_INSERT [dbo].[Paciente] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoUsuario] ON 

INSERT [dbo].[TipoUsuario] ([Id], [Tipo]) VALUES (1, N'Desenvolvedor')
INSERT [dbo].[TipoUsuario] ([Id], [Tipo]) VALUES (2, N'Medico')
INSERT [dbo].[TipoUsuario] ([Id], [Tipo]) VALUES (3, N'Paciente')
SET IDENTITY_INSERT [dbo].[TipoUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [IdTipoUsuario]) VALUES (1, N'Fernanda', N'fernanda@edusync.com', N'$2b$10$RUK/V5KMRsVTlsCb6ghaBuX7O9BzR2frZmDrA9vdccDpvV2UgYRP2', 1)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [IdTipoUsuario]) VALUES (2, N'Sérgio', N'sergio@edusync.com', N'$2b$10$5LMovtayfiW5SO2BBQ.5Ye.gPzdxIcxNU5vq1ocbK/v/gx/obXibS', 1)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [IdTipoUsuario]) VALUES (3, N'Celso', N'celso@edusync.com.com', N'$2b$10$HNgf6ffl3fu9Jt5joDEOeuArAnIhbu6NyUa8QJ6eoK/KYTRsc.OJK', 1)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [IdTipoUsuario]) VALUES (4, N'Maria', N'maria@email.com', N'$2b$10$7AmXHnSNNzfDHsV.TYB/Ve4AfPZi2WRTc5DWDz6FLGxVdkgNKfnAC', 2)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [IdTipoUsuario]) VALUES (5, N'João', N'joao@email.com', N'$2b$10$I55Jtu9lv9X/98wBRKfGx.YnismMMq3AQLBRAcXkX2ZZMvI4wwJ7u', 2)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [IdTipoUsuario]) VALUES (6, N'Pedro', N'pedro@email.com', N'$2b$10$rugWWmClZkSxeKqTuxHeveQMPcHSKfpeeQIkM/.NOp1yUAopA8aIy', 2)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [IdTipoUsuario]) VALUES (7, N'Leonardo', N'leonardo@email.com', N'$2b$10$NzFyNvYLBsPpMl3fdKFlPO01ml5nVNVHlL42r41ZaHzeHfQbYne4i', 2)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [IdTipoUsuario]) VALUES (8, N'Carla', N'carla@email.com', N'$2b$10$1/rv28jCbFz2DER3MJ4ZP.54xsTEkHuzGvqNDhjVSjEFRm0PjMhLa', 2)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [IdTipoUsuario]) VALUES (9, N'Paulo', N'paulo@email.com', N'$2b$10$hZ1exkfVNdq4HK2VpER23.6uimyVn4WoTKd0DgXW/gVZx3ccaHKSy', 3)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [IdTipoUsuario]) VALUES (10, N'Claudio', N'claudio@email.com', N'$2b$10$iYdnxziBv3We/ZpaaiCc.OQmOottLl5EpGojriwrv/IHEb1pljUdy', 3)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [IdTipoUsuario]) VALUES (11, N'Henrique', N'henrique@email.com', N'$2b$10$9YQnBGwpjRkwV3UNDA1XJe84v.cV5/8MdksmDmxPX.9uCrEZYojMq', 3)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [IdTipoUsuario]) VALUES (12, N'Lorena', N'lorena@email.com', N'$2b$10$NuCKlLjLgVDhHMFIuncTv.RoXf3whoqSvRkKrnbdmxr/5Jv4rMHnC', 3)
INSERT [dbo].[Usuario] ([Id], [Nome], [Email], [Senha], [IdTipoUsuario]) VALUES (13, N'Viviane', N'viviane@email.com', N'$2b$10$4V8q0Eq9xByBLvzW/.yMHe4FSz1rE5EnWySkZMfKh10JWMoJ31gmm', 3)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Medico_IdMedico] FOREIGN KEY([IdMedico])
REFERENCES [dbo].[Medico] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Medico_IdMedico]
GO
ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Paciente_IdPaciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([Id])
GO
ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Paciente_IdPaciente]
GO
ALTER TABLE [dbo].[Medico]  WITH CHECK ADD  CONSTRAINT [FK_Medico_Especialidade_IdEspecialidade] FOREIGN KEY([IdEspecialidade])
REFERENCES [dbo].[Especialidade] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Medico] CHECK CONSTRAINT [FK_Medico_Especialidade_IdEspecialidade]
GO
ALTER TABLE [dbo].[Medico]  WITH CHECK ADD  CONSTRAINT [FK_Medico_Usuario_IdUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Medico] CHECK CONSTRAINT [FK_Medico_Usuario_IdUsuario]
GO
ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Usuario_IdUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [FK_Paciente_Usuario_IdUsuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TipoUsuario_IdTipoUsuario] FOREIGN KEY([IdTipoUsuario])
REFERENCES [dbo].[TipoUsuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_TipoUsuario_IdTipoUsuario]
GO
