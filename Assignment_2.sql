USE AdventureWorks2019
GO

--1.How many products can you find in the Production.Product table?
SELECT COUNT(*) AS ProductCount
FROM Production.Product

--2.Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory.
--The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(ProductSubcategoryID) AS ProductSubcategoryCount
FROM Production.Product

--3.How many Products reside in each SubCategory? Write a query to display the results with the following titles.
-- ProductSubcategoryID CountedProducts
SELECT ProductSubcategoryID, COUNT(*) AS CountedProducts
FROM Production.Product
GROUP BY ProductSubcategoryID

--4.How many products that do not have a product subcategory.
SELECT COUNT(*) AS ProductsWithoutSubcategory
FROM Production.Product
WHERE ProductSubcategoryID IS NULL;

--5.Write a query to list the sum of products quantity in the Production.ProductInventory table.
SELECT SUM(Quantity) AS QuantitySum5
FROM Production.ProductInventory

--6.Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40
--and limit the result to include just summarized quantities less than 100.
SELECT SUM(Quantity) AS QuantitySum6
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100

--7.Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 
--and limit the result to include just summarized quantities less than 100
-- Shelf   ProductID   TheSum
SELECT Shelf, ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY Shelf, ProductID
HAVING SUM(Quantity) < 100

--8.Write the query to list the average quantity for products 
--where column LocationID has the value of 10 from the table Production.ProductInventory table.
SELECT AVG(Quantity) AS AverageQuantity
FROM Production.ProductInventory
WHERE LocationID = 10

--9.Write query  to see the average quantity of products by shelf from the table Production.ProductInventory
-- ProductID   Shelf   TheAvg
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, Shelf

--10.Write query  to see the average quantity  of  products by shelf excluding rows
--that has the value of N/A in the column Shelf from the table Production.ProductInventory
-- ProductID   Shelf   TheAvg
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE Shelf != 'N/A'
GROUP BY ProductID, Shelf

--11.List the members (rows) and average list price in the Production.Product table.
--This should be grouped independently over the Color and the Class column.
--Exclude the rows where Color or Class are null.
-- Color   Class   TheCount   AvgPrice
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class

--12.Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables.
--Join them and produce a result set similar to the following.
--  Country              Province
SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion c
JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode

--13.Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables 
--and list the countries filter them by Germany and Canada.
--Join them and produce a result set similar to the following.
-- Country               Province
SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion c
JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode
WHERE c.Name IN ('Germany', 'Canada')

--- Using Northwnd Database: (Use aliases for all the Joins)
USE Northwind
GO

-- 14.List all Products that has been sold at least once in last 27 years.
SELECT DISTINCT p.ProductName
FROM Products p
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderID = o.OrderID
WHERE DATEDIFF(YEAR, o.OrderDate, GETDATE()) <= 27

-- 15.List top 5 locations (Zip Code) where the products sold most.
SELECT TOP 5 o.ShipPostalCode, COUNT(od.ProductID) AS ProductCount
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.ShipPostalCode
ORDER BY ProductCount DESC

-- 16.List top 5 locations (Zip Code) where the products sold most in last 27 years.
SELECT TOP 5 o.ShipPostalCode, COUNT(od.ProductID) AS ProductCount
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE DATEDIFF(YEAR, o.OrderDate, GETDATE()) <= 27
GROUP BY o.ShipPostalCode
ORDER BY ProductCount DESC

-- 17.List all city names and number of customers in that city
SELECT c.City, COUNT(*) AS CustomerCount
FROM Customers c
GROUP BY c.City

-- 18.List city names which have more than 2 customers, and number of customers in that city
SELECT c.City, COUNT(*) AS CustomerCount
FROM Customers c
GROUP BY c.City
HAVING COUNT(*) > 2

-- 19.List the names of customers who placed orders after 1/1/98 with order date.
SELECT DISTINCT c.ContactName, o.OrderDate
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01'

-- 20.List the names of all customers with most recent order dates
SELECT c.ContactName, MAX(o.OrderDate) AS MostRecentOrderDate
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName

-- 21.Display the names of all customers  along with the  count of products they bought
SELECT c.ContactName, SUM(od.Quantity) AS TotalProducts
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.ContactName

-- 22.Display the customer ids who bought more than 100 Products with count of products.
SELECT c.CustomerID, SUM(od.Quantity) AS TotalQuantities
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CustomerID
HAVING SUM(od.Quantity) > 100

-- 23.List all of the possible ways that suppliers can ship their products. Display the results as below
-- Supplier Company Name                Shipping Company Name
SELECT s.CompanyName AS [Supplier Company Name], sh.CompanyName AS [Shipping Company Name]
FROM Suppliers s
CROSS JOIN Shippers sh

-- 24.Display the products order each day. Show Order date and Product Name.
SELECT o.OrderDate, p.ProductName
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
ORDER BY o.OrderDate

-- 25.Displays pairs of employees who have the same job title.
SELECT e1.EmployeeID AS Employee1, e2.EmployeeID AS Employee2, e1.Title
FROM Employees e1
JOIN Employees e2 ON e1.Title = e2.Title AND e1.EmployeeID < e2.EmployeeID

-- 26.Display all the Managers who have more than 2 employees reporting to them.
SELECT e.ReportsTo, COUNT(*) AS ReportCount
FROM Employees e
GROUP BY e.ReportsTo
HAVING COUNT(*) > 2

-- 27.Display the customers and suppliers by city. The results should have the following columns
-- City, Name, Contact Name, Type (Customer or Supplier)
SELECT c.City, c.CompanyName AS Name, c.ContactName AS [Contact Name], 'Customer' AS [Type (Customer or Supplier)]
FROM Customers c
UNION
SELECT s.City, s.CompanyName AS Name, s.ContactName, 'Supplier' AS Type
FROM Suppliers s