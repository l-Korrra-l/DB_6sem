use Exec_control;
go

--clr on
exec sp_configure 'clr_enabled', 1;
reconfigure;

EXEC sp_configure 'show advanced options', 1;
RECONFIGURE;

EXEC sp_configure 'clr strict security', 0;
RECONFIGURE;
---
drop assembly Control_Assembly
create assembly Control_Assembly from 'C:\Users\User\Documents\Study_6sem\ѕЅЅ¬ѕ\DB_6sem\лабы\03. SQL CLR\Control_Assembly\Control_Assembly\bin\Debug\Control_Assembly.dll'
	WITH PERMISSION_SET = SAFE;
go

--update
alter assembly Control_Assembly
	from 'C:\Users\User\Documents\Study_6sem\ѕЅЅ¬ѕ\DB_6sem\лабы\03. SQL CLR\Control_Assembly\Control_Assembly\bin\Debug\Control_Assembly.dll'
	with permission_set = safe;
go

--procedures
create procedure AllProducts
as
external name Control_Assembly.StoredProcedures.AllProducts;
go

exec AllProducts;

--datetime
create procedure GetCurrent (@dateStart datetime, @dateEnd datetime)
as external name Control_Assembly.StoredProcedures.GetCurrent

exec GetCurrent @dateStart = '01-01-1998', @dateEnd = '01-02-2025';
exec current_ord;

create procedure GetOverdue (@dateStart datetime, @dateEnd datetime)
as external name Control_Assembly.StoredProcedures.GetOverdue

exec GetOverdue  @dateStart = '01-01-1998', @dateEnd = '01-02-2025';
exec overdue_ord;

--type

create type Prod
external name Control_Assembly.SqlUserDefinedType1;
go

declare @prod Prod
set @prod = 'а какой то что то какбутбы обед будет? - 50,2 - 2'
select @prod.ToString();
go


---func
create function  RelocateFile (@pathfrom nvarchar(256),
                                @pathto nvarchar(256))
    RETURNS bit WITH EXECUTE AS CALLER
as external name Control_Assembly.StoredProcedures.RelocateFile;

go
exec RelocateFile @pathfrom = N'C:\Users\User\Documents\Study_6sem\ѕЅЅ¬ѕ\DB_6sem\лабы\03. SQL CLR\a\test.txt', @pathto = N'C:\Users\User\Documents\Study_6sem\ѕЅЅ¬ѕ\DB_6sem\лабы\03. SQL CLR\b\test.txt';
go

--type
create type Curr
external name Control_Assembly.SqlUserDefinedType2;
go

declare @prod Curr
select @prod.ToString();
go


--update
alter assembly Control_Assembly
	from 'C:\Users\User\Documents\Study_6sem\ѕЅЅ¬ѕ\DB_6sem\лабы\03. SQL CLR\Control_Assembly\Control_Assembly\bin\Debug\Control_Assembly.dll'
	with permission_set = safe;
go

create type Cur
external name Control_Assembly.SqlUserDefinedType3;
go

declare @prod Cur
set @prod = 'а какой то что то какбутбы обед будет? & 05/01/2000 & 05/01/2025'
select @prod.ToString();
go

declare @prod Cur
set @prod = 'а какой то что то какбутбы обед будет? & 05/01/2000 &'
select @prod.ToString();
go