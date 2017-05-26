--1
SELECT COUNT(Id) AS Count FROM WizzardDeposits

--2
SELECT MAX(w.MagicWandSize) AS LongestMagicWand FROM WizzardDeposits AS w

--3
SELECT w.DepositGroup, MAX(w.MagicWandSize) AS LongestMagicWand 
  FROM WizzardDeposits AS w
  GROUP BY w.DepositGroup

--4!!!
SELECT DepositGroup FROM
  (SELECT DepositGroup, AVG(MagicWandSize) AS AverageMagicWandSize FROM WizzardDeposits
  GROUP BY DepositGroup) as avgm
  WHERE AverageMagicWandSize = ( SELECT MIN(AverageMagicWandSize) MinAverageMagicWandSize 
								   FROM
								(SELECT DepositGroup, AVG(MagicWandSize) AS AverageMagicWandSize
								   FROM [dbo].[WizzardDeposits]
								  GROUP BY DepositGroup) AS av)

--5
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
GROUP BY DepositGroup

--6
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--7
SELECT DepositGroup,SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--8
SELECT DepositGroup,MagicWandCreator,MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator ASC, DepositGroup ASC

--9
SELECT (CASE 
WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
ELSE '[61+]' END) AS AgeGroup,
COUNT(*) AS WizzardCount
  FROM WizzardDeposits
  GROUP BY CASE 
WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
ELSE '[61+]' END

--10
SELECT DISTINCT LEFT(FirstName,1) AS first_letter FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY FirstName
ORDER BY first_letter ASC

--11
SELECT DepositGroup,IsDepositExpired,AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup,IsDepositExpired
ORDER BY DepositGroup DESC,IsDepositExpired ASC

--12!!!
SELECT SUM(w.DepositAmount - wd.DepositAmount) AS SumDifference FROM WizzardDeposits as w
INNER JOIN WizzardDeposits AS wd
ON w.Id + 1 = wd.Id

--13
USE SoftUni
SELECT DepartmentID,MIN(Salary) AS MinimumSalary FROM Employees
WHERE DepartmentID LIKE '[257]' AND HireDate > '01/01/2000'
GROUP BY DepartmentId

--14
SELECT DepartmentID,Salary,ManagerID
INTO NewEmployees FROM Employees
WHERE Salary > 30000
DELETE FROM NewEmployees
WHERE ManagerID = 42
UPDATE NewEmployees
SET Salary +=5000
WHERE DepartmentID = 1
SELECT DepartmentId,AVG(Salary) AS AverageSalary FROM NewEmployees
GROUP BY DepartmentID

--15
SELECT DepartmentID,MAX(Salary) AS MaxSalary FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--16
SELECT COUNT(Salary) AS [Count] FROM Employees
WHERE ManagerID IS NULL

--17
SELECT DISTINCT sal.DepartmentId, sal.Salary 
  FROM
(SELECT e.DepartmentId,
              e.Salary,
DENSE_RANK() OVER (PARTITION BY e.DepartmentID ORDER BY e.Salary DESC) AS SalaryRank
   FROM Employees AS e) AS sal
  WHERE sal.SalaryRank = 3
  
--18
SELECT TOP 10 e.FirstName,e.LastName,e.DepartmentID FROM Employees AS e
INNER JOIN
(SELECT em.DepartmentID AS DepartmentId,AVG(em.Salary) AS AvgSalary FROM Employees AS em
GROUP BY em.DepartmentID) AS ej
ON(ej.DepartmentId = e.DepartmentID AND Salary > AvgSalary)
ORDER BY e.DepartmentID ASC