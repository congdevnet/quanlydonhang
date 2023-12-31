USE [master]
GO
/****** Object:  Database [ManagerShop]    Script Date: 5/16/2023 6:17:23 PM ******/
CREATE DATABASE [ManagerShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ManagerShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ManagerShop.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ManagerShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ManagerShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ManagerShop] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ManagerShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ManagerShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ManagerShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ManagerShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ManagerShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ManagerShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [ManagerShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ManagerShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ManagerShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ManagerShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ManagerShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ManagerShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ManagerShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ManagerShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ManagerShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ManagerShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ManagerShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ManagerShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ManagerShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ManagerShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ManagerShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ManagerShop] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ManagerShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ManagerShop] SET RECOVERY FULL 
GO
ALTER DATABASE [ManagerShop] SET  MULTI_USER 
GO
ALTER DATABASE [ManagerShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ManagerShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ManagerShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ManagerShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ManagerShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ManagerShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ManagerShop', N'ON'
GO
ALTER DATABASE [ManagerShop] SET QUERY_STORE = ON
GO
ALTER DATABASE [ManagerShop] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ManagerShop]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/16/2023 6:17:23 PM ******/
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
/****** Object:  Table [dbo].[AppointmentSchedules]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentSchedules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppointmentDate] [datetime2](7) NULL,
	[Note] [nvarchar](500) NULL,
	[DateCreated] [datetime2](7) NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AppointmentSchedules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassifyProducts]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassifyProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_ClassifyProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerManages]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerManages](
	[Id] [uniqueidentifier] NOT NULL,
	[StaffMKTId] [uniqueidentifier] NULL,
	[StaffSaleId] [uniqueidentifier] NULL,
	[DateAdded] [datetime2](7) NULL,
	[SplitDate] [datetime2](7) NULL,
	[CustomerStatusId] [int] NOT NULL,
	[GroupCustomerId] [int] NOT NULL,
	[CustomerId] [uniqueidentifier] NULL,
	[SplitUserId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_CustomerManages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Address] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[PhoneNumber] [nvarchar](12) NOT NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[Gender] [int] NOT NULL,
	[Note] [nvarchar](500) NULL,
	[Age] [float] NULL,
	[Weight] [float] NULL,
	[City] [int] NULL,
	[District] [int] NULL,
	[ward] [int] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerStatuss]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerStatuss](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_CustomerStatuss] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryAddress]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryAddress](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[City] [int] NOT NULL,
	[District] [int] NOT NULL,
	[Wards] [int] NOT NULL,
	[Address] [nvarchar](256) NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_DeliveryAddress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpenseOrders]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenseOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[IntoMoney] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[TransportFee] [float] NOT NULL,
	[Surcharge] [float] NOT NULL,
	[DeclarePrice] [float] NOT NULL,
	[Prepay] [float] NOT NULL,
	[Payments] [float] NOT NULL,
	[StillOwed] [float] NOT NULL,
 CONSTRAINT [PK_ExpenseOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupCustomers]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupCustomers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_GroupCustomers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManagementCancellations]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagementCancellations](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[DeleteDate] [datetime2](7) NULL,
	[Note] [nvarchar](500) NULL,
 CONSTRAINT [PK_ManagementCancellations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManagementOrderDates]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagementOrderDates](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[ClosingDate] [datetime2](7) NULL,
	[DayShipping] [datetime2](7) NULL,
	[FinishDay] [datetime2](7) NULL,
	[ConfirmationDate] [datetime2](7) NULL,
 CONSTRAINT [PK_ManagementOrderDates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManagementOrders]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagementOrders](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[OrderInfoContentId] [int] NOT NULL,
	[OrderStatusId] [int] NOT NULL,
	[MethodDeliveryId] [int] NOT NULL,
	[OrderSourceId] [int] NOT NULL,
	[SingleTypeId] [int] NOT NULL,
	[Note] [nvarchar](500) NULL,
 CONSTRAINT [PK_ManagementOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManageOrderss]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManageOrderss](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[ApplicationDate] [datetime2](7) NULL,
	[IsOrderActive] [bit] NOT NULL,
 CONSTRAINT [PK_ManageOrderss] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MethodDeliverys]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MethodDeliverys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_MethodDeliverys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderInfoContents]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderInfoContents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_OrderInfoContents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetime2](7) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderSources]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderSources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[IsCheck] [bit] NOT NULL,
 CONSTRAINT [PK_OrderSources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatuss]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatuss](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Number] [int] NULL,
 CONSTRAINT [PK_OrderStatuss] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOrders]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOrders](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Quantity] [float] NOT NULL,
 CONSTRAINT [PK_ProductOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[ProductCode] [nvarchar](256) NOT NULL,
	[Quanlity] [float] NOT NULL,
	[InventoryNumber] [float] NOT NULL,
	[Barcode] [nvarchar](50) NOT NULL,
	[ProductName] [nvarchar](256) NOT NULL,
	[Price] [float] NOT NULL,
	[InitialPrice] [float] NULL,
	[Mass] [float] NOT NULL,
	[Picture] [nvarchar](256) NOT NULL,
	[DateCreated] [datetime2](7) NULL,
	[Expired] [datetime2](7) NULL,
	[UnitId] [int] NOT NULL,
	[StatusProductId] [int] NOT NULL,
	[ClassifyProductId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaim]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SingleTypes]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SingleTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_SingleTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusProducts]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_StatusProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupCode] [nvarchar](256) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Address] [nvarchar](256) NOT NULL,
	[Phone] [nvarchar](12) NOT NULL,
	[City] [int] NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Units]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Units](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaim]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Sex] [bit] NOT NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[Address] [nvarchar](max) NOT NULL,
	[CityId] [int] NOT NULL,
	[Skype] [nvarchar](max) NOT NULL,
	[Avartar] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime2](7) NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserToken]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserToken](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserToken] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouses]    Script Date: 5/16/2023 6:17:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Warehouses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230512213616_Innitdata', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230512214042_Innitdata1', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230512233225_Innitdata2', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230513100932_Updata', N'7.0.4')
GO
SET IDENTITY_INSERT [dbo].[ClassifyProducts] ON 

INSERT [dbo].[ClassifyProducts] ([Id], [Name]) VALUES (1, N'Áo')
INSERT [dbo].[ClassifyProducts] ([Id], [Name]) VALUES (2, N'Quần')
INSERT [dbo].[ClassifyProducts] ([Id], [Name]) VALUES (3, N'Balo')
INSERT [dbo].[ClassifyProducts] ([Id], [Name]) VALUES (4, N'Giầy')
INSERT [dbo].[ClassifyProducts] ([Id], [Name]) VALUES (5, N'Váy')
SET IDENTITY_INSERT [dbo].[ClassifyProducts] OFF
GO
INSERT [dbo].[CustomerManages] ([Id], [StaffMKTId], [StaffSaleId], [DateAdded], [SplitDate], [CustomerStatusId], [GroupCustomerId], [CustomerId], [SplitUserId]) VALUES (N'd92974b5-c9fb-426f-b695-08db5335893f', N'40a76602-1634-4d58-8e74-522d40e7f524', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-05-13T05:09:20.4059787' AS DateTime2), CAST(N'2023-05-13T05:09:20.4058940' AS DateTime2), 1, 1, N'98032352-5c09-4cc9-498b-08db53358934', NULL)
INSERT [dbo].[CustomerManages] ([Id], [StaffMKTId], [StaffSaleId], [DateAdded], [SplitDate], [CustomerStatusId], [GroupCustomerId], [CustomerId], [SplitUserId]) VALUES (N'bab8424e-8f47-47b2-b696-08db5335893f', N'40a76602-1634-4d58-8e74-522d40e7f524', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-05-13T05:09:35.4184546' AS DateTime2), CAST(N'2023-05-13T05:09:35.4184538' AS DateTime2), 1, 1, N'4805a808-25b7-46db-498c-08db53358934', NULL)
INSERT [dbo].[CustomerManages] ([Id], [StaffMKTId], [StaffSaleId], [DateAdded], [SplitDate], [CustomerStatusId], [GroupCustomerId], [CustomerId], [SplitUserId]) VALUES (N'773cd717-d87b-41d0-b697-08db5335893f', N'40a76602-1634-4d58-8e74-522d40e7f524', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-05-13T05:09:40.4893957' AS DateTime2), CAST(N'2023-05-13T05:09:40.4893953' AS DateTime2), 1, 1, N'601d7889-5b21-4680-498d-08db53358934', NULL)
INSERT [dbo].[CustomerManages] ([Id], [StaffMKTId], [StaffSaleId], [DateAdded], [SplitDate], [CustomerStatusId], [GroupCustomerId], [CustomerId], [SplitUserId]) VALUES (N'c4bd37f7-1bb5-4851-b698-08db5335893f', N'40a76602-1634-4d58-8e74-522d40e7f524', N'e48e4bfc-c4e7-4346-a306-8c455d1241e3', CAST(N'2023-05-13T05:09:43.5826552' AS DateTime2), CAST(N'2023-05-13T05:09:43.5826549' AS DateTime2), 6, 1, N'f5d32fed-4c30-4fc8-498e-08db53358934', NULL)
INSERT [dbo].[CustomerManages] ([Id], [StaffMKTId], [StaffSaleId], [DateAdded], [SplitDate], [CustomerStatusId], [GroupCustomerId], [CustomerId], [SplitUserId]) VALUES (N'7132ea5d-8ea2-481c-b699-08db5335893f', N'40a76602-1634-4d58-8e74-522d40e7f524', N'e48e4bfc-c4e7-4346-a306-8c455d1241e3', CAST(N'2023-05-13T05:09:47.0390181' AS DateTime2), CAST(N'2023-05-13T05:09:47.0390176' AS DateTime2), 6, 1, N'b2acde80-b820-4da3-498f-08db53358934', NULL)
INSERT [dbo].[CustomerManages] ([Id], [StaffMKTId], [StaffSaleId], [DateAdded], [SplitDate], [CustomerStatusId], [GroupCustomerId], [CustomerId], [SplitUserId]) VALUES (N'c6269ff3-a3de-47ab-d0ca-08db55a0a387', N'40a76602-1634-4d58-8e74-522d40e7f524', N'00000000-0000-0000-0000-000000000000', CAST(N'2023-05-16T07:01:02.9743179' AS DateTime2), CAST(N'2023-05-16T07:01:02.9742345' AS DateTime2), 6, 1, N'bf6b2a3f-4fc0-4083-484a-08db55a0a37a', NULL)
GO
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Email], [PhoneNumber], [DateOfBirth], [Gender], [Note], [Age], [Weight], [City], [District], [ward]) VALUES (N'98032352-5c09-4cc9-498b-08db53358934', N'Bùi Xuân Huấn', NULL, N'', N'0369784521', NULL, 0, N'', 0, 0, -2147483648, -2147483648, -2147483648)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Email], [PhoneNumber], [DateOfBirth], [Gender], [Note], [Age], [Weight], [City], [District], [ward]) VALUES (N'4805a808-25b7-46db-498c-08db53358934', NULL, NULL, N'', N'0369784528', NULL, 0, N'', 0, 0, -2147483648, -2147483648, -2147483648)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Email], [PhoneNumber], [DateOfBirth], [Gender], [Note], [Age], [Weight], [City], [District], [ward]) VALUES (N'601d7889-5b21-4680-498d-08db53358934', NULL, NULL, N'', N'0959784528', NULL, 0, N'', 0, 0, -2147483648, -2147483648, -2147483648)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Email], [PhoneNumber], [DateOfBirth], [Gender], [Note], [Age], [Weight], [City], [District], [ward]) VALUES (N'f5d32fed-4c30-4fc8-498e-08db53358934', N'Nguyễn Lan Anh', N'Số 20', N'lanAnh123@gmail.com', N'0369784585', CAST(N'2000-06-15T00:00:00.0000000' AS DateTime2), 0, N'', 20, 30, 12, 107, 3436)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Email], [PhoneNumber], [DateOfBirth], [Gender], [Note], [Age], [Weight], [City], [District], [ward]) VALUES (N'b2acde80-b820-4da3-498f-08db53358934', N'Bùi Xuân Huấn', N'Số 15', N'xuankhanh28@gmail.com', N'0959784530', CAST(N'1984-06-28T00:00:00.0000000' AS DateTime2), 0, N'', 50, 30, 30, 300, 11254)
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Email], [PhoneNumber], [DateOfBirth], [Gender], [Note], [Age], [Weight], [City], [District], [ward]) VALUES (N'bf6b2a3f-4fc0-4083-484a-08db55a0a37a', N'Nguyễn Lan Anh Vân', N'Số 20', N'lanAnh1234@gmail.com', N'0987456125', CAST(N'1989-06-29T00:00:00.0000000' AS DateTime2), 1, N'', 20, 50, 15, 133, 4282)
GO
SET IDENTITY_INSERT [dbo].[CustomerStatuss] ON 

INSERT [dbo].[CustomerStatuss] ([Id], [Name]) VALUES (1, N'Mới nhập')
INSERT [dbo].[CustomerStatuss] ([Id], [Name]) VALUES (2, N'Tiếp nhận')
INSERT [dbo].[CustomerStatuss] ([Id], [Name]) VALUES (3, N'Tư vấn')
INSERT [dbo].[CustomerStatuss] ([Id], [Name]) VALUES (4, N'Không nghe máy')
INSERT [dbo].[CustomerStatuss] ([Id], [Name]) VALUES (5, N'Đã chăm sóc')
INSERT [dbo].[CustomerStatuss] ([Id], [Name]) VALUES (6, N'Đặt hàng')
INSERT [dbo].[CustomerStatuss] ([Id], [Name]) VALUES (7, N'Không đặt hàng')
SET IDENTITY_INSERT [dbo].[CustomerStatuss] OFF
GO
SET IDENTITY_INSERT [dbo].[DeliveryAddress] ON 

INSERT [dbo].[DeliveryAddress] ([Id], [Name], [City], [District], [Wards], [Address], [IsDefault]) VALUES (1, N'Công ty Sông Công', 1, 1, 1, N'Số 15', 1)
SET IDENTITY_INSERT [dbo].[DeliveryAddress] OFF
GO
SET IDENTITY_INSERT [dbo].[ExpenseOrders] ON 

INSERT [dbo].[ExpenseOrders] ([Id], [OrderId], [IntoMoney], [Discount], [TransportFee], [Surcharge], [DeclarePrice], [Prepay], [Payments], [StillOwed]) VALUES (4, N'3c418147-b87c-43ea-98e7-bf38fb56e43b', 600000, 5, 50000, 0, 0, 615000, 620000, 5000)
INSERT [dbo].[ExpenseOrders] ([Id], [OrderId], [IntoMoney], [Discount], [TransportFee], [Surcharge], [DeclarePrice], [Prepay], [Payments], [StillOwed]) VALUES (28, N'36e34b78-1120-4859-aaf8-fee3de3d5ed0', 1150000, 5, 68000, 0, 0, 733000, 1160500, 427500)
INSERT [dbo].[ExpenseOrders] ([Id], [OrderId], [IntoMoney], [Discount], [TransportFee], [Surcharge], [DeclarePrice], [Prepay], [Payments], [StillOwed]) VALUES (29, N'55e6f95d-b05d-4a4d-a403-74a7d601a570', 1050000, 5, 85000, 0, 0, 1082000, 1082500, 500)
SET IDENTITY_INSERT [dbo].[ExpenseOrders] OFF
GO
SET IDENTITY_INSERT [dbo].[GroupCustomers] ON 

INSERT [dbo].[GroupCustomers] ([Id], [Name]) VALUES (1, N'Khách lẻ')
INSERT [dbo].[GroupCustomers] ([Id], [Name]) VALUES (2, N'Khách vip')
INSERT [dbo].[GroupCustomers] ([Id], [Name]) VALUES (3, N'Khách buôn')
INSERT [dbo].[GroupCustomers] ([Id], [Name]) VALUES (4, N'Khách cũ')
INSERT [dbo].[GroupCustomers] ([Id], [Name]) VALUES (5, N'Khách quen')
SET IDENTITY_INSERT [dbo].[GroupCustomers] OFF
GO
INSERT [dbo].[ManagementOrderDates] ([Id], [OrderId], [ClosingDate], [DayShipping], [FinishDay], [ConfirmationDate]) VALUES (N'7c88e4ab-6091-4e6b-a4d0-72252bac2d2e', N'36e34b78-1120-4859-aaf8-fee3de3d5ed0', CAST(N'2023-05-16T05:22:28.6317782' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[ManagementOrderDates] ([Id], [OrderId], [ClosingDate], [DayShipping], [FinishDay], [ConfirmationDate]) VALUES (N'6ed00190-309c-40ee-addd-f3726faaadf7', N'3c418147-b87c-43ea-98e7-bf38fb56e43b', CAST(N'2023-05-13T22:01:30.0840194' AS DateTime2), NULL, NULL, NULL)
GO
INSERT [dbo].[ManagementOrders] ([Id], [OrderId], [OrderInfoContentId], [OrderStatusId], [MethodDeliveryId], [OrderSourceId], [SingleTypeId], [Note]) VALUES (N'57e73e16-184d-4de1-ef38-08db53c2eef0', N'3c418147-b87c-43ea-98e7-bf38fb56e43b', 1, 3, 1, 4, 1, N'Chuyển càng sớm càng tốt')
INSERT [dbo].[ManagementOrders] ([Id], [OrderId], [OrderInfoContentId], [OrderStatusId], [MethodDeliveryId], [OrderSourceId], [SingleTypeId], [Note]) VALUES (N'7846ed59-71df-4727-f8eb-08db5592b753', N'36e34b78-1120-4859-aaf8-fee3de3d5ed0', 1, 3, 1, 4, 1, NULL)
INSERT [dbo].[ManagementOrders] ([Id], [OrderId], [OrderInfoContentId], [OrderStatusId], [MethodDeliveryId], [OrderSourceId], [SingleTypeId], [Note]) VALUES (N'10267763-4f60-452b-f977-08db55a0e3e1', N'55e6f95d-b05d-4a4d-a403-74a7d601a570', 1, 1, 1, 1, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[ManageOrderss] ON 

INSERT [dbo].[ManageOrderss] ([Id], [OrderId], [CustomerId], [ApplicationDate], [IsOrderActive]) VALUES (12, N'3c418147-b87c-43ea-98e7-bf38fb56e43b', N'b2acde80-b820-4da3-498f-08db53358934', CAST(N'2023-05-13T22:00:28.1887995' AS DateTime2), 1)
INSERT [dbo].[ManageOrderss] ([Id], [OrderId], [CustomerId], [ApplicationDate], [IsOrderActive]) VALUES (13, N'36e34b78-1120-4859-aaf8-fee3de3d5ed0', N'f5d32fed-4c30-4fc8-498e-08db53358934', CAST(N'2023-05-14T12:07:02.1243990' AS DateTime2), 1)
INSERT [dbo].[ManageOrderss] ([Id], [OrderId], [CustomerId], [ApplicationDate], [IsOrderActive]) VALUES (14, N'55e6f95d-b05d-4a4d-a403-74a7d601a570', N'bf6b2a3f-4fc0-4083-484a-08db55a0a37a', CAST(N'2023-05-16T07:01:19.9524299' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[ManageOrderss] OFF
GO
SET IDENTITY_INSERT [dbo].[MethodDeliverys] ON 

INSERT [dbo].[MethodDeliverys] ([Id], [Name]) VALUES (1, N'Chuyển phát thường')
INSERT [dbo].[MethodDeliverys] ([Id], [Name]) VALUES (2, N'Chuyển phát nhanh')
INSERT [dbo].[MethodDeliverys] ([Id], [Name]) VALUES (3, N'Chuyển qua bưu điện')
SET IDENTITY_INSERT [dbo].[MethodDeliverys] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderInfoContents] ON 

INSERT [dbo].[OrderInfoContents] ([Id], [Name]) VALUES (1, N'CSKH')
INSERT [dbo].[OrderInfoContents] ([Id], [Name]) VALUES (2, N'Chăm sóc lần 1')
INSERT [dbo].[OrderInfoContents] ([Id], [Name]) VALUES (3, N'Chăm sóc lần 2')
SET IDENTITY_INSERT [dbo].[OrderInfoContents] OFF
GO
INSERT [dbo].[Orders] ([Id], [DateCreated], [UserId]) VALUES (N'55e6f95d-b05d-4a4d-a403-74a7d601a570', CAST(N'2023-05-16T07:01:19.9021659' AS DateTime2), N'40a76602-1634-4d58-8e74-522d40e7f524')
INSERT [dbo].[Orders] ([Id], [DateCreated], [UserId]) VALUES (N'3c418147-b87c-43ea-98e7-bf38fb56e43b', CAST(N'2023-05-13T22:00:27.9113153' AS DateTime2), N'40a76602-1634-4d58-8e74-522d40e7f524')
INSERT [dbo].[Orders] ([Id], [DateCreated], [UserId]) VALUES (N'36e34b78-1120-4859-aaf8-fee3de3d5ed0', CAST(N'2023-05-14T12:07:02.0457521' AS DateTime2), N'40a76602-1634-4d58-8e74-522d40e7f524')
GO
SET IDENTITY_INSERT [dbo].[OrderSources] ON 

INSERT [dbo].[OrderSources] ([Id], [Name], [IsCheck]) VALUES (1, N'Giới thiệu', 1)
INSERT [dbo].[OrderSources] ([Id], [Name], [IsCheck]) VALUES (2, N'Facebook', 1)
INSERT [dbo].[OrderSources] ([Id], [Name], [IsCheck]) VALUES (3, N'Zalo', 1)
INSERT [dbo].[OrderSources] ([Id], [Name], [IsCheck]) VALUES (4, N'Tự tìm', 1)
INSERT [dbo].[OrderSources] ([Id], [Name], [IsCheck]) VALUES (6, N'Khách cho', 1)
SET IDENTITY_INSERT [dbo].[OrderSources] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderStatuss] ON 

INSERT [dbo].[OrderStatuss] ([Id], [Name], [Number]) VALUES (1, N'Tiếp nhận', 1)
INSERT [dbo].[OrderStatuss] ([Id], [Name], [Number]) VALUES (2, N'Tư vấn', 2)
INSERT [dbo].[OrderStatuss] ([Id], [Name], [Number]) VALUES (3, N'Đặt hàng', 3)
INSERT [dbo].[OrderStatuss] ([Id], [Name], [Number]) VALUES (4, N'Xác nhận', 4)
INSERT [dbo].[OrderStatuss] ([Id], [Name], [Number]) VALUES (5, N'Chốt đơn', 5)
INSERT [dbo].[OrderStatuss] ([Id], [Name], [Number]) VALUES (6, N'Vận chuyển', 6)
INSERT [dbo].[OrderStatuss] ([Id], [Name], [Number]) VALUES (7, N'Hoàn thành', 7)
INSERT [dbo].[OrderStatuss] ([Id], [Name], [Number]) VALUES (8, N'Hủy', 8)
INSERT [dbo].[OrderStatuss] ([Id], [Name], [Number]) VALUES (9, N'Bom', 9)
SET IDENTITY_INSERT [dbo].[OrderStatuss] OFF
GO
INSERT [dbo].[ProductOrders] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (N'0a831f64-0301-4542-8b74-08db53c2eeeb', N'3c418147-b87c-43ea-98e7-bf38fb56e43b', N'73e73dcb-d3a1-4bf1-9ab6-08db5334fe72', 4)
INSERT [dbo].[ProductOrders] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (N'a2d00877-d0cf-45fb-ad61-16c776249bd6', N'36e34b78-1120-4859-aaf8-fee3de3d5ed0', N'6193d58d-a99d-45dc-9ab5-08db5334fe72', 1)
INSERT [dbo].[ProductOrders] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (N'3ca2a1e3-0c3e-4c6a-a629-3529e0ceedda', N'36e34b78-1120-4859-aaf8-fee3de3d5ed0', N'5afb4fc4-0080-4e90-9ab7-08db5334fe72', 2)
INSERT [dbo].[ProductOrders] ([Id], [OrderId], [ProductId], [Quantity]) VALUES (N'9ae95ed5-8fa1-480a-a7ff-f0492fa09b9e', N'55e6f95d-b05d-4a4d-a403-74a7d601a570', N'800caa78-8bb5-4989-9ab4-08db5334fe72', 3)
GO
INSERT [dbo].[Products] ([Id], [ProductCode], [Quanlity], [InventoryNumber], [Barcode], [ProductName], [Price], [InitialPrice], [Mass], [Picture], [DateCreated], [Expired], [UnitId], [StatusProductId], [ClassifyProductId]) VALUES (N'800caa78-8bb5-4989-9ab4-08db5334fe72', N'SP001', 25, 25, N'125478', N'Áo thun màu đen loại 1', 350000, 300000, 12.9, N'images.jpg', NULL, NULL, 1, 1, 1)
INSERT [dbo].[Products] ([Id], [ProductCode], [Quanlity], [InventoryNumber], [Barcode], [ProductName], [Price], [InitialPrice], [Mass], [Picture], [DateCreated], [Expired], [UnitId], [StatusProductId], [ClassifyProductId]) VALUES (N'6193d58d-a99d-45dc-9ab5-08db5334fe72', N'SP002', 25, 25, N'125479', N'Quần bò thun loại mới 1', 450000, 400000, 10.8, N'quanbo.jpg', NULL, NULL, 1, 1, 2)
INSERT [dbo].[Products] ([Id], [ProductCode], [Quanlity], [InventoryNumber], [Barcode], [ProductName], [Price], [InitialPrice], [Mass], [Picture], [DateCreated], [Expired], [UnitId], [StatusProductId], [ClassifyProductId]) VALUES (N'73e73dcb-d3a1-4bf1-9ab6-08db5334fe72', N'SP003', 35, 35, N'125410', N'Balo đẹp 1', 150000, 120000, 15, N'balo1.jpg', NULL, NULL, 1, 1, 3)
INSERT [dbo].[Products] ([Id], [ProductCode], [Quanlity], [InventoryNumber], [Barcode], [ProductName], [Price], [InitialPrice], [Mass], [Picture], [DateCreated], [Expired], [UnitId], [StatusProductId], [ClassifyProductId]) VALUES (N'5afb4fc4-0080-4e90-9ab7-08db5334fe72', N'SP004', 20, 20, N'456123', N'Balo mới 1', 350000, 300000, 15.5, N'balo2.jpg', NULL, NULL, 1, 1, 3)
INSERT [dbo].[Products] ([Id], [ProductCode], [Quanlity], [InventoryNumber], [Barcode], [ProductName], [Price], [InitialPrice], [Mass], [Picture], [DateCreated], [Expired], [UnitId], [StatusProductId], [ClassifyProductId]) VALUES (N'2d21a071-0f4b-42a0-9ab8-08db5334fe72', N'SP005', 30, 30, N'456124', N'Váy vàng đẹp 1', 150000, 145000, 10, N'vay12.jpg', NULL, NULL, 1, 1, 5)
INSERT [dbo].[Products] ([Id], [ProductCode], [Quanlity], [InventoryNumber], [Barcode], [ProductName], [Price], [InitialPrice], [Mass], [Picture], [DateCreated], [Expired], [UnitId], [StatusProductId], [ClassifyProductId]) VALUES (N'b5cbbad0-f582-483b-9ab9-08db5334fe72', N'SP006', 20, 20, N'456127', N'Váy đỏ đẹp 1', 200000, 100000, 18, N'vay13.jpg', NULL, NULL, 1, 1, 5)
GO
INSERT [dbo].[Roles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'eaa7d4c6-f51e-4e0e-88b4-556f3550afa8', N'Quản trị viên', N'Admin', NULL, N'32a644dc-6649-40d0-b9b4-de34361a0692')
INSERT [dbo].[Roles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'fd106bef-1b44-44c5-91d5-ca250da233dc', N'Nhân viên Sale', N'Sale', NULL, N'7d4a8547-f077-47cf-a1d9-ff4dfa044aea')
INSERT [dbo].[Roles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'8681b0e2-e6fd-4c8b-8977-de04987f80ba', N'Quản lý MKT', N'MgMKT', NULL, N'5f95bd84-ce00-48e1-974c-0b61238ab838')
INSERT [dbo].[Roles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bc861e4d-6504-4f65-a4cf-e2d3f60d6a1f', N'Nhân viên MKT', N'MKT', NULL, N'03ffd3e8-3caa-4b69-bc2d-84708b4e4cab')
GO
SET IDENTITY_INSERT [dbo].[SingleTypes] ON 

INSERT [dbo].[SingleTypes] ([Id], [Name]) VALUES (1, N'Tạo tay')
INSERT [dbo].[SingleTypes] ([Id], [Name]) VALUES (2, N'Facebook')
INSERT [dbo].[SingleTypes] ([Id], [Name]) VALUES (3, N'ZaLo')
SET IDENTITY_INSERT [dbo].[SingleTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[StatusProducts] ON 

INSERT [dbo].[StatusProducts] ([Id], [Name]) VALUES (1, N'Kinh doanh')
INSERT [dbo].[StatusProducts] ([Id], [Name]) VALUES (2, N'Không kinh doanh')
SET IDENTITY_INSERT [dbo].[StatusProducts] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([Id], [SupCode], [Name], [Address], [Phone], [City]) VALUES (1, N'CT001', N'Công ty Sông Công', N'Cầu Giấy-Mai Dịch- Hà Nội', N'0369123456', 1)
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET IDENTITY_INSERT [dbo].[Units] ON 

INSERT [dbo].[Units] ([Id], [Name]) VALUES (1, N'g')
INSERT [dbo].[Units] ([Id], [Name]) VALUES (2, N'kg')
INSERT [dbo].[Units] ([Id], [Name]) VALUES (3, N'l')
INSERT [dbo].[Units] ([Id], [Name]) VALUES (4, N'm2')
INSERT [dbo].[Units] ([Id], [Name]) VALUES (5, N'm3')
SET IDENTITY_INSERT [dbo].[Units] OFF
GO
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (N'37dc78be-5899-4092-9f31-7c336837a531', N'eaa7d4c6-f51e-4e0e-88b4-556f3550afa8')
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (N'e48e4bfc-c4e7-4346-a306-8c455d1241e3', N'fd106bef-1b44-44c5-91d5-ca250da233dc')
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (N'00000000-0000-0000-0000-000000000000', N'8681b0e2-e6fd-4c8b-8977-de04987f80ba')
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (N'40a76602-1634-4d58-8e74-522d40e7f524', N'bc861e4d-6504-4f65-a4cf-e2d3f60d6a1f')
GO
INSERT [dbo].[Users] ([Id], [FullName], [Sex], [DateOfBirth], [Address], [CityId], [Skype], [Avartar], [DateCreated], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'40a76602-1634-4d58-8e74-522d40e7f524', N'Đặng Xuân MKT', 0, CAST(N'2023-05-13T17:09:32.0913627' AS DateTime2), N'MKT123', 1, N'', N'', CAST(N'2023-05-13T17:09:32.0913626' AS DateTime2), N'MKT123', N'MKT123', N'NhanvienMKT@gmail.com', N'MKT123@gmail.com', 1, N'AQAAAAEAACcQAAAAEJd1IwUWvPlTBT1cjRSJLEGOBUQTBjMslvaRv+EB3Kg5Yz7yqvKIf1rBagAMwfjh/A==', N'', N'4d282f73-3ef7-4bc5-8369-ad4bee945442', N'0369852145', 0, 0, NULL, 0, 0)
INSERT [dbo].[Users] ([Id], [FullName], [Sex], [DateOfBirth], [Address], [CityId], [Skype], [Avartar], [DateCreated], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'37dc78be-5899-4092-9f31-7c336837a531', N'Admin', 0, CAST(N'2023-05-13T17:09:32.0680643' AS DateTime2), N'Admin', 1, N'', N'', CAST(N'2023-05-13T17:09:32.0680641' AS DateTime2), N'Admin', N'Admin', N'Admin123@gmail.com', N'Admin123@gmail.com', 1, N'AQAAAAEAACcQAAAAENGQ8RdewAm886XbtxmIU4nlbyRQJCbvfXiabwu6ZurCl/q//q8SMnc8aGmsXteqJw==', N'', N'3e1bcb50-824b-4c90-832a-1b778902864b', N'0369852147', 0, 0, NULL, 0, 0)
INSERT [dbo].[Users] ([Id], [FullName], [Sex], [DateOfBirth], [Address], [CityId], [Skype], [Avartar], [DateCreated], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e48e4bfc-c4e7-4346-a306-8c455d1241e3', N'Bùi Xuân Sale', 0, CAST(N'2023-05-13T17:09:32.0808389' AS DateTime2), N'Sale123', 1, N'', N'', CAST(N'2023-05-13T17:09:32.0808386' AS DateTime2), N'Sale123', N'Sale123', N'NhanvienSale@gmail.com', N'Sale123@gmail.com', 1, N'AQAAAAEAACcQAAAAEIoJsLprSDBF3TKC8WnAgEu28tiZnzl79N+a0UMG+F7Q1rrHNMZDtbSARHHPc+gu2g==', N'', N'38847d3e-185d-4c4d-9015-80015f119307', N'0369852114', 0, 0, NULL, 0, 0)
INSERT [dbo].[Users] ([Id], [FullName], [Sex], [DateOfBirth], [Address], [CityId], [Skype], [Avartar], [DateCreated], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8e2027cb-cec4-40d9-9d53-f7e28483d3cb', N'Trần Văn Phường', 0, CAST(N'2023-05-13T17:09:32.1042253' AS DateTime2), N'MGMKT123', 1, N'', N'', CAST(N'2023-05-13T17:09:32.1042251' AS DateTime2), N'MGMKT123', N'MGMKT123', N'QuanlynhanvienMKT@gmail.com', N'MKT123@gmail.com', 1, N'AQAAAAEAACcQAAAAEIMe+oo5+SWEgzpUQ2MCsni3rBIAFrH0rRZa+729skKeQt2/6oQ2l4HYR7vVWQPKwg==', N'', N'b4e23d96-5efd-47c0-9b00-4d929a636df0', N'0369852150', 0, 0, NULL, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Warehouses] ON 

INSERT [dbo].[Warehouses] ([Id], [Name]) VALUES (1, N'Kho tổng')
INSERT [dbo].[Warehouses] ([Id], [Name]) VALUES (2, N'Kho cấp 1')
INSERT [dbo].[Warehouses] ([Id], [Name]) VALUES (3, N'Kho cấp 2')
SET IDENTITY_INSERT [dbo].[Warehouses] OFF
GO
/****** Object:  Index [IX_AppointmentSchedules_CustomerId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_AppointmentSchedules_CustomerId] ON [dbo].[AppointmentSchedules]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CustomerManages_CustomerId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_CustomerManages_CustomerId] ON [dbo].[CustomerManages]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CustomerManages_CustomerStatusId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_CustomerManages_CustomerStatusId] ON [dbo].[CustomerManages]
(
	[CustomerStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CustomerManages_GroupCustomerId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_CustomerManages_GroupCustomerId] ON [dbo].[CustomerManages]
(
	[GroupCustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExpenseOrders_OrderId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ExpenseOrders_OrderId] ON [dbo].[ExpenseOrders]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ManagementCancellations_OrderId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ManagementCancellations_OrderId] ON [dbo].[ManagementCancellations]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ManagementOrderDates_OrderId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ManagementOrderDates_OrderId] ON [dbo].[ManagementOrderDates]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ManagementOrders_MethodDeliveryId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ManagementOrders_MethodDeliveryId] ON [dbo].[ManagementOrders]
(
	[MethodDeliveryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ManagementOrders_OrderId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ManagementOrders_OrderId] ON [dbo].[ManagementOrders]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ManagementOrders_OrderInfoContentId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ManagementOrders_OrderInfoContentId] ON [dbo].[ManagementOrders]
(
	[OrderInfoContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ManagementOrders_OrderSourceId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ManagementOrders_OrderSourceId] ON [dbo].[ManagementOrders]
(
	[OrderSourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ManagementOrders_OrderStatusId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ManagementOrders_OrderStatusId] ON [dbo].[ManagementOrders]
(
	[OrderStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ManagementOrders_SingleTypeId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ManagementOrders_SingleTypeId] ON [dbo].[ManagementOrders]
(
	[SingleTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ManageOrderss_CustomerId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ManageOrderss_CustomerId] ON [dbo].[ManageOrderss]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ManageOrderss_OrderId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ManageOrderss_OrderId] ON [dbo].[ManageOrderss]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_UserId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_UserId] ON [dbo].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductOrders_OrderId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductOrders_OrderId] ON [dbo].[ProductOrders]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductOrders_ProductId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductOrders_ProductId] ON [dbo].[ProductOrders]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_ClassifyProductId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_ClassifyProductId] ON [dbo].[Products]
(
	[ClassifyProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_StatusProductId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_StatusProductId] ON [dbo].[Products]
(
	[StatusProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_UnitId]    Script Date: 5/16/2023 6:17:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_UnitId] ON [dbo].[Products]
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ManageOrderss] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsOrderActive]
GO
ALTER TABLE [dbo].[AppointmentSchedules]  WITH CHECK ADD  CONSTRAINT [FK_AppointmentSchedules_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AppointmentSchedules] CHECK CONSTRAINT [FK_AppointmentSchedules_Customers_CustomerId]
GO
ALTER TABLE [dbo].[CustomerManages]  WITH CHECK ADD  CONSTRAINT [FK_CustomerManages_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[CustomerManages] CHECK CONSTRAINT [FK_CustomerManages_Customers_CustomerId]
GO
ALTER TABLE [dbo].[CustomerManages]  WITH CHECK ADD  CONSTRAINT [FK_CustomerManages_CustomerStatuss_CustomerStatusId] FOREIGN KEY([CustomerStatusId])
REFERENCES [dbo].[CustomerStatuss] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomerManages] CHECK CONSTRAINT [FK_CustomerManages_CustomerStatuss_CustomerStatusId]
GO
ALTER TABLE [dbo].[CustomerManages]  WITH CHECK ADD  CONSTRAINT [FK_CustomerManages_GroupCustomers_GroupCustomerId] FOREIGN KEY([GroupCustomerId])
REFERENCES [dbo].[GroupCustomers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomerManages] CHECK CONSTRAINT [FK_CustomerManages_GroupCustomers_GroupCustomerId]
GO
ALTER TABLE [dbo].[ExpenseOrders]  WITH CHECK ADD  CONSTRAINT [FK_ExpenseOrders_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExpenseOrders] CHECK CONSTRAINT [FK_ExpenseOrders_Orders_OrderId]
GO
ALTER TABLE [dbo].[ManagementCancellations]  WITH CHECK ADD  CONSTRAINT [FK_ManagementCancellations_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManagementCancellations] CHECK CONSTRAINT [FK_ManagementCancellations_Orders_OrderId]
GO
ALTER TABLE [dbo].[ManagementOrderDates]  WITH CHECK ADD  CONSTRAINT [FK_ManagementOrderDates_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManagementOrderDates] CHECK CONSTRAINT [FK_ManagementOrderDates_Orders_OrderId]
GO
ALTER TABLE [dbo].[ManagementOrders]  WITH CHECK ADD  CONSTRAINT [FK_ManagementOrders_MethodDeliverys_MethodDeliveryId] FOREIGN KEY([MethodDeliveryId])
REFERENCES [dbo].[MethodDeliverys] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManagementOrders] CHECK CONSTRAINT [FK_ManagementOrders_MethodDeliverys_MethodDeliveryId]
GO
ALTER TABLE [dbo].[ManagementOrders]  WITH CHECK ADD  CONSTRAINT [FK_ManagementOrders_OrderInfoContents_OrderInfoContentId] FOREIGN KEY([OrderInfoContentId])
REFERENCES [dbo].[OrderInfoContents] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManagementOrders] CHECK CONSTRAINT [FK_ManagementOrders_OrderInfoContents_OrderInfoContentId]
GO
ALTER TABLE [dbo].[ManagementOrders]  WITH CHECK ADD  CONSTRAINT [FK_ManagementOrders_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManagementOrders] CHECK CONSTRAINT [FK_ManagementOrders_Orders_OrderId]
GO
ALTER TABLE [dbo].[ManagementOrders]  WITH CHECK ADD  CONSTRAINT [FK_ManagementOrders_OrderSources_OrderSourceId] FOREIGN KEY([OrderSourceId])
REFERENCES [dbo].[OrderSources] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManagementOrders] CHECK CONSTRAINT [FK_ManagementOrders_OrderSources_OrderSourceId]
GO
ALTER TABLE [dbo].[ManagementOrders]  WITH CHECK ADD  CONSTRAINT [FK_ManagementOrders_OrderStatuss_OrderStatusId] FOREIGN KEY([OrderStatusId])
REFERENCES [dbo].[OrderStatuss] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManagementOrders] CHECK CONSTRAINT [FK_ManagementOrders_OrderStatuss_OrderStatusId]
GO
ALTER TABLE [dbo].[ManagementOrders]  WITH CHECK ADD  CONSTRAINT [FK_ManagementOrders_SingleTypes_SingleTypeId] FOREIGN KEY([SingleTypeId])
REFERENCES [dbo].[SingleTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManagementOrders] CHECK CONSTRAINT [FK_ManagementOrders_SingleTypes_SingleTypeId]
GO
ALTER TABLE [dbo].[ManageOrderss]  WITH CHECK ADD  CONSTRAINT [FK_ManageOrderss_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManageOrderss] CHECK CONSTRAINT [FK_ManageOrderss_Customers_CustomerId]
GO
ALTER TABLE [dbo].[ManageOrderss]  WITH CHECK ADD  CONSTRAINT [FK_ManageOrderss_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ManageOrderss] CHECK CONSTRAINT [FK_ManageOrderss_Orders_OrderId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users_UserId]
GO
ALTER TABLE [dbo].[ProductOrders]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrders_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductOrders] CHECK CONSTRAINT [FK_ProductOrders_Orders_OrderId]
GO
ALTER TABLE [dbo].[ProductOrders]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrders_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductOrders] CHECK CONSTRAINT [FK_ProductOrders_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ClassifyProducts_ClassifyProductId] FOREIGN KEY([ClassifyProductId])
REFERENCES [dbo].[ClassifyProducts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ClassifyProducts_ClassifyProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_StatusProducts_StatusProductId] FOREIGN KEY([StatusProductId])
REFERENCES [dbo].[StatusProducts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_StatusProducts_StatusProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Units_UnitId] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Units] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Units_UnitId]
GO
USE [master]
GO
ALTER DATABASE [ManagerShop] SET  READ_WRITE 
GO
