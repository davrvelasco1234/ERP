


DROP TABLE Autos
DROP TABLE Modelos
DROP TABLE Carrocerias
DROP TABLE Marcas
DROP PROCEDURE SP_GetAutos
GO


CREATE TABLE Marcas
(
	Mar_IdMarca INT PRIMARY KEY IDENTITY,
	Mar_Descripcion VARCHAR(50)
)
GO


CREATE TABLE Carrocerias
(
	Car_IdCarroceria INT PRIMARY KEY IDENTITY,
	Car_Descripcion VARCHAR(50)
)
GO


CREATE TABLE Modelos
(
	Mod_IdModelo INT PRIMARY KEY IDENTITY,
	Mod_IdMarca INT,
	Mod_Descripcion VARCHAR(50)
)
GO


CREATE TABLE Autos
(
	Aut_IdAuto INT PRIMARY KEY IDENTITY,
	Aut_IdMarca INT,
	Aut_IdCarroceria INT,
    Aut_IdModelo INT,
	Aut_Anio INT,
    Aut_Color VARCHAR(50),
    Aut_Observaciones VARCHAR(200),
    Aut_Precio DECIMAL(16,6),
    Aut_FechaCompra DATETIME
)
GO



INSERT INTO Marcas VALUES('TOYOTA')								DECLARE @Toyota int = (SELECT SCOPE_IDENTITY())
INSERT INTO Marcas VALUES('NISSAN')								DECLARE @Nissan int = (SELECT SCOPE_IDENTITY())
INSERT INTO Marcas VALUES('MERCEDES BENZ')						DECLARE @Mercedes int = (SELECT SCOPE_IDENTITY())
INSERT INTO Marcas VALUES('BMW')								DECLARE @Bmw int = (SELECT SCOPE_IDENTITY())
INSERT INTO Marcas VALUES('CHEVROLET')							DECLARE @Cevrolet int = (SELECT SCOPE_IDENTITY())
INSERT INTO Marcas VALUES('FORD')								DECLARE @Ford int = (SELECT SCOPE_IDENTITY())
INSERT INTO Marcas VALUES('TESLA')								DECLARE @Tesla int = (SELECT SCOPE_IDENTITY())


INSERT INTO Carrocerias VALUES('PickUp')						DECLARE @PickUp int = (SELECT SCOPE_IDENTITY())
INSERT INTO Carrocerias VALUES('Syubi')							DECLARE @Syubi int = (SELECT SCOPE_IDENTITY())
INSERT INTO Carrocerias VALUES('Sedan')							DECLARE @Sedan int = (SELECT SCOPE_IDENTITY())
INSERT INTO Carrocerias VALUES('Hatchback')						DECLARE @Hatchback int = (SELECT SCOPE_IDENTITY())


INSERT INTO Modelos values(@Toyota,'Corolla')			DECLARE @Corolla int = (SELECT SCOPE_IDENTITY())
INSERT INTO Modelos values(@Toyota,'Yaris')				DECLARE @Yaris int = (SELECT SCOPE_IDENTITY())
INSERT INTO Modelos values(@Toyota,'Rav4')				DECLARE @Rav4 int = (SELECT SCOPE_IDENTITY())
INSERT INTO Modelos values(@Nissan,'Versa')				DECLARE @Versa int = (SELECT SCOPE_IDENTITY())
INSERT INTO Modelos values(@Mercedes,'Clase C')			DECLARE @ClaseC int = (SELECT SCOPE_IDENTITY())
INSERT INTO Modelos values(@Bmw,'Series 3')				DECLARE @Series3 int = (SELECT SCOPE_IDENTITY())
INSERT INTO Modelos values(@Cevrolet,'Cruze')			DECLARE @Cruze int = (SELECT SCOPE_IDENTITY())
INSERT INTO Modelos values(@Ford,'Fusion')				DECLARE @Fusion int = (SELECT SCOPE_IDENTITY())
INSERT INTO Modelos values(@Tesla,'Model S')				DECLARE @ModelS int = (SELECT SCOPE_IDENTITY())


INSERT INTO Autos VALUES (@Toyota, @Sedan, @Corolla, '2022', 'Gris', 'Auto nuevo', 4200.00, GETDATE())
INSERT INTO Autos VALUES (@Toyota, @Sedan, @Yaris, '2022', 'Rojo', 'Auto nuevo', 320000.00, GETDATE())
INSERT INTO Autos VALUES (@Toyota, @Syubi, @Rav4, '2018', 'Gris', 'Camioneta Seminueva', 390000.00, GETDATE())
INSERT INTO Autos VALUES (@Nissan, @Sedan, @Versa, '2020', 'Azul', 'Auto Semi-Nuevo sin daños', 230000.00, GETDATE())
INSERT INTO Autos VALUES (@Bmw, @Sedan, @Series3, '2021', 'Blanco', 'Auto Semi-Nuevo con garantia', 540000.00, GETDATE())
INSERT INTO Autos VALUES (@Cevrolet, @Sedan, @Cruze, '2016', 'Gris', 'Auto Semi-Nuevo con garantia', 200000.00, GETDATE())
GO


CREATE PROCEDURE SP_GetAutos
(
	@IdMarca int = '',
	@IdModelo int = '',
	@IdCarroceria int = '',
	@IdAuto int = '',
	@Anio int = '',
	@PrecioMin int = '',
	@PrecioMax int = ''
)
AS
BEGIN
	SELECT 
		Aut_IdAuto AS IdAuto, 
		Mar_IdMarca AS IdMarca, Mar_Descripcion AS DescMarca,
		Car_IdCarroceria AS IdCarroceria, Car_Descripcion AS DescCarroceria,
		Mod_IdModelo AS IdModelo, Mod_Descripcion AS DescModelo,
		Aut_Anio AS Anio, Aut_Color AS Color, Aut_Precio AS Precio, Aut_FechaCompra AS FechaCompra, Aut_Observaciones AS Observaciones
	FROM Autos
		JOIN Marcas ON Mar_IdMarca = Aut_IdMarca
		JOIN Modelos ON Mod_IdModelo = Aut_IdModelo
		JOIN Carrocerias ON Car_IdCarroceria = Aut_IdCarroceria
	WHERE
		(Mar_IdMarca = @IdMarca or @IdMarca = '')
		AND (Mod_IdModelo = @IdModelo or @IdModelo = '')
		AND (Car_IdCarroceria = @IdCarroceria or @IdCarroceria = '')
		AND (Aut_IdAuto = @IdAuto or @IdAuto = '')
		AND (Aut_Anio = @Anio or @Anio = '')
		AND (Aut_Precio >= @PrecioMin or @PrecioMin = '')
		AND (Aut_Precio <= @PrecioMax or @PrecioMax = '')
END
GO





--EXEC SP_GetAutos @IdMarca = '', @IdModelo = '', @IdCarroceria = '', @IdAuto = '', @Anio = '', @PrecioMin = '', @PrecioMax = ''


/*

SELECT Mar_IdMarca AS Clave, Mar_Descripcion AS Descripcion FROM Marcas
SELECT Mar_IdMarca AS Clave, Mar_Descripcion AS Descripcion FROM Marcas WHERE Mar_IdMarca = @Clave
INSERT INTO Marcas (Mar_Descripcion) VALUES (@Descripcion)
UPDATE Marcas SET Mar_Descripcion = @Descripcion FROM Marcas WHERE Mar_IdMarca = @Clave
DELETE Marcas WHERE Mar_IdMarca = @Clave



SELECT Car_IdCarroceria AS Clave, Car_Descripcion AS Descripcion FROM Carrocerias
SELECT Car_IdCarroceria AS Clave, Car_Descripcion AS Descripcion FROM Carrocerias WHERE Car_IdCarroceria = @Clave
INSERT INTO Carrocerias (Car_Descripcion) VALUES (@Descripcion)
UPDATE Carrocerias SET Car_Descripcion = @Descripcion FROM Carrocerias WHERE Car_IdCarroceria = @Clave
DELETE Carrocerias WHERE Car_IdCarroceria = @Clave



SELECT Mod_IdModelo AS Clave, Mod_IdMarca AS Opcion, Mod_Descripcion AS Descripcion FROM Modelos
SELECT Mod_IdModelo AS Clave, Mod_IdMarca AS Opcion, Mod_Descripcion AS Descripcion FROM Modelos WHERE Mod_IdModelo = @Clave
INSERT INTO Modelos (Mod_IdMarca, Mod_Descripcion) VALUES (@Opcion, @Descripcion)
UPDATE Modelos SET Mod_IdMarca=@Opcion, Mod_Descripcion=@Descripcion FROM Modelos WHERE Mod_IdModelo = @Clave
DELETE Modelos WHERE Mod_IdModelo = @Clave




INSERT INTO Autos (Aut_IdMarca, Aut_IdModelo, Aut_IdCarroceria, Aut_Anio, Aut_Color, Aut_Precio, Aut_FechaCompra, Aut_Observaciones) VALUES (@IdMarca, @IdModelo, @IdCarroceria, @Anio, @Color, @Precio, @FechaCompra, @Observaciones)
UPDATE Autos SET Aut_IdMarca = @IdMarca, Aut_IdModelo = @IdModelo, Aut_Anio = @Anio, Aut_Color = @Color, Aut_Observaciones = @Observaciones, Aut_Precio = @Precio, Aut_FechaCompra = @FechaCompra WHERE Aut_IdAuto = @IdAuto
DELETE Autos WHERE Aut_IdAuto = @IdAuto

*/





