USE [master]
GO
/****** Object:  Database [Pastane]    Script Date: 5.06.2022 18:21:43 ******/
CREATE DATABASE [Pastane]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pastane', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Pastane.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Pastane_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Pastane_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Pastane] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pastane].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pastane] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pastane] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pastane] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pastane] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pastane] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pastane] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Pastane] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pastane] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pastane] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pastane] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pastane] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pastane] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pastane] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pastane] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pastane] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Pastane] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pastane] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pastane] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pastane] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pastane] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pastane] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Pastane] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pastane] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Pastane] SET  MULTI_USER 
GO
ALTER DATABASE [Pastane] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pastane] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pastane] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pastane] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Pastane] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Pastane] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Pastane', N'ON'
GO
ALTER DATABASE [Pastane] SET QUERY_STORE = OFF
GO
USE [Pastane]
GO
/****** Object:  Table [dbo].[KullaniciGiris]    Script Date: 5.06.2022 18:21:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KullaniciGiris](
	[KullaniciNo] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAd] [varchar](50) NULL,
	[KullaniciSifre] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Telefon] [char](20) NULL,
 CONSTRAINT [PK_KullaniciGiris] PRIMARY KEY CLUSTERED 
(
	[KullaniciNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteriler]    Script Date: 5.06.2022 18:21:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteriler](
	[MusteriNo] [int] IDENTITY(1,1) NOT NULL,
	[MusteriAdSoyad] [varchar](50) NULL,
	[MusteriTelefon] [char](20) NULL,
 CONSTRAINT [PK_Müsteriler] PRIMARY KEY CLUSTERED 
(
	[MusteriNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Satici]    Script Date: 5.06.2022 18:21:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satici](
	[SaticiNo] [int] IDENTITY(1,1) NOT NULL,
	[SaticiAdSoyad] [varchar](50) NULL,
	[SaticiAdres] [varchar](max) NULL,
	[Saticiİl] [varchar](50) NULL,
	[Saticiİlce] [varchar](50) NULL,
 CONSTRAINT [PK_Satıcı] PRIMARY KEY CLUSTERED 
(
	[SaticiNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Siparis]    Script Date: 5.06.2022 18:21:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siparis](
	[SiparisNo] [int] IDENTITY(1,1) NOT NULL,
	[SiparisAdi] [varchar](50) NULL,
	[SiparisAdres] [varchar](50) NULL,
	[SiparisAdet] [int] NULL,
	[SiparisFiyat] [int] NULL,
	[Tutar] [int] NULL,
	[UrunNo] [int] NULL,
	[MusteriNo] [int] NULL,
	[SaticiNo] [int] NULL,
 CONSTRAINT [PK_Sipariş] PRIMARY KEY CLUSTERED 
(
	[SiparisNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urunler]    Script Date: 5.06.2022 18:21:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunler](
	[UrunNo] [int] IDENTITY(1,1) NOT NULL,
	[UrunAdi] [varchar](50) NULL,
	[UrunFiyat] [int] NULL,
	[KullanimTarihi] [varchar](50) NULL,
	[UretimTarihi] [varchar](50) NULL,
 CONSTRAINT [PK_Urunler] PRIMARY KEY CLUSTERED 
(
	[UrunNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[KullaniciGiris] ON 

INSERT [dbo].[KullaniciGiris] ([KullaniciNo], [KullaniciAd], [KullaniciSifre], [Email], [Telefon]) VALUES (1, N'NİHAL', N'1234', N'nihal', N'02125555555         ')
INSERT [dbo].[KullaniciGiris] ([KullaniciNo], [KullaniciAd], [KullaniciSifre], [Email], [Telefon]) VALUES (3, N'm', N'm', N'm@gmail.com', N'05555555555         ')
SET IDENTITY_INSERT [dbo].[KullaniciGiris] OFF
GO
SET IDENTITY_INSERT [dbo].[Musteriler] ON 

INSERT [dbo].[Musteriler] ([MusteriNo], [MusteriAdSoyad], [MusteriTelefon]) VALUES (4, N'Miraç Efe', N'02126020074         ')
INSERT [dbo].[Musteriler] ([MusteriNo], [MusteriAdSoyad], [MusteriTelefon]) VALUES (14, N'Canan Karatay', N'02121111111         ')
INSERT [dbo].[Musteriler] ([MusteriNo], [MusteriAdSoyad], [MusteriTelefon]) VALUES (15, N'Sibel Akgöz', N'02123333333         ')
INSERT [dbo].[Musteriler] ([MusteriNo], [MusteriAdSoyad], [MusteriTelefon]) VALUES (16, N'Sultan Öz', N'03569889898         ')
INSERT [dbo].[Musteriler] ([MusteriNo], [MusteriAdSoyad], [MusteriTelefon]) VALUES (17, N'Tuğçe Demirbilek', N'09889556652         ')
SET IDENTITY_INSERT [dbo].[Musteriler] OFF
GO
SET IDENTITY_INSERT [dbo].[Satici] ON 

INSERT [dbo].[Satici] ([SaticiNo], [SaticiAdSoyad], [SaticiAdres], [Saticiİl], [Saticiİlce]) VALUES (1, N'Faruk Güllüoğlu', N'Atatürk Cad', N'İstanbul', N'Ümraniye')
INSERT [dbo].[Satici] ([SaticiNo], [SaticiAdSoyad], [SaticiAdres], [Saticiİl], [Saticiİlce]) VALUES (2, N'Bakery', N'Hürriyet Mah', N'İstanbul', N'Kadıköy')
INSERT [dbo].[Satici] ([SaticiNo], [SaticiAdSoyad], [SaticiAdres], [Saticiİl], [Saticiİlce]) VALUES (3, N'Kazanoğlu Fırın', N'Koçman Cad', N'İstanbul', N'Şişli')
INSERT [dbo].[Satici] ([SaticiNo], [SaticiAdSoyad], [SaticiAdres], [Saticiİl], [Saticiİlce]) VALUES (5, N'Selen Şişman', N'İkbal Sokak', N'İstanbul', N'Maltepe')
INSERT [dbo].[Satici] ([SaticiNo], [SaticiAdSoyad], [SaticiAdres], [Saticiİl], [Saticiİlce]) VALUES (6, N'Sütlüce', N'Kaypak Cad', N'Bolu', N'Kasaplar')
SET IDENTITY_INSERT [dbo].[Satici] OFF
GO
SET IDENTITY_INSERT [dbo].[Siparis] ON 

INSERT [dbo].[Siparis] ([SiparisNo], [SiparisAdi], [SiparisAdres], [SiparisAdet], [SiparisFiyat], [Tutar], [UrunNo], [MusteriNo], [SaticiNo]) VALUES (1, N'Gun1 ', N'Güneşli Mah', 2, 60, 60, 1, 4, 1)
INSERT [dbo].[Siparis] ([SiparisNo], [SiparisAdi], [SiparisAdres], [SiparisAdet], [SiparisFiyat], [Tutar], [UrunNo], [MusteriNo], [SaticiNo]) VALUES (2, N'Ev', N'Hekimbaşı Mah', 2, 50, 100, 5, 14, 2)
INSERT [dbo].[Siparis] ([SiparisNo], [SiparisAdi], [SiparisAdres], [SiparisAdet], [SiparisFiyat], [Tutar], [UrunNo], [MusteriNo], [SaticiNo]) VALUES (3, N'Okul', N'Cumhuriyet Cad', 10, 100, 1000, 1, 14, 3)
INSERT [dbo].[Siparis] ([SiparisNo], [SiparisAdi], [SiparisAdres], [SiparisAdet], [SiparisFiyat], [Tutar], [UrunNo], [MusteriNo], [SaticiNo]) VALUES (27, N'İş Yeri', N'Asma Sok', 2, 46, 46, 1, 4, 1)
SET IDENTITY_INSERT [dbo].[Siparis] OFF
GO
SET IDENTITY_INSERT [dbo].[Urunler] ON 

INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [UrunFiyat], [KullanimTarihi], [UretimTarihi]) VALUES (1, N'San Sebatian', 50, N'11 Ekim 2022 Salı', N'10 Ekim 2022 Pazartesi')
INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [UrunFiyat], [KullanimTarihi], [UretimTarihi]) VALUES (4, N'Turta', 75, N'15 Nisan 2022 Cuma', N'15 Nisan 2022 Cuma')
INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [UrunFiyat], [KullanimTarihi], [UretimTarihi]) VALUES (5, N'Pasta', 150, N'11 Nisan 2022 Pazartesi', N'1 Şubat 2022 Salı')
SET IDENTITY_INSERT [dbo].[Urunler] OFF
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Sipariş_Müsteriler] FOREIGN KEY([MusteriNo])
REFERENCES [dbo].[Musteriler] ([MusteriNo])
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Sipariş_Müsteriler]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Sipariş_Satıcı] FOREIGN KEY([SaticiNo])
REFERENCES [dbo].[Satici] ([SaticiNo])
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Sipariş_Satıcı]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Sipariş_Urunler] FOREIGN KEY([UrunNo])
REFERENCES [dbo].[Urunler] ([UrunNo])
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Sipariş_Urunler]
GO
USE [master]
GO
ALTER DATABASE [Pastane] SET  READ_WRITE 
GO
