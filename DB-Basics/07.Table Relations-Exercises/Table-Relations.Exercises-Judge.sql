--1
CREATE TABLE Passports
(
PassportID INT PRIMARY KEY,
PassportNumber NVARCHAR(20)
)

CREATE TABLE Persons
(
PersonID INT PRIMARY KEY,
FirstName NVARCHAR(50),
Salary DECIMAL,
PassportID INT,
CONSTRAINT FK_Persons_Passports FOREIGN KEY(PassportID)
REFERENCES Passports(PassportID)
)

--2
CREATE TABLE Manufacturers
(
ManufacturerID INT PRIMARY KEY,
Name NVARCHAR(50),
EstablishedOn DATE,
)

CREATE TABLE Models
(
ModelID INT PRIMARY KEY,
Name NVARCHAR(50),
ManufacturerID INT,
CONSTRAINT FK_Models_Manufacturers FOREIGN KEY(ManufacturerID)
REFERENCES Manufacturers(ManufacturerID)
)

--3
CREATE TABLE Students
(
StudentID INT PRIMARY KEY,
Name NVARCHAR(50)
)

CREATE TABLE Exams
(
ExamID INT PRIMARY KEY,
Name NVARCHAR(50)
)

CREATE TABLE StudentsExams
(
StudentID INT NOT NULL,
ExamID INT NOT NULL,
)

ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentID_ExamID PRIMARY KEY(StudentID,ExamID),
CONSTRAINT FK_Student_Exams FOREIGN KEY(StudentID)
REFERENCES Students(StudentID),
CONSTRAINT FK_Exams_Student FOREIGN KEY(ExamID)
REFERENCES Exams(ExamID)

--4
CREATE TABLE Teachers
(
TeacherID INT PRIMARY KEY,
Name NVARCHAR(50),
ManagerID INT ,
CONSTRAINT FK_Teacher FOREIGN KEY (ManagerID)
REFERENCES Teachers(TeacherID)
)

--5
CREATE TABLE Cities
(
CityID INT PRIMARY KEY,
Name varchar(50)
)

CREATE TABLE Customers
(
CustomerID INT PRIMARY KEY,
Name varchar(50),
Birthday date,
CityID INT,
CONSTRAINT FK_Customers_Cities FOREIGN KEY (CityID)
REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
OrderID INT PRIMARY KEY, 
CustomerID INT,
CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes
(
ItemTypeID INT PRIMARY KEY,
Name varchar(50)
)

CREATE TABLE Items
(
ItemID INT PRIMARY KEY,
Name varchar(50),
ItemTypeID INT,
CONSTRAINT FK_Items_ItemTypes FOREIGN KEY (ItemTypeID)
REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
OrderID INT,
ItemID INT,
CONSTRAINT PK_OrderID_ItemID PRIMARY KEY(OrderID,ItemID),
CONSTRAINT FK_OrderID_Order FOREIGN KEY (OrderID)
REFERENCES Orders(OrderID),
CONSTRAINT FK_Items_Order FOREIGN KEY (ItemID)
REFERENCES Items(ItemID)
)

--6 University Database
CREATE TABLE  Subjects
(
SubjectID INT PRIMARY KEY,
SubjectName NVARCHAR(50)
)

CREATE TABLE Majors
(
MajorID INT PRIMARY KEY,
Name NVARCHAR(50)
)

CREATE TABLE Students
(
StudentID INT PRIMARY KEY,
StudentNumber NVARCHAR(20),
StudentName NVARCHAR(100),
MajorID INT,
CONSTRAINT FK_Students_Majors FOREIGN KEY (MajorID)
REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
PaymentID INT PRIMARY KEY,
PaymentDate DATE,
PaymentAmount DECIMAL,
StudentID INT,
CONSTRAINT FK_Payments_Students FOREIGN KEY (StudentID)
REFERENCES Students(StudentID)
)

CREATE TABLE Agenda
(
StudentID INT,
SubjectID INT,
CONSTRAINT PK_StudentID_SubjectID PRIMARY KEY(StudentID,SubjectID),
CONSTRAINT FK_Agenda_Students FOREIGN KEY (StudentID)
REFERENCES Students(StudentID),
CONSTRAINT FK_Agenda_Subjects FOREIGN KEY (SubjectID)
REFERENCES Subjects(SubjectID)
)

--7 SEE SoftUni DATABASE - Diagrams

--8 SEE Geography DATABASE - Diagrams

--9
SELECT TOP 5 e.EmployeeId,e.JobTitle,a.AddressID,a.AddressText FROM Employees AS e
INNER JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY e.AddressID ASC

--10
SELECT TOP 5 e.EmployeeID,e.FirstName,e.Salary,d.Name FROM Employees AS e
INNER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID ASC

--11
SELECT TOP 3 e.EmployeeID,e.FirstName FROM Employees AS e
LEFT JOIN EmployeesProjects ep 
ON ep.EmployeeID = e.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID ASC

--12
SELECT TOP 5 e.EmployeeID,e.FirstName,p.Name AS ProjectName FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13'
AND EndDate IS NULL
ORDER BY e.EmployeeID ASC

--13
SELECT e.EmployeeID,e.FirstName,CASE WHEN YEAR(p.StartDate) >= 2005 THEN NULL ELSE p.Name END AS ProjectName FROM Employees AS e
INNER JOIN EmployeesProjects ep
ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects p
ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

--14 Selfreferencing
SELECT e.EmployeeID,e.FirstName,e.ManagerID,em.FirstName AS ManagerName FROM Employees AS e
INNER JOIN Employees AS em
ON e.ManagerID = em.EmployeeID
WHERE e.ManagerID = 3 OR e.ManagerID = 7
ORDER BY e.EmployeeID ASC

--15 Geography
SELECT c.CountryCode,m.MountainRange,p.PeakName,p.Elevation FROM Countries AS c
INNER JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
INNER JOIN Mountains AS m
ON m.Id = mc.MountainId
INNER JOIN Peaks AS p
ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--16
SELECT c.CountryCode, COUNT(m.MountainRange) AS MountainRanges FROM Countries AS c
INNER JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
INNER JOIN Mountains AS m
ON m.Id = mc.MountainId
WHERE c.CountryCode = 'BG' OR c.CountryCode = 'US' OR c.CountryCode = 'RU'
GROUP BY c.CountryCode

--17
SELECT TOP 5 c.CountryName,r.RiverName FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r
ON cr.RiverId = r.Id
INNER JOIN Continents AS co
ON c.ContinentCode = co.ContinentCode
WHERE co.ContinentName = 'Africa'
ORDER BY c.CountryName ASC

--18
SELECT
  sel.ContinentCode,
  sel.CurrencyCode AS CurrencyCode,
  sel.CurrencyUs AS CurrencyUsage
     FROM (SELECT c.ContinentCode,
                  cr.CurrencyCode,
                  COUNT(cr.Description) AS CurrencyUs,
                  DENSE_RANK() over (partition by c.ContinentCode order by COUNT(cr.CurrencyCode) desc) as rankk
             FROM  Currencies cr
             JOIN Countries c ON cr.CurrencyCode = c.CurrencyCode
             GROUP BY c.ContinentCode, cr.CurrencyCode
             HAVING  COUNT(cr.Description) > 1) as sel
where sel.rankk = 1 
ORDER BY ContinentCode

--19
SELECT COUNT(c.CountryCode) AS CountryCode FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m
ON mc.MountainId = m.Id
WHERE mc.MountainId IS NULL

--20
SELECT TOP 5 c.CountryName,MAX(p.Elevation) AS HighestPeakElevation,MAX(r.Length) AS LongestRiverLength FROM Countries AS c
left JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
left JOIN Mountains AS m
ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p
ON p.MountainId = m.Id
LEFT JOIN CountriesRivers AS cr
ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r
ON cr.RiverId = r.Id
GROUP BY c.CountryName, p.Elevation,r.Length
ORDER BY p.Elevation DESC, r.Length DESC, c.CountryName ASC