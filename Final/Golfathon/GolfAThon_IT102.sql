--Lance Brown
--Assignment 8
--7/25/20
-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbSQL1;     -- Get out of the master database
SET NOCOUNT ON; -- Report only errors

-- --------------------------------------------------------------------------------
-- Drop Tables
-- --------------------------------------------------------------------------------
IF OBJECT_ID( 'TGolferEventYearSponsors' )		IS NOT NULL DROP TABLE	TGolferEventYearSponsors
IF OBJECT_ID( 'TGolferEventYears' )				IS NOT NULL DROP TABLE	TGolferEventYears
IF OBJECT_ID( 'TEventYears' )					IS NOT NULL DROP TABLE	TEventYears
IF OBJECT_ID( 'TGolfers' )						IS NOT NULL DROP TABLE	TGolfers
IF OBJECT_ID( 'TGenders' )						IS NOT NULL DROP TABLE	TGenders
IF OBJECT_ID( 'TShirtSizes' )					IS NOT NULL DROP TABLE	TShirtSizes
IF OBJECT_ID( 'TPaymentTypes' )					IS NOT NULL DROP TABLE	TPaymentTypes
IF OBJECT_ID( 'TSponsors' )						IS NOT NULL DROP TABLE	TSponsors
IF OBJECT_ID( 'TSponsorTypes' )					IS NOT NULL DROP TABLE	TSponsorTypes

-- --------------------------------------------------------------------------------
-- Drop sprocs
-- --------------------------------------------------------------------------------
IF OBJECT_ID( 'uspAddGolfer' )					IS NOT NULL DROP PROCEDURE	uspAddGolfer
IF OBJECT_ID( 'uspAddEvent' )					IS NOT NULL DROP PROCEDURE	uspAddEvent

IF OBJECT_ID( 'uspAddGolferEventYear' )					IS NOT NULL DROP PROCEDURE	uspAddGolferEventYear

IF OBJECT_ID( 'uspAddGolferAndEventYear' )					IS NOT NULL DROP PROCEDURE	uspAddGolferAndEventYear
IF OBJECT_ID( 'uspAddGolferSponsor' )					IS NOT NULL DROP PROCEDURE	uspAddGolferSponsor

IF OBJECT_ID( 'vAvailableGolfers' )					IS NOT NULL DROP VIEW	vAvailableGolfers
IF OBJECT_ID( 'vEventGolfers' )					IS NOT NULL DROP VIEW	vEventGolfers
IF OBJECT_ID( 'vGolferSponsors' )					IS NOT NULL DROP VIEW	vGolferSponsors

-- --------------------------------------------------------------------------------
-- Step #1: Create Tables
-- --------------------------------------------------------------------------------
CREATE TABLE TEventYears
(
	 intEventYearID		INTEGER		
	,intEventYear		INTEGER			NOT NULL
	,CONSTRAINT TEventYears_PK PRIMARY KEY ( intEventYearID	)
)

CREATE TABLE TGenders
(
	 intGenderID		INTEGER 			NOT NULL
	,strGenderDesc			VARCHAR(50)		NOT NULL
	,CONSTRAINT TGenders_PK PRIMARY KEY ( intGenderID )
)

CREATE TABLE TShirtSizes
(
	 intShirtSizeID			INTEGER			NOT NULL
	,strShirtSizeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TShirtSizes_PK PRIMARY KEY ( intShirtSizeID )
)

CREATE TABLE TGolfers
(
	 intGolferID		INTEGER	
	,strFirstName		VARCHAR(50)		NOT NULL
	,strLastName		VARCHAR(50)		NOT NULL
	,strStreetAddress	VARCHAR(50)		NOT NULL
	,strCity			VARCHAR(50)		NOT NULL
	,strState			VARCHAR(50)		NOT NULL
	,strZip				VARCHAR(50)		NOT NULL
	,strPhoneNumber		VARCHAR(50)		NOT NULL
	,strEmail			VARCHAR(50)		NOT NULL
	,intShirtSizeID		INTEGER			NOT NULL
	,intGenderID		INTEGER			NOT NULL
	,CONSTRAINT TGolfers_PK PRIMARY KEY ( intGolferID )
)

CREATE TABLE TSponsors
(
	 intSponsorID		INTEGER			NOT NULL
	,strFirstName		VARCHAR(50)		NOT NULL
	,strLastName		VARCHAR(50)		NOT NULL
	,strStreetAddress	VARCHAR(50)		NOT NULL
	,strCity			VARCHAR(50)		NOT NULL
	,strState			VARCHAR(50)		NOT NULL
	,strZip				VARCHAR(50)		NOT NULL
	,strPhoneNumber		VARCHAR(50)		NOT NULL
	,strEmail			VARCHAR(50)		NOT NULL
	,CONSTRAINT TSponsors_PK PRIMARY KEY ( intSponsorID )
)

CREATE TABLE TPaymentTypes
(
	 intPaymentTypeID		INTEGER			NOT NULL
	,strPaymentTypeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TPaymentTypes_PK PRIMARY KEY ( intPaymentTypeID )
)

CREATE TABLE TGolferEventYears
(
	 intGolferEventYearID	INTEGER IDENTITY		
	,intGolferID			INTEGER			NOT NULL
	,intEventYearID			INTEGER			NOT NULL
	,CONSTRAINT TGolferEventYears_UQ UNIQUE ( intGolferID, intEventYearID )
	,CONSTRAINT TGolferEventYears_PK PRIMARY KEY ( intGolferEventYearID )
)


CREATE TABLE TGolferEventYearSponsors
(
	 intGolferEventYearSponsorID	INTEGER IDENTITY			NOT NULL
	,intGolferID					INTEGER			NOT NULL
	,intEventYearID					INTEGER			NOT NULL
	,intSponsorID					INTEGER			NOT NULL
	,monPledgeAmount				MONEY			NOT NULL
	,intSponsorTypeID				INTEGER			NOT NULL
	,intPaymentTypeID				INTEGER			NOT NULL
	,blnPaid						BIT			NOT NULL
	,CONSTRAINT TGolferEventYearSponsors_UQ UNIQUE ( intGolferID, intEventYearID, intSponsorID )
	,CONSTRAINT TGolferEventYearSponsors_PK PRIMARY KEY ( intGolferEventYearSponsorID )
)

CREATE TABLE TSponsorTypes
(
	 intSponsorTypeID		INTEGER			NOT NULL
	,strSponsorTypeDesc		VARCHAR(50)		NOT NULL
	,CONSTRAINT TSponsorTypes_PK PRIMARY KEY ( intSponsorTypeID )
)


-- --------------------------------------------------------------------------------
-- Step #2: Identify and Create Foreign Keys
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column(s)
-- -	-----							------						---------
-- 1	TGolfers						TGenders					intGenderID
-- 2	TGolfers						TShirtSizes					intShirtSizeID
-- 3    TGolferEventYears				TGolfers					intGolferID
-- 4	TGolferEventYearSponsors		TGolferEventYears			intGolferID, intEventYearID
-- 5	TGolferEventYears				TEventYears					intEventYearID
-- 6    TGolferEventYearSponsors		TSponsors					intSponsorID
-- 7	TGolferEventYearSponsors		TSponsorTypes				intSponsorTypeID
-- 8	TGolferEventYearSponsors		TPaymentTypes				intPaymentTypeID

-- 1
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TGenders_FK
FOREIGN KEY ( intGenderID ) REFERENCES TGenders ( intGenderID )

-- 2
ALTER TABLE TGolfers ADD CONSTRAINT TGolfers_TShirtSizes_FK
FOREIGN KEY ( intShirtSizeID ) REFERENCES TShirtSizes ( intShirtSizeID )

-- 3
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TGolfers_FK
FOREIGN KEY ( intGolferID ) REFERENCES TGolfers ( intGolferID )

-- 4
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TGolferEventYears_FK
FOREIGN KEY ( intGolferID, intEventYearID ) REFERENCES TGolferEventYears ( intGolferID, intEventYearID )

-- 5
ALTER TABLE TGolferEventYears ADD CONSTRAINT TGolferEventYears_TEventYears_FK
FOREIGN KEY ( intEventYearID ) REFERENCES TEventYears ( intEventYearID )

-- 6
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsors_FK
FOREIGN KEY ( intSponsorID ) REFERENCES TSponsors ( intSponsorID )

-- 7
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TSponsorTypes_FK
FOREIGN KEY ( intSponsorTypeID ) REFERENCES TSponsorTypes ( intSponsorTypeID )

-- 8
ALTER TABLE TGolferEventYearSponsors ADD CONSTRAINT TGolferEventYearSponsors_TPaymentTypes_FK
FOREIGN KEY ( intPaymentTypeID ) REFERENCES TPaymentTypes ( intPaymentTypeID )

-- --------------------------------------------------------------------------------
-- Step #3: Add data to Gender
-- --------------------------------------------------------------------------------

INSERT INTO TGenders( intGenderID, strGenderDesc)
VALUES		(1, 'Female')
		,(2, 'Male')

---- --------------------------------------------------------------------------------
---- Step #4: Add men's and women's shirt sizes
---- --------------------------------------------------------------------------------

INSERT INTO TShirtSizes( intShirtSizeID, strShirtSizeDesc)
VALUES		(1, 'Mens Small')
		,(2, 'Mens Medium')
		,(3, 'Mens Large')
		,(4, 'Mens XLarge')
		,(5, 'Womens Small')
		,(6, 'Womens Medium')
		,(7, 'Womens Large')
		,(8, 'Womens XLarge')

---- --------------------------------------------------------------------------------
---- Step #5: Add years
---- --------------------------------------------------------------------------------
INSERT INTO TEventYears ( intEventYearID, intEventYear )
	VALUES	 ( 1, 2015)
		,( 2, 2016)
		,(3, 2017)

---- --------------------------------------------------------------------------------
---- Step #6: Add sponsor types
---- --------------------------------------------------------------------------------
INSERT INTO TSponsorTypes ( intSponsorTypeID, strSponsorTypeDesc)
	VALUES (1, 'Parent')
		,(2, 'Alumni')
		,(3, 'Friend')
		,(4, 'Business')

---- --------------------------------------------------------------------------------
---- Step #7: Add payment types
---- --------------------------------------------------------------------------------
INSERT INTO TPaymentTypes ( intPaymentTypeID, strPaymentTypeDesc)
	VALUES (1, 'Check')
		,(2, 'Cash')
		,(3, 'Credit Card')
---- --------------------------------------------------------------------------------
---- Step #8: Add sponsors
---- --------------------------------------------------------------------------------

INSERT INTO TSponsors ( intSponsorID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail )
VALUES	 ( 1, 'Jim', 'Smith', '1979 Wayne Trace Rd.', 'Willow', 'OH', '42368', '5135551212', 'jsmith@yahoo.com' )
		,( 2, 'Sally', 'Jones', '987 Mills Rd.', 'Cincinnati', 'OH', '45202', '5135551234', 'sjones@yahoo.com' )

---- --------------------------------------------------------------------------------
---- Step #9: Add golfers
---- --------------------------------------------------------------------------------

INSERT INTO TGolfers ( intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID )
VALUES	 ( 1, 'Bill', 'Goldstein', '156 Main St.', 'Mason', 'OH', '45040', '5135559999', 'bGoldstein@yahoo.com', 1, 2 )
		,( 2, 'Tara', 'Everett', '3976 Deer Run', 'West Chester', 'OH', '45069', '5135550101', 'teverett@yahoo.com', 6, 1 )

---- --------------------------------------------------------------------------------
---- Step # 10: Add Golfers and sponsors to link them
---- --------------------------------------------------------------------------------

INSERT INTO TGolferEventYears ( intGolferID, intEventYearID)
	VALUES ( 1, 1)
		,( 2, 1)
		,( 1, 2)
		,( 2, 2)

---- --------------------------------------------------------------------------------
---- Step # 10: Add Golfers and sponsors to link them
---- --------------------------------------------------------------------------------
INSERT INTO TGolferEventYearSponsors ( intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, blnPaid )
VALUES	 ( 1, 1, 1, 25.00, 1, 1, 1 )
		,( 1, 1, 2, 25.00, 1, 1, 1 )
	

GO
CREATE VIEW vAvailableGolfers
AS
SELECT
	TG.intGolferID
	,TG.strLastName
	,TE.intEventYearID
FROM
	TGolfers as TG
	,TEventYears as TE
WHERE
	TG.intGolferID NOT IN (SELECT intGolferID from TGolferEventYears)
	

GO
CREATE VIEW vEventGolfers
AS
SELECT
	TG.intGolferID
	,TG.strLastNAme
	,TE.intEventYearID
FROM
	TGolfers as TG
	,TEventYears as TE
	,TGolferEventYears as TGE
WHERE
	TG.intGolferID = TGE.intGolferID
AND	TE.intEventYearID = TGE.intEventYearID

GO
CREATE VIEW vGolferSponsors
AS
SELECT
	TG.intGolferID 
	,TG.strLastName 
	,TE.intEventYearID
	,TS.intSponsorID
	,TS.strLastName as SponsorName
	,TGES.monPledgeAmount
	,TGES.intSponsorTypeID 
	,TGES.intPaymentTypeID 
	,TGES.blnPaid 
	FROM
	TGolfers as TG
	,TEventYears as TE
	,TSponsors as TS
	,TGolferEventYearSponsors as TGES
WHERE
	TG.intGolferID = TGES.intGolferID
AND	TE.intEventYearID=TGES.intEventYearID
AND TS.intSponsorID = TGES.intSponsorID

GO
CREATE PROCEDURE uspAddGolfer
		@intGolferID as INTEGER OUTPUT
		,@strFirstName as VARCHAR(255)
		,@strLastName as VARCHAR(255)
		,@strStreetAddress as VARCHAR(255)
		,@strCity as VARCHAR(255)
		,@strState as VARCHAR(255)
		,@strZip as VARCHAR(255)
		,@strPhoneNumber as VarChar(255)
		,@strEmail as VARCHAR(255)
		,@intShirtSizeID as INTEGER
		,@intGenderID as INTEGER
AS
SET XACT_ABORT ON

BEGIN TRANSACTION

	SELECT @intGolferID = MAX(intGolferID) + 1
	FROM TGolfers(TABLOCKX)

	SELECT @intGolferID = COALESCE(@intGolferID, 1)

	--insert data
	INSERT INTO TGolfers(intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID)
	VALUES (@intGolferID, @strFirstName, @strLastName, @strStreetAddress, @strCity, @strState, @strZip, @strPhoneNumber, @strEmail, @intShirtSizeID, @intGenderID)

COMMIT TRANSACTION

GO
CREATE PROCEDURE uspAddEvent
		@intEventYearID as INTEGER OUTPUT
		,@intEventYear as INTEGER
AS
SET XACT_ABORT ON

BEGIN TRANSACTION

	SELECT @intEventYearID = MAX(intEventYearID) + 1
	FROM TEventYears(TABLOCKX)

	SELECT @intEventYearID = COALESCE(@intEventYearID, 1)

	--insert data
	INSERT INTO TEventYears(intEventYearID, intEventYear)
	VALUES (@intEventYearID, @intEventYear)

COMMIT TRANSACTION

GO
CREATE PROCEDURE uspAddGolferEventYear
		@intGolferEventYearID  as INTEGER OUTPUT
		,@intGolferID as INTEGER
		,@intEventYearID as INTEGER
AS
SET XACT_ABORT ON

BEGIN TRANSACTION

	--insert data
	INSERT INTO TGolferEventYears WITH (TABLOCKX) (intGolferID, intEventYearID)
	VALUES (@intGolferID, @intEventYearID)

COMMIT TRANSACTION

GO
CREATE PROCEDURE uspAddGolferAndEventYear
		@intGolferEventYearID as INTEGER OUTPUT
		,@strFirstName		AS VARCHAR(50)		
		,@strLastName		AS VARCHAR(50)		
		,@strStreetAddress	AS VARCHAR(50)		
		,@strCity			AS VARCHAR(50)		
		,@strState			AS VARCHAR(50)		
		,@strZip			AS VARCHAR(50)		
		,@strPhoneNumber	AS VARCHAR(50)		
		,@strEmail			AS VARCHAR(50)		
		,@intShirtSizeID	AS INTEGER			
		,@intGenderID		AS INTEGER			
		,@intEventYear		AS INTEGER			
AS
SET XACT_ABORT ON

BEGIN TRANSACTION
	DECLARE @intGolferID as INTEGER
	DECLARE @intEventYearID as INTEGER
	EXECUTE uspAddGolfer @intGolferID OUTPUT, @strFirstName, @strLastName, @strStreetAddress, @strCity, @strState, @strZip, @strPhoneNumber, @strEmail, @intShirtSizeID, @intGenderID
	
	EXECUTE uspAddEvent @intEventYearID OUTPUT, @intEventYear

	EXECUTE uspAddGolferEventYear @intGolferEventYearID OUTPUT, @intGolferID, @intEventYearID
	--insert data
	INSERT INTO TGolferEventYears with (TABLOCKX) (intGolferID, intEventYearID)
	VALUES (@intGolferID, @intEventYearID)

COMMIT TRANSACTION




SELECT intGolferID, strLastName FROM vAvailableGolfers WHERE intEventYearID = 2


SELECT
	TG.intGolferID
	,TG.strLastName
FROM
	TGolfers as TG
WHERE
	TG.intGolferID NOT IN (SELECT intGolferID from TGolferEventYears)
	--AND TE.intEventYearID = TGE.intEventYearID

GO--intGolferEventYearSponsorID, intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, blnPaid
CREATE PROCEDURE uspAddGolferSponsor
		@intGolferEventYearSponsorID as INTEGER OUTPUT		
		,@intGolferID as INTEGER
		,@intEventYearID as INTEGER
		,@intSponsorID as Integer
		,@monPledgeAmount	AS MONEY		
		,@intSponsorTypeID	AS INTEGER		
		,@intPaymentTypeID	AS INTEGER		
		,@blnPaid			AS BIT		
				
AS
SET XACT_ABORT ON

BEGIN TRANSACTION

	
	
	--EXECUTE uspAddGolferSponsor @intGolferEventYearSponsorID OUTPUT, @intGolferID, @intEventYearID, @intSponsorID, @monPledgeAmount, @intSponsorTypeID, @intPaymentTypeID, @blnPaid
	--insert data
	INSERT INTO TGolferEventYearSponsors with (TABLOCKX) (intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, blnPaid)
	VALUES (@intGolferID, @intEventYearID, @intSponsorID, @monPledgeAmount, @intSponsorTypeID, @intPaymentTypeID, @blnPaid)

COMMIT TRANSACTION	
