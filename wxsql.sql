USE [master]
GO
/****** Object:  Database [TestDB]    Script Date: 2017/12/4 11:06:36 ******/
CREATE DATABASE [TestDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestDB', FILENAME = N'E:\yang.liao\DB\TestDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestDB_log', FILENAME = N'E:\yang.liao\DB\TestDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  UserDefinedFunction [dbo].[f_GetCSharpDataTypeBySqlUserType]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  Table [dbo].[Article]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [nvarchar](30) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[ContentSourceUrl] [varchar](200) NOT NULL,
	[MediaId] [varchar](128) NOT NULL,
	[ArticleContent] [nvarchar](4000) NOT NULL,
	[Intro] [nvarchar](128) NOT NULL,
	[ShowCover] [int] NOT NULL,
	[CoverSrc] [varchar](150) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUserAccount] [varchar](30) NOT NULL,
	[AppId] [varchar](128) NOT NULL,
	[Statu] [int] NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GloblaToken]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  Table [dbo].[GongzhongAccount]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GongzhongAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppID] [varchar](128) NOT NULL,
	[AppSecret] [varchar](128) NOT NULL,
	[AppAccount] [varchar](128) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Intro] [nvarchar](150) NOT NULL,
	[CreateUserAccount] [varchar](30) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_GongzhongAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GroupSend]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GroupSend](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SendType] [varchar](50) NOT NULL,
	[SendName] [nvarchar](50) NOT NULL,
	[MessageType] [varchar](50) NOT NULL,
	[Media_Id] [varchar](50) NOT NULL,
	[IsToAll] [bit] NOT NULL,
	[TagId] [varchar](10) NOT NULL,
	[SendStatu] [int] NOT NULL,
	[CreateUserAccount] [varchar](30) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Msg_id] [varchar](50) NOT NULL,
	[Msg_data_id] [varchar](50) NOT NULL,
	[AppId] [varchar](128) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KeyWordsReply]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KeyWordsReply](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KeyWords] [nvarchar](50) NOT NULL,
	[Intro] [nvarchar](50) NOT NULL,
	[ReplyType] [varchar](30) NOT NULL,
	[ReplyContent] [varchar](4000) NOT NULL,
	[Statu] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUserAccount] [varchar](30) NOT NULL,
	[AppId] [varchar](120) NOT NULL,
 CONSTRAINT [PK_KeyWordsReply] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Material]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Material](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaterialName] [nvarchar](50) NOT NULL,
	[MaterialType] [varchar](50) NOT NULL,
	[Media_id] [varchar](50) NOT NULL,
	[Url] [varchar](200) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUserAccount] [varchar](30) NOT NULL,
	[Intro] [nvarchar](200) NOT NULL,
	[Expire] [varchar](10) NOT NULL,
	[AppId] [varchar](128) NOT NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Name] [nvarchar](14) NOT NULL,
	[Type] [varchar](30) NOT NULL,
	[Value] [nvarchar](200) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[LevelCode] [varchar](50) NOT NULL,
	[AppId] [varchar](128) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_MENU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MenuType]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  Table [dbo].[SystemUser]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SystemUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GongzhongAccountId] [int] NOT NULL,
	[Account] [varchar](30) NOT NULL,
	[Password] [varchar](32) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUserName] [nvarchar](30) NOT NULL,
	[AccountState] [int] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[IsSuperAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_SYSTEMUSER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OpenID] [varchar](128) NOT NULL,
	[NickName] [nvarchar](50) NULL,
	[HeadImg] [varchar](200) NULL,
	[Sex] [int] NULL,
	[Country] [nvarchar](50) NULL,
	[Province] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Language] [nvarchar](50) NULL,
	[Subscribe_Time] [datetime] NULL,
	[Unionid] [varchar](128) NULL,
	[IsSubscribe] [bit] NULL,
	[UnSubscribe_Time] [datetime] NULL,
	[AppId] [varchar](128) NOT NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TagId] [varchar](10) NOT NULL,
	[OpenId] [varchar](128) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserMessage]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserMessage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MessageType] [varchar](50) NOT NULL,
	[OpenID] [varchar](512) NOT NULL,
	[XmlContent] [nvarchar](1000) NOT NULL,
	[MsgId] [varchar](20) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[ContentValue] [nvarchar](500) NOT NULL,
	[AppId] [varchar](128) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserTag]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](60) NOT NULL,
	[TagId] [varchar](10) NOT NULL,
	[CreateUserAccount] [varchar](30) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[AppId] [varchar](128) NOT NULL,
 CONSTRAINT [PK_UserTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[GongzhongAccount] ON 

INSERT [dbo].[GongzhongAccount] ([Id], [AppID], [AppSecret], [AppAccount], [Name], [Intro], [CreateUserAccount], [CreateTime]) VALUES (1, N'wx25491e8ba573f372', N'd4624c36b6795d1d99dcf0547af5443d', N'gh_b26d4dbcc910  ', N'微信平台测试公众号', N'微信官方测试公众号', N'admin', CAST(N'2017-11-30 11:21:39.043' AS DateTime))
INSERT [dbo].[GongzhongAccount] ([Id], [AppID], [AppSecret], [AppAccount], [Name], [Intro], [CreateUserAccount], [CreateTime]) VALUES (3, N'wx597094182764fce6', N'17f13a6a5ed8fcd1db48508d1c4d0a64', N'gh_c133711080c2', N'廖扬的订阅号', N'廖扬的订阅号', N'admin', CAST(N'2017-11-30 18:18:22.797' AS DateTime))
INSERT [dbo].[GongzhongAccount] ([Id], [AppID], [AppSecret], [AppAccount], [Name], [Intro], [CreateUserAccount], [CreateTime]) VALUES (4, N'wx6024e649bbe6d984', N'585beba9d5946109776746704e1bd669', N'gh_868ac27c4dfb', N'鲜果惠', N'波哥的鲜果惠', N'admin', CAST(N'2017-12-04 10:19:56.720' AS DateTime))
SET IDENTITY_INSERT [dbo].[GongzhongAccount] OFF
SET IDENTITY_INSERT [dbo].[KeyWordsReply] ON 

INSERT [dbo].[KeyWordsReply] ([Id], [KeyWords], [Intro], [ReplyType], [ReplyContent], [Statu], [CreateTime], [CreateUserAccount], [AppId]) VALUES (1, N'默认', N'默认', N'text', N'<xml>
                        <ToUserName><![CDATA[{0}]]></ToUserName>
                        <FromUserName><![CDATA[{1}]]></FromUserName>
                        <CreateTime>{2}</CreateTime>
                        <MsgType><![CDATA[text]]></MsgType>
                        <Content><![CDATA[哈哈，<a href="http://www.baidu.com">点我吧</a>]]></Content></xml>', 0, CAST(N'2017-12-04 10:13:34.600' AS DateTime), N'liaoyang', N'wx25491e8ba573f372')
SET IDENTITY_INSERT [dbo].[KeyWordsReply] OFF
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Type], [Value], [CreateTime], [LevelCode], [AppId], [Status]) VALUES (1, 0, N'菜单根节点', N'', N'', CAST(N'2017-12-01 17:55:39.833' AS DateTime), N'100', N'', 0)
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

INSERT [dbo].[SystemUser] ([Id], [GongzhongAccountId], [Account], [Password], [CreateTime], [CreateUserName], [AccountState], [IsAdmin], [IsSuperAdmin]) VALUES (1, 0, N'admin', N'e10adc3949ba59abbe56e057f20f883e', CAST(N'2017-12-01 17:55:39.780' AS DateTime), N'', 0, 1, 1)
INSERT [dbo].[SystemUser] ([Id], [GongzhongAccountId], [Account], [Password], [CreateTime], [CreateUserName], [AccountState], [IsAdmin], [IsSuperAdmin]) VALUES (2, 1, N'liaoyang', N'e10adc3949ba59abbe56e057f20f883e', CAST(N'2017-12-01 17:56:31.810' AS DateTime), N'admin', 0, 1, 0)
INSERT [dbo].[SystemUser] ([Id], [GongzhongAccountId], [Account], [Password], [CreateTime], [CreateUserName], [AccountState], [IsAdmin], [IsSuperAdmin]) VALUES (3, 3, N'liaoyang2', N'e10adc3949ba59abbe56e057f20f883e', CAST(N'2017-12-01 17:56:53.220' AS DateTime), N'admin', 0, 1, 0)
INSERT [dbo].[SystemUser] ([Id], [GongzhongAccountId], [Account], [Password], [CreateTime], [CreateUserName], [AccountState], [IsAdmin], [IsSuperAdmin]) VALUES (4, 4, N'weiwei@mxtx.vip', N'1e084c3b4f747e575233dc6673ff52c6', CAST(N'2017-12-04 10:20:24.833' AS DateTime), N'admin', 0, 1, 0)
SET IDENTITY_INSERT [dbo].[SystemUser] OFF
SET IDENTITY_INSERT [dbo].[UserMessage] ON 

INSERT [dbo].[UserMessage] ([Id], [MessageType], [OpenID], [XmlContent], [MsgId], [CreateTime], [ContentValue], [AppId]) VALUES (1, N'text', N'o0YXKt_EJTmDd7Xx3cxZGyGAU5hI', N'<xml><ToUserName><![CDATA[gh_b26d4dbcc910]]></ToUserName>
<FromUserName><![CDATA[o0YXKt_EJTmDd7Xx3cxZGyGAU5hI]]></FromUserName>
<CreateTime>1512355719</CreateTime>
<MsgType><![CDATA[text]]></MsgType>
<Content><![CDATA[哈哈哈]]></Content>
<MsgId>6495518353467649633</MsgId>
</xml>', N'6495518353467649633', CAST(N'2017-12-04 10:48:47.433' AS DateTime), N'哈哈哈', N'wx25491e8ba573f372')
INSERT [dbo].[UserMessage] ([Id], [MessageType], [OpenID], [XmlContent], [MsgId], [CreateTime], [ContentValue], [AppId]) VALUES (2, N'text', N'o0YXKt_EJTmDd7Xx3cxZGyGAU5hI', N'<xml><ToUserName><![CDATA[gh_b26d4dbcc910]]></ToUserName>
<FromUserName><![CDATA[o0YXKt_EJTmDd7Xx3cxZGyGAU5hI]]></FromUserName>
<CreateTime>1512355719</CreateTime>
<MsgType><![CDATA[text]]></MsgType>
<Content><![CDATA[哈哈哈]]></Content>
<MsgId>6495518353467649633</MsgId>
</xml>', N'6495518353467649633', CAST(N'2017-12-04 10:48:47.433' AS DateTime), N'哈哈哈', N'wx25491e8ba573f372')
SET IDENTITY_INSERT [dbo].[UserMessage] OFF
/****** Object:  StoredProcedure [dbo].[Proc_Article_DeleteById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:yang.liao*****
*****CreateTime:10 26 2017  5:14PM*****/
create proc [dbo].[Proc_Article_DeleteById]
@Id int
AS
delete from [Article] where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_Article_Insert]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****插入*****
*****CreateUser:yang.liao*****
*****CreateTime:11 30 2017  1:55PM*****/
CREATE proc [dbo].[Proc_Article_Insert]
@Id int output,
@AuthorName nvarchar(30),
@Title nvarchar(50),
@ContentSourceUrl varchar(200),
@MediaId varchar(128),
@ArticleContent nvarchar(4000),
@Intro nvarchar(128),
@ShowCover int,
@CoverSrc varchar(150),
@CreateTime DateTime,
@CreateUserAccount varchar(30),
@AppId varchar(128),
@Statu int
AS
insert into [Article](
AuthorName,
Title,
ContentSourceUrl,
MediaId,
ArticleContent,
Intro,
ShowCover,
CoverSrc,
CreateTime,
CreateUserAccount,
AppId,
Statu
)
values(
@AuthorName,
@Title,
@ContentSourceUrl,
@MediaId,
@ArticleContent,
@Intro,
@ShowCover,
@CoverSrc,
@CreateTime,
@CreateUserAccount,
@AppId,
@Statu
)
SET @Id=@@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[Proc_Article_SelectById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:10 26 2017  5:14PM*****/
create proc [dbo].[Proc_Article_SelectById]
@Id int
AS
select * FROM [Article] WHERE Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_Article_SelectList]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:10 26 2017  5:14PM*****/
CREATE proc [dbo].[Proc_Article_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [Article] '+ @whereStr
EXEC sp_executesql @sql




GO
/****** Object:  StoredProcedure [dbo].[Proc_Article_SelectPage]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:10 26 2017  5:14PM*****/
create proc [dbo].[Proc_Article_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','Article',@pageIndex,@pageSize,@orderBy,@where

GO
/****** Object:  StoredProcedure [dbo].[Proc_Article_UpdateById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_Article_UpdateById]
@Id int,
@AuthorName nvarchar(30),
@Title nvarchar(50),
@ContentSourceUrl varchar(200),
@MediaId varchar(128),
@ArticleContent nvarchar(4000),
@Intro nvarchar(128),
@ShowCover int,
@CoverSrc varchar(150),
@CreateTime DateTime,
@CreateUserAccount varchar(30),
@AppId varchar(128),
@Statu int
AS
update [Article] SET 
AuthorName=@AuthorName,
Title=@Title,
ContentSourceUrl=@ContentSourceUrl,
MediaId=@MediaId,
ArticleContent=@ArticleContent,
Intro=@Intro,
ShowCover=@ShowCover,
CoverSrc=@CoverSrc,
CreateTime=@CreateTime,
CreateUserAccount=@CreateUserAccount,
AppId=@AppId,
Statu=@Statu
 where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[Proc_GloblaToken_DeleteById]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_GloblaToken_Insert]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_GloblaToken_SelectById]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_GloblaToken_SelectList]    Script Date: 2017/12/4 11:06:36 ******/
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
SET @sql=N'SELECT * FROM [GloblaToken] '+ @whereStr
EXEC sp_executesql @sql






GO
/****** Object:  StoredProcedure [dbo].[Proc_GloblaToken_SelectPage]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_GloblaToken_UpdateById]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_GongzhongAccount_DeleteById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:yang.liao*****
*****CreateTime:11 30 2017 11:20AM*****/
create proc [dbo].[Proc_GongzhongAccount_DeleteById]
@Id int
AS
delete from [GongzhongAccount] where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_GongzhongAccount_Insert]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_GongzhongAccount_Insert]
@Id int output,
@AppID varchar(128),
@AppSecret varchar(128),
@AppAccount varchar(128),
@Name nvarchar(50),
@Intro nvarchar(150),
@CreateUserAccount varchar(30),
@CreateTime DateTime
AS
insert into [GongzhongAccount](
AppID,
AppSecret,
AppAccount,
Name,
Intro,
CreateUserAccount,
CreateTime
)
values(
@AppID,
@AppSecret,
@AppAccount,
@Name,
@Intro,
@CreateUserAccount,
@CreateTime
)
SET @Id=@@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[Proc_GongzhongAccount_SelectById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 30 2017 11:20AM*****/
create proc [dbo].[Proc_GongzhongAccount_SelectById]
@Id int
AS
select * FROM [GongzhongAccount] WHERE Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_GongzhongAccount_SelectList]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 30 2017 11:20AM*****/
create proc [dbo].[Proc_GongzhongAccount_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [GongzhongAccount] '+ @whereStr
EXEC sp_executesql @sql




GO
/****** Object:  StoredProcedure [dbo].[Proc_GongzhongAccount_SelectPage]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 30 2017 11:20AM*****/
create proc [dbo].[Proc_GongzhongAccount_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','GongzhongAccount',@pageIndex,@pageSize,@orderBy,@where

GO
/****** Object:  StoredProcedure [dbo].[Proc_GongzhongAccount_UpdateById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Proc_GongzhongAccount_UpdateById]
@Id int,
@AppID varchar(128),
@AppSecret varchar(128),
@AppAccount varchar(128),
@Name nvarchar(50),
@Intro nvarchar(150),
@CreateUserAccount varchar(30),
@CreateTime DateTime
AS
update [GongzhongAccount] SET 
AppID=@AppID,
AppSecret=@AppSecret,
AppAccount=@AppAccount,
Name=@Name,
Intro=@Intro,
CreateUserAccount=@CreateUserAccount,
CreateTime=@CreateTime
 where Id=@Id

GO
/****** Object:  StoredProcedure [dbo].[Proc_GroupSend_DeleteById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:yang.liao*****
*****CreateTime:11 23 2017  2:41PM*****/
create proc [dbo].[Proc_GroupSend_DeleteById]
@Id int
AS
delete from [GroupSend] where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_GroupSend_Insert]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_GroupSend_Insert]
@Id int output,
@SendType varchar(50),
@SendName nvarchar(50),
@MessageType varchar(50),
@Media_Id varchar(50),
@IsToAll bit,
@TagId varchar(10),
@SendStatu int,
@CreateUserAccount varchar(30),
@CreateTime DateTime,
@Msg_id varchar(50),
@Msg_data_id varchar(50),
@AppId varchar(128)
AS
insert into [GroupSend](
SendType,
SendName,
MessageType,
Media_Id,
IsToAll,
TagId,
SendStatu,
CreateUserAccount,
CreateTime,
Msg_id,
Msg_data_id,
AppId
)
values(
@SendType,
@SendName,
@MessageType,
@Media_Id,
@IsToAll,
@TagId,
@SendStatu,
@CreateUserAccount,
@CreateTime,
@Msg_id,
@Msg_data_id,
@AppId
)
SET @Id=@@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[Proc_GroupSend_SelectById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 23 2017  2:41PM*****/
create proc [dbo].[Proc_GroupSend_SelectById]
@Id int
AS
select * FROM [GroupSend] WHERE Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_GroupSend_SelectList]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 23 2017  2:41PM*****/
create proc [dbo].[Proc_GroupSend_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [GroupSend] '+ @whereStr
EXEC sp_executesql @sql




GO
/****** Object:  StoredProcedure [dbo].[Proc_GroupSend_SelectPage]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 23 2017  2:41PM*****/
create proc [dbo].[Proc_GroupSend_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','GroupSend',@pageIndex,@pageSize,@orderBy,@where

GO
/****** Object:  StoredProcedure [dbo].[Proc_GroupSend_UpdateById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_GroupSend_UpdateById]
@Id int,
@SendType varchar(50),
@SendName nvarchar(50),
@MessageType varchar(50),
@Media_Id varchar(50),
@IsToAll bit,
@TagId varchar(10),
@SendStatu int,
@CreateUserAccount varchar(30),
@CreateTime DateTime,
@Msg_id varchar(50),
@Msg_data_id varchar(50),
@AppId varchar(128)
AS
update [GroupSend] SET 
SendType=@SendType,
SendName=@SendName,
MessageType=@MessageType,
Media_Id=@Media_Id,
IsToAll=@IsToAll,
TagId=@TagId,
SendStatu=@SendStatu,
CreateUserAccount=@CreateUserAccount,
CreateTime=@CreateTime,
Msg_id=@Msg_id,
Msg_data_id=@Msg_data_id,
AppId=@AppId
 where Id=@Id

GO
/****** Object:  StoredProcedure [dbo].[Proc_KeyWordsReply_DeleteById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:yang.liao*****
*****CreateTime:11  9 2017  1:58PM*****/
create proc [dbo].[Proc_KeyWordsReply_DeleteById]
@Id int
AS
delete from [KeyWordsReply] where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_KeyWordsReply_Insert]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_KeyWordsReply_Insert]
@Id int output,
@KeyWords nvarchar(50),
@Intro nvarchar(50),
@ReplyType varchar(30),
@ReplyContent varchar(4000),
@Statu int,
@CreateTime DateTime,
@CreateUserAccount varchar(30),
@AppId varchar(120)
AS
insert into [KeyWordsReply](
KeyWords,
Intro,
ReplyType,
ReplyContent,
Statu,
CreateTime,
CreateUserAccount,
AppId
)
values(
@KeyWords,
@Intro,
@ReplyType,
@ReplyContent,
@Statu,
@CreateTime,
@CreateUserAccount,
@AppId
)
SET @Id=@@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[Proc_KeyWordsReply_SelectById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11  9 2017  1:58PM*****/
create proc [dbo].[Proc_KeyWordsReply_SelectById]
@Id int
AS
select * FROM [KeyWordsReply] WHERE Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_KeyWordsReply_SelectList]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11  9 2017  1:58PM*****/
CREATE proc [dbo].[Proc_KeyWordsReply_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [KeyWordsReply] '+ @whereStr
EXEC sp_executesql @sql




GO
/****** Object:  StoredProcedure [dbo].[Proc_KeyWordsReply_SelectPage]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11  9 2017  1:58PM*****/
create proc [dbo].[Proc_KeyWordsReply_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','KeyWordsReply',@pageIndex,@pageSize,@orderBy,@where

GO
/****** Object:  StoredProcedure [dbo].[Proc_KeyWordsReply_UpdateById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_KeyWordsReply_UpdateById]
@Id int,
@KeyWords nvarchar(50),
@Intro nvarchar(50),
@ReplyType varchar(30),
@ReplyContent varchar(4000),
@Statu int,
@CreateTime DateTime,
@CreateUserAccount varchar(30),
@AppId varchar(120)
AS
update [KeyWordsReply] SET 
KeyWords=@KeyWords,
Intro=@Intro,
ReplyType=@ReplyType,
ReplyContent=@ReplyContent,
Statu=@Statu,
CreateTime=@CreateTime,
CreateUserAccount=@CreateUserAccount,
AppId=@AppId
 where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[Proc_Material_DeleteById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:yang.liao*****
*****CreateTime:10 26 2017  5:15PM*****/
create proc [dbo].[Proc_Material_DeleteById]
@Id int
AS
delete from [Material] where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_Material_Insert]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[Proc_Material_Insert]
@Id int output,
@MaterialName nvarchar(50),
@MaterialType varchar(50),
@Media_id varchar(50),
@Url varchar(200),
@CreateTime DateTime,
@CreateUserAccount varchar(30),
@Intro nvarchar(200),
@Expire varchar(10),
@AppId varchar(128)
AS
insert into [Material](
MaterialName,
MaterialType,
Media_id,
Url,
CreateTime,
CreateUserAccount,
Intro,
Expire,
AppId
)
values(
@MaterialName,
@MaterialType,
@Media_id,
@Url,
@CreateTime,
@CreateUserAccount,
@Intro,
@Expire,
@AppId
)
SET @Id=@@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[Proc_Material_SelectById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:10 26 2017  5:15PM*****/
create proc [dbo].[Proc_Material_SelectById]
@Id int
AS
select * FROM [Material] WHERE Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_Material_SelectList]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:10 26 2017  5:15PM*****/
CREATE proc [dbo].[Proc_Material_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [Material] '+ @whereStr
EXEC sp_executesql @sql





GO
/****** Object:  StoredProcedure [dbo].[Proc_Material_SelectPage]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:10 26 2017  5:15PM*****/
create proc [dbo].[Proc_Material_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','Material',@pageIndex,@pageSize,@orderBy,@where

GO
/****** Object:  StoredProcedure [dbo].[Proc_Material_UpdateById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[Proc_Material_UpdateById]
@Id int,
@MaterialName nvarchar(50),
@MaterialType varchar(50),
@Media_id varchar(50),
@Url varchar(200),
@CreateTime DateTime,
@CreateUserAccount varchar(30),
@Intro nvarchar(200),
@Expire varchar(10),
@AppId varchar(128)
AS
update [Material] SET 
MaterialName=@MaterialName,
MaterialType=@MaterialType,
Media_id=@Media_id,
Url=@Url,
CreateTime=@CreateTime,
CreateUserAccount=@CreateUserAccount,
Intro=@Intro,
Expire=@Expire,
AppId=@AppId
 where Id=@Id


GO
/****** Object:  StoredProcedure [dbo].[Proc_Menu_DeleteById]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_Menu_DeleteByParentId]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_Menu_Insert]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_Menu_Insert]
@Id int output,
@ParentId int,
@Name nvarchar(14),
@Type varchar(30),
@Value nvarchar(200),
@CreateTime DATETIME,
@LevelCode VARCHAR(50),
@AppId VARCHAR(128),
@Status INT
AS
DECLARE @code VARCHAR(50)
IF EXISTS (SELECT 1 FROM dbo.Menu WHERE ParentId=@ParentId)
SELECT @code=CAST(MAX(LevelCode) AS INT)+1 FROM dbo.Menu WHERE ParentId=@ParentId;
ELSE
SELECT @code= LevelCode+N'100' FROM dbo.Menu WHERE Id=@ParentId;

insert into [Menu](
ParentId,
Name,
Type,
Value,
CreateTime,
LevelCode,
AppId,
[Status]
)
values(
@ParentId,
@Name,
@Type,
@Value,
@CreateTime,
@code,
@AppId,
@Status
)
SET @Id=@@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[Proc_Menu_SelectById]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_Menu_SelectList]    Script Date: 2017/12/4 11:06:36 ******/
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
SET @sql=N'SELECT * FROM [Menu] '+ @whereStr
EXEC sp_executesql @sql






GO
/****** Object:  StoredProcedure [dbo].[Proc_Menu_SelectMenuList]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Proc_Menu_SelectMenuList]
@AppId varchar(128)
AS
with temp(ID,ParentId,Name,[Type],value,CreateTime,LevelCode,[Status],AppId)
as
(
--初始查询
select ID,ParentId,Name,[Type],value,CreateTime,LevelCode,[Status],AppId FROM dbo.Menu
where ParentId = 0
union all
--递归条件
select a.ID,a.ParentId, a.Name,a.[Type],a.value,a.CreateTime,a.LevelCode,a.[Status],a.[AppId]
from dbo.Menu a 
INNER JOIN temp b ON ( a.ParentId=b.id) WHERE a.AppId=@AppId
)
select ID,ParentId,(replicate('&nbsp;',((LEN(LevelCode)/3)-2)*10)+Name)  as Name,[Type],value,CreateTime,LevelCode,[Status],AppId from temp WHERE temp.ParentId>0 ORDER BY LevelCode

 


GO
/****** Object:  StoredProcedure [dbo].[Proc_Menu_SelectPage]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_Menu_UpdateById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_Menu_UpdateById]
@Id int,
@ParentId int,
@Name nvarchar(14),
@Type varchar(30),
@Value nvarchar(200),
@CreateTime DateTime,
@LevelCode varchar(50),
@AppId varchar(128),
@Status int
AS
update [Menu] SET 
ParentId=@ParentId,
Name=@Name,
Type=@Type,
Value=@Value,
CreateTime=@CreateTime,
LevelCode=@LevelCode,
AppId=@AppId,
Status=@Status
 where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[Proc_MenuType_DeleteById]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_MenuType_Insert]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_MenuType_SelectById]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_MenuType_SelectList]    Script Date: 2017/12/4 11:06:36 ******/
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
SET @sql=N'SELECT * FROM [MenuType] '+ @whereStr
EXEC sp_executesql @sql






GO
/****** Object:  StoredProcedure [dbo].[Proc_MenuType_SelectPage]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_MenuType_UpdateById]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_SelectPageBase]    Script Date: 2017/12/4 11:06:36 ******/
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
	SELECT ROW_NUMBER()OVER (ORDER BY '+@sort+')AS num,'+@columns+' FROM ['+@tableName+'] as t1 '+@where+')AS t
	WHERE num > '+CAST((@pageIndex-1)*@pageSize AS VARCHAR(5))+' AND num <= '+CAST(@pageIndex*@pageSize AS VARCHAR(5))
	+';
	SELECT @rowCount1= COUNT(1) FROM ['+@tableName+'] as t1 '+@where
	PRINT @sql
	EXEC sp_executesql @sql,N'@rowCount1 int output',@rowCount1=@rowCount OUTPUT






GO
/****** Object:  StoredProcedure [dbo].[Proc_System_Init]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Proc_System_Init]
AS
begin
INSERT INTO dbo.Menu
        ( ParentId ,
          Name ,
          Type ,
          Value ,
          CreateTime ,
          LevelCode ,
		  AppId,
          Status
        )
VALUES  ( 0 , -- ParentId - int
          N'菜单根节点' , -- Name - nvarchar(14)
          '' , -- Type - varchar(30)
          N'' , -- Value - nvarchar(200)
          GETDATE() , -- CreateTime - datetime
          '100' , -- LevelCode - varchar(50)
		  '',
          0  -- Status - int
        );
end
GO
/****** Object:  StoredProcedure [dbo].[Proc_SystemUser_DeleteById]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_SystemUser_Insert]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_SystemUser_Insert]
@Id int output,
@GongzhongAccountId int,
@Account varchar(30),
@Password varchar(32),
@CreateTime DateTime,
@CreateUserName nvarchar(30),
@AccountState int,
@IsAdmin bit,
@IsSuperAdmin bit
AS
insert into [SystemUser](
GongzhongAccountId,
Account,
Password,
CreateTime,
CreateUserName,
AccountState,
IsAdmin,
IsSuperAdmin
)
values(
@GongzhongAccountId,
@Account,
@Password,
@CreateTime,
@CreateUserName,
@AccountState,
@IsAdmin,
@IsSuperAdmin
)
SET @Id=@@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[Proc_SystemUser_SelectById]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_SystemUser_SelectList]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_SystemUser_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [SystemUser] '+ @whereStr
EXEC sp_executesql @sql
GO
/****** Object:  StoredProcedure [dbo].[Proc_SystemUser_SelectPage]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_SystemUser_UpdateById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_SystemUser_UpdateById]
@Id int,
@GongzhongAccountId int,
@Account varchar(30),
@Password varchar(32),
@CreateTime DateTime,
@CreateUserName nvarchar(30),
@AccountState int,
@IsAdmin bit,
@IsSuperAdmin bit
AS
update [SystemUser] SET 
GongzhongAccountId=@GongzhongAccountId,
Account=@Account,
Password=@Password,
CreateTime=@CreateTime,
CreateUserName=@CreateUserName,
AccountState=@AccountState,
IsAdmin=@IsAdmin,
IsSuperAdmin=@IsSuperAdmin
 where Id=@Id

GO
/****** Object:  StoredProcedure [dbo].[Proc_User_DeleteById]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_User_Insert]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****插入*****
*****CreateUser:liaoyang*****
*****CreateTime:09  8 2017  5:44PM*****/
CREATE PROC [dbo].[Proc_User_Insert]
    @Id INT OUTPUT,
    @OpenID VARCHAR(128),
    @NickName NVARCHAR(50),
    @HeadImg VARCHAR(200),
    @Sex INT,
    @Country NVARCHAR(50),
    @Province NVARCHAR(50),
    @City NVARCHAR(50),
    @Language NVARCHAR(50),
    @Subscribe_Time DATETIME,
    @Unionid VARCHAR(128),
	@IsSubscribe BIT,
	@UnSubscribe_Time DATETIME,
	@AppId varchar(128)
AS
    IF EXISTS (SELECT 1 FROM dbo.[User] WHERE OpenID = @OpenID)
    BEGIN
        UPDATE dbo.[User]
        SET -- varchar(128)
            NickName = @NickName,             -- nvarchar(50)
            HeadImg = @HeadImg,               -- varchar(200)
            Sex = @Sex,                       -- int
            Country = @Country,               -- nvarchar(50)
            Province = @Province,             -- nvarchar(50)
            City = @City,                     -- nvarchar(50)
            [Language] = @Language,             -- nvarchar(50)
            Subscribe_Time = @Subscribe_time, -- datetime
            Unionid = @Unionid,               -- varchar(128)
            IsSubscribe = @IsSubscribe,               -- varchar(128)
            UnSubscribe_Time = @UnSubscribe_Time,               -- varchar(128)
			AppId = @AppId
        WHERE OpenID = @OpenID;
        SET @Id = 1;
    END;
    ELSE
    BEGIN
        INSERT INTO [User]
        (
            OpenID,
            NickName,
            HeadImg,
            Sex,
            Country,
            Province,
            City,
            [Language],
            Subscribe_time,
            Unionid,
			IsSubscribe,
			UnSubscribe_Time,
			AppId
        )
        VALUES
        (@OpenID,
            @NickName,
            @HeadImg,
            @Sex,
            @Country,
            @Province,
            @City,
            @Language,
            @Subscribe_time,
            @Unionid,
			@IsSubscribe,
			@UnSubscribe_Time,
			@AppId
        );
        SET @Id = @@IDENTITY;
    END;





GO
/****** Object:  StoredProcedure [dbo].[Proc_User_SelectById]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_User_SelectList]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:09 11 2017  3:48PM*****/
CREATE proc [dbo].[Proc_User_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [User] '+ @whereStr
EXEC sp_executesql @sql






GO
/****** Object:  StoredProcedure [dbo].[Proc_User_SelectPage]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_User_UpdateById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_User_UpdateById]
@Id int,
@OpenID varchar(128),
@NickName nvarchar(50),
@HeadImg varchar(200),
@Sex int,
@Country nvarchar(50),
@Province nvarchar(50),
@City nvarchar(50),
@Language nvarchar(50),
@Subscribe_Time DateTime,
@Unionid varchar(128),
@IsSubscribe bit,
@UnSubscribe_Time DateTime,
@AppId varchar(128)
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
Subscribe_Time=@Subscribe_Time,
Unionid=@Unionid,
IsSubscribe=@IsSubscribe,
UnSubscribe_Time=@UnSubscribe_Time,
AppId=@AppId
 where Id=@Id

GO
/****** Object:  StoredProcedure [dbo].[Proc_UserGroup_DeleteById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:yang.liao*****
*****CreateTime:11 21 2017  3:56PM*****/
create proc [dbo].[Proc_UserGroup_DeleteById]
@Id int
AS
delete from [UserGroup] where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_UserGroup_Insert]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****插入*****
*****CreateUser:yang.liao*****
*****CreateTime:11 21 2017  3:56PM*****/
CREATE proc [dbo].[Proc_UserGroup_Insert]
@Id int output,
@TagId varchar(10),
@OpenId varchar(128),
@CreateTime DateTime
AS
IF NOT EXISTS(SELECT 1 FROM UserGroup WHERE TagId=@TagId AND OpenId=@OpenId)
begin
insert into [UserGroup](
TagId,
OpenId,
CreateTime
)
values(
@TagId,
@OpenId,
@CreateTime
)
SET @Id=@@IDENTITY
END
ELSE
BEGIN
SET @Id=0
END




GO
/****** Object:  StoredProcedure [dbo].[Proc_UserGroup_SelectById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 21 2017  3:56PM*****/
create proc [dbo].[Proc_UserGroup_SelectById]
@Id int
AS
select * FROM [UserGroup] WHERE Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_UserGroup_SelectList]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 21 2017  3:56PM*****/
create proc [dbo].[Proc_UserGroup_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [UserGroup] '+ @whereStr
EXEC sp_executesql @sql




GO
/****** Object:  StoredProcedure [dbo].[Proc_UserGroup_SelectPage]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 21 2017  3:56PM*****/
create proc [dbo].[Proc_UserGroup_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','UserGroup',@pageIndex,@pageSize,@orderBy,@where

GO
/****** Object:  StoredProcedure [dbo].[Proc_UserGroup_UpdateById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****修改*****
*****CreateUser:yang.liao*****
*****CreateTime:11 21 2017  3:56PM*****/
create proc [dbo].[Proc_UserGroup_UpdateById]
@Id int,
@TagId varchar(10),
@OpenId varchar(128),
@CreateTime DateTime
AS
update [UserGroup] SET 
TagId=@TagId,
OpenId=@OpenId,
CreateTime=@CreateTime
 where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_UserMessage_DeleteById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:yang.liao*****
*****CreateTime:10 20 2017  3:39PM*****/
create proc [dbo].[Proc_UserMessage_DeleteById]
@Id int
AS
delete from [UserMessage] where Id=@Id





GO
/****** Object:  StoredProcedure [dbo].[Proc_UserMessage_Insert]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Proc_UserMessage_Insert]
@Id int output,
@MessageType varchar(50),
@OpenID varchar(512),
@XmlContent nvarchar(1000),
@MsgId varchar(20),
@CreateTime DateTime,
@ContentValue nvarchar(500),
@AppId varchar(128)
AS
insert into [UserMessage](
MessageType,
OpenID,
XmlContent,
MsgId,
CreateTime,
ContentValue,
AppId
)
values(
@MessageType,
@OpenID,
@XmlContent,
@MsgId,
@CreateTime,
@ContentValue,
@AppId
)
SET @Id=@@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[Proc_UserMessage_SelectById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:10 20 2017  3:39PM*****/
create proc [dbo].[Proc_UserMessage_SelectById]
@Id int
AS
select * FROM [UserMessage] WHERE Id=@Id





GO
/****** Object:  StoredProcedure [dbo].[Proc_UserMessage_SelectList]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:10 20 2017  3:39PM*****/
CREATE proc [dbo].[Proc_UserMessage_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [UserMessage] '+ @whereStr
EXEC sp_executesql @sql





GO
/****** Object:  StoredProcedure [dbo].[Proc_UserMessage_SelectPage]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:10 20 2017  3:39PM*****/
create proc [dbo].[Proc_UserMessage_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','UserMessage',@pageIndex,@pageSize,@orderBy,@where


GO
/****** Object:  StoredProcedure [dbo].[Proc_UserMessage_UpdateById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_UserMessage_UpdateById]
@Id int,
@MessageType varchar(50),
@OpenID varchar(512),
@XmlContent nvarchar(1000),
@MsgId varchar(20),
@CreateTime DateTime,
@ContentValue nvarchar(500),
@AppId varchar(128)
AS
update [UserMessage] SET 
MessageType=@MessageType,
OpenID=@OpenID,
XmlContent=@XmlContent,
MsgId=@MsgId,
CreateTime=@CreateTime,
ContentValue=@ContentValue,
AppId=@AppId
 where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[Proc_UserTag_DeleteById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:yang.liao*****
*****CreateTime:11 21 2017  2:47PM*****/
create proc [dbo].[Proc_UserTag_DeleteById]
@Id int
AS
delete from [UserTag] where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_UserTag_Insert]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_UserTag_Insert]
@Id int output,
@TagName nvarchar(60),
@TagId varchar(10),
@CreateUserAccount varchar(30),
@CreateTime DateTime,
@AppId varchar(128)
AS
insert into [UserTag](
TagName,
TagId,
CreateUserAccount,
CreateTime,
AppId
)
values(
@TagName,
@TagId,
@CreateUserAccount,
@CreateTime,
@AppId
)
SET @Id=@@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[Proc_UserTag_SelectById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 21 2017  2:47PM*****/
create proc [dbo].[Proc_UserTag_SelectById]
@Id int
AS
select * FROM [UserTag] WHERE Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_UserTag_SelectList]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 21 2017  2:47PM*****/
create proc [dbo].[Proc_UserTag_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [UserTag] '+ @whereStr
EXEC sp_executesql @sql




GO
/****** Object:  StoredProcedure [dbo].[Proc_UserTag_SelectPage]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 21 2017  2:47PM*****/
create proc [dbo].[Proc_UserTag_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','UserTag',@pageIndex,@pageSize,@orderBy,@where

GO
/****** Object:  StoredProcedure [dbo].[Proc_UserTag_UpdateById]    Script Date: 2017/12/4 11:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_UserTag_UpdateById]
@Id int,
@TagName nvarchar(60),
@TagId varchar(10),
@CreateUserAccount varchar(30),
@CreateTime DateTime,
@AppId varchar(128)
AS
update [UserTag] SET 
TagName=@TagName,
TagId=@TagId,
CreateUserAccount=@CreateUserAccount,
CreateTime=@CreateTime,
AppId=@AppId
 where Id=@Id

GO
/****** Object:  StoredProcedure [dbo].[Tool_CreateDALByMSEnterlibry]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Tool_CreateModel]    Script Date: 2017/12/4 11:06:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Tool_CreateProc]    Script Date: 2017/12/4 11:06:36 ******/
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
SET @sql=N''SELECT * FROM ['+@tableName+'] ''+ @whereStr
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缩略图素材ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Article', @level2type=N'COLUMN',@level2name=N'MediaId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'https请求方式: GET
   https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
   
   正常情况下，微信会返回下述JSON数据包给公众号：
   {"access_token":"ACCESS_TOKEN","expires_in":7200}
   
   错误时微信会返回错误码等信息
   {"errcode":40013,"errmsg":"invalid appid"}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GloblaToken'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送类型，根据openId发送，还是根据tagId发送' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupSend', @level2type=N'COLUMN',@level2name=N'SendType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否记录到用户的历史记录中' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupSend', @level2type=N'COLUMN',@level2name=N'IsToAll'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按标签发送时赋值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupSend', @level2type=N'COLUMN',@level2name=N'TagId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'群发图文消息时有效' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupSend', @level2type=N'COLUMN',@level2name=N'Msg_data_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片、语音、视屏、缩略图' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Material', @level2type=N'COLUMN',@level2name=N'MaterialType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 正常 1 不可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SystemUser', @level2type=N'COLUMN',@level2name=N'AccountState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值为1时是男性，值为2时是女性，值为0时是未知' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'整个请求内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserMessage', @level2type=N'COLUMN',@level2name=N'XmlContent'
GO
USE [master]
GO
ALTER DATABASE [TestDB] SET  READ_WRITE 
GO
