---
create table Report(
  id int generated always as identity,
  xml_ xmltype
);
----
create or replace function gen_XML2
return xmltype 
as
  xml xmltype;
  a      NVARCHAR2(500);
begin
  a:='select name, photo,  AUDIENCE_SCORe  from  CINEMAS';
--  inner join  EMPLOYEES
--				on  CINEMAS.ID = EMPLOYEES.CINEMA_ID 
--			  inner join  SESSIONSS
--				on SESSIONSS.ROOM_ID = CINEMAS.ID';        
  select xmlelement("XML",
      xmlelement(evalname('cinemas'),
      dbms_xmlgen.getxmltype(a)))
  into xml
  from dual;
  return xml;
end gen_XML2;

select gen_XML2 from dual;

CREATE OR REPLACE PROCEDURE INSERTXML_PROC(
    id integer,
    x IN XMLTYPE)
IS
BEGIN
  INSERT INTO Report (xml_) values (x);
  COMMIT;
END;

begin 
    INSERTXML_PROC(1, gen_XML2);
end;
select * from Report;
select r.xml_.GETSTRINGVAL() from Report r;

-----
drop procedure FINDXML;
create or replace procedure FINDXML(aa out VARCHAR2 ) 
is
begin
      select r.xml_.GETSTRINGVAL() xml
      into aa from Report r
      where r.xml_.EXISTSNODE('/XML/cinemas/ROWSET/ROW/NAME')=1 and r.id=1;
end FINDXML;

DECLARE 
    word VARCHAR2(4000); 
BEGIN
  FINDXML(:word);
  DBMS_OUTPUT.PUT_LINE(:word);
END;

----------------------------------
drop INDEX po_xmlindex_ix ;
select * from Report;
CREATE INDEX po_xmlindex_ix ON report (xml_) INDEXTYPE IS XDB.XMLIndex;
select * from Report;