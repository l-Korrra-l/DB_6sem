--------------------------------------------------------
--  File created - суббота-мая-28-2022   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table ORDERS
--------------------------------------------------------

  CREATE TABLE "MIGRANT"."ORDERS" 
   (	"ID" NUMBER(10,0), 
	"CUST" NUMBER(10,0), 
	"REPRES" NUMBER(10,0), 
	"TOTAL_COST" NUMBER(38,2), 
	"ORDER_DATE" VARCHAR2(10 CHAR), 
	"PLANNED_D_DAY" VARCHAR2(10 CHAR), 
	"PAY_DATE" VARCHAR2(10 CHAR), 
	"CUST_CONFIRM" VARCHAR2(10 CHAR), 
	"SENDED" VARCHAR2(10 CHAR), 
	"ENTER_COUNTR" VARCHAR2(10 CHAR), 
	"POST_OFICE" VARCHAR2(10 CHAR), 
	"DELIVERED" VARCHAR2(10 CHAR)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index SYS_C0010486
--------------------------------------------------------

  CREATE UNIQUE INDEX "MIGRANT"."SYS_C0010486" ON "MIGRANT"."ORDERS" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Trigger ORDERS_ID_TRIG
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE TRIGGER "MIGRANT"."ORDERS_ID_TRIG" BEFORE INSERT OR UPDATE ON ORDERS
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.ID IS NULL THEN
    SELECT  ORDERS_ID_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(ID),0) INTO v_newVal FROM ORDERS;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT ORDERS_ID_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
   -- assign the value from the sequence to emulate the identity column
   :new.ID := v_newVal;
  END IF;
END;
/
ALTER TRIGGER "MIGRANT"."ORDERS_ID_TRIG" ENABLE;
--------------------------------------------------------
--  Constraints for Table ORDERS
--------------------------------------------------------

  ALTER TABLE "MIGRANT"."ORDERS" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "MIGRANT"."ORDERS" MODIFY ("CUST" NOT NULL ENABLE);
  ALTER TABLE "MIGRANT"."ORDERS" MODIFY ("TOTAL_COST" NOT NULL ENABLE);
  ALTER TABLE "MIGRANT"."ORDERS" MODIFY ("ORDER_DATE" NOT NULL ENABLE);
  ALTER TABLE "MIGRANT"."ORDERS" MODIFY ("PLANNED_D_DAY" NOT NULL ENABLE);
  ALTER TABLE "MIGRANT"."ORDERS" ADD PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
