--1
INSERT into ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (1, 2117, 101, 100, '2022-03-08', '2022-03-09');
INSERT INTO ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (2,2111,101,500,'2022-03-08', '2022-03-09' );
INSERT into ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (3, 2118, 105, 100, '2022-04-08', '2022-03-09');
INSERT INTO ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (4,2119,105,500,'2022-05-08', '2022-03-09' );
INSERT into ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY, DELIVERED) VALUES (5, 2117, 101, 100, '2022-03-08', '2022-03-09', '2022-03-08');
INSERT INTO ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY, DELIVERED) VALUES (6,2111,101,500,'2022-03-08', '2022-03-09' , '2022-06-09');
INSERT into ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY, DELIVERED) VALUES (7, 2118, 101, 100, '2022-04-08', '2022-04-09', '2022-04-09');
INSERT INTO ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY, DELIVERED) VALUES (8,2119,105,500,'2022-05-08', '2022-05-09' , '2022-06-09');
INSERT into ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (9, 2117, 107, 100, '2022-03-08', '2022-03-09');
INSERT INTO ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (10,2111,101,500,'2022-03-08', '2022-03-09' );
INSERT into ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (13, 2118, 101, 100, '2022-04-08', '2022-03-09');
INSERT INTO ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (14,2119,105,500,'2022-05-08', '2022-03-09' );
INSERT into ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY, DELIVERED) VALUES (15, 2117, 105, 100, '2022-03-08', '2022-03-09', '2022-03-08');
INSERT INTO ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY, DELIVERED) VALUES (16,2111,105,500,'2022-03-08', '2022-03-09' , '2022-06-09');
INSERT into ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY, DELIVERED) VALUES (17, 2118, 101, 100, '2022-04-08', '2022-04-09', '2022-04-09');
INSERT INTO ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY, DELIVERED) VALUES (18,2119,105,500,'2022-05-08', '2022-05-09' , '2022-06-09');
INSERT into ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (19, 2117, 107, 100, '2022-03-08', '2022-03-09');
INSERT INTO ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (20,2111,107,500,'2022-03-08', '2022-03-09' );
INSERT into ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (21, 2117, 105, 100, '2022-03-08', '2022-03-09');
INSERT INTO ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (22,2111,105,500,'2022-03-08', '2022-03-09' );
INSERT into ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (23, 2118, 105, 100, '2022-04-08', '2022-03-09');
INSERT INTO ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (24,2119,105,500,'2022-05-08', '2022-03-09' );
INSERT into ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY, DELIVERED) VALUES (25, 2117, 105, 100, '2022-03-08', '2022-03-09', '2022-03-08');
INSERT INTO ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY, DELIVERED) VALUES (26,2111,105,500,'2022-03-08', '2022-03-09' , '2022-06-09');
INSERT into ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY, DELIVERED) VALUES (27, 2118, 105, 100, '2022-04-08', '2022-04-09', '2022-04-09');
INSERT INTO ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY, DELIVERED) VALUES (28,2119,105,500,'2022-05-08', '2022-05-09' , '2022-06-09');
INSERT into ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (29, 2117, 105, 100, '2022-03-08', '2022-03-09');
INSERT INTO ORDERS(ID,CUST, REPRES, TOTAL_COST, ORDER_DATE, PLANNED_D_DAY) VALUES (30,2111,105,500,'2022-03-08', '2022-03-09' );
--•	количество вовремя выполненных поручений;
select count(*) from orders where delivered <= planned_d_day and delivered >= order_date;
--за период

select count(*) from orders where (TO_DATE(delivered, 'YYYY-MM-DD') <= TO_DATE(planned_d_day, 'YYYY-MM-DD')) and 
            (TO_DATE(delivered, 'YYYY-MM-DD') >= TO_DATE('2022-03-08', 'YYYY-MM-DD') and TO_DATE(delivered, 'YYYY-MM-DD') <= TO_DATE('2022-04-08', 'YYYY-MM-DD'));

--•	сравнение их с общим количеством выполненных поручений (в %);
declare 
st_t char(20) := TO_DATE('2022-03-08', 'YYYY-MM-DD');
en_t char(20) :=TO_DATE('2022-04-08', 'YYYY-MM-DD');
c_t FLOAT := 0;
c_t1 FLOAT := 0;
begin
select  count(*) into c_t 
            from orders o 
        where (TO_DATE(o.delivered, 'YYYY-MM-DD') >= TO_DATE('2022-01-01', 'YYYY-MM-DD') and TO_DATE(o.delivered, 'YYYY-MM-DD') <= TO_DATE('2022-04-08', 'YYYY-MM-DD'));
select  count(*) into c_t1 from orders a 
        where  a.delivered is not null;
    dbms_output.put_line(100*c_t/c_t1 || '%');
end;
--•	сравнение с общим количеством не выполненных поручений (в %).
declare 
st_t char(20) := TO_DATE('2022-03-08', 'YYYY-MM-DD');
en_t char(20) :=TO_DATE('2022-04-08', 'YYYY-MM-DD');
c_t FLOAT := 0;
c_t1 FLOAT := 0;
begin
select  count(*) into c_t 
            from orders o 
        where (TO_DATE(o.delivered, 'YYYY-MM-DD') >= TO_DATE('2022-01-01', 'YYYY-MM-DD') and TO_DATE(o.delivered, 'YYYY-MM-DD') <= TO_DATE('2022-04-08', 'YYYY-MM-DD'));
select  count(*) into c_t1 from orders a 
        where  a.delivered is null;
    dbms_output.put_line(100*c_t/c_t1 || '%');
end;
--3
--Продемонстрируйте применение функции ранжирования ROW_NUMBER() для разбиения результатов запроса 
select* from orders;
select cust, 
      repres,  
      total_cost, 
      order_date,
      row_number() over (partition by cust Order By cust  ) as rn from orders;
--4
--4.	Продемонстрируйте применение функции ранжирования ROW_NUMBER() для удаления дубликатов.

      
select count(*)
    from(
        select cust, 
      repres,  
      total_cost, 
      order_date,
      row_number() over (partition by cust Order By cust  ) as rn from orders
        )
    where rn>1

delete from orders
where rowid in(
    select rwid from(
    select 
    rowid rwid,
    cust, 
      repres,  
      total_cost, 
      order_date,
      row_number() over (partition by cust, repres,  
      total_cost, 
      order_date Order By cust  ) as rn from orders
        ) 
        where rn>1
)
select* from orders;
select repres,COUNT(*)  over(partition by repres) AS s_coun from orders;
--Вернуть для каждого сотрудника количество выполненных и не выполненных заданий за последние 6 месяцев помесячно.
select * from salesreprs;
select distinct(name),COUNT(*)  over(partition by name) AS s_count  from salesreprs o  join orders a 
            on o.id = a.repres
            where TO_DATE(delivered, 'YYYY-MM-DD') >= TO_DATE('2022-01-01', 'YYYY-MM-DD');
select distinct(name),COUNT(*)  over(partition by name) AS s_count  from salesreprs o  join orders a 
            on o.id = a.repres
            where TO_DATE(planned_d_day, 'YYYY-MM-DD') >= TO_DATE('2022-01-01', 'YYYY-MM-DD') and a.delivered is null;

--Какой сотрудник выполнил наибольшее число поручений определенного вида? Вернуть для всех видов.
select name,COUNT(*)  over(partition by name) AS s_count  from salesreprs o  join orders a 
            on o.id = a.repres
            where TO_DATE(delivered, 'YYYY-MM-DD') >= TO_DATE('2022-01-01', 'YYYY-MM-DD')
            order by s_count DESC
            FETCH NEXT 1 ROWS ONLY;
