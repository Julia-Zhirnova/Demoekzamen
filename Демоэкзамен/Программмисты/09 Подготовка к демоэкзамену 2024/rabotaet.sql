USE [master]
GO
/****** Object:  Database [uchet_zayavok]    Script Date: 11.04.2024 4:41:34 ******/
CREATE DATABASE [uchet_zayavok]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'uchet_zayavok', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\uchet_zayavok.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'uchet_zayavok_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\uchet_zayavok_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [uchet_zayavok] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [uchet_zayavok].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [uchet_zayavok] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [uchet_zayavok] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [uchet_zayavok] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [uchet_zayavok] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [uchet_zayavok] SET ARITHABORT OFF 
GO
ALTER DATABASE [uchet_zayavok] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [uchet_zayavok] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [uchet_zayavok] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [uchet_zayavok] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [uchet_zayavok] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [uchet_zayavok] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [uchet_zayavok] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [uchet_zayavok] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [uchet_zayavok] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [uchet_zayavok] SET  DISABLE_BROKER 
GO
ALTER DATABASE [uchet_zayavok] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [uchet_zayavok] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [uchet_zayavok] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [uchet_zayavok] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [uchet_zayavok] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [uchet_zayavok] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [uchet_zayavok] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [uchet_zayavok] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [uchet_zayavok] SET  MULTI_USER 
GO
ALTER DATABASE [uchet_zayavok] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [uchet_zayavok] SET DB_CHAINING OFF 
GO
ALTER DATABASE [uchet_zayavok] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [uchet_zayavok] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [uchet_zayavok] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [uchet_zayavok] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [uchet_zayavok] SET QUERY_STORE = OFF
GO
USE [uchet_zayavok]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 11.04.2024 4:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameClient] [varchar](100) NOT NULL,
 CONSTRAINT [PK_client] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ispolnitel]    Script Date: 11.04.2024 4:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ispolnitel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameIspolnitel] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Ispolnitel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Neisp]    Script Date: 11.04.2024 4:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Neisp](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeNeisp] [varchar](100) NOT NULL,
 CONSTRAINT [PK_neisp] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oborud]    Script Date: 11.04.2024 4:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oborud](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeOborud] [varchar](100) NOT NULL,
	[NameOborud] [varchar](100) NOT NULL,
 CONSTRAINT [PK_oborud] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Otchet]    Script Date: 11.04.2024 4:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Otchet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Time] [int] NOT NULL,
	[Material] [varchar](100) NOT NULL,
	[Cost] [int] NOT NULL,
	[ReasonNeisp] [varchar](100) NOT NULL,
	[OpisanieHelp] [text] NOT NULL,
	[ZayavkaID] [int] NOT NULL,
	[IspolnitelID] [int] NOT NULL,
	[ZapchastID] [int] NULL,
 CONSTRAINT [PK_Otchet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11.04.2024 4:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleUser] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 11.04.2024 4:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StatusZayavki] [varchar](50) NOT NULL,
 CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11.04.2024 4:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](100) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zapchast]    Script Date: 11.04.2024 4:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zapchast](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameZapchact] [varchar](100) NOT NULL,
 CONSTRAINT [PK_zapchast] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zayavka]    Script Date: 11.04.2024 4:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zayavka](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DataAdd] [date] NULL,
	[OborudID] [int] NULL,
	[TypeNeispID] [int] NULL,
	[OpisanieProblem] [text] NULL,
	[ClientID] [int] NULL,
	[StatusID] [int] NULL,
	[IspolnitelID] [int] NULL,
	[Comment] [text] NULL,
	[Material] [varchar](100) NULL,
	[Cost] [int] NULL,
	[ReasonNeisp] [varchar](100) NULL,
	[OpisanieHelp] [text] NULL,
	[ZapchastID] [int] NULL,
	[DataEnd] [date] NULL,
	[PhotoPath] [varchar](100) NULL,
 CONSTRAINT [PK_zayavka] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ID], [NameClient]) VALUES (1, N'Владислав')
INSERT [dbo].[Client] ([ID], [NameClient]) VALUES (2, N'Матвей')
INSERT [dbo].[Client] ([ID], [NameClient]) VALUES (3, N'Дмитрий')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Ispolnitel] ON 

INSERT [dbo].[Ispolnitel] ([ID], [NameIspolnitel]) VALUES (1, N'Олег')
INSERT [dbo].[Ispolnitel] ([ID], [NameIspolnitel]) VALUES (2, N'Варвара')
INSERT [dbo].[Ispolnitel] ([ID], [NameIspolnitel]) VALUES (3, N'Георгий')
SET IDENTITY_INSERT [dbo].[Ispolnitel] OFF
GO
SET IDENTITY_INSERT [dbo].[Neisp] ON 

INSERT [dbo].[Neisp] ([ID], [TypeNeisp]) VALUES (1, N'Дефект')
INSERT [dbo].[Neisp] ([ID], [TypeNeisp]) VALUES (2, N'Повреждение')
INSERT [dbo].[Neisp] ([ID], [TypeNeisp]) VALUES (3, N'Отказ')
SET IDENTITY_INSERT [dbo].[Neisp] OFF
GO
SET IDENTITY_INSERT [dbo].[Oborud] ON 

INSERT [dbo].[Oborud] ([ID], [TypeOborud], [NameOborud]) VALUES (1, N'1 Тип Оборудования', N'Оборудование1')
INSERT [dbo].[Oborud] ([ID], [TypeOborud], [NameOborud]) VALUES (2, N'2 Тип Оборудования', N'Оборудование2')
INSERT [dbo].[Oborud] ([ID], [TypeOborud], [NameOborud]) VALUES (3, N'3 Тип Оборудования', N'Оборудование3')
SET IDENTITY_INSERT [dbo].[Oborud] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [RoleUser]) VALUES (1, N'Менеджер')
INSERT [dbo].[Role] ([ID], [RoleUser]) VALUES (2, N'Клиент')
INSERT [dbo].[Role] ([ID], [RoleUser]) VALUES (3, N'Исполнитель')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([ID], [StatusZayavki]) VALUES (1, N'В ожидании')
INSERT [dbo].[Status] ([ID], [StatusZayavki]) VALUES (2, N'В работе')
INSERT [dbo].[Status] ([ID], [StatusZayavki]) VALUES (3, N'Выполнено')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Login], [Password], [RoleID]) VALUES (1, N'Manager', N'12345', 1)
INSERT [dbo].[Users] ([ID], [Login], [Password], [RoleID]) VALUES (2, N'Client', N'12345', 2)
INSERT [dbo].[Users] ([ID], [Login], [Password], [RoleID]) VALUES (3, N'Ispolnitel', N'12345', 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Zapchast] ON 

INSERT [dbo].[Zapchast] ([ID], [NameZapchact]) VALUES (1, N'Запчасть 1')
INSERT [dbo].[Zapchast] ([ID], [NameZapchact]) VALUES (2, N'Запчасть 2')
INSERT [dbo].[Zapchast] ([ID], [NameZapchact]) VALUES (3, N'Запчасть 3')
SET IDENTITY_INSERT [dbo].[Zapchast] OFF
GO
SET IDENTITY_INSERT [dbo].[Zayavka] ON 

INSERT [dbo].[Zayavka] ([ID], [DataAdd], [OborudID], [TypeNeispID], [OpisanieProblem], [ClientID], [StatusID], [IspolnitelID], [Comment], [Material], [Cost], [ReasonNeisp], [OpisanieHelp], [ZapchastID], [DataEnd], [PhotoPath]) VALUES (2, CAST(N'2019-02-22' AS Date), 1, 1, N'Описание1', 1, 1, 1, N'Комментарий1', N'Материал1', 1000, N'Причина неисправности  1', N'Оказанная помощь 1', 1, CAST(N'2019-02-25' AS Date), N'/Images/1.png')
INSERT [dbo].[Zayavka] ([ID], [DataAdd], [OborudID], [TypeNeispID], [OpisanieProblem], [ClientID], [StatusID], [IspolnitelID], [Comment], [Material], [Cost], [ReasonNeisp], [OpisanieHelp], [ZapchastID], [DataEnd], [PhotoPath]) VALUES (3, CAST(N'2023-08-26' AS Date), 2, 2, N'Описание2', 2, 2, 2, N'Комментарий2', N'Материал2', 1500, N'Причина неисправности  2', N'Оказанная помощь 2', 2, CAST(N'2023-08-29' AS Date), N'/Images/2.png')
INSERT [dbo].[Zayavka] ([ID], [DataAdd], [OborudID], [TypeNeispID], [OpisanieProblem], [ClientID], [StatusID], [IspolnitelID], [Comment], [Material], [Cost], [ReasonNeisp], [OpisanieHelp], [ZapchastID], [DataEnd], [PhotoPath]) VALUES (5, CAST(N'2025-04-11' AS Date), 3, 3, N'Описание3', 3, 2, 3, N'Комментарий3', N'Материал3', 2000, N'Причина неисправности  3', N'Оказанная помощь 3', 3, CAST(N'2025-06-15' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Zayavka] OFF
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role]
GO
ALTER TABLE [dbo].[Zayavka]  WITH CHECK ADD  CONSTRAINT [FK_zayavka_client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ID])
GO
ALTER TABLE [dbo].[Zayavka] CHECK CONSTRAINT [FK_zayavka_client]
GO
ALTER TABLE [dbo].[Zayavka]  WITH CHECK ADD  CONSTRAINT [FK_zayavka_Ispolnitel] FOREIGN KEY([IspolnitelID])
REFERENCES [dbo].[Ispolnitel] ([ID])
GO
ALTER TABLE [dbo].[Zayavka] CHECK CONSTRAINT [FK_zayavka_Ispolnitel]
GO
ALTER TABLE [dbo].[Zayavka]  WITH CHECK ADD  CONSTRAINT [FK_zayavka_neisp] FOREIGN KEY([TypeNeispID])
REFERENCES [dbo].[Neisp] ([ID])
GO
ALTER TABLE [dbo].[Zayavka] CHECK CONSTRAINT [FK_zayavka_neisp]
GO
ALTER TABLE [dbo].[Zayavka]  WITH CHECK ADD  CONSTRAINT [FK_zayavka_oborud] FOREIGN KEY([OborudID])
REFERENCES [dbo].[Oborud] ([ID])
GO
ALTER TABLE [dbo].[Zayavka] CHECK CONSTRAINT [FK_zayavka_oborud]
GO
ALTER TABLE [dbo].[Zayavka]  WITH CHECK ADD  CONSTRAINT [FK_zayavka_status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([ID])
GO
ALTER TABLE [dbo].[Zayavka] CHECK CONSTRAINT [FK_zayavka_status]
GO
ALTER TABLE [dbo].[Zayavka]  WITH CHECK ADD  CONSTRAINT [FK_Zayavka_Zapchast] FOREIGN KEY([ZapchastID])
REFERENCES [dbo].[Zapchast] ([ID])
GO
ALTER TABLE [dbo].[Zayavka] CHECK CONSTRAINT [FK_Zayavka_Zapchast]
GO
USE [master]
GO
ALTER DATABASE [uchet_zayavok] SET  READ_WRITE 
GO
