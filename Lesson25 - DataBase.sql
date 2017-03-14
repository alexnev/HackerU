--CREATE TABLE Persons
--(
--FirstName VarChar(50),
--LastName VarChar(50),
--BirthDate int
--)

--INSERT INTO Persons (FirstName, LastName, BirthDate)
--VALUES ('Isra', 'Baby', 1984);

--SELECT FirstName, LastName, BirthDate FROM Persons
--SELECT * FROM Persons;
--SELECT DISTINCT * FROM Persons;

--SELECT FirstName, LastName, BirthDate 
--FROM Persons
--WHERE BirthDate <= 1973 OR BirthDate >= 1960 AND FirstName = 'Elad';

--SELECT FirstName, LastName, BirthDate FROM Persons
--ORDER BY BirthDate ASC, LastName DESC

--UPDATE Persons SET BirthDate = 1969 
--WHERE FirstName = 'Elad'

--DELETE FROM Persons WHERE FirstName = 'Erez' AND BirthDate = 1973
--UPDATE Persons SET BirthDate=1973 WHERE FirstName = 'Erez'

--SELECT TOP 10 FirstName, LastName, BirthDate FROM Persons
--ORDER BY BirthDate DESC

--SELECT * INTO PersonsBackup FROM Persons;
--DELETE FROM Persons;

--SELECT * FROM Persons