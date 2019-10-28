USE [master]
GO
/****** Object:  Database [QLNH]    Script Date: 10/13/2019 11:48:36 AM ******/
CREATE DATABASE [QLNH]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLNH', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QLNH.mdf' , SIZE = 3136KB , MAXSIZE = 29687808KB , FILEGROWTH = 262144KB )
 LOG ON 
( NAME = N'QLNH_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QLNH_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLNH] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLNH].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLNH] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLNH] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLNH] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLNH] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLNH] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLNH] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLNH] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLNH] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLNH] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLNH] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLNH] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLNH] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLNH] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLNH] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLNH] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLNH] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLNH] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLNH] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLNH] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLNH] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLNH] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLNH] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLNH] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLNH] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLNH] SET  MULTI_USER 
GO
ALTER DATABASE [QLNH] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLNH] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLNH] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLNH] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QLNH]
GO
/****** Object:  Table [dbo].[BanAn]    Script Date: 10/13/2019 11:48:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BanAn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoaiBanAn] [nvarchar](100) NULL,
	[TrangThai] [nvarchar](100) NULL,
	[GhiChu] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 10/13/2019 11:48:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[IdHoaDon] [int] NOT NULL,
	[IdMonAn] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[IdHoaDon] ASC,
	[IdMonAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 10/13/2019 11:48:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdBanAn] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
	[ThoiGianLap] [datetime] NOT NULL,
	[ThanhTien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 10/13/2019 11:48:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NULL,
	[SDT] [int] NULL,
	[DiaChi] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiMonAn]    Script Date: 10/13/2019 11:48:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiMonAn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 10/13/2019 11:48:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NULL,
	[TenDangNhap] [nvarchar](100) NULL,
	[MatKhau] [nvarchar](100) NULL,
	[Role] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuDatBan]    Script Date: 10/13/2019 11:48:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuDatBan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdBanAn] [int] NOT NULL,
	[IdKhachHang] [int] NOT NULL,
	[ThoiGianDat] [datetime] NULL,
	[GhiChu] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThucDon]    Script Date: 10/13/2019 11:48:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThucDon](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdLoaiMonAn] [int] NOT NULL,
	[Ten] [nvarchar](100) NULL,
	[Gia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BanAn] ON 

INSERT [dbo].[BanAn] ([Id], [LoaiBanAn], [TrangThai], [GhiChu]) VALUES (1, N'Bàn 2', N'Trống', NULL)
INSERT [dbo].[BanAn] ([Id], [LoaiBanAn], [TrangThai], [GhiChu]) VALUES (2, N'Bàn 2', N'Trống', NULL)
INSERT [dbo].[BanAn] ([Id], [LoaiBanAn], [TrangThai], [GhiChu]) VALUES (3, N'Bàn 4', N'Trống', NULL)
INSERT [dbo].[BanAn] ([Id], [LoaiBanAn], [TrangThai], [GhiChu]) VALUES (4, N'Bàn 4', N'Trống', NULL)
INSERT [dbo].[BanAn] ([Id], [LoaiBanAn], [TrangThai], [GhiChu]) VALUES (5, N'Bàn 6', N'Trống', NULL)
INSERT [dbo].[BanAn] ([Id], [LoaiBanAn], [TrangThai], [GhiChu]) VALUES (6, N'Bàn 6', N'Trống', NULL)
INSERT [dbo].[BanAn] ([Id], [LoaiBanAn], [TrangThai], [GhiChu]) VALUES (7, N'Bàn 1', N'Trống', NULL)
INSERT [dbo].[BanAn] ([Id], [LoaiBanAn], [TrangThai], [GhiChu]) VALUES (8, N'Bàn 1', N'Trống', NULL)
INSERT [dbo].[BanAn] ([Id], [LoaiBanAn], [TrangThai], [GhiChu]) VALUES (9, N'Bàn 10', N'Trống', NULL)
INSERT [dbo].[BanAn] ([Id], [LoaiBanAn], [TrangThai], [GhiChu]) VALUES (10, N'Bàn 10', N'Trống', NULL)
SET IDENTITY_INSERT [dbo].[BanAn] OFF
SET IDENTITY_INSERT [dbo].[LoaiMonAn] ON 

INSERT [dbo].[LoaiMonAn] ([Id], [Ten]) VALUES (1, N'Hải sản')
INSERT [dbo].[LoaiMonAn] ([Id], [Ten]) VALUES (2, N'Mực')
INSERT [dbo].[LoaiMonAn] ([Id], [Ten]) VALUES (3, N'Cá hồi')
INSERT [dbo].[LoaiMonAn] ([Id], [Ten]) VALUES (4, N'Súp')
INSERT [dbo].[LoaiMonAn] ([Id], [Ten]) VALUES (5, N'Gỏi')
INSERT [dbo].[LoaiMonAn] ([Id], [Ten]) VALUES (6, N'Lẩu các loại')
INSERT [dbo].[LoaiMonAn] ([Id], [Ten]) VALUES (7, N'Món chiên')
INSERT [dbo].[LoaiMonAn] ([Id], [Ten]) VALUES (8, N'Thức uống')
SET IDENTITY_INSERT [dbo].[LoaiMonAn] OFF
SET IDENTITY_INSERT [dbo].[ThucDon] ON 

INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (1, 1, N'Gỏi sứa', 60000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (2, 1, N'Cua rang me', 80000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (3, 1, N'Cua hấp sả', 200000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (4, 1, N'Cua rang muối', 250000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (5, 1, N'Sỏ huyết nướng', 250000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (6, 2, N'Mực xào thập cẩm', 280000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (7, 2, N'Mực chiên bơ', 280000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (8, 2, N'Mực trứng hấp', 180000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (9, 2, N'Mực trứng nướng muối ớt', 180000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (10, 2, N'Mực trứng chiên', 180000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (11, 3, N'Súp cá hồi', 20000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (12, 3, N'Gỏi cá hồi', 250000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (13, 3, N'Cháo cá hồi', 20000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (14, 3, N'Cá hồi nướng', 320000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (15, 3, N'Cá hồi hấp xì dầu', 350000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (17, 3, N'Cá hồi rang muối', 320000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (18, 4, N'Súp cua', 28000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (19, 4, N'Súp bắp cua', 31000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (20, 4, N'Súp tôm', 33000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (21, 4, N'Súp nghêu', 28000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (22, 4, N'Súp hải sản', 39000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (23, 5, N'Gỏi bưởi', 121000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (24, 5, N'Gỏi bò bóp thấu', 110000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (25, 5, N'Gỏi ngó sen tôm thịt', 121000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (26, 5, N'Gỏi khoai môn', 110000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (27, 5, N'Gỏi xoài tôm thịt', 110000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (28, 6, N'Lẩu vịt', 400000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (29, 6, N'Lẩu riêu cua hấp bò', 500000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (30, 6, N'Lẩu bò nhúng dấm', 350000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (31, 6, N'Lẩu thập cẩm', 600000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (32, 6, N'Lẩu ếch măng cay', 400000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (33, 6, N'Lẩu gà rượu vang', 600000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (34, 6, N'Lẩu cá lăng', 500000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (35, 7, N'Chả giò thăng hoa', 50000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (36, 7, N'Khoai lang chiên', 30000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (37, 7, N'Cà tím chiên dòn', 40000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (38, 7, N'Khoai tây chiên', 30000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (39, 7, N'Hoành thánh chiên tứ vị', 50000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (40, 7, N'Nấm bào ngư chiên xù', 40000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (41, 8, N'Nước ngọt các loại', 12000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (42, 8, N'Nước suối', 7000)
INSERT [dbo].[ThucDon] ([Id], [IdLoaiMonAn], [Ten], [Gia]) VALUES (43, 8, N'Bia các loại', 15000)
SET IDENTITY_INSERT [dbo].[ThucDon] OFF
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([IdHoaDon])
REFERENCES [dbo].[HoaDon] ([Id])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_ThucDon] FOREIGN KEY([IdMonAn])
REFERENCES [dbo].[ThucDon] ([Id])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_ThucDon]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_BanAn] FOREIGN KEY([IdBanAn])
REFERENCES [dbo].[BanAn] ([Id])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_BanAn]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[NguoiDung] ([Id])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_User]
GO
ALTER TABLE [dbo].[PhieuDatBan]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDatBan_BanAn] FOREIGN KEY([IdBanAn])
REFERENCES [dbo].[BanAn] ([Id])
GO
ALTER TABLE [dbo].[PhieuDatBan] CHECK CONSTRAINT [FK_PhieuDatBan_BanAn]
GO
ALTER TABLE [dbo].[PhieuDatBan]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDatBan_KhachHang] FOREIGN KEY([IdKhachHang])
REFERENCES [dbo].[KhachHang] ([Id])
GO
ALTER TABLE [dbo].[PhieuDatBan] CHECK CONSTRAINT [FK_PhieuDatBan_KhachHang]
GO
ALTER TABLE [dbo].[ThucDon]  WITH CHECK ADD  CONSTRAINT [FK_ThucDon_LoaiMonAn] FOREIGN KEY([IdLoaiMonAn])
REFERENCES [dbo].[LoaiMonAn] ([Id])
GO
ALTER TABLE [dbo].[ThucDon] CHECK CONSTRAINT [FK_ThucDon_LoaiMonAn]
GO
USE [master]
GO
ALTER DATABASE [QLNH] SET  READ_WRITE 
GO
