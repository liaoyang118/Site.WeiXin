
declare mycur cursor local for select [name] from dbo.sysobjects where xtype='P'
declare @name varchar(100) 
  
OPEN mycur 
  
FETCH NEXT from mycur into @name
  
WHILE @@FETCH_STATUS = 0  
  
BEGIN 
exec('drop PROCEDURE ' + @name) 
FETCH NEXT from mycur into @name
END 
  
CLOSE mycur