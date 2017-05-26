----SECTION 1
CREATE TABLE DepositTypes
(
DepositTypeID INT PRIMARY KEY,
Name VARCHAR(20)
)

CREATE TABLE Deposits
(
DepositID INT PRIMARY KEY IDENTITY(1,1),
Amount DECIMAL(10,2),
StartDate DATE,
EndDate DATE,
DepositTypeID INT,
CustomerID	INT,
CONSTRAINT FK_Deposits_DepositTypes FOREIGN KEY (DepositTypeID)
REFERENCES DepositTypes(DepositTypeID),
CONSTRAINT FK_Deposits_Customers FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)
)

CREATE TABLE EmployeesDeposits
(
EmployeeID INT,
DepositID INT,
CONSTRAINT PK_EmployeeID_DepositID PRIMARY KEY(EmployeeID,DepositID),
CONSTRAINT FK_EmployeeDeposits_Employees FOREIGN KEY (EmployeeID)
REFERENCES Employees(EmployeeID),
CONSTRAINT FK_EmployeeDeposits_Deposits FOREIGN KEY (DepositID)
REFERENCES Deposits(DepositID)
)

CREATE TABLE CreditHistory
(
CreditHistoryID INT PRIMARY KEY,
Mark CHAR(1),
StartDate DATE,
EndDate DATE,
CustomerID INT,
CONSTRAINT FK_CreditHistory_Customers FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)
)

CREATE TABLE Users
(
UserID INT PRIMARY KEY,
UserName VARCHAR(20),
Password VARCHAR(20),
CustomerID INT UNIQUE,
CONSTRAINT FK_Users_Customers FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)
)

CREATE TABLE Payments
(
PaymentID INT PRIMARY KEY,
Date DATE,
Amount DECIMAL(10,2),
LoanID INT,
CONSTRAINT FK_Payments_Loans FOREIGN KEY (LoanID)
REFERENCES Loans(LoanID)
)

ALTER TABLE Employees
ADD ManagerID INT
CONSTRAINT FK_Employees_ManagerID FOREIGN KEY (ManagerID)
REFERENCES Employees(EmployeeID)

----SECTION 2
--1 INSERT
INSERT INTO DepositTypes(DepositTypeID,Name)
VALUES
(1,'Time Deposit'),
(2,'Call Deposit'),
(3,'Free Deposit')

INSERT INTO Deposits(Amount,StartDate,EndDate,DepositTypeID,CustomerID)
SELECT
     CASE
	     WHEN c.DateOfBirth > '1980-01-01' THEN 1000 ELSE 1500 END +
	 CASE
	     WHEN c.Gender = 'm' THEN 100 ELSE 200 END 
		 AS Amount,
		 GETDATE() AS StartDate,
		 NULL AS EndDate,
	CASE 
	    WHEN CustomerID > 15 THEN 3
		WHEN CustomerID %2 = 0 THEN 2
		WHEN CustomerID %2 = 1 THEN 1
		END AS DepositTypeID,
		CustomerID
 FROM Customers AS c
 WHERE c.CustomerID < 20

INSERT INTO EmployeesDeposits(EmployeeID,DepositID)
VALUES
(15,4),
(20,15),
(8,7),
(4,8),
(3,13),
(3,8),
(4,10),
(10,1),
(13,4),
(14,9)

--2.2 UPDATE
UPDATE Employees
SET ManagerID =
       (CASE
	    WHEN Employees.EmployeeID BETWEEN 2 AND 10 THEN 1
        WHEN Employees.EmployeeID BETWEEN 12 AND 20 THEN 11
	    WHEN Employees.EmployeeID BETWEEN 22 AND 30 THEN 21
	    WHEN Employees.EmployeeID BETWEEN 11 AND 21 THEN 1
		END)

--2.3 DELETE
DELETE FROM EmployeesDeposits
WHERE DepositID = 9 OR EmployeeID = 3

----SECTION 3 QUERYING
--1 
SELECT e.EmployeeID,e.HireDate,e.Salary,e.BranchID FROM Employees AS e
WHERE e.Salary > 2000 AND e.HireDate > '2009-06-15'

--2
SELECT c.FirstName,c.DateOfBirth,DATEDIFF(YEAR,c.DateOfBirth,'2016-10-01') AS Age FROM Customers AS c
WHERE DATEDIFF(YEAR,c.DateOfBirth,'2016-10-01') BETWEEN 40 AND 50

--3
SELECT c.CustomerID,c.FirstName,c.LastName,c.Gender,ci.CityName FROM Customers AS c
INNER JOIN Cities AS ci
ON c.CityID = ci.CityID
WHERE (c.LastName LIKE 'Bu%' OR c.FirstName LIKE '%a')
 AND
LEN(ci.CityName) >= 8
ORDER BY c.CustomerID ASC

--4
SELECT TOP 5 e.EmployeeID,e.FirstName,a.AccountNumber FROM Employees AS e
INNER JOIN EmployeesAccounts AS ea
ON ea.EmployeeID = e.EmployeeID
INNER JOIN Accounts AS a
ON a.AccountID = ea.AccountID
WHERE YEAR(a.StartDate) > 2012
ORDER BY e.FirstName DESC

--5
SELECT c.CityName,b.Name,COUNT(e.EmployeeID) AS EmployeesCount FROM Cities AS c
INNER JOIN Branches AS b
ON b.CityID = c.CityID
INNER JOIN Employees AS e
ON e.BranchID = b.BranchID
WHERE c.CityID != 4 AND c.CityID != 5
GROUP BY c.CityName,b.Name
HAVING COUNT(e.EmployeeID) >= 3

--6
SELECT SUM(l.Amount) AS TotalLoanAmount,MAX(l.Interest) AS MaxInterest,MIN(e.Salary) AS MinEmployeeSalary FROM Loans AS l
INNER JOIN EmployeesLoans AS el
ON el.LoanID = l.LoanID
INNER JOIN Employees AS e
ON e.EmployeeID = el.EmployeeID

--7
SELECT TOP 3 e.FirstName,c.CityName FROM Employees AS e
INNER JOIN Branches AS b
ON b.BranchID = e.BranchID
INNER JOIN Cities AS c
ON c.CityID = b.CityID
UNION ALL
SELECT TOP 3 c.FirstName,ci.CityName FROM Customers AS c
INNER JOIN Cities AS ci
ON ci.CityID = c.CityID

--8
SELECT c.CustomerID,c.Height FROM Customers AS c
LEFT JOIN Accounts AS a
ON a.CustomerID = c.CustomerID
WHERE a.CustomerID IS NULL AND
c.Height BETWEEN 1.74 AND 2.04

--9
SELECT TOP 5 c.CustomerID,l.Amount FROM Customers AS c
INNER JOIN Loans AS l
ON l.CustomerID = c.CustomerID
WHERE l.Amount > (SELECT AVG(Amount) AS Amount FROM Loans AS l
INNER JOIN Customers AS c
ON c.CustomerID = l.CustomerID
WHERE c.Gender = 'm')
ORDER BY c.LastName ASC

--10
SELECT c.CustomerID,c.FirstName,a.StartDate FROM Customers AS c
INNER JOIN Accounts AS a
ON a.CustomerID = c.CustomerID
WHERE a.StartDate IN (SELECT MIN(a.StartDate) AS StartDate FROM Accounts AS a) 

----SECTION 4 PROGRAMMABILITY
--1
CREATE FUNCTION dbo.udf_ConcatString(@firstString VARCHAR(50), @secondString VARCHAR(50))
RETURNS VARCHAR(50)
AS
BEGIN
RETURN CONCAT(REVERSE(@firstString),REVERSE(@secondString))
END

--2
CREATE PROCEDURE usp_CustomersWithUnexpiredLoans(@CustomerID INT)
AS
BEGIN
	SELECT c.CustomerID,c.FirstName,l.LoanID FROM Customers AS c
	INNER JOIN Loans AS l
	ON l.CustomerID = c.CustomerID
	WHERE c.CustomerID = @CustomerID AND l.ExpirationDate IS NULL
END

EXEC usp_CustomersWithUnexpiredLoans @CustomerID = 9

--3
CREATE PROCEDURE usp_TakeLoan (@CustomerID INT, @LoanAmount DECIMAL(18,2), @Interest DECIMAL(4,2), @StartDate DATE)
AS
BEGIN
 BEGIN TRANSACTION
  INSERT INTO Loans(StartDate,Amount,Interest,CustomerID) VALUES
     (@StartDate,
     @LoanAmount,
     @Interest,
     @CustomerID)
   IF(@LoanAmount NOT BETWEEN 0.01 AND 100000)
   BEGIN
   RAISERROR('Invalid Loan Amount.',16,1)
   ROLLBACK
   END
   ELSE 
   BEGIN
    COMMIT
    END
END

--4
CREATE TRIGGER TK_HireEmployee ON Employees
AFTER INSERT
AS
BEGIN
 UPDATE [dbo].[EmployeesLoans]
  SET EmployeeID = i.EmployeeID
  FROM EmployeesLoans AS e
  JOIN inserted AS i ON e.EmployeeID + 1 = i.EmployeeID
END

--5