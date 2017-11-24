GO
TRUNCATE TABLE dbo.Article;
TRUNCATE TABLE dbo.GloblaToken;
TRUNCATE TABLE dbo.GroupSend;
TRUNCATE TABLE dbo.KeyWordsReply;
TRUNCATE TABLE dbo.Material;
TRUNCATE TABLE dbo.Menu;
TRUNCATE TABLE dbo.SystemUser;
TRUNCATE TABLE dbo.[User];
TRUNCATE TABLE dbo.UserGroup;
TRUNCATE TABLE dbo.UserMessage;
TRUNCATE TABLE dbo.UserTag;
GO
INSERT INTO dbo.Menu
        ( ParentId ,
          Name ,
          Type ,
          Value ,
          CreateTime ,
          LevelCode ,
          Status
        )
VALUES  ( 0 , -- ParentId - int
          N'菜单根节点' , -- Name - nvarchar(14)
          '' , -- Type - varchar(30)
          N'' , -- Value - nvarchar(200)
          GETDATE() , -- CreateTime - datetime
          '100' , -- LevelCode - varchar(50)
          0  -- Status - int
        );
INSERT INTO dbo.SystemUser
        ( AppId ,
          Account ,
          Password ,
          CreateTime ,
          CreateUserName ,
          AccountState
        )
VALUES  ( 'wx25491e8ba573f372' , -- AppId - varchar(128)
          'admin' , -- Account - varchar(30)
          'e10adc3949ba59abbe56e057f20f883e' , -- Password - varchar(32)
          GETDATE() , -- CreateTime - datetime
          N'admin' , -- CreateUserName - nvarchar(30)
          0  -- AccountState - int
        );