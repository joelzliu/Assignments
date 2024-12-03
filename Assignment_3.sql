USE Northwind
GO

-- 1.List all cities that have both Employees and Customers.
SELECT DISTINCT e.City
FROM Employees e
JOIN Customers c ON e.City = c.City

-- 2.List all cities that have Customers but no Employee.
-- a.Use sub-query
SELECT DISTINCT c.City
FROM Customers c
WHERE c.City NOT IN (SELECT DISTINCT e.City FROM Employees e)

-- b.Do not use sub-query
SELECT DISTINCT c.City
FROM Customers c
LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL

-- 3.List all products and their total order quantities throughout all orders.
SELECT p.ProductName, SUM(od.Quantity) AS TotalOrderQuantities
FROM Products p
JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductName

-- 4.List all Customer Cities and total products ordered by that city.
SELECT c.City, SUM(od.Quantity) AS TotalProductsOrdered
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City

-- 5.List all Customer Cities that have at least two customers.
SELECT City
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) >= 2

-- 6.List all Customer Cities that have ordered at least two different kinds of products.
SELECT c.City
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
HAVING COUNT(DISTINCT od.ProductID) >= 2

-- 7.List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
SELECT DISTINCT c.ContactName, c.City AS OwnCity, o.ShipCity
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE c.City != o.ShipCity

-- 8.List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
WITH PopularProducts AS (
    SELECT TOP 5 p.ProductID, p.ProductName, AVG(od.UnitPrice) AS AvgPrice, SUM(od.Quantity) AS TotalQuantity
    FROM [Order Details] od
    JOIN Products p ON od.ProductID = p.ProductID
    GROUP BY p.ProductID, p.ProductName
    ORDER BY TotalQuantity DESC
),
CityOrders AS (
    SELECT p.ProductID, c.City, SUM(od.Quantity) AS CityQuantity
    FROM [Order Details] od
    JOIN Orders o ON od.OrderID = o.OrderID
    JOIN Customers c ON o.CustomerID = c.CustomerID
    JOIN Products p ON od.ProductID = p.ProductID
    GROUP BY p.ProductID, c.City
),
CityMostOrders AS (
    SELECT co.ProductID, co.City, co.CityQuantity,
        RANK() OVER (PARTITION BY co.ProductID ORDER BY co.CityQuantity DESC) AS RankByCity
    FROM CityOrders co
)
SELECT pp.ProductName, pp.AvgPrice, cmo.City, cmo.CityQuantity AS MaxCityQuantity
FROM PopularProducts pp
JOIN CityMostOrders cmo ON pp.ProductID = cmo.ProductID
WHERE cmo.RankByCity = 1

-- 9.List all cities that have never ordered something but we have employees there.
-- a.Use sub-query
SELECT DISTINCT e.City
FROM Employees e
WHERE e.City NOT IN (SELECT DISTINCT o.ShipCity FROM Orders o)

-- b.Do not use sub-query
SELECT DISTINCT e.City
FROM Employees e
LEFT JOIN Orders o ON e.City = o.ShipCity
WHERE o.ShipCity IS NULL

-- 10.List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, 
-- and also the city of most total quantity of products ordered from. (tip: join  sub-query)
WITH EmployeeOrderCounts AS (
    SELECT e.City AS EmployeeCity, COUNT(DISTINCT o.OrderID) AS TotalOrders
    FROM Orders o
    JOIN Employees e ON o.EmployeeID = e.EmployeeID
    GROUP BY e.City
),
MostOrdersEmployeeCity AS (
    SELECT TOP 1 EmployeeCity, TotalOrders
    FROM EmployeeOrderCounts
    ORDER BY TotalOrders DESC
),
CustomerOrderCounts AS (
    SELECT c.City AS CustomerCity, SUM(od.Quantity) AS TotalProductQuantity
    FROM [Order Details] od
    JOIN Orders o ON od.OrderID = o.OrderID
    JOIN Customers c ON o.CustomerID = c.CustomerID
    GROUP BY c.City
),
MostProductsOrderedCity AS (
    SELECT TOP 1 CustomerCity, TotalProductQuantity
    FROM CustomerOrderCounts
    ORDER BY TotalProductQuantity DESC
)
SELECT mo.EmployeeCity AS City
FROM MostOrdersEmployeeCity mo
JOIN MostProductsOrderedCity mp ON mo.EmployeeCity = mp.CustomerCity

-- 11.How do you remove the duplicates record of a table?
WITH CTE AS (
    SELECT ProductID,
        ROW_NUMBER() OVER (PARTITION BY ProductName ORDER BY ProductID) AS RowNum
    FROM Products
)
DELETE FROM Products
WHERE ProductID IN (
    SELECT ProductID FROM CTE WHERE RowNum > 1
)