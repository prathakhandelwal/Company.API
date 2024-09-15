# Company.API
Run the Company.API as Startup project to run the APIs. Use Swagger UI to utilise the API calls. 

# Database Script - SqlServer 
IF db_id('companydb') IS NULL 
    CREATE DATABASE companydb

GO

CREATE TABLE companydb.dbo.Companies (
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255) Not Null,
	Exchange varchar(255) Not Null,
	Ticker varchar(100) Not Null,
	Isin varchar(100) Not Null UNIQUE,
	Website varchar(Max) 
); 
