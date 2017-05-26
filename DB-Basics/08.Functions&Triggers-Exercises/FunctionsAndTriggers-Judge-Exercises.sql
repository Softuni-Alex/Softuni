----Functions,Triggers and Transactions
--1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS 
BEGIN
 SELECT e.FirstName,e.LastName FROM Employees AS e
 WHERE e.Salary > 35000
END

--2
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@number MONEY)
AS
BEGIN
SELECT e.FirstName,e.LastName FROM Employees AS e
WHERE e.Salary >= @number
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--3
CREATE PROCEDURE usp_GetTownsStartingWith (@townNames VARCHAR(50))
AS
BEGIN
SELECT t.Name FROM Towns AS t
WHERE t.Name LIKE (@townNames + '%')
END

EXEC usp_GetTownsStartingWith b

--4
CREATE PROCEDURE usp_GetEmployeesFromTown (@townName VARCHAR(50))
AS
BEGIN
SELECT e.FirstName,e.LastName FROM Employees AS e
INNER JOIN Addresses AS a
ON a.AddressID = e.AddressID
INNER JOIN Towns AS t
ON a.TownID = t.TownID
WHERE t.Name = @townName
END

EXEC usp_GetEmployeesFromTown 'Sofia'

--5
CREATE FUNCTION ufn_GetSalaryLevel(@salary MONEY)
RETURNS VARCHAR(50) 
AS
BEGIN 
	DECLARE @levelOfSalary VARCHAR(50)
		IF(@salary < 30000)
			BEGIN
				SET @levelOfSalary = 'Low'
			END
		IF (@salary BETWEEN 30000 AND 50000)
			BEGIN
				SET @levelOfSalary = 'Average'
			END
		IF (@salary > 50000)
			BEGIN
				SET @levelOfSalary = 'High'
			END
			RETURN @levelOfSalary
END

SELECT dbo.ufn_GetSalaryLevel(13500.00)

--6
CREATE PROCEDURE usp_EmployeesBySalaryLevel (@levelOfSalary VARCHAR(10))
AS
BEGIN
	IF (@levelOfSalary = 'low')
		BEGIN
			SELECT e.FirstName,e.LastName FROM Employees AS e
			WHERE e.Salary < 30000
		END
	IF(@levelOfSalary = 'average')
		BEGIN
			SELECT e.FirstName,e.LastName FROM Employees AS e
			WHERE e.Salary BETWEEN 30000 AND 50000
		END
	IF(@levelOfSalary = 'high')
		BEGIN
			SELECT e.FirstName,e.LastName FROM Employees AS e
			WHERE e.Salary > 50000
		END
END

EXEC dbo.usp_EmployeesBySalaryLevel 'high'

--7
 CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX),@word VARCHAR(MAX))
RETURNS INT
     AS
  BEGIN
		DECLARE @currentLetter VARCHAR
		DECLARE @currentLetterPositon INT
		DECLARE @wordLength INT
		DECLARE @setOfLettersResult INT
		
		SET @currentLetterPositon = 1
		SET @wordLength = LEN(@word)
		
		WHILE(@currentLetterPositon <= @wordLength)
		BEGIN 
			SET @currentLetter = SUBSTRING(@word,@currentLetterPositon,1)
			SET @setOfLettersResult = CHARINDEX(@currentLetter,@setOfLetters,1)
			IF (@setOfLettersResult = 0)
				BEGIN
					RETURN 0
					BREAK
				END
			SET @currentLetterPositon +=1
		END
		RETURN 1
    END

	SELECT dbo.ufn_IsWordComprised('oistmiahf','Sofia')

--8 NOT YET
DELETE FROM Departments
WHERE Name = 'Production' AND Name = 'Production Control'
AND ManagerID = (SELECT e.EmployeeID FROM Employees AS e)

--9 USE BankFromExercises DATABASE
CREATE TABLE AccountHolders
(
Id INT PRIMARY KEY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
SSN VARCHAR(100)
)

CREATE TABLE Accounts
(
Id INT PRIMARY KEY,
AccountHolderId INT,
Balance MONEY,
CONSTRAINT FK_Accounts_AccountHolders FOREIGN KEY (AccountHolderId)
REFERENCES AccountHolders(Id)
)

CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT ah.FirstName + ' ' + ah.LastName FROM AccountHolders AS ah
END

--10
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@number MONEY)
AS 
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name] FROM
	(
		SELECT FirstName, LastName, SUM(a.Balance) AS TotalBalance FROM AccountHolders AS ah
		JOIN Accounts AS a
		ON a.AccountHolderId = ah.Id
		GROUP BY ah.FirstName, ah.LastName
	) AS tb
	WHERE tb.TotalBalance > @number
END

--11

--22
SELECT G.Name AS Game, GT.Name AS [Game Type],U.Username,UG.Level,UG.Cash,C.Name AS Character
FROM Users AS U
INNER JOIN UsersGames AS UG
ON U.Id = UG.UserId
INNER JOIN Games AS G
ON UG.GameId = G.Id
INNER JOIN GameTypes AS GT
ON G.GameTypeId = GT.Id
INNER JOIN Characters AS C
ON UG.CharacterId = C.Id
ORDER BY UG.Level DESC, U.Username ASC,G.Name ASC

--31
SELECT cur.CurrencyCode AS 'CurrencyCode' , cur.Description AS 'Currency' , COUNT(c.CountryCode) AS 'NumberOfCountries'
   FROM dbo.Countries AS c
   RIGHT JOIN dbo.Currencies AS cur
         ON cur.CurrencyCode = c.CurrencyCode
 GROUP BY cur.CurrencyCode , cur.Description
 ORDER BY 'NumberOfCountries' DESC , 'Currency' ASC
