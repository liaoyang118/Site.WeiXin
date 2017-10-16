USE [master]
GO
/****** Object:  Database [TestDB]    Script Date: 2017/10/16 19:08:28 ******/
CREATE DATABASE [TestDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestDB', FILENAME = N'E:\yang.liao\DB\TestDB.mdf' , SIZE = 256000KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [2013] 
( NAME = N'TestDB_2013', FILENAME = N'E:\yang.liao\DB\TestDB_2013.ndf' , SIZE = 23552KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
 FILEGROUP [2014] 
( NAME = N'TestDB_2014', FILENAME = N'E:\yang.liao\DB\TestDB_2014.ndf' , SIZE = 6144KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ),
( NAME = N'TestDB_2015', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TestDB_2015.ndf' , SIZE = 6144KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestDB_log', FILENAME = N'E:\yang.liao\DB\TestDB_log.ldf' , SIZE = 149696KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TestDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestDB] SET RECOVERY FULL 
GO
ALTER DATABASE [TestDB] SET  MULTI_USER 
GO
ALTER DATABASE [TestDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TestDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TestDB', N'ON'
GO
USE [TestDB]
GO
/****** Object:  PartitionFunction [bgPartitionFun]    Script Date: 2017/10/16 19:08:28 ******/
CREATE PARTITION FUNCTION [bgPartitionFun](int) AS RANGE LEFT FOR VALUES (100000, 200000, 300000)
GO
/****** Object:  PartitionScheme [bgPartitionSchema]    Script Date: 2017/10/16 19:08:28 ******/
CREATE PARTITION SCHEME [bgPartitionSchema] AS PARTITION [bgPartitionFun] TO ([PRIMARY], [2013], [2014], [PRIMARY])
GO
/****** Object:  UserDefinedFunction [dbo].[f_GetCSharpDataTypeBySqlUserType]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[f_GetCSharpDataTypeBySqlUserType] (@userType VARCHAR(5),@maxLength INT)  
RETURNS VARCHAR(50) AS
BEGIN
	DECLARE @columnType NVARCHAR(30)
	IF(@userType IN ('175','231','239'))
	BEGIN
		SET @columnType='nvarchar('+CAST(@maxLength/2 AS VARCHAR(5))+')'
	END
	ELSE IF(@userType IN ('56'))
	BEGIN
		SET @columnType='int'
	END
	ELSE IF(@userType IN ('61'))
	BEGIN
		SET @columnType='DateTime'
	END
	ELSE IF(@userType IN ('106'))
	BEGIN
		SET @columnType='money'
	END
	ELSE IF(@userType IN ('104'))
	BEGIN
		SET @columnType='bit'
	END
	ELSE IF(@userType IN ('167'))
	BEGIN
		SET @columnType='varchar('+CAST(@maxLength AS VARCHAR(5))+')'
	END
RETURN @columnType
END



GO
/****** Object:  Table [dbo].[GloblaToken]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GloblaToken](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Token] [varchar](512) NULL,
	[AppId] [varchar](128) NULL,
	[ExpireTime] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Name] [nvarchar](14) NULL,
	[Type] [varchar](30) NULL,
	[Value] [nvarchar](200) NULL,
	[CreateTime] [datetime] NULL,
	[LevelCode] [varchar](50) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_MENU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MenuType]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MenuType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](30) NULL,
	[Intro] [nvarchar](30) NULL,
 CONSTRAINT [PK_MENUTYPE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SystemUser]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SystemUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppId] [varchar](128) NULL,
	[Account] [varchar](30) NULL,
	[Password] [varchar](32) NULL,
	[CreateTime] [datetime] NULL,
	[CreateUserName] [nvarchar](30) NULL,
	[AccountState] [int] NULL,
 CONSTRAINT [PK_SYSTEMUSER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OpenID] [varchar](128) NULL,
	[NickName] [nvarchar](50) NULL,
	[HeadImg] [varchar](200) NULL,
	[Sex] [bit] NULL,
	[Country] [nvarchar](50) NULL,
	[Province] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Language] [nvarchar](50) NULL,
	[Subscribe_time] [datetime] NULL,
	[Unionid] [varchar](128) NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Type], [Value], [CreateTime], [LevelCode], [Status]) VALUES (1, 0, N'趣味找书', N'view', N'', CAST(N'2017-10-16 15:27:13.790' AS DateTime), N'001', 0)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Type], [Value], [CreateTime], [LevelCode], [Status]) VALUES (2, 0, N'Kindel知识', N'view', N'', CAST(N'2017-10-16 15:27:42.187' AS DateTime), N'002', 0)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Type], [Value], [CreateTime], [LevelCode], [Status]) VALUES (3, 1, N'爱好兴趣', N'view', N'', CAST(N'2017-10-16 15:28:27.477' AS DateTime), N'001001', 0)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Type], [Value], [CreateTime], [LevelCode], [Status]) VALUES (5, 2, N'同步推', N'view', N'', CAST(N'2017-10-16 15:28:54.587' AS DateTime), N'002001', 0)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Type], [Value], [CreateTime], [LevelCode], [Status]) VALUES (6, 2, N'绑定邮箱', N'view', N'', CAST(N'2017-10-16 15:29:03.700' AS DateTime), N'002002', 0)
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[MenuType] ON 

INSERT [dbo].[MenuType] ([Id], [Type], [Intro]) VALUES (1, N'click', N'key值触发')
INSERT [dbo].[MenuType] ([Id], [Type], [Intro]) VALUES (2, N'view', N'Url跳转')
INSERT [dbo].[MenuType] ([Id], [Type], [Intro]) VALUES (3, N'scancode_push', N'扫码推事件')
INSERT [dbo].[MenuType] ([Id], [Type], [Intro]) VALUES (4, N'scancode_waitmsg', N'扫码推事件，弹出“消息接收中')
INSERT [dbo].[MenuType] ([Id], [Type], [Intro]) VALUES (5, N'pic_sysphoto', N'弹出系统拍照发图')
INSERT [dbo].[MenuType] ([Id], [Type], [Intro]) VALUES (6, N'pic_photo_or_album', N'弹出拍照或者相册发图')
INSERT [dbo].[MenuType] ([Id], [Type], [Intro]) VALUES (7, N'pic_weixin', N'弹出微信相册发图器')
INSERT [dbo].[MenuType] ([Id], [Type], [Intro]) VALUES (8, N'location_select', N'弹出地理位置选择器')
INSERT [dbo].[MenuType] ([Id], [Type], [Intro]) VALUES (9, N'media_id', N'下发消息（除文本消息）')
INSERT [dbo].[MenuType] ([Id], [Type], [Intro]) VALUES (10, N'view_limited', N'跳转图文消息URL')
SET IDENTITY_INSERT [dbo].[MenuType] OFF
SET IDENTITY_INSERT [dbo].[SystemUser] ON 

INSERT [dbo].[SystemUser] ([Id], [AppId], [Account], [Password], [CreateTime], [CreateUserName], [AccountState]) VALUES (1, N'wx25491e8ba573f372', N'admin', N'21232f297a57a5a743894a0e4a801fc3', CAST(N'2017-09-11 16:23:55.270' AS DateTime), N'廖扬', 0)
SET IDENTITY_INSERT [dbo].[SystemUser] OFF
/****** Object:  StoredProcedure [dbo].[Proc_GloblaToken_DeleteById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:43PM*****/
create proc [dbo].[Proc_GloblaToken_DeleteById]
@Id int
AS
delete from [GloblaToken] where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_GloblaToken_Insert]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****插入*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:43PM*****/
create proc [dbo].[Proc_GloblaToken_Insert]
@Id int output,
@Token varchar(512),
@AppId varchar(128),
@ExpireTime DateTime
AS
insert into [GloblaToken](
Token,
AppId,
ExpireTime
)
values(
@Token,
@AppId,
@ExpireTime
)
SET @Id=@@IDENTITY




GO
/****** Object:  StoredProcedure [dbo].[Proc_GloblaToken_SelectById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:43PM*****/
create proc [dbo].[Proc_GloblaToken_SelectById]
@Id int
AS
select * FROM [GloblaToken] WHERE Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_GloblaToken_SelectList]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:09 11 2017  3:47PM*****/
CREATE proc [dbo].[Proc_GloblaToken_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [GloblaToken] WHERE 1=1 '+ @whereStr
EXEC sp_executesql @sql




GO
/****** Object:  StoredProcedure [dbo].[Proc_GloblaToken_SelectPage]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:43PM*****/
create proc [dbo].[Proc_GloblaToken_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','GloblaToken',@pageIndex,@pageSize,@orderBy,@where

GO
/****** Object:  StoredProcedure [dbo].[Proc_GloblaToken_UpdateById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****修改*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:43PM*****/
create proc [dbo].[Proc_GloblaToken_UpdateById]
@Id int,
@Token varchar(512),
@AppId varchar(128),
@ExpireTime DateTime
AS
update [GloblaToken] SET 
Token=@Token,
AppId=@AppId,
ExpireTime=@ExpireTime
 where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_Menu_DeleteById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_Menu_DeleteById]
@Id int
AS
delete from [Menu] where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_Menu_DeleteByParentId]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Proc_Menu_DeleteByParentId]
@ParentId INT,
@Id INT
as
DELETE dbo.Menu WHERE Id=@Id OR ParentId=@ParentId
GO
/****** Object:  StoredProcedure [dbo].[Proc_Menu_Insert]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****插入*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_Menu_Insert]
@Id int output,
@ParentId int,
@Name nvarchar(14),
@Type varchar(30),
@Value nvarchar(200),
@CreateTime DateTime
AS
insert into [Menu](
ParentId,
Name,
Type,
Value,
CreateTime
)
values(
@ParentId,
@Name,
@Type,
@Value,
@CreateTime
)
SET @Id=@@IDENTITY




GO
/****** Object:  StoredProcedure [dbo].[Proc_Menu_SelectById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_Menu_SelectById]
@Id int
AS
select * FROM [Menu] WHERE Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_Menu_SelectList]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:09 11 2017  3:48PM*****/
CREATE proc [dbo].[Proc_Menu_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [Menu] WHERE 1=1 '+ @whereStr
EXEC sp_executesql @sql




GO
/****** Object:  StoredProcedure [dbo].[Proc_Menu_SelectMenuList]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Proc_Menu_SelectMenuList]
AS
with temp(ID,ParentId,Name,[Type],value,CreateTime,LevelCode,[Status])
as
(
--初始查询
select ID,ParentId,Name,[Type],value,CreateTime,LevelCode,[Status] FROM dbo.Menu
where ParentId = 0    
union all
--递归条件
select a.ID,a.ParentId, a.Name,a.[Type],a.value,a.CreateTime,a.LevelCode,a.[Status]
from dbo.Menu a 
inner join
temp b
on ( a.ParentId=b.id)
)
select ID,ParentId,(replicate('&nbsp;',((LEN(LevelCode)/3)-1)*10)+Name)  as Name,[Type],value,CreateTime,LevelCode,[Status] from temp ORDER BY LevelCode

 
GO
/****** Object:  StoredProcedure [dbo].[Proc_Menu_SelectPage]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_Menu_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','Menu',@pageIndex,@pageSize,@orderBy,@where

GO
/****** Object:  StoredProcedure [dbo].[Proc_Menu_UpdateById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****修改*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_Menu_UpdateById]
@Id int,
@ParentId int,
@Name nvarchar(14),
@Type varchar(30),
@Value nvarchar(200),
@CreateTime DateTime
AS
update [Menu] SET 
ParentId=@ParentId,
Name=@Name,
Type=@Type,
Value=@Value,
CreateTime=@CreateTime
 where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_MenuType_DeleteById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_MenuType_DeleteById]
@Id int
AS
delete from [MenuType] where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_MenuType_Insert]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****插入*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_MenuType_Insert]
@Id int output,
@Type varchar(30),
@Intro nvarchar(30)
AS
insert into [MenuType](
Type,
Intro
)
values(
@Type,
@Intro
)
SET @Id=@@IDENTITY




GO
/****** Object:  StoredProcedure [dbo].[Proc_MenuType_SelectById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_MenuType_SelectById]
@Id int
AS
select * FROM [MenuType] WHERE Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_MenuType_SelectList]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:09 11 2017  3:48PM*****/
CREATE proc [dbo].[Proc_MenuType_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [MenuType] WHERE 1=1 '+ @whereStr
EXEC sp_executesql @sql




GO
/****** Object:  StoredProcedure [dbo].[Proc_MenuType_SelectPage]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_MenuType_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','MenuType',@pageIndex,@pageSize,@orderBy,@where

GO
/****** Object:  StoredProcedure [dbo].[Proc_MenuType_UpdateById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****修改*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_MenuType_UpdateById]
@Id int,
@Type varchar(30),
@Intro nvarchar(30)
AS
update [MenuType] SET 
Type=@Type,
Intro=@Intro
 where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_SelectPageBase]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Proc_SelectPageBase]
	@rowCount INT OUTPUT,
	@columns VARCHAR(200),
	@Identity VARCHAR(20),
	@tableName VARCHAR(50),
	@pageIndex INT,
	@pageSize INT,
	@orderBy VARCHAR(20),
	@where VARCHAR(300)
AS
	DECLARE @sql NVARCHAR(2000),@sort NVARCHAR(50)
	SET @sort=@orderBy
	IF(@orderBy='')
	BEGIN
	SET @sort=@Identity
	END
	
	SET @sql=N'SELECT * FROM(
	SELECT ROW_NUMBER()OVER (ORDER BY '+@sort+')AS num,'+@columns+' FROM ['+@tableName+']'+@where+')AS t
	WHERE num > '+CAST((@pageIndex-1)*@pageSize AS VARCHAR(5))+' AND num <= '+CAST(@pageIndex*@pageSize AS VARCHAR(5))
	+' order by '+@sort+';
	SELECT @rowCount1= COUNT(1) FROM ['+@tableName+']'+@where
	PRINT @sql
	EXEC sp_executesql @sql,N'@rowCount1 int output',@rowCount1=@rowCount OUTPUT



GO
/****** Object:  StoredProcedure [dbo].[Proc_SystemUser_DeleteById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_SystemUser_DeleteById]
@Id int
AS
delete from [SystemUser] where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_SystemUser_Insert]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****插入*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_SystemUser_Insert]
@Id int output,
@AppId varchar(128),
@Account varchar(30),
@Password varchar(32),
@CreateTime DateTime,
@CreateUserName nvarchar(30),
@AccountState int
AS
insert into [SystemUser](
AppId,
Account,
Password,
CreateTime,
CreateUserName,
AccountState
)
values(
@AppId,
@Account,
@Password,
@CreateTime,
@CreateUserName,
@AccountState
)
SET @Id=@@IDENTITY




GO
/****** Object:  StoredProcedure [dbo].[Proc_SystemUser_SelectById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_SystemUser_SelectById]
@Id int
AS
select * FROM [SystemUser] WHERE Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_SystemUser_SelectList]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:09 11 2017  3:46PM*****/
CREATE proc [dbo].[Proc_SystemUser_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [SystemUser] WHERE 1=1 '+ @whereStr
EXEC sp_executesql @sql
GO
/****** Object:  StoredProcedure [dbo].[Proc_SystemUser_SelectPage]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_SystemUser_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','SystemUser',@pageIndex,@pageSize,@orderBy,@where

GO
/****** Object:  StoredProcedure [dbo].[Proc_SystemUser_UpdateById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****修改*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_SystemUser_UpdateById]
@Id int,
@AppId varchar(128),
@Account varchar(30),
@Password varchar(32),
@CreateTime DateTime,
@CreateUserName nvarchar(30),
@AccountState int
AS
update [SystemUser] SET 
AppId=@AppId,
Account=@Account,
Password=@Password,
CreateTime=@CreateTime,
CreateUserName=@CreateUserName,
AccountState=@AccountState
 where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_User_DeleteById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_User_DeleteById]
@Id int
AS
delete from [User] where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_User_Insert]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****插入*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_User_Insert]
@Id int output,
@OpenID varchar(128),
@NickName nvarchar(50),
@HeadImg varchar(200),
@Sex BIT,
@Country nvarchar(50),
@Province nvarchar(50),
@City nvarchar(50),
@Language nvarchar(50),
@Subscribe_time DateTime,
@Unionid varchar(128)
AS
insert into [User](
OpenID,
NickName,
HeadImg,
Sex,
Country,
Province,
City,
Language,
Subscribe_time,
Unionid
)
values(
@OpenID,
@NickName,
@HeadImg,
@Sex,
@Country,
@Province,
@City,
@Language,
@Subscribe_time,
@Unionid
)
SET @Id=@@IDENTITY




GO
/****** Object:  StoredProcedure [dbo].[Proc_User_SelectById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_User_SelectById]
@Id int
AS
select * FROM [User] WHERE Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_User_SelectList]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:09 11 2017  3:48PM*****/
create proc [dbo].[Proc_User_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [User] WHERE 1=1 and '+ @whereStr
EXEC sp_executesql @sql




GO
/****** Object:  StoredProcedure [dbo].[Proc_User_SelectPage]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_User_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','User',@pageIndex,@pageSize,@orderBy,@where

GO
/****** Object:  StoredProcedure [dbo].[Proc_User_UpdateById]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****修改*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
create proc [dbo].[Proc_User_UpdateById]
@Id int,
@OpenID varchar(128),
@NickName nvarchar(50),
@HeadImg varchar(200),
 @Sex BIT,
@Country nvarchar(50),
@Province nvarchar(50),
@City nvarchar(50),
@Language nvarchar(50),
@Subscribe_time DateTime,
@Unionid varchar(128)
AS
update [User] SET 
OpenID=@OpenID,
NickName=@NickName,
HeadImg=@HeadImg,
Sex=@Sex,
Country=@Country,
Province=@Province,
City=@City,
Language=@Language,
Subscribe_time=@Subscribe_time,
Unionid=@Unionid
 where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Tool_CreateDALByMSEnterlibry]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Tool_CreateDALByMSEnterlibry]
	@procname varchar(100),
	@returnType VARCHAR(50),
	@inputType VARCHAR(50)
AS
IF NOT EXISTS(SELECT * FROM sys.procedures WHERE name=@procname)
BEGIN
PRINT 'Not Find This Procdurece'
RETURN
END

DECLARE @name VARCHAR(30),@userType INT,@isOutPut BIT,@hasOutPut BIT,@outputArgu VARCHAR(30)
DECLARE columnCursor SCROLL CURSOR FOR
SELECT name,user_type_id,is_output FROM sys.parameters WHERE object_id=OBJECT_ID(@procname)



OPEN columnCursor

PRINT N'#region '+@procname
IF((CHARINDEX('selectPage',@procname)!=0))
	BEGIN
		PRINT N'public '+@returnType+' '+SUBSTRING(@procname,CHARINDEX('_',@procname)+1,LEN(@procname)-4)+'(string cloumns,int pageIndex,int pageSize,string orderBy,string where,out int rowCount)'
	END
ELSE
	BEGIN
		PRINT N'public '+@returnType+' '+SUBSTRING(@procname,CHARINDEX('_',@procname)+1,LEN(@procname)-4)+'('+@inputType+' obj)'
	END

PRINT N'{
		DbCommand dbCmd = db.GetStoredProcCommand("'+@procname+'");'
			
FETCH NEXT FROM columnCursor INTO @name,@userType,@isOutPut
DECLARE @csharpType VARCHAR(20)

WHILE @@FETCH_STATUS=0
BEGIN
	IF(@userType IN (56))
	SET @csharpType='Int32'
	ELSE IF(@userType IN (61,167,175,231))
	SET @csharpType='String'
	ELSE IF(@userType IN (60))
	SET @csharpType='Decimal'
	ELSE IF(@userType IN (62))
	SET @csharpType='Single'
	ELSE
	SET @csharpType='String'
IF(@isOutPut=1)
	BEGIN
	SET @hasOutPut=1
	SET @outputArgu=@name
	PRINT N'		db.AddOutParameter(dbCmd, "'+@name+'", DbType.'+@csharpType+',4);'
	END
ELSE
	BEGIN
	IF(CHARINDEX('selectPage',@procname)!=0)
	BEGIN
		PRINT N'		db.AddInParameter(dbCmd, "'+@name+'", DbType.'+@csharpType+','+SUBSTRING(@name,2,LEN(@name)-1)+');'
	END
	else
	PRINT N'		db.AddInParameter(dbCmd, "'+@name+'", DbType.'+@csharpType+', obj.'+SUBSTRING(@name,2,LEN(@name)-1)+');'
	
	END

FETCH NEXT FROM columnCursor INTO @name,@userType,@isOutPut
END
DECLARE @modelType VARCHAR(30)
IF(LOWER(@returnType)='int' OR @returnType='')
BEGIN

PRINT N'		try
			{ 
				int returnValue = db.ExecuteNonQuery(dbCmd);'
	IF(@hasOutPut=1)
	BEGIN
		PRINT N'			int '+SUBSTRING(@outputArgu,2,LEN(@outputArgu)-1)+' = (int)dbCmd.Parameters["'+@outputArgu+'"].Value;'
	END
PRINT N'		return returnValue;
			}
			 catch(Exception e)
			{
				throw new Exception(e.Message);
			}'
END
ELSE IF(CHARINDEX('list',@returnType)!=0)
BEGIN
	SET @modelType=SUBSTRING(@procname,CHARINDEX('_',@procname)+1,CHARINDEX('_',@procname,6)-CHARINDEX('_',@procname)-1)
PRINT N'		'+@returnType+' list=new '+@returnType+'();
			try
            {
               using( IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						'+@modelType+' obj=new '+@modelType+'();
						//属性赋值
	                    
						list.Add(obj);
					}'
		IF(CHARINDEX('selectPage',@procname)!=0)
		BEGIN
			PRINT N'					reader.NextResult();
				}'
			PRINT N'			'+SUBSTRING(@outputArgu,2,LEN(@outputArgu)-1)+' = (int)dbCmd.Parameters["'+@outputArgu+'"].Value;'
		END
PRINT'			return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }'
END
ELSE
BEGIN
	
	SET @modelType=SUBSTRING(@procname,CHARINDEX('_',@procname)+1,CHARINDEX('_',@procname,6)-1-CHARINDEX('_',@procname))
	PRINT N'		'+@modelType+' obj=null;
			try
            {
               using(IDataReader reader = db.ExecuteReader(dbCmd))
               {
					while (reader.Read())
					{
						obj=new '+@modelType+'();
						//属性赋值
	                    
					}
                }'
		IF(CHARINDEX('selectPage',@procname)!=0)
		PRINT N'			'+SUBSTRING(@outputArgu,2,LEN(@outputArgu)-1)+' = (int)dbCmd.Parameters["'+@outputArgu+'"].Value;'
PRINT'			return obj;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }'
END
PRINT N'}
	#endregion
'

CLOSE columnCursor
DEALLOCATE columnCursor



GO
/****** Object:  StoredProcedure [dbo].[Tool_CreateModel]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Tool_CreateModel]
	@tableName VARCHAR(50)
AS
--用来在游标中储值
DECLARE @modelName VARCHAR(50),@type VARCHAR(5)
--用来存储类型
DECLARE @fieldType VARCHAR(20)
-----------------------------查询表的所有字段
IF NOT EXISTS(SELECT * FROM sys.tables WHERE name=@tableName)
BEGIN
PRINT 'Not Find This Table'
RETURN
END


--定义游标 for 结果集
DECLARE modelCursor CURSOR FOR
(SELECT name,xtype FROM  syscolumns WHERE id=OBJECT_ID(@tableName))
--打开游标
OPEN modelCursor
--移动游标到下一个
FETCH NEXT FROM modelCursor INTO @modelName,@type
--循环取出游标的值

---打印Model类
	PRINT 'public class '+@tableName
	PRINT '{'
WHILE @@FETCH_STATUS=0
BEGIN
	IF(@type IN ('167','175','231','239'))
	BEGIN
		SET @fieldType='string'
	END
	ELSE IF(@type IN ('56'))
	BEGIN
		SET @fieldType='int'
	END
	ELSE IF(@type IN ('61'))
	BEGIN
		SET @fieldType='DateTime'
	END
	ELSE IF(@type IN ('106'))
	BEGIN
		SET @fieldType='decimal'
	END
	--打印属性
	PRINT ''
	PRINT '#region '+@modelName
	PRINT 'private '+@fieldType+' _'+@modelName+';'
    PRINT 'public '+@fieldType+' '+@modelName
    PRINT '{'
    PRINT ' get {'
    PRINT '     return this._'+@modelName+';'
    PRINT ' }'
    PRINT ' set {'
    PRINT '     this._'+@modelName+' = value;'
    PRINT ' }'
    PRINT '}'
	PRINT '#endregion'
	--移动游标
	FETCH NEXT FROM modelCursor INTO @modelName,@type
END
PRINT '}'
---关闭游标
CLOSE modelCursor
---释放游标
DEALLOCATE modelCursor



GO
/****** Object:  StoredProcedure [dbo].[Tool_CreateProc]    Script Date: 2017/10/16 19:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Tool_CreateProc]
	@tableName VARCHAR(50),
	@createUser NVARCHAR(50)=''
AS
DECLARE @name VARCHAR(20),@userType VARCHAR(5),@isIdentity BIT,@maxLength INT

IF NOT EXISTS(SELECT * FROM sys.tables WHERE name=@tableName)
BEGIN
PRINT 'Not Find This Table'
RETURN
END


DECLARE columnsCursor SCROLL CURSOR FOR
--查询表有哪些列
SELECT name,user_type_id,is_identity,max_length FROM sys.columns WHERE object_id=OBJECT_ID(@tableName)

--打开游标
OPEN columnsCursor
--移动游标
FETCH NEXT FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength

----------------------------插入----------------------------------
PRINT N'
GO'
	PRINT N'if exists (select * from sysobjects where name=''Proc_'+@tableName+'_Insert'')
	begin
	print ''has exists this name Proc,please ensure''
	return
	end
GO
/*****插入*****
*****CreateUser:'+@createUser+'*****'+'
*****CreateTime:'+CAST(GETDATE()AS VARCHAR(30))+'*****/
create proc Proc_'+@tableName+'_Insert'
DECLARE @columnType NVARCHAR(30),@argus VARCHAR(100),@outPutArgument VARCHAR(30)

WHILE @@FETCH_STATUS=0
BEGIN
		--调用函数，得到数据类型
		SET @columnType=dbo.f_GetCSharpDataTypeBySqlUserType(@userType,@maxLength)
		IF(@isIdentity=1)
		BEGIN
		SET @argus= '@'+@name+' '+@columnType+' output'
		SET @outPutArgument=@name
		END
		ELSE
		SET @argus= '@'+@name+' '+@columnType
--移动游标,判断是否还有下一条
FETCH NEXT FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength
	IF(@@FETCH_STATUS=0)
	BEGIN
	PRINT @argus+','
	END
	ELSE
	BEGIN
	PRINT @argus
	END
END

-------------------------
PRINT 'AS'
PRINT 'insert into ['+@tableName+']('


--移动游标,判断是否还有下一条
FETCH FIRST FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength

WHILE @@FETCH_STATUS=0
BEGIN
	--调用函数，得到数据类型
	SET @columnType=dbo.f_GetCSharpDataTypeBySqlUserType(@userType,@maxLength)
	IF(@isIdentity=1)
	BEGIN
		--移动游标,判断是否还有下一条
		FETCH RELATIVE 1 FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength
		CONTINUE
	END
	ELSE
	BEGIN
		SET @argus=@name
	END
--移动游标,判断是否还有下一条
	FETCH RELATIVE 1 FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength
	IF(@@FETCH_STATUS=0)
	BEGIN
	PRINT @argus+','
	END
	ELSE
	BEGIN
	PRINT @argus
	END
	
END



PRINT ')
values('

--移动游标到第一条
FETCH FIRST FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength

WHILE @@FETCH_STATUS=0
BEGIN
	IF(@isIdentity=1)
	BEGIN
		--移动游标,判断是否还有下一条
		FETCH RELATIVE 1 FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength
		CONTINUE
	END
	ELSE
	BEGIN
		SET @argus='@'+@name
	END
--移动游标,判断是否还有下一条
	FETCH RELATIVE 1 FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength
	IF(@@FETCH_STATUS=0)
	BEGIN
	PRINT @argus+','
	END
	ELSE
	BEGIN
	PRINT @argus
	END
END
PRINT ')'
PRINT 'SET @'+@outPutArgument+'=@@IDENTITY'

-----------------------删除------------------------------
PRINT N'


GO'
	PRINT N'if exists (select * from sysobjects where name=''Proc_'+@tableName+'_DeleteBy'+@outPutArgument+''')
	begin
	print ''has exists this name Proc,please ensure''
	return
	end
GO
/*****删除*****
*****CreateUser:'+@createUser+'*****'+'
*****CreateTime:'+CAST(GETDATE()AS VARCHAR(30))+'*****/
create proc Proc_'+@tableName+'_DeleteBy'+@outPutArgument
PRINT '@'+@outPutArgument+' int
AS
'
PRINT 'delete from ['+@tableName+'] where '+@outPutArgument+'='+'@'+@outPutArgument

-----------------------修改------------------------------
PRINT N'


GO'
PRINT N'if exists (select * from sysobjects where name=''Proc_'+@tableName+'_UpdateBy'+@outPutArgument+''')
	begin
	print ''has exists this name Proc,please ensure''
	return
	end
GO
/*****修改*****
*****CreateUser:'+@createUser+'*****'+'
*****CreateTime:'+CAST(GETDATE()AS VARCHAR(30))+'*****/
create proc Proc_'+@tableName+'_UpdateBy'+@outPutArgument

--移动游标到第一条
FETCH FIRST FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength

WHILE @@FETCH_STATUS=0
BEGIN
		--调用函数，得到数据类型
		SET @columnType=dbo.f_GetCSharpDataTypeBySqlUserType(@userType,@maxLength)
		--IF(@isIdentity=1)
		--BEGIN
		----SET @argus=''
		--SET @outPutArgument=@name
		----移动游标,判断是否还有下一条
		--FETCH RELATIVE 1 FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength
		--CONTINUE
		--END
		--ELSE
		SET @argus= '@'+@name+' '+@columnType
--移动游标,判断是否还有下一条
FETCH RELATIVE 1 FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength
	IF(@@FETCH_STATUS=0)
	BEGIN
	PRINT @argus+','
	END
	ELSE
	BEGIN
	PRINT @argus
	END
END
PRINT 'AS'
PRINT 'update ['+@tableName+'] SET '

--移动游标到第一条
FETCH FIRST FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength
DECLARE @VALUES VARCHAR(50)
WHILE @@FETCH_STATUS=0
BEGIN
		IF(@isIdentity=1)
		BEGIN
		--移动游标,判断是否还有下一条
		FETCH RELATIVE 1 FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength
		CONTINUE
		END
		ELSE
		SET @VALUES= @name+'='+'@'+@name
--移动游标,判断是否还有下一条
FETCH RELATIVE 1 FROM columnsCursor INTO @name,@userType,@isIdentity,@maxLength
	IF(@@FETCH_STATUS=0)
	BEGIN
	PRINT @VALUES+','
	END
	ELSE
	BEGIN
	PRINT @VALUES
	END
END
PRINT ' where '+@outPutArgument+'='+'@'+@outPutArgument



-----------------------查询------------------------------
PRINT N'


GO'
	PRINT N'if exists (select * from sysobjects where name=''Proc_'+@tableName+'_SelectBy'+@outPutArgument+''')
	begin
	print ''has exists this name Proc,please ensure''
	return
	end
GO
/*****查询*****
*****CreateUser:'+@createUser+'*****'+'
*****CreateTime:'+CAST(GETDATE()AS VARCHAR(30))+'*****/
create proc Proc_'+@tableName+'_SelectBy'+@outPutArgument
PRINT '@'+@outPutArgument+' int'
PRINT 'AS
select * FROM ['+@tableName+'] WHERE '+@outPutArgument+'='+'@'+@outPutArgument


----------------------- where查询---------------------------------------


PRINT N'


GO'
	PRINT N'if exists (select * from sysobjects where name=''Proc_'+@tableName+'_SelectList'')
	begin
	print ''has exists this name Proc,please ensure''
	return
	end
GO
/*****查询*****
*****CreateUser:'+@createUser+'*****'+'
*****CreateTime:'+CAST(GETDATE()AS VARCHAR(30))+'*****/
create proc Proc_'+@tableName+'_SelectList'
PRINT '@whereStr nvarchar(1000)'
PRINT 'AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N''SELECT * FROM ['+@tableName+'] WHERE 1=1 ''+ @whereStr
EXEC sp_executesql @sql'




-----------------------分页查询------------------------------
PRINT N'


GO'
PRINT N'if exists (select * from sysobjects where name=''Proc_'+@tableName+'_SelectPage'+''')
	begin
	print ''has exists this name Proc,please ensure''
	return
	end
GO
/*****查询*****
*****CreateUser:'+@createUser+'*****'+'
*****CreateTime:'+CAST(GETDATE()AS VARCHAR(30))+'*****/
create proc Proc_'+@tableName+'_SelectPage'
PRINT '@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
'
PRINT 'exec Proc_SelectPageBase @rowCount output,@cloumns,'''+@outPutArgument+''','''+@tableName+''',@pageIndex,@pageSize,@orderBy,@where'




--关闭游标
CLOSE columnsCursor
--释放游标
DEALLOCATE columnsCursor


--EXEC Tool_CreateProc 'User'



GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'https请求方式: GET
   https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
   
   正常情况下，微信会返回下述JSON数据包给公众号：
   {"access_token":"ACCESS_TOKEN","expires_in":7200}
   
   错误时微信会返回错误码等信息
   {"errcode":40013,"errmsg":"invalid appid"}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GloblaToken'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 正常 1 不可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'AccountState'
GO
USE [master]
GO
ALTER DATABASE [TestDB] SET  READ_WRITE 
GO
