----1 Data Definition 
CREATE TABLE Flights
(
FlightID INT PRIMARY KEY,
DepartureTime DATETIME NOT NULL,
ArrivalTime DATETIME NOT NULL,
Status VARCHAR(9) CHECK(Status = 'Departing' OR Status = 'Delayed' OR Status = 'Arrived' OR Status ='Canceled'),
OriginAirportID INT,
DestinationAirportID INT,
AirlineID INT,
CONSTRAINT FK_Flights_AirportsOrigin FOREIGN KEY (OriginAirportID)
REFERENCES Airports(AirportID),
CONSTRAINT FK_Flights_AirportsDestination FOREIGN KEY (DestinationAirportID)
REFERENCES Airports(AirportID),
CONSTRAINT FK_Flights_Airlines FOREIGN KEY (AirlineID)
REFERENCES Airlines(AirlineID)
)

CREATE TABLE Tickets
(
TicketID INT PRIMARY KEY,
Price DECIMAL(8,2) NOT NULL,
Class VARCHAR(6) CHECK(Class = 'First' OR Class = 'Second' OR Class = 'Third'),
Seat VARCHAR(5) NOT NULL,
CustomerID INT,
FlightID INT,
CONSTRAINT FK_Tickets_Customers FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID),
CONSTRAINT FK_Tickets_Flights FOREIGN KEY (FlightID)
REFERENCES Flights(FlightID)
)

----2 Database Manipulations
--1
INSERT INTO Flights(FlightID,DepartureTime,ArrivalTime,[Status],OriginAirportID,DestinationAirportID,AirlineID)
VALUES
(1,'2016-10-13 06:00 AM','2016-10-13 10:00 AM','Delayed',1,4,1),
(2,'2016-10-12 12:00 PM','2016-10-12 12:01 PM','Departing',1,3,2),
(3,'2016-10-14 03:00 PM','2016-10-20 04:00 AM','Delayed',4,2,4),
(4,'2016-10-12 01:24 PM','2016-10-12 4:31 PM','Departing',3,1,3),
(5,'2016-10-12 08:11 AM','2016-10-12 11:22 PM','Departing',4,1,1),
(6,'1995-06-21 12:30 PM','1995-06-22 08:30 PM','Arrived',2,3,5),
(7,'2016-10-12 11:34 PM','2016-10-13 03:00 AM','Departing',2,4,2),
(8,'2016-11-11 01:00 PM','2016-11-12 10:00 PM','Delayed',4,3,1),
(9,'2015-10-01 12:00 PM','2015-12-01 01:00 AM','Arrived',1,2,1),
(10,'2016-10-12 07:30 PM','2016-10-13 12:30 PM','Departing',2,1,7)

INSERT INTO Tickets(TicketID,Price,Class,Seat,CustomerID,FlightID)
VALUES
(1,3000.00,'First','233-A',3,8),
(2,1799.90,'Second','123-D',1,1),
(3,1200.50,'Second','12-Z',2,5),
(4,410.68,'Third','45-Q',2,8),
(5,560.00,'Third','201-R',4,6),
(6,2100.00,'Second','13-T',1,9),
(7,5500.00,'First','98-O',2,7)

--2
UPDATE Flights
SET AirlineID = 1
WHERE Status = 'Arrived'

--3
UPDATE Tickets
SET Price = Price * 1.50
WHERE EXISTS (SELECT MAX(a.Rating) FROM Airlines AS a)

--4
CREATE TABLE CustomerBankAccounts
(
AccountID INT PRIMARY KEY,
AccountNumber VARCHAR(10) UNIQUE NOT NULL,
Balance DECIMAL(10,2) NOT NULL,
CustomerID INT,
CONSTRAINT FK_CustomerBankAccounts_Customers FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)
)

CREATE TABLE CustomerReviews
(
ReviewID INT PRIMARY KEY,
ReviewContent VARCHAR(255) NOT NULL,
ReviewGrade INT CHECK(ReviewGrade BETWEEN 0 AND 10),
AirlineID INT,
CustomerID INT,
CONSTRAINT FK_CustomerReviews_Airlines FOREIGN KEY(AirlineID)
REFERENCES Airlines(AirlineID),
CONSTRAINT FK_CustomerReviews_Customers FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)
)

--5
INSERT INTO CustomerReviews(ReviewID,ReviewContent,ReviewGrade,AirlineID,CustomerID)
VALUES
(1,'Me is very happy. Me likey this airline. Me good.',10,1,1),
(2,'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!',10,1,4),
(3,'Meh...',5,4,3),
(4,'Well Ive seen better, but Ive certainly seen a lot worse...',7,3,5)

INSERT INTO CustomerBankAccounts(AccountID,AccountNumber,Balance,CustomerID)
VALUES
(1,'123456790',2569.23,1),
(2,'18ABC23672',14004568.23,2),
(3,'F0RG0100N3',19345.20,5)

----SECTION 3 QUERYING
--1
SELECT t.TicketID,t.Price,t.Class,t.Seat FROM Tickets AS t
ORDER BY t.TicketID ASC

--2
SELECT c.CustomerID,c.FirstName + ' ' + c.LastName AS FullName,c.Gender FROM Customers AS c
ORDER BY FullName ASC,c.CustomerID ASC

--3
SELECT f.FlightID,f.DepartureTime,f.ArrivalTime FROM Flights AS f
WHERE f.Status = 'Delayed'
ORDER BY FlightID ASC

--4

--5
SELECT t.TicketID,a.AirportName AS Destination,c.FirstName + ' ' + c.LastName AS CustomerName FROM Tickets AS t
INNER JOIN Flights AS f
ON t.FlightID = f.FlightID
INNER JOIN Airports AS a
ON a.AirportID = f.DestinationAirportID
INNER JOIN Customers AS c
ON t.CustomerID = c.CustomerID
WHERE t.Price < 5000 AND t.Class = 'First'
ORDER BY t.TicketID ASC

--6
SELECT c.CustomerID,c.FirstName + ' ' + c.LastName AS FullName,t.TownName AS HomeTown FROM Customers AS c
INNER JOIN Towns AS t
ON c.HomeTownID = t.TownID
LEFT JOIN CustomerReviews AS cr
ON cr.CustomerID = c.CustomerID
LEFT JOIN Airlines AS a
ON a.AirlineID = cr.AirlineID
LEFT JOIN Flights AS f
ON f.AirlineID = a.AirlineID
WHERE c.HomeTownID = f.OriginAirportID
ORDER BY c.CustomerID ASC
--or subs

--7
SELECT c.CustomerID,c.FirstName + ' ' + c.LastName AS FullName,DATEDIFF(YEAR,c.DateOfBirth,GETDATE()) AS Age FROM Customers AS c
LEFT JOIN Tickets AS t
ON t.CustomerID = c.CustomerID
LEFT JOIN Flights AS f
ON f.FlightID = t.FlightID
WHERE t.TicketID IS NOT NULL AND f.Status = 'Departing'
ORDER BY Age ASC,CustomerID ASC
--or may be with grouping

--8
SELECT TOP 3 c.CustomerID,c.FirstName + ' ' + c.LastName AS FullName,t.Price,a.AirportName FROM Customers AS c
INNER JOIN Tickets AS t
ON t.CustomerID = c.CustomerID
INNER JOIN Flights AS f
ON f.FlightID = t.FlightID
INNER JOIN Airports AS a
ON a.AirportID = f.DestinationAirportID
WHERE f.Status = 'Delayed' -- not sure for the where !
ORDER BY t.Price DESC,CustomerID ASC

--9
SELECT f.FlightID,f.DepartureTime,f.ArrivalTime,a.AirportName AS Origin,f.DestinationAirportID AS Destination FROM Flights AS f
INNER JOIN Airports AS a
ON a.AirportID = f.OriginAirportID
INNER JOIN Tickets AS t
ON t.FlightID = f.FlightID

--10
SELECT c.CustomerID,c.FirstName + ' ' + c.LastName AS FullName, DATEDIFF(YEAR,c.DateOfBirth,GETDATE()) AS Age FROM Customers AS c
LEFT JOIN Tickets AS t 
ON t.CustomerID = c.CustomerID
LEFT JOIN Flights AS f
ON f.FlightID = t.FlightID
WHERE f.FlightID IS NOT NULL AND f.Status = 'Arrived'
GROUP BY c.CustomerID,c.FirstName + ' ' + c.LastName,DATEDIFF(YEAR,c.DateOfBirth,GETDATE())
HAVING DATEDIFF(YEAR,c.DateOfBirth,GETDATE()) < 21
ORDER BY Age DESC,CustomerID ASC

--11
SELECT a.AirportID,a.AirportName,COUNT(@asd) AS Passangers FROM Airports AS a
ORDER BY a.AirportID ASC

----SECTION 4 PROGRAMABILITY
--1
CREATE PROCEDURE usp_SubmitReview(@CustomerID INT,@ReviewContent VARCHAR(255),@ReviewGrade INT,@AirlineName VARCHAR(30))
AS
BEGIN 
	IF @AirlineName IN (SELECT a.AirlineName FROM Airlines AS a)
		BEGIN
			RAISERROR('Airline does not exist.',16,1)
		END
	ELSE
		BEGIN
			DECLARE @reviewID INT
			SET @reviewID = (SELECT MAX(cr.ReviewID) + 1 FROM CustomerReviews AS cr)
			DECLARE @airlineID INT
			SET @airlineID = (SELECT a.AirlineID FROM Airlines AS a 
							  WHERE a.AirlineName = @AirlineName)

			INSERT INTO CustomerReviews(ReviewID,ReviewContent,ReviewGrade,AirlineID,CustomerID)
			VALUES(@reviewID,@ReviewContent,@ReviewGrade,@airlineID,@CustomerID)
		END
END

--2
CREATE PROCEDURE usp_PurchaseTicket(@CustomerID INT,@FlightID INT,@TicketPrice DECIMAL(8,2),@Class VARCHAR(6),@Seat VARCHAR(5))
AS
BEGIN 
	BEGIN TRANSACTION
		DECLARE @AccountBalance DECIMAL(10,2)
		SET @AccountBalance = (SELECT cba.Balance FROM CustomerBankAccounts AS cba WHERE cba.CustomerID = @CustomerID)

			IF @TicketPrice > @AccountBalance
				BEGIN
					RAISERROR('Insufficient bank account balance for ticket purchase.',16,1)
					ROLLBACK
				END
				ELSE
					BEGIN
					DECLARE @ticketID INT = (SELECT MAX(t.TicketID) + 1 FROM Tickets AS t)

						INSERT INTO Tickets(TicketID,Price,Class,Seat,CustomerID,FlightID)
						VALUES(@ticketID,@TicketPrice,@Class,@Seat,@CustomerID,@FlightID)

						UPDATE CustomerBankAccounts
						SET Balance -= @TicketPrice
						COMMIT
				    END
	END