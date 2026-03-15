CREATE TABLE Movies (
    MovieID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100),
    Genre NVARCHAR(50),
    DurationMinutes INT,
    Rating NVARCHAR(10),
    ReleaseDate DATE
);

INSERT INTO Movies (Title, Genre, DurationMinutes, Rating, ReleaseDate)
VALUES
('Avengers: Endgame', 'Action', 181, 'PG-13', '2019-04-26'),
('Spider-Man: No Way Home', 'Action', 148, 'PG-13', '2021-12-17'),
('Frozen II', 'Animation', 103, 'PG', '2019-11-22');

CREATE TABLE Theaters (
    TheaterID INT IDENTITY(1,1) PRIMARY KEY,
    TheaterName NVARCHAR(100),
    Location NVARCHAR(100)
);

INSERT INTO Theaters (TheaterName, Location)
VALUES
('Junction City Cinema', 'Yangon'),
('Nay Pyi Taw Cinema', 'Nay Pyi Taw');

CREATE TABLE Screens (
    ScreenID INT IDENTITY(1,1) PRIMARY KEY,
    TheaterID INT,
    ScreenName NVARCHAR(50),
    TotalSeats INT,
    FOREIGN KEY (TheaterID) REFERENCES Theaters(TheaterID)
);

INSERT INTO Screens (TheaterID, ScreenName, TotalSeats)
VALUES
(1, 'Screen 1', 100),
(1, 'Screen 2', 80),
(2, 'Screen 1', 120);

CREATE TABLE Showtimes (
    ShowtimeID INT IDENTITY(1,1) PRIMARY KEY,
    MovieID INT,
    ScreenID INT,
    ShowDate DATE,
    ShowTime TIME,
    Price DECIMAL(10,2),
    FOREIGN KEY (MovieID) REFERENCES Movies(MovieID),
    FOREIGN KEY (ScreenID) REFERENCES Screens(ScreenID)
);
INSERT INTO Showtimes (MovieID, ScreenID, ShowDate, ShowTime, Price)
VALUES
(1, 1, '2026-03-15', '18:00', 8000),
(2, 2, '2026-03-15', '20:00', 8500),
(3, 3, '2026-03-16', '16:00', 7000);

CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100),
    Phone NVARCHAR(20),
    Email NVARCHAR(100)
);

INSERT INTO Customers (FullName, Phone, Email)
VALUES
('Aung Aung', '0912345678', 'aung@email.com'),
('Su Su', '0998765432', 'susu@email.com');

CREATE TABLE Bookings (
    BookingID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT,
    ShowtimeID INT,
    SeatsBooked INT,
    BookingDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ShowtimeID) REFERENCES Showtimes(ShowtimeID)
);

INSERT INTO Bookings (CustomerID, ShowtimeID, SeatsBooked)
VALUES
(1, 1, 2),
(2, 2, 3);
