--1
SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'SA%'

--2
SELECT FirstName,LastName FROM Employees
WHERE LastName LIKE '%ei%'

--3
SELECT FirstName FROM Employees
WHERE (DepartmentID = 3 OR DepartmentID = 10) AND YEAR(HireDate) BETWEEN 1995 AND 2005

--4
SELECT FirstName,LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--5
SELECT Name FROM Towns
WHERE LEN(Name) = 5 OR LEN(Name) = 6  
ORDER BY Name ASC

--6
SELECT TownId,Name FROM Towns
WHERE Name LIKE 'M%' OR Name LIKE 'K%' OR Name LIKE 'B%' OR Name LIKE 'E%'
ORDER BY Name ASC 

--7
SELECT TownId,Name FROM Towns
WHERE Name NOT LIKE 'R%' AND
Name NOT LIKE 'B%' AND
Name NOT LIKE 'D%'
ORDER BY Name ASC

--8
 CREATE VIEW V_EmployeesHiredAfter2000 AS
 SELECT FirstName,LastName FROM Employees
 WHERE YEAR(HireDate) > 2000
 
 --9
  SELECT FirstName,LastName FROM Employees
 WHERE LEN(LastName) = 5

--10
SELECT CountryName,IsoCode FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode ASC

--11
SELECT p.PeakName, r.RiverName, LOWER(CONCAT(p.PeakName,SUBSTRING(r.RiverName,2,LEN(r.RiverName)))) AS Mix 
FROM[dbo].[Peaks] AS p, [dbo].[Rivers] AS r
WHERE RIGHT(p.PeakName,1) = LEFT(r.RiverName,1) 
ORDER BY Mix ASC

--12
SELECT TOP 50 Name AS Game, 
FORMAT(Start,'yyyy-MM-dd') FROM Games
--CONVERT(varchar(10),Start,126) FROM Games
WHERE YEAR(Start) > 2010 AND YEAR(Start) < 2013
ORDER BY Start ASC, Game ASC

--13
SELECT Username, (SUBSTRING(Email,CHARINDEX('@',Email) + 1,LEN(Email))) 
AS 'Email Provider' FROM Users
ORDER BY [Email Provider] ASC, Username ASC

--14
SELECT UserName,IpAddress FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username ASC

--15
SELECT Name,
(CASE 
  WHEN DATEPART(HH,Start) >= 0 AND DATEPART(HH,Start) < 12 THEN 'Morning'
  WHEN DATEPART(HH,Start) >= 12 AND DATEPART(HH,Start) < 18 THEN 'Afternoon'
  WHEN DATEPART(HH,Start) >= 18 AND DATEPART(HH,Start) < 24 THEN 'Evening' 
  END) AS 'Part of the Day',
(CASE
 WHEN Duration IS NULL THEN 'Extra Long'
 WHEN Duration <=3 THEN 'Extra Short'
 WHEN Duration >=4 AND Duration <=6 THEN 'Short'
 ELSE 'Long'
 END) AS Duration
	FROM Games
ORDER BY Name ASC, Duration ASC,[Part of the Day] ASC

--16
SELECT 
ProductName,
OrderDate,
DATEADD(DD,3,OrderDate) AS 'Pay Due',
DATEADD(MM,1,OrderDate) AS 'Deliver Due'
 FROM Orders

--17
 USE People
SELECT
      Name,
      DATEDIFF(YEAR,BirthDate,GETDATE()) AS 'Age in Years',
	  DATEDIFF(MONTH,BirthDate,GETDATE()) AS 'Age in Months',
	  DATEDIFF(DAY,BirthDate,GETDATE()) AS 'Age in Days',
	  DATEDIFF(MI,BirthDate,GETDATE()) AS 'Age in Minutes'
FROM People