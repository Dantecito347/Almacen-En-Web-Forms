CREATE DATABASE Almacen;
GO

USE Almacen;
GO

CREATE TABLE Productos_Alimentos (
ID INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(100) NOT NULL,
Precio DECIMAL(10,2) NOT NULL,
Stock INT NOT NULL,
);
GO

SET IDENTITY_INSERT Productos_Alimentos ON;

INSERT INTO Productos_Alimentos (ID, Nombre, Precio, Stock) VALUES
(1, 'Fideos Sol Pampeano Tallarínes', 800.00, 50),
(2, 'Fideos Sol Pampeano Spaggueti', 800.00, 50),
(3, 'Fideos Sol Pampeano Tirabuzón', 800.00, 50),
(4, 'Fideos Sol Pampeano Dedal', 800.00, 50),
(5, 'Fideos Sol Pampeano Codo', 800.00, 50),
(6, 'Fideos Sol Pampeano Mostachol', 800.00, 50),
(7, 'Arroz Máximo 1kg', 1900.00, 50),
(8, 'Arrpz Molinos ALA', 2500.00, 20),
(9, 'Aceite Natura 900ml', 2300.00, 25),
(10, 'Aceite Cocinero 900ml', 2700.00, 15),
(11, 'Sal Fina Celusal 500g', 1290.00, 15),
(12, 'Puré de Tomate Mora 520g', 730.00, 25),
(13, 'Puré de Tomate INCAA 520g', 1000.00, 25),
(14, 'Mayonesa Hellmans 500ml', 2850.00, 30),
(15, 'Mayonesa Hellmans 250ml', 1450.00, 50),
(16, 'Mayonesa CadaDia 250ml', 950.00, 25),
(17, 'Yerba Unión 500g', 2200.00, 15),
(18,'Yerba Chamigo 500g', 1900.00, 15),
(19, 'Yerba Amanda 500g', 2350.00, 15),
(20, 'Yerba Rosamonte 500g', 2100.00, 15),
(21, 'Yerba Mañanita 500g', 2200.00, 15),
(22, 'Yerba Taraguí 500g', 2200.00, 15),
(23, 'Harina Leudante Morixe 1kg', 1200.00, 20),
(24, 'Harina Leudante Pureza 1kg', 1650.00, 15),
(25, 'Azúcar Común Doña Inés 1kg', 1100.00, 35),
(26, 'Polenta S&P 500g', 750.00, 40),
(27, 'Chocolatada en polvo Nesquik 360g', 3400.00, 25),
(28, 'Chocolatada en polvo Chocolino 180g', 1800.00, 35);

SET IDENTITY_INSERT Productos_Alimentos OFF;

CREATE TABLE Productos_Bebidas (
ID INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(100) NOT NULL,
Precio DECIMAL(10,2) NOT NULL,
Stock INT NOT NULL
);

SET IDENTITY_INSERT Productos_Bebidas ON;

INSERT INTO Productos_Bebidas (ID, Nombre, Precio, Stock) VALUES
(1, 'Gaseosa Secco 3l', 2000.00, 50),
(2, 'Gaseosa Manaos 3l', 3000.00, 50),
(3, 'Gaseosa Baggio 2.25l', 1400.00, 50),
(4, 'Sprite 1.75l', 3400.00, 50),
(5, 'Jugo de Uva Brio Villa del Sur', 950.00, 30),
(6, 'Jugo de Naranja Brio Villa del Sur', 920.00, 60),
(7, 'Jugo de Pomelo Brio Villa del Sur', 920.00, 60),
(8, 'Jugo Multifruta Brio Villa del Sur', 920.00, 60);

SET IDENTITY_INSERT Productos_Bebidas OFF;

CREATE TABLE Productos_Lacteos (
ID INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(100) NOT NULL,
Precio DECIMAL(10,2) NOT NULL,
Stock INT NOT NULL
);

SET IDENTITY_INSERT Productos_Lacteos ON;

INSERT INTO Productos_Lacteos (ID, Nombre, Precio, Stock) VALUES
(1, 'Leche Entera Ilolay 1l', 2200.00, 50),
(2, 'Leche Entera Milkout 1l', 1950.00, 50),
(3, 'Leche Entera Apostoles 1l', 1700.00, 50),
(4, 'Leche Entera 7 Vidas 1l', 1750.00, 50),
(5, 'Leche Entera La Familia 1l', 1400.00, 50),
(6, 'Queso Cremoso 200g', 1900.00, 20),
(7, 'Manteca La Familia 200ml', 2100.00, 25),
(8, 'Crema de Leche La Familia', 2100.00, 15),
(9, 'Dulce de Leche Tonadita 400g', 2100.00, 15),
(10, 'Dulce de Leche Milkout 400g', 2600.00, 15),
(11, 'Dulce de Leche La Paulina 400g', 3200.00, 15);

SET IDENTITY_INSERT Productos_Lacteos OFF;

CREATE TABLE Repartidores (
PersonaID INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50) NOT NULL,
Apellido VARCHAR(50) NOT NULL,
Email VARCHAR(100) UNIQUE NOT NULL,
Celular VARCHAR(20) UNIQUE NOT NULL,
Localidad VARCHAR(100) NOT NULL,
TipoDeVehiculo VARCHAR(100) NOT NULL,
);

SET IDENTITY_INSERT Repartidores ON; 

INSERT INTO Repartidores (PersonaID, Nombre, Apellido, Email, Celular, Localidad, TipoDeVehiculo) VALUES
(1, 'Carlos', 'Gómez', 'carlos.gomez@example.com', '1234567890', 'Buenos Aires', 'Auto'),
(2, 'Lucia', 'Martínez', 'lucia.martinez@example.com', '9876543210', 'Rosario', 'Bicicleta'),
(3, 'Juan', 'Peréz', 'juan,perez@example.com', '1357924680', 'Córdoba', 'Auto'),
(4, 'Sofía', 'López', 'sofia.lopez@example.com', '1482593760', 'Mendoza', 'Moto'),
(5, 'Diego', 'Ramírez', 'diego.ramirez@example.com', '2468013579', 'La Plata', 'Camioneta');

SET IDENTITY_INSERT Repartidores OFF;  

CREATE TABLE Carrito (
ID INT PRIMARY KEY IDENTITY(1,1),
ProductoID INT NOT NULL,
NombreProducto VARCHAR(100) NOT NULL,
Precio DECIMAL(10,2) NOT NULL,
Cantidad INT NOT NULL
);

CREATE PROCEDURE ObtenerCarritoConTotal
AS
BEGIN
    SELECT ID, NombreProducto, Precio, Cantidad, (Precio * Cantidad) AS Subtotal
    FROM Carrito;

    SELECT SUM(Precio * Cantidad) AS Total
    FROM Carrito;
END
GO

CREATE PROCEDURE AgregarProductoAlCarrito
    @ProductoID INT,
    @NombreProducto VARCHAR(100),
    @Precio DECIMAL(10,2),
    @Cantidad INT
AS
BEGIN
    INSERT INTO Carrito (ProductoID, NombreProducto, Precio, Cantidad)
    VALUES (@ProductoID, @NombreProducto, @Precio, @Cantidad);
END
GO


ALTER PROCEDURE EliminarProductoDelCarrito
    @CarritoID INT
AS
BEGIN
    DELETE FROM Carrito
    WHERE ID = @CarritoID;
END


CREATE PROCEDURE ActualizarCantidadProducto
    @CarritoID INT,
    @NuevaCantidad INT
AS
BEGIN
    UPDATE Carrito
    SET Cantidad = @NuevaCantidad
    WHERE ID = @CarritoID;
END

CREATE PROCEDURE GestionarRepartidor
    @Accion VARCHAR(10), -- 'INSERTAR' o 'ELIMINAR'
    @Nombre VARCHAR(50) = NULL,
    @Apellido VARCHAR(50) = NULL,
    @Email VARCHAR(100) = NULL,
    @Celular VARCHAR(20) = NULL,
    @Localidad VARCHAR(100) = NULL,
    @TipoDeVehiculo VARCHAR(100) = NULL,
	@ProductoID INT = NULL,
AS
BEGIN
    IF @Accion = 'INSERTAR'
    BEGIN
        IF EXISTS (SELECT 1 FROM Repartidores WHERE Email = @Email OR Celular = @Celular)
        BEGIN
            PRINT 'Ya existe un repartidor con ese Email o Celular.';
        END
        ELSE
        BEGIN
            INSERT INTO Repartidores (Nombre, Apellido, Email, Celular, Localidad, TipoDeVehiculo)
            VALUES (@Nombre, @Apellido, @Email, @Celular, @Localidad, @TipoDeVehiculo);
            PRINT 'Repartidor insertado correctamente.';
        END
    END
    ELSE IF @Accion = 'ELIMINAR'
    BEGIN
        IF EXISTS (SELECT 1 FROM Repartidores WHERE PersonaID = @PersonaID OR Email = @Email)
        BEGIN
            DELETE FROM Repartidores WHERE PersonaID = @PersonaID OR Email = @Email;
            PRINT 'Repartidor eliminado correctamente.';
        END
        ELSE
        BEGIN
            PRINT 'No se encontró un repartidor con ese ID o Email.';
        END
    END
    ELSE
    BEGIN
        PRINT 'Acción no reconocida.';
    END
END;



CREATE PROCEDURE DescontarStock
  @ProductoID INT,
  @Cantidad   INT
AS
BEGIN
  SET NOCOUNT ON;
  BEGIN TRAN;

  IF EXISTS(SELECT 1 FROM Productos_Alimentos   WHERE ID = @ProductoID)
  BEGIN
    UPDATE Productos_Alimentos
      SET Stock = Stock - @Cantidad
    WHERE ID = @ProductoID;
  END
  ELSE IF EXISTS(SELECT 1 FROM Productos_Bebidas    WHERE ID = @ProductoID)
  BEGIN
    UPDATE Productos_Bebidas
      SET Stock = Stock - @Cantidad
    WHERE ID = @ProductoID;
  END
  ELSE IF EXISTS(SELECT 1 FROM Productos_Lacteos    WHERE ID = @ProductoID)
  BEGIN
    UPDATE Productos_Lacteos
      SET Stock = Stock - @Cantidad
    WHERE ID = @ProductoID;
  END
  ELSE
  BEGIN
    RAISERROR('ProductoID %d no existe en ninguna tabla de productos.',16,1,@ProductoID);
    ROLLBACK;
    RETURN;
  END

  COMMIT;
END
GO



  CREATE PROCEDURE ReponerStock
    @ProductoID INT,
    @Cantidad   INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM Productos_Alimentos WHERE ID = @ProductoID)
    BEGIN
        UPDATE Productos_Alimentos
        SET Stock = Stock + @Cantidad
        WHERE ID = @ProductoID;
    END
    ELSE IF EXISTS(SELECT 1 FROM Productos_Bebidas WHERE ID = @ProductoID)
    BEGIN
        UPDATE Productos_Bebidas
        SET Stock = Stock + @Cantidad
        WHERE ID = @ProductoID;
    END
    ELSE IF EXISTS(SELECT 1 FROM Productos_Lacteos WHERE ID = @ProductoID)
    BEGIN
        UPDATE Productos_Lacteos
        SET Stock = Stock + @Cantidad
        WHERE ID = @ProductoID;
    END
END
GO