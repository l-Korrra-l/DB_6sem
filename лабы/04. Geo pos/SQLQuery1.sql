--import
select *from gadm36_blr_0;
select *from gadm36_blr_1;
select *from gadm36_blr_2;
go
select * from geometry_columns;
go
select*from spatial_ref_sys;
go
--
--set position
alter table offices add position int null;
ALTER TABLE offices 
ADD CONSTRAINT off_pos
FOREIGN KEY (position)
REFERENCES gadm36_blr_1(ogr_fid);


select *from OFFICES;
update OFFICES set position = 1 where id=11
update OFFICES set position = 5 where id=12
update OFFICES set position = 5 where id=13
update OFFICES set position = 4 where id=21
update OFFICES set position = 2 where id=22
go
---
--3.	Найти пересечение, исключение или объединение данных. -- поиск неверно указанных зон доставки
CREATE OR ALTER PROCEDURE intersection
as
begin
	declare @poly1 geometry = 'POLYGON ((1 1, 1 4, 4 4, 4 1, 1 1))';
	declare @poly2 geometry = 'POLYGON ((2 2, 2 6, 6 6, 6 2, 2 2))';
	declare @inters geometry = @poly1.STIntersection(@poly2);
	declare @iskl geometry = @poly1.STDifference(@poly2);
	select	@inters.STAsText() as 'Пересечение', 
			@iskl.STAsText() as 'Исключение';
end

exec intersection;

--4.	Найти расстояние между двумя объектами. -- office dist -- путь к ближайшему офису
	declare @g geometry;
	declare @h geometry;
	declare @dist float;
	select @g = ogr_geometry.STAsText() from gadm36_blr_1 where ogr_fid=1;
	select @h = ogr_geometry.STAsText() from gadm36_blr_1 where ogr_fid=3;
	select @dist = @g.STDistance(@h);
	select @dist as 'Distance', (select name_1 from gadm36_blr_1 where ogr_fid=3) as 'From', 
			name_1 as 'To' from gadm36_blr_1 where ogr_fid=1;


CREATE OR ALTER PROCEDURE  OFFICES_Dist
AS 
BEGIN
DECLARE @Pos AS INT;
declare @g geometry,@h geometry;
declare @name nvarchar(80),  @name2 nvarchar(80);
select @g = ogr_geometry.STAsText() from gadm36_blr_1 where ogr_fid=3;
DECLARE OFFICES_CUR CURSOR FOR SELECT position FROM OFFICES;
OPEN OFFICES_CUR
PRINT '-=-=-=-=-=-=-|OFFICES DISTANCE|-=-=-=-=-=-=-'
FETCH NEXT FROM OFFICES_CUR INTO @Pos
WHILE @@FETCH_STATUS = 0  
BEGIN  
select @h = ogr_geometry.STAsText() from gadm36_blr_1 where ogr_fid=@Pos;
declare @dist float;
select @dist = @g.STDistance(@h);
select @name=name_1 from gadm36_blr_1 where ogr_fid=3
select @name2=name_1 from gadm36_blr_1 where ogr_fid=@Pos
Print @name + ' - > ' + @name2 + ' ... ' + cast((@dist) as varchar) + ' ' +  cast((@Pos) as varchar)
FETCH NEXT FROM OFFICES_CUR INTO @Pos
END
PRINT '-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-='
CLOSE OFFICES_CUR
DEALLOCATE OFFICES_CUR
END

EXEC OFFICES_Dist
--5.	Изменить (уточнить) пространственный объект, добавляя дополнительные точки. -- уточнить зоны доставки
create table Position
(
	Id int identity(1, 1) primary key,
	Name nvarchar(50) not null,
	Polygon geography
);

--
DECLARE @JSON nvarchar(max), @coord nvarchar(max), @r nvarchar(max);
SELECT @JSON = BulkColumn FROM OPENROWSET (BULK 'C:\Users\User\Documents\Study_6sem\ПББВП\DB_6sem\лабы\04\whale.geojson', SINGLE_CLOB) as JSON
select @r = Reg,@coord=[Coordinates] 
from openjson(@JSON, '$')
with
(
	Reg nvarchar(50) '$.region',
    [Coordinates] nvarchar(max) '$.coordinates'
)
SELECT TOP(1) @coord+=', '+value FROM STRING_SPLIT(@coord, ',')
insert into Position values (@r, geography::STPolyFromText(concat('POLYGON((', @coord  , '))'), 4326))
select Top(1) Polygon from Position;


Create or alter procedure AddPoint (@a int, @b int)
as
begin
DECLARE @JSON nvarchar(max), @count int, @coord nvarchar(max), @frst nvarchar(max);
SELECT @JSON = BulkColumn FROM OPENROWSET (BULK 'C:\Users\User\Documents\Study_6sem\ПББВП\DB_6sem\лабы\04\whale.geojson', SINGLE_CLOB) as JSON;
select @coord = [Coordinates] --as coordinates
from openjson(@JSON, '$')
with
(
	Reg nvarchar(50) '$.region',
    [Coordinates] nvarchar(max) '$.coordinates'
) where Reg = 'test'
set @coord+= ', ' + convert(nvarchar(max), @a) + ' ' + convert(nvarchar(max), @b) + ' ' + ', ';
SELECT TOP(1) @coord+=value FROM STRING_SPLIT(@coord, ',') 
update Position set Polygon = geography::STPolyFromText(concat('POLYGON((', @coord , '))'), 4326) where name='test';
--select geography::STPolyFromText(concat('POLYGON((', @coord , '))'), 4326) as geography
end;

exec AddPoint @a = 3, @b = 5
select Top(1) Polygon from Position;

---7.	Уменьшить время поиска для данных электронных карт.
select *from gadm36_blr_2 where name_2 = 'Vawkavysk';
create index index1 ON gadm36_blr_2 (name_2);
drop index index1 ON gadm36_blr_2;