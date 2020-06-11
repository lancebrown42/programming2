-- --------------------------------------------------------------------------------
-- Name: Lance Brown
-- Class: IT 102
-- Abstract: Adding customers from VB
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbSQL1;     -- Get out of the master database
SET NOCOUNT ON; -- Report only errors
-- --------------------------------------------------------------------------------
-- Drop Tables
-- --------------------------------------------------------------------------------

IF OBJECT_ID( 'TCustomers' )			IS NOT NULL DROP TABLE TCustomers

-- --------------------------------------------------------------------------------
-- Step #1.1: Create Tables
-- --------------------------------------------------------------------------------

CREATE TABLE TCustomers
(
	 intCustomerID	INTEGER				NOT NULL
	,strFirstName	VARCHAR(255)		NOT NULL
	,strLastName	VARCHAR(255)		NOT NULL
	,strAddress		VARCHAR(255)		NOT NULL
	,strCity		VARCHAR(255)		NOT NULL
	,strState		VARCHAR(255)		NOT NULL
	,strZip			VARCHAR(255)		NOT NULL
	,strLoyaltyCard VARCHAR(255)		NOT NULL
	,CONSTRAINT TCustomers_PK PRIMARY KEY ( intCustomerID )
)


Select * from TCustomers