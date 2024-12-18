USE [master]
GO
/****** Object:  Database [CRUD]    Script Date: 24.04.2022 21:04:05 ******/
CREATE DATABASE [CRUD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CRUD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CRUD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CRUD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CRUD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CRUD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CRUD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CRUD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CRUD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CRUD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CRUD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CRUD] SET ARITHABORT OFF 
GO
ALTER DATABASE [CRUD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CRUD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CRUD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CRUD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CRUD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CRUD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CRUD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CRUD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CRUD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CRUD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CRUD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CRUD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CRUD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CRUD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CRUD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CRUD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CRUD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CRUD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CRUD] SET  MULTI_USER 
GO
ALTER DATABASE [CRUD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CRUD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CRUD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CRUD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CRUD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CRUD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CRUD] SET QUERY_STORE = OFF
GO
USE [CRUD]
GO
/****** Object:  Table [dbo].[agents]    Script Date: 24.04.2022 21:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[agents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[MiddleName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[DealShare] [int] NULL,
 CONSTRAINT [PK_Realtors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 24.04.2022 21:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[MiddleName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Phone] [int] NULL,
	[Email] [varchar](100) NULL,
 CONSTRAINT [PK_clients_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[agents] ON 

INSERT [dbo].[agents] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (1, N'Фахрутдинов', N'Роман', N'Рубинович', 20)
INSERT [dbo].[agents] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (4, N'Устинов', N'Максим', N'Алексеевич', 40)
INSERT [dbo].[agents] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (7, N'Сысоева', N'Людмила', N'Валентиновна', 45)
INSERT [dbo].[agents] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (9, N'Додонов', N'Илья', N'Геннадьевич', 45)
INSERT [dbo].[agents] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (11, N'Мухтаруллин', N'Руслан', N'Расыхович', 45)
INSERT [dbo].[agents] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (13, N'Мосеева', N'Любовь', N'Александровна', 45)
INSERT [dbo].[agents] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (15, N'Киселев', N'Алексей', N'Геннадьевич', 45)
INSERT [dbo].[agents] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (19, N'Клюйков', N'Евгений', N'Николаевич', 50)
INSERT [dbo].[agents] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (24, N'Жданова', N'Галина', N'Николаевна', 45)
INSERT [dbo].[agents] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (34, N'Басырова', N'Елена', N'Азатовна', 45)
INSERT [dbo].[agents] ([Id], [FirstName], [MiddleName], [LastName], [DealShare]) VALUES (38, N'Швецов', N'Виталий', N'Олегович', 45)
SET IDENTITY_INSERT [dbo].[agents] OFF
GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (2, N'Семенов', N'Евгений ', N'Николаевич', NULL, N'')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (3, N'Денисова', N'Олеся', N'Леонидовна', NULL, N'dummy@email.ru')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (5, N'Сафронов', N'Алексей', N'Вячеславович', NULL, N'client@esoft.tech')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (6, N'Кудряшов', N'Александр', N'Витальевич', 551988, N'')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (8, N'Фёдоров', N'Алексей', N'Николаевич', NULL, N'fedorov@mail.ru')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (10, N'Пелымская', N'Светлана', N'Александровна', NULL, N'')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (12, N'Коновальчик', N'Татьяна', N'Геннадьевна', NULL, N'dummy@email.ru')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (14, N'Молоковская', N'Светлана', N'Михайловна', 898489848, N'')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (16, N'Моторина', N'Анастасия', N'Сергеевна', 895159848, N'')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (17, N'Поспелова', N'Ольга', N'Александровна', NULL, N'angel@mail.ru')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (18, N'Жиляков', N'Владимир', N'Владимирович', 445588, N'445588@email.ru')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (20, N'Ефремов', N'Владислав', N'Николаевич', NULL, N'parampampam@mail.ru')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (21, N'Баль', N'Валентина', N'Сергеевна', NULL, N'')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (22, N'Стрелков', N'Артем', N'Николаевич', NULL, N'test@test.test')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (23, N'Луканин', N'Павел', N'Валерьевич', NULL, N'foo@bar.ru')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (25, N'Шарипова', N'Эльвира', N'Закирчановна', NULL, N'')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (26, N'Фомина', N'Маргарита', N'Николаевна', NULL, N'fomina@email.ru')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (27, N'Кремлев', N'Владислав', N'Юрьевич', 777, N'kremlevvu@gmail.ru')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (28, N'Пономарева', N'Елена', N'Сергеевна', NULL, N'ponomareva@gmail.ru')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (29, N'Шелест', N'Тамара', N'Васильевна', 112, N'')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (30, N'Шарипов', N'Рустам', N'Владимирович', NULL, N'sharipov@yandex.ru')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (31, N'Романов', N'Сергей', N'Федорович', 2, N'')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (32, N'Кручинин', N'Иван', N'Андреевич', NULL, N'kruch@list.ru')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (33, N'Алферов', N'Алексей', N'Николаевич', 688899444, N'')
INSERT [dbo].[clients] ([Id], [FirstName], [MiddleName], [LastName], [Phone], [Email]) VALUES (35, N'Попов ', N'Алексей', N'Николаевич', 489848565, N'popovan@bik.ru')
SET IDENTITY_INSERT [dbo].[clients] OFF
GO
USE [master]
GO
ALTER DATABASE [CRUD] SET  READ_WRITE 
GO
