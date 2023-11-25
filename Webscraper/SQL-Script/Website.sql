CREATE TABLE Website
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    City NVARCHAR(255) NOT NULL,
    [Url] NVARCHAR(255) NOT NULL
);


INSERT INTO Website (City, [URL])
VALUES ('Aalborg', 'https://www.yr.no/nb/v%C3%A6rvarsel/daglig-tabell/2-2624886/Danmark/Nordjylland/%C3%85lborg/Aalborg');
