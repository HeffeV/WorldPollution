drop table [ContinentPollution],[CountryPollution],[Country],[Continent]

CREATE TABLE [Continent] (
	Id int IDENTITY(1,1) NOT NULL,
	Name varchar(512) NOT NULL,
  CONSTRAINT [PK_CONTINENT] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [ContinentPollution] (
	Id int NOT NULL IDENTITY(1,1),
	ContinentId int NOT NULL,
	Year int NOT NULL,
	Pollution float NOT NULL
)
GO
CREATE TABLE [Country] (
	Id int NOT NULL IDENTITY(1,1),
	Name varchar(512) NOT NULL,
	ContinentId int NOT NULL,
	CountryCode varchar(512) NOT NULL,
	Population int NOT NULL,
	Area int NOT NULL,
	Industry float NOT NULL,
	Agriculture float NOT NULL,
	PopDensity float NOT NULL,
	Literacy float NOT NULL,
  CONSTRAINT [PK_COUNTRY] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [CountryPollution] (
	Id int NOT NULL IDENTITY(1,1),
	CountryId int NOT NULL,
	Year int NOT NULL,
	Pollution float NOT NULL
)
GO

ALTER TABLE [ContinentPollution] WITH CHECK ADD CONSTRAINT [ContinentPollution_fk0] FOREIGN KEY ([ContinentId]) REFERENCES [Continent]([Id])
ON UPDATE CASCADE on delete cascade
GO
ALTER TABLE [ContinentPollution] CHECK CONSTRAINT [ContinentPollution_fk0]
GO

ALTER TABLE [Country] WITH CHECK ADD CONSTRAINT [Country_fk0] FOREIGN KEY ([ContinentId]) REFERENCES [Continent]([Id])
ON UPDATE CASCADE on delete cascade
GO
ALTER TABLE [Country] CHECK CONSTRAINT [Country_fk0]
GO

ALTER TABLE [CountryPollution] WITH CHECK ADD CONSTRAINT [CountryPollution_fk0] FOREIGN KEY ([CountryId]) REFERENCES [Country]([Id])
ON UPDATE CASCADE on delete cascade
GO
ALTER TABLE [CountryPollution] CHECK CONSTRAINT [CountryPollution_fk0]
GO

