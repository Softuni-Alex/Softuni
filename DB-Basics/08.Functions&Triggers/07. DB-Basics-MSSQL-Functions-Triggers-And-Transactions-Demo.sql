-- Functions

USE SoftUni
GO

SELECT * FROM [dbo].[Projects]

CREATE FUNCTION udf_ProjectWeeks(@StartDate DATE, @EndDate DATE)
RETURNS INT
AS
BEGIN
-- Logic
	DECLARE @projectWeeks INT;

	IF(@EndDate IS NULL)
	BEGIN
		SET @EndDate = GETDATE()
	END


	SET @projectWeeks = DATEDIFF(WEEK, @StartDate, @EndDate)
	RETURN @projectWeeks
END

SELECT p.ProjectID, p.StartDate, p.EndDate, 
       dbo.udf_ProjectWeeks(p.StartDate,p.EndDate)
  FROM [dbo].[Projects] AS p



CREATE FUNCTION udf_return_table ()
RETURNS @myTable TABLE (
	Id INT,
	Name VARCHAR(50)
	)
AS
BEGIN

	INSERT INTO @myTable(Id, Name)
	VALUES (1, 'myName')

	RETURN
END

SELECT * FROM dbo.udf_return_table()

-- Transactions

SELECT TOP 1000 [TownID]
      ,[Name]
  FROM [SoftUni].[dbo].[Towns]

BEGIN TRAN

INSERT INTO  [SoftUni].[dbo].[Towns]( [Name])
VALUES ('Plovdiv')

COMMIT

-- Procedures
SELECT * FROM [dbo].[EmployeesProjects]

CREATE PROCEDURE udp_AssignProject (@EmployeeID INT, @ProjectID INT)
AS
BEGIN 
	DECLARE @maxProjects INT
	DECLARE @currentProjects INT
	SET @maxProjects = 3
	SET @currentProjects = (SELECT COUNT(*) AS ProjectsCount
							  FROM [dbo].[EmployeesProjects] AS p
							 WHERE p.EmployeeID = @EmployeeID)
	


	BEGIN TRAN 

	INSERT INTO [dbo].[EmployeesProjects](EmployeeID, ProjectID)
	VALUES (@EmployeeID, @ProjectID)

	IF(@currentProjects >= @maxProjects)
	BEGIN 
		RAISERROR('Too many projects', 16, 1)
		ROLLBACK
	END
	ELSE
	BEGIN
		COMMIT
	END
END


SELECT * FROM [dbo].[EmployeesProjects]

EXEC dbo.udp_AssignProject 263, 6


IF OBJECT_ID('[dbo].[EmployeesProjects2]') IS NULL
	PRINT 'No Table'
	PRINT 'MESSAGE 2'

-- Loops

CREATE PROCEDURE udp_TestLoop
AS
BEGIN
	DECLARE @startValue INT = 0;
	DECLARE @maxValue INT = 10;

	WHILE (@startValue < @maxValue)
	BEGIN
		PRINT @startValue
		SET @startValue +=1
	END
END

EXEC udp_TestLoop

BEGIN TRY
	SELECT 0/0
END TRY
BEGIN CATCH
	PRINT 'Error'
END CATCH


DECLARE @noArray VARCHAR(50) = (SELECT p.Name FROM [dbo].[Projects] AS p)

-- Triggers
SELECT * FROM [dbo].[EmployeesProjects]


ALTER TRIGGER tr_LogRecords
ON [dbo].[EmployeesProjects]
INSTEAD OF DELETE
AS
BEGIN
	IF OBJECT_ID('[EmployeesProjectsHistory]') IS NULL
	BEGIN
		CREATE TABLE EmployeesProjectsHistory(
			EmployeeId INT,
			ProjectId INT
			)
	END

    INSERT INTO [EmployeesProjectsHistory](EmployeeId,ProjectId)
	SELECT d.EmployeeID, d.ProjectID FROM deleted AS d
END


DELETE FROM [EmployeesProjects]
WHERE EmployeeID = 8

SELECT * FROM [EmployeesProjects]