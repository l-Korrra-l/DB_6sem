drop table offices
CREATE TABLE OFFICES
     (	
		node hierarchyid PRIMARY KEY CLUSTERED,
		LEVEL as node.GetLevel() Persisted,
		OFFICE_ID INTEGER NOT NULL,
        CITY VARCHAR(15) NOT NULL,
		REGION VARCHAR(10) NOT NULL,
		SALES DECIMAL(9,2) NOT NULL,
		position int null);

--/1
INSERT INTO OFFICES(node,office_id, city, region, sales) VALUES(hierarchyid::GetRoot(),22,'Denver','Western',186042.00);

--/1/1
declare @id hierarchyid;
select @id= max(node) from OFFICES where node.GetAncestor(1) = hierarchyid::GetRoot();
insert into OFFICES(node,office_id, city, region, sales)
VALUES(hierarchyid::GetRoot().GetDescendant(@id, null),11,'New York','Eastern',692637.00);

declare @id hierarchyid;
select @id= max(node) from OFFICES where node.GetAncestor(1) = hierarchyid::GetRoot();
insert into OFFICES(node,office_id, city, region, sales)
VALUES(hierarchyid::GetRoot().GetDescendant(@id, null),12,'Chicago','Eastern',735042.00);

INSERT INTO OFFICES(node,office_id, city, region, sales) VALUES(21,'Los Angeles','Western',835915.00);

select *from OFFICES;
update OFFICES set position = 1 where OFFICE_id=11
update OFFICES set position = 5 where OFFICE_id=12
update OFFICES set position = 5 where OFFICE_id=13
update OFFICES set position = 4 where OFFICE_id=21
update OFFICES set position = 2 where OFFICE_id=22
go

----
create or alter procedure gethierarchyById @id hierarchyid
as
begin
select node.ToString()[string], node.GetLevel()[level], * from OFFICES where node.IsDescendantOf(@id) = 1;
end;

exec gethierarchyById '/';
exec gethierarchyById '/2/';
---
go
create or alter procedure insertValue
@hid hierarchyid, @id int, @city nvarchar(15), @reg nvarchar(10), @sales DECIMAL(9,2)
as
begin
declare @LCV hierarchyid
begin transaction
		select @LCV=max(node)
		from OFFICES where
		node.GetAncestor(1)=@HID;
		INSERT INTO OFFICES(node,office_id, city, region, sales)
					VALUES (@HID.GetDescendant(@LCV,NULL), @id,
					@city, @reg, @sales);
					commit;
end;

exec insertValue '/2/1/2/', 13,'Atlanta','Eastern1',367911.00;
exec gethierarchyById '/';
-----------------
go
create or alter procedure MoveBranche  @oldparent hierarchyid,
							@newparent hierarchyid
as begin
DECLARE children_cursor CURSOR FOR  
	SELECT node FROM OFFICES
		WHERE node.GetAncestor(1) = @OldParent; 
		
DECLARE @ChildId hierarchyid;  
	OPEN children_cursor  
		FETCH NEXT FROM children_cursor INTO @ChildId;	
		
WHILE @@FETCH_STATUS = 0  
BEGIN  
START:  
    DECLARE @NewId hierarchyid;  
    SELECT @NewId = @NewParent.GetDescendant(MAX(node), NULL)  
    FROM OFFICES WHERE node.GetAncestor(1) = @NewParent;  

    UPDATE OFFICES
    SET node = node.GetReparentedValue(@ChildId, @NewId)  
		WHERE node.IsDescendantOf(@ChildId) = 1;  

    IF @@error <> 0 GOTO START  
        FETCH NEXT FROM children_cursor INTO @ChildId;  
END  
CLOSE children_cursor;  
DEALLOCATE children_cursor;  
end;
go

exec MoveBranche '/2/1/2/', '/1/';
exec gethierarchyById '/';
---