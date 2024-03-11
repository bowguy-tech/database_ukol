USE [master]
GO
/****** Object:  Database [kremlik]    Script Date: 11-Mar-24 10:30:49 AM ******/
CREATE DATABASE [kremlik]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kremlik', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS2019\MSSQL\DATA\kremlik.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'kremlik_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS2019\MSSQL\DATA\kremlik_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [kremlik] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kremlik].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [kremlik] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [kremlik] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [kremlik] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [kremlik] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [kremlik] SET ARITHABORT OFF 
GO
ALTER DATABASE [kremlik] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [kremlik] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [kremlik] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [kremlik] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [kremlik] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [kremlik] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [kremlik] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [kremlik] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [kremlik] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [kremlik] SET  ENABLE_BROKER 
GO
ALTER DATABASE [kremlik] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [kremlik] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [kremlik] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [kremlik] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [kremlik] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [kremlik] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [kremlik] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [kremlik] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [kremlik] SET  MULTI_USER 
GO
ALTER DATABASE [kremlik] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [kremlik] SET DB_CHAINING OFF 
GO
ALTER DATABASE [kremlik] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [kremlik] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [kremlik] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [kremlik] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [kremlik] SET QUERY_STORE = OFF
GO
USE [kremlik]
GO
/****** Object:  Table [dbo].[adresa]    Script Date: 11-Mar-24 10:30:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adresa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mesto_id] [int] NOT NULL,
	[ulice] [varchar](50) NULL,
	[cislo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11-Mar-24 10:30:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] NOT NULL,
	[CustomerName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mesto]    Script Date: 11-Mar-24 10:30:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mesto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jmeno] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[jmeno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[objednavka]    Script Date: 11-Mar-24 10:30:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[objednavka](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[zakaznik_id] [int] NOT NULL,
	[dorucena] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 11-Mar-24 10:30:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderItemId] [int] NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11-Mar-24 10:30:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[CustomerId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[polozka]    Script Date: 11-Mar-24 10:30:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[polozka](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[objednavka_id] [int] NOT NULL,
	[polozka_id] [int] NOT NULL,
	[pocet_ks] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prodejce]    Script Date: 11-Mar-24 10:30:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prodejce](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adresa_id] [int] NOT NULL,
	[jmeno] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[jmeno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11-Mar-24 10:30:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] NOT NULL,
	[ProductName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 11-Mar-24 10:30:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierId] [int] NOT NULL,
	[SupplierName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[typ_polozky]    Script Date: 11-Mar-24 10:30:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[typ_polozky](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[prodejce_id] [int] NOT NULL,
	[jmeno] [varchar](50) NOT NULL,
	[cena_ks] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zakaznik]    Script Date: 11-Mar-24 10:30:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zakaznik](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adresa_id] [int] NOT NULL,
	[jmeno] [varchar](50) NOT NULL,
	[prijmeni] [varchar](50) NOT NULL,
	[zalozeni] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[adresa]  WITH CHECK ADD FOREIGN KEY([mesto_id])
REFERENCES [dbo].[mesto] ([id])
GO
ALTER TABLE [dbo].[objednavka]  WITH CHECK ADD FOREIGN KEY([zakaznik_id])
REFERENCES [dbo].[zakaznik] ([id])
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[polozka]  WITH CHECK ADD FOREIGN KEY([objednavka_id])
REFERENCES [dbo].[objednavka] ([id])
GO
ALTER TABLE [dbo].[polozka]  WITH CHECK ADD FOREIGN KEY([polozka_id])
REFERENCES [dbo].[typ_polozky] ([id])
GO
ALTER TABLE [dbo].[prodejce]  WITH CHECK ADD FOREIGN KEY([adresa_id])
REFERENCES [dbo].[adresa] ([id])
GO
ALTER TABLE [dbo].[typ_polozky]  WITH CHECK ADD FOREIGN KEY([prodejce_id])
REFERENCES [dbo].[prodejce] ([id])
GO
ALTER TABLE [dbo].[zakaznik]  WITH CHECK ADD FOREIGN KEY([adresa_id])
REFERENCES [dbo].[adresa] ([id])
GO
USE [master]
GO
ALTER DATABASE [kremlik] SET  READ_WRITE 
GO