USE [master]
GO
/****** Object:  Database [Enterprise]    Script Date: 21/02/2024 12:29:38 ******/
CREATE DATABASE [Enterprise]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Enterprise', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Enterprise.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Enterprise_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Enterprise_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Enterprise] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Enterprise].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Enterprise] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Enterprise] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Enterprise] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Enterprise] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Enterprise] SET ARITHABORT OFF 
GO
ALTER DATABASE [Enterprise] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Enterprise] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Enterprise] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Enterprise] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Enterprise] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Enterprise] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Enterprise] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Enterprise] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Enterprise] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Enterprise] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Enterprise] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Enterprise] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Enterprise] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Enterprise] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Enterprise] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Enterprise] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Enterprise] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Enterprise] SET RECOVERY FULL 
GO
ALTER DATABASE [Enterprise] SET  MULTI_USER 
GO
ALTER DATABASE [Enterprise] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Enterprise] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Enterprise] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Enterprise] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Enterprise] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Enterprise] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Enterprise', N'ON'
GO
ALTER DATABASE [Enterprise] SET QUERY_STORE = ON
GO
ALTER DATABASE [Enterprise] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Enterprise]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 21/02/2024 12:29:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Author] [varchar](50) NOT NULL,
	[PublicationDate] [date] NOT NULL,
	[Publisher] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookCategory]    Script Date: 21/02/2024 12:29:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookCategory](
	[BookId] [int] NULL,
	[CategoryId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 21/02/2024 12:29:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21/02/2024 12:29:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Utente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([Id], [Name], [Author], [PublicationDate], [Publisher]) VALUES (1, N'La nascita della Tragedia', N'Friedrich Nietzsche', CAST(N'1872-01-01' AS Date), N'Piccola Biblioteca Adelphi')
INSERT [dbo].[Book] ([Id], [Name], [Author], [PublicationDate], [Publisher]) VALUES (3, N'1984', N'George Orwell', CAST(N'1949-06-08' AS Date), N'Mondadori')
INSERT [dbo].[Book] ([Id], [Name], [Author], [PublicationDate], [Publisher]) VALUES (4, N'Siddharta', N'Hermann Hesse', CAST(N'1922-01-01' AS Date), N'Piccola Biblioteca Adelphi')
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
INSERT [dbo].[BookCategory] ([BookId], [CategoryId]) VALUES (3, 4)
INSERT [dbo].[BookCategory] ([BookId], [CategoryId]) VALUES (3, 1)
INSERT [dbo].[BookCategory] ([BookId], [CategoryId]) VALUES (4, 1)
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (3, N'AutoBiografia')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (4, N'Fantascienza')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Romanzo')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Email], [Name], [Surname], [Password]) VALUES (1, N'edd.katun@gmail.com', N'eduardo', N'tiano', N'password01')
INSERT [dbo].[User] ([Id], [Email], [Name], [Surname], [Password]) VALUES (3, N'ed.katun@gmail.com', N'edu', N'nando', N'asdadasdasdasd')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Unica_Categoria]    Script Date: 21/02/2024 12:29:38 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [Unica_Categoria] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__A9D10534D61DD24D]    Script Date: 21/02/2024 12:29:38 ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BookCategory]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[BookCategory]  WITH CHECK ADD  CONSTRAINT [FK__LibroCate__IdLib__6383C8BA] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BookCategory] CHECK CONSTRAINT [FK__LibroCate__IdLib__6383C8BA]
GO
USE [master]
GO
ALTER DATABASE [Enterprise] SET  READ_WRITE 
GO
