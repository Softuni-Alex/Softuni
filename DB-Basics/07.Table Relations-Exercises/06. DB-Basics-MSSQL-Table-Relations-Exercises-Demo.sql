-- Sql Server
CREATE DATABASE SelfReference
GO

USE SelfReference
GO

CREATE TABLE Employees(
EmployeeId INT PRIMARY KEY,
EmployeeName VARCHAR(50),
ManagerId INT NULL,
CONSTRAINT FK_Employees_Employees FOREIGN KEY(ManagerId)
REFERENCES Employees(EmployeeId)
)

-- Managers
INSERT INTO Employees(EmployeeId, EmployeeName, ManagerId)
VALUES (1, 'Manager 1', NULL), (2, 'Manager 2', NULL)

INSERT INTO Employees(EmployeeId, EmployeeName, ManagerId)
VALUES (3, 'Employee', 1)

SELECT * 
  FROM Employees AS e1
 INNER JOIN Employees AS e2
    ON e1.ManagerId = e2.EmployeeId

-- 13

SELECT e.EmployeeId, e.FirstName, 
	   p.Name
  FROM [dbo].[Employees] AS e
 INNER JOIN [dbo].[EmployeesProjects] AS ep
    ON e.EmployeeId = ep.EmployeeId
  LEFT JOIN [dbo].[Projects] AS p
    ON ep.ProjectId = p.ProjectId
   AND p.StartDate < '2005-01-01' -- case 1
 WHERE e.EmployeeId = 24
  --AND p.StartDate < '2005-01-01' -- case 2

  --(SELECT * FROM [dbo].[Projects]
  --  WHERE StartDate < '2005-01-01') AS p -- case 1

 SELECT * FROM [dbo].[Employees]
 WHERE EmployeeId IN (24,25)
 UNION
 SELECT * FROM [dbo].[Employees]
  WHERE EmployeeId = 25

--21 

--1 Country, Mountain, Highest Peak, Elevation
--2 Country, Mountain, Highest Peak, Elevation without mountains
--3 1 Union 2
SELECT TOP 5 * FROM(
SELECT c.CountryName, p.PeakName, p.Elevation, m.MountainRange 
 FROM [dbo].[Countries] AS c
INNER JOIN [dbo].[MountainsCountries] AS mc
   ON c.CountryCode = mc.CountryCode
INNER JOIN [dbo].[Mountains] AS m
   ON mc.MountainId = m.Id
INNER JOIN [dbo].[Peaks] AS p
   ON p.MountainId = m.Id
INNER JOIN (
SELECT c.CountryName, MAX(p.Elevation) AS MaxElevation
 FROM [dbo].[Countries] AS c
INNER JOIN [dbo].[MountainsCountries] AS mc
   ON c.CountryCode = mc.CountryCode
INNER JOIN [dbo].[Mountains] AS m
   ON mc.MountainId = m.Id
INNER JOIN [dbo].[Peaks] AS p
   ON p.MountainId = m.Id
GROUP BY c.CountryName
) AS max_elevation
 ON max_elevation.MaxElevation = p.Elevation
AND max_elevation.CountryName = c.CountryName
UNION ALL
SELECT c.CountryName, '(no highest peak)' AS PeakName,
       0 AS Elevation, '(no mountain)' AS MountainRange
 FROM [dbo].[Countries] AS c
 LEFT JOIN [dbo].[MountainsCountries] AS mc
    ON c.CountryCode = mc.CountryCode
 WHERE mc.MountainId  IS NULL
 ) AS results
 ORDER BY CountryName, PeakName
