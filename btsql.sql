USE [master]
GO
/****** Object:  Database [BusinessBT]    Script Date: 2017/11/15 20:06:34 ******/
CREATE DATABASE [BusinessBT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BusinessBT', FILENAME = N'E:\yang.liao\DB\BusinessBT.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BusinessBT_log', FILENAME = N'E:\yang.liao\DB\BusinessBT_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BusinessBT] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BusinessBT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BusinessBT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BusinessBT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BusinessBT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BusinessBT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BusinessBT] SET ARITHABORT OFF 
GO
ALTER DATABASE [BusinessBT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BusinessBT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BusinessBT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BusinessBT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BusinessBT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BusinessBT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BusinessBT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BusinessBT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BusinessBT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BusinessBT] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BusinessBT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BusinessBT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BusinessBT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BusinessBT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BusinessBT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BusinessBT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BusinessBT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BusinessBT] SET RECOVERY FULL 
GO
ALTER DATABASE [BusinessBT] SET  MULTI_USER 
GO
ALTER DATABASE [BusinessBT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BusinessBT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BusinessBT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BusinessBT] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BusinessBT] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BusinessBT', N'ON'
GO
USE [BusinessBT]
GO
/****** Object:  UserDefinedFunction [dbo].[f_GetCSharpDataTypeBySqlUserType]    Script Date: 2017/11/15 20:06:34 ******/
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
/****** Object:  Table [dbo].[BusinessAccountBinding]    Script Date: 2017/11/15 20:06:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BusinessAccountBinding](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OpenId] [varchar](128) NOT NULL,
	[BusinessUserId] [int] NOT NULL,
	[BussinessUserAccount] [varchar](30) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_BusinessAccountBinding] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BusinessUser]    Script Date: 2017/11/15 20:06:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BusinessUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[Password] [varchar](32) NOT NULL,
	[Status] [int] NOT NULL,
	[CreateUserAccount] [varchar](30) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_BusinessUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BusinessAccountBinding] ON 

INSERT [dbo].[BusinessAccountBinding] ([Id], [OpenId], [BusinessUserId], [BussinessUserAccount], [CreateTime]) VALUES (1, N'o0YXKt_EJTmDd7Xx3cxZGyGAU5hI', 1, N'admin', CAST(N'2017-11-14 18:02:20.883' AS DateTime))
SET IDENTITY_INSERT [dbo].[BusinessAccountBinding] OFF
SET IDENTITY_INSERT [dbo].[BusinessUser] ON 

INSERT [dbo].[BusinessUser] ([Id], [Account], [Password], [Status], [CreateUserAccount], [CreateTime]) VALUES (1, N'admin', N'123456', 0, N'admin', CAST(N'2017-11-14 17:49:01.493' AS DateTime))
SET IDENTITY_INSERT [dbo].[BusinessUser] OFF
/****** Object:  StoredProcedure [dbo].[Proc_BusinessAccountBinding_DeleteById]    Script Date: 2017/11/15 20:06:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:yang.liao*****
*****CreateTime:11 14 2017  4:43PM*****/
create proc [dbo].[Proc_BusinessAccountBinding_DeleteById]
@Id int
AS
delete from [BusinessAccountBinding] where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_BusinessAccountBinding_Insert]    Script Date: 2017/11/15 20:06:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****插入*****
*****CreateUser:yang.liao*****
*****CreateTime:11 14 2017  4:43PM*****/
create proc [dbo].[Proc_BusinessAccountBinding_Insert]
@Id int output,
@OpenId varchar(128),
@BusinessUserId int,
@BussinessUserAccount varchar(30),
@CreateTime DateTime
AS
insert into [BusinessAccountBinding](
OpenId,
BusinessUserId,
BussinessUserAccount,
CreateTime
)
values(
@OpenId,
@BusinessUserId,
@BussinessUserAccount,
@CreateTime
)
SET @Id=@@IDENTITY




GO
/****** Object:  StoredProcedure [dbo].[Proc_BusinessAccountBinding_SelectById]    Script Date: 2017/11/15 20:06:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 14 2017  4:43PM*****/
create proc [dbo].[Proc_BusinessAccountBinding_SelectById]
@Id int
AS
select * FROM [BusinessAccountBinding] WHERE Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_BusinessAccountBinding_SelectList]    Script Date: 2017/11/15 20:06:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 14 2017  4:43PM*****/
create proc [dbo].[Proc_BusinessAccountBinding_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [BusinessAccountBinding] '+ @whereStr
EXEC sp_executesql @sql




GO
/****** Object:  StoredProcedure [dbo].[Proc_BusinessAccountBinding_SelectPage]    Script Date: 2017/11/15 20:06:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 14 2017  4:43PM*****/
create proc [dbo].[Proc_BusinessAccountBinding_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','BusinessAccountBinding',@pageIndex,@pageSize,@orderBy,@where

GO
/****** Object:  StoredProcedure [dbo].[Proc_BusinessAccountBinding_UpdateById]    Script Date: 2017/11/15 20:06:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****修改*****
*****CreateUser:yang.liao*****
*****CreateTime:11 14 2017  4:43PM*****/
create proc [dbo].[Proc_BusinessAccountBinding_UpdateById]
@Id int,
@OpenId varchar(128),
@BusinessUserId int,
@BussinessUserAccount varchar(30),
@CreateTime DateTime
AS
update [BusinessAccountBinding] SET 
OpenId=@OpenId,
BusinessUserId=@BusinessUserId,
BussinessUserAccount=@BussinessUserAccount,
CreateTime=@CreateTime
 where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_BusinessUser_DeleteById]    Script Date: 2017/11/15 20:06:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****删除*****
*****CreateUser:yang.liao*****
*****CreateTime:11 14 2017  4:43PM*****/
create proc [dbo].[Proc_BusinessUser_DeleteById]
@Id int
AS
delete from [BusinessUser] where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_BusinessUser_Insert]    Script Date: 2017/11/15 20:06:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****插入*****
*****CreateUser:yang.liao*****
*****CreateTime:11 14 2017  4:43PM*****/
create proc [dbo].[Proc_BusinessUser_Insert]
@Id int output,
@Account varchar(50),
@Password varchar(32),
@Status int,
@CreateUserAccount varchar(30),
@CreateTime DateTime
AS
insert into [BusinessUser](
Account,
Password,
Status,
CreateUserAccount,
CreateTime
)
values(
@Account,
@Password,
@Status,
@CreateUserAccount,
@CreateTime
)
SET @Id=@@IDENTITY




GO
/****** Object:  StoredProcedure [dbo].[Proc_BusinessUser_SelectById]    Script Date: 2017/11/15 20:06:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 14 2017  4:43PM*****/
create proc [dbo].[Proc_BusinessUser_SelectById]
@Id int
AS
select * FROM [BusinessUser] WHERE Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_BusinessUser_SelectList]    Script Date: 2017/11/15 20:06:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 14 2017  4:43PM*****/
create proc [dbo].[Proc_BusinessUser_SelectList]
@whereStr nvarchar(1000)
AS
DECLARE @sql NVARCHAR(2000)
SET @sql=N'SELECT * FROM [BusinessUser] '+ @whereStr
EXEC sp_executesql @sql




GO
/****** Object:  StoredProcedure [dbo].[Proc_BusinessUser_SelectPage]    Script Date: 2017/11/15 20:06:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****查询*****
*****CreateUser:yang.liao*****
*****CreateTime:11 14 2017  4:43PM*****/
create proc [dbo].[Proc_BusinessUser_SelectPage]
@rowCount INT OUTPUT,
@cloumns VARCHAR(200),
@pageIndex INT,
@pageSize INT,
@orderBy VARCHAR(20),
@where VARCHAR(300)
AS
exec Proc_SelectPageBase @rowCount output,@cloumns,'Id','BusinessUser',@pageIndex,@pageSize,@orderBy,@where

GO
/****** Object:  StoredProcedure [dbo].[Proc_BusinessUser_UpdateById]    Script Date: 2017/11/15 20:06:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*****修改*****
*****CreateUser:yang.liao*****
*****CreateTime:11 14 2017  4:43PM*****/
create proc [dbo].[Proc_BusinessUser_UpdateById]
@Id int,
@Account varchar(50),
@Password varchar(32),
@Status int,
@CreateUserAccount varchar(30),
@CreateTime DateTime
AS
update [BusinessUser] SET 
Account=@Account,
Password=@Password,
Status=@Status,
CreateUserAccount=@CreateUserAccount,
CreateTime=@CreateTime
 where Id=@Id




GO
/****** Object:  StoredProcedure [dbo].[Proc_SelectPageBase]    Script Date: 2017/11/15 20:06:34 ******/
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
/****** Object:  StoredProcedure [dbo].[Tool_CreateDALByMSEnterlibry]    Script Date: 2017/11/15 20:06:34 ******/
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
/****** Object:  StoredProcedure [dbo].[Tool_CreateModel]    Script Date: 2017/11/15 20:06:34 ******/
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
/****** Object:  StoredProcedure [dbo].[Tool_CreateProc]    Script Date: 2017/11/15 20:06:34 ******/
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
USE [master]
GO
ALTER DATABASE [BusinessBT] SET  READ_WRITE 
GO
