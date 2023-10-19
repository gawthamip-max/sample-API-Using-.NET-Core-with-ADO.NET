CREATE TABLE Customer
(
    UserId UNIQUEIDENTIFIER PRIMARY KEY,
    Username NVARCHAR(30),
    Email NVARCHAR(20),
    FirstName NVARCHAR(20),
    LastName NVARCHAR(20),
    CreatedOn DATETIME,
    IsActive BIT
);

CREATE TABLE [Order]
(
    OrderId UNIQUEIDENTIFIER PRIMARY KEY,
    ProductId UNIQUEIDENTIFIER,
    OrderStatus INT,
    OrderType INT,
    OrderBy UNIQUEIDENTIFIER,
    OrderedOn DATETIME,
    ShippedOn DATETIME,
    IsActive BIT,
    FOREIGN KEY (ProductId) REFERENCES Product(ProductId),
    FOREIGN KEY (OrderBy) REFERENCES Customer(UserId)
);

CREATE TABLE Product
(
    ProductId UNIQUEIDENTIFIER PRIMARY KEY,
    ProductName NVARCHAR(50),
    UnitPrice DECIMAL(18, 2),
    SupplierId UNIQUEIDENTIFIER,
    CreatedOn DATETIME,
    IsActive BIT,
    FOREIGN KEY (SupplierId) REFERENCES Supplier(SupplierId)
);

CREATE TABLE Supplier
(
    SupplierId UNIQUEIDENTIFIER PRIMARY KEY,
    SupplierName NVARCHAR(50),
    CreatedOn DATETIME,
    IsActive BIT
);

CREATE PROCEDURE GetActiveOrdersByCustomer
    @CustomerId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT O.OrderId, P.ProductName, S.SupplierName
    FROM Orders AS O
    INNER JOIN Products AS P ON O.ProductId = P.ProductId
    INNER JOIN Suppliers AS S ON P.SupplierId = S.SupplierId
    WHERE O.OrderBy = @CustomerId AND O.IsActive = 1
END
