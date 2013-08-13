/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [Log4NetUser]    Script Date: 08/13/2013 22:07:21 ******/
CREATE LOGIN [Log4NetUser] WITH PASSWORD=N'XXX', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [Log4NetUser] Enable
GO

CREATE USER [Log4NetUser] FOR LOGIN [Log4NetUser] WITH DEFAULT_SCHEMA=[dbo]
GO