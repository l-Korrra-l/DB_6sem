---1
drop tablespace blob_lab;
CREATE TABLESPACE blob_lab
    DATAFILE 'C:\app\ora_install_user\product\12.1.0\dbhome_1\database\ts_lab2.dbf'
    SIZE 1000 m
    AUTOEXTEND ON NEXT 500M
    MAXSIZE 2000M
    EXTENT MANAGEMENT LOCAL;

--2
create directory bfile_dir as 'C:\pics\';
drop DIRECTORY bfile_dir;
--3
CREATE USER lob_user IDENTIFIED BY 12345
    DEFAULT TABLESPACE blob_lab QUOTA UNLIMITED ON blob_lab
    ACCOUNT UNLOCK;
    
grant create table to lob_user; 
grant create session, CREATE ANY DIRECTORY, DROP ANY DIRECTORY to lob_user;
grant all privileges to lob_user;
--5
drop table blob_t;
create table blob_t (
    id number primary key not null,
    foto blob not null,
    doc bfile
    );

--6
insert into blob_t
    values (3,
            utl_raw.cast_to_raw('Ñ:\pics\pic.jpeg'),
            BFILENAME( 'BFILE_DIR', 'doc.docx'));


declare 
fHnd bfile; 
b blob; 
srcOffset integer := 1; 
dstOffset integer := 1; 
begin 
dbms_lob.CreateTemporary( b, true ); 
fHnd := BFilename( 'BFILE_DIR', 'pic.pnug' ); 
dbms_lob.FileOpen( fHnd, DBMS_LOB.FILE_READONLY ); 
dbms_lob.LoadFromFile( b, fHnd, DBMS_LOB.LOBMAXSIZE, dstOffset, srcOffset ); 
insert into blob_t values(2, b, BFILENAME( 'BFILE_DIR', 'doc.txt')); 
commit; 
dbms_lob.FileClose( fHnd ); 
end;
  
--check
select * from blob_t;
select * from all_directories;
update blob_t set doc = BFILENAME( 'bfile_dir', 'doc.txt') where id =3;