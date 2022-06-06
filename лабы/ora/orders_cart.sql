--------------------------------------------------------
--  File created - суббота-мая-28-2022   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table ORDERS_CART
--------------------------------------------------------

  CREATE TABLE "MIGRANT"."ORDERS_CART" 
   (	"ORD_ID" NUMBER(10,0), 
	"PROD_ID" CHAR(5 CHAR), 
	"PROD_COUNT" NUMBER(10,0)
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table ORDERS_CART
--------------------------------------------------------

  ALTER TABLE "MIGRANT"."ORDERS_CART" MODIFY ("PROD_ID" NOT NULL ENABLE);
