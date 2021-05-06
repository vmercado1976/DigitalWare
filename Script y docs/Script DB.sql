Create Database DigitalWareDB
Go
Use DigitalWareDB
Go
Create Table Almacen (Id int primary key identity(1,1), Codigo AS ('ALM' + right('0000' + convert([varchar],Id),(4))),  Descripcion varchar(50), Direccion varchar(50))
Go
INSERT INTO Almacen (Descripcion, Direccion) Values ('Principal', 'Calle 73 Via 40-25')
GO
Create Table Categoria (Id int primary key identity(1,1), Codigo AS ('CT' + right('0000' + convert([varchar],Id),(4))), Nombre varchar(50), Descripcion varchar(50))
GO
INSERT INTO Categoria (Nombre,Descripcion) VALUES('SUETER','SUETERS')
INSERT INTO Categoria (Nombre,Descripcion) VALUES('CAMISA', 'CAMISAS')
INSERT INTO Categoria (Nombre,Descripcion) VALUES('PANTALON', 'PANTALONES')
INSERT INTO Categoria (Nombre,Descripcion) VALUES('JEAN', 'JEANS')
--SELECT * FROM Categoria
GO
Create Table Producto (Id int primary key identity(1,1), Codigo AS ('PR' + right('0000' + convert([varchar],Id),(4))),  Nombre varchar(50), Descripcion varchar(50), IdCategoria int references Categoria(Id))
Go
INSERT INTO Producto (Nombre,Descripcion,IdCategoria) VALUES('Suerter Con Cuello', 'Tipo Polo', 1)
INSERT INTO Producto  (Nombre,Descripcion,IdCategoria) VALUES('Suerter Sin Cuello', 'Tipo Redondo', 1)
INSERT INTO Producto  (Nombre,Descripcion,IdCategoria) VALUES('Camisa Manga Larga', 'Seda',2)
INSERT INTO Producto  (Nombre,Descripcion,IdCategoria) VALUES('Camisa Manga Corta', 'Seda',2)
INSERT INTO Producto  (Nombre,Descripcion,IdCategoria) VALUES('Pantalon Tela', 'Seda',3)
INSERT INTO Producto  (Nombre,Descripcion,IdCategoria) VALUES('Pantalon Dril', 'Dril',3)

--SELECT * FROM Producto
GO
Create Table ListaPrecio (Id int primary key identity(1,1), Precio decimal(18,2), Fecha datetime, IdProducto int references Producto(Id))
Go
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(50000, '01/01/2021', 1)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(60000, '02/01/2021', 1)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(65000, '03/01/2021', 1)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(20000, '01/01/2021', 2)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(30000, '02/01/2021', 2)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(35000, '03/01/2021', 2)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(100000, '01/01/2021', 3)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(130000, '02/01/2021', 3)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(135000, '03/01/2021', 3)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(100000, '01/01/2021', 4)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(130000, '02/01/2021', 4)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(135000, '03/01/2021', 4)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(120000, '01/01/2021', 5)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(130000, '02/01/2021', 5)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(140000, '03/01/2021',5)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(120000, '01/01/2021', 6)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(130000, '02/01/2021', 6)
INSERT INTO ListaPrecio (Precio,Fecha,IdProducto) VALUES(140000, '03/01/2021',6)
--select *, month(fecha) from listaprecio
Create Table Kardex (ID int primary key identity(1,1), IdAlmacen int references Almacen(Id), IdProducto int references Producto(Id), Fecha datetime,Documento varchar(5), Entrada int,  Salida int, Saldo int, UltimoCosto decimal(18,2), CostoPromedio decimal(18,2))
Go
INSERT INTO Kardex(IdAlmacen, IdProducto, Fecha, Documento, Entrada, Salida, Saldo, UltimoCosto, CostoPromedio)	VALUES (1,1,GetDate(),'EA',100,0,100,30000,30000)
INSERT INTO Kardex(IdAlmacen, IdProducto, Fecha, Documento, Entrada, Salida, Saldo, UltimoCosto, CostoPromedio)	VALUES (1,2,GETDATE(),'EA',200,0,200,15000,15000)
INSERT INTO Kardex(IdAlmacen, IdProducto, Fecha, Documento, Entrada, Salida, Saldo, UltimoCosto, CostoPromedio)	VALUES (1,3,GETDATE(),'EA',150,0,150,85000,85000)
INSERT INTO Kardex(IdAlmacen, IdProducto, Fecha, Documento, Entrada, Salida, Saldo, UltimoCosto, CostoPromedio)	VALUES (1,4,GETDATE(),'EA',150,0,150,85000,85000)
INSERT INTO Kardex(IdAlmacen, IdProducto, Fecha, Documento, Entrada, Salida, Saldo, UltimoCosto, CostoPromedio)	VALUES (1,5,GETDATE(),'EA',150,0,150,90000,90000)
INSERT INTO Kardex(IdAlmacen, IdProducto, Fecha, Documento, Entrada, Salida, Saldo, UltimoCosto, CostoPromedio)	VALUES (1,6,GETDATE(),'EA',150,0,150,90000,90000)
--select * from Kardex
GO
Create Table Tipo_Identificacion  (Id int primary key identity(1,1), Abreviatura varchar(5), Descripcion varchar(50))
GO
INSERT INTO Tipo_Identificacion(Abreviatura,Descripcion) VALUES('CC','CEDULA DE CIUDADANIA')
INSERT INTO Tipo_Identificacion(Abreviatura,Descripcion) VALUES('CE','CEDULA DE EXTRANJERIA')
INSERT INTO Tipo_Identificacion(Abreviatura,Descripcion) VALUES('NIP','NUMERO DE IDENTIFICACION PERSONAL')
INSERT INTO Tipo_Identificacion(Abreviatura,Descripcion) VALUES('NIT', 'NUMERO DE IDENTIFICACION TRIBUTARIA')
INSERT INTO Tipo_Identificacion(Abreviatura,Descripcion) VALUES('TI','TARJETA DE IDENTIDAD')
INSERT INTO Tipo_Identificacion(Abreviatura,Descripcion) VALUES('PAP','PASAPORTE')
GO
Create Table Cliente (Id int primary key identity(1,1), Codigo AS ('CL' + right('0000' + convert([varchar],Id),(4))), Identificacion varchar(30), Tipo_Documento int references Tipo_Identificacion(Id), NombreCompleto varchar(100), Direccion varchar(50), Telefono varchar(30), FechaNac datetime, Correo varchar(50))
Go
INSERT INTO Cliente(Identificacion, Tipo_Documento, NombreCompleto, Direccion, Telefono, FechaNac, Correo)
VALUES ('8784671',1,'Víctor Mercado Rudas', 'Calle 33 N44 -55', '3108036517', '12/29/1976','victormercadorudas@hotmail.com')
INSERT INTO Cliente(Identificacion, Tipo_Documento, NombreCompleto, Direccion, Telefono, FechaNac, Correo)
VALUES ('22457582',1,'José Perez', 'Calle 33 N14 -55', '3201458714', '01/01/1999','joseperez@hotmail.com')
--select * from cliente
Go
Create Table Factura (Id int primary key identity(1,1), Codigo AS ('FC' + right('0000' + convert([varchar],Id),(4))), IdCliente int references Cliente(Id), Fecha datetime, Subtotal decimal(18,2), Descuento  decimal(18,2), Iva  decimal(18,2), Total  decimal(18,2))
Go
Create Table Detalle (Id int primary key identity(1,1), IdFactura int references Factura(Id),  IdProducto int references Producto(Id), Cantidad int, IdPrecio int references ListaPrecio(Id), Descuento decimal(4,2), Iva decimal(4,2))
Go
--procedimientos almacenados tabla Producto
alter Procedure ProductoAddOrEdit
(
@Id int = null,
@Codigo varchar(6)=null,
@Nombre varchar(50),
@Descripcion varchar(50),
@IdCategoria int
)
AS 
BEGIN

	IF  (@Codigo IS NOT NULL) BEGIN
		IF NOT EXISTS(SELECT 1 FROM Producto WHERE Codigo=@Codigo) BEGIN
				RAISERROR('El código del producto ingresado NO existe',16,1)
				RETURN 0
		END

		SELECT @Id=Id FROM Producto WHERE Codigo=@Codigo
	END


		IF (@Id IS NOT NULL) BEGIN
			UPDATE Producto
				SET
					Nombre=@Nombre,
					Descripcion=@Descripcion,
					IdCategoria=@IdCategoria
				WHERE Id=@Id
		END
		ELSE BEGIN
			INSERT INTO Producto (Nombre,Descripcion,IdCategoria)VALUES(@Nombre,@Descripcion,@IdCategoria)
			SELECT @Id = SCOPE_IDENTITY()
		END

		SELECT p.*, c.* FROM Producto p INNER JOIN Categoria c ON p.IdCategoria=c.Id WHERE p.Id=@Id
END
GO
create Procedure ProductoGetAllOrSeach
(
@Id int = null,
@Codigo varchar(6)=null,
@Search varchar(50)=null
)
AS
BEGIN

	IF  (@Codigo IS NOT NULL) BEGIN
		IF NOT EXISTS(SELECT 1 FROM Producto WHERE Codigo=@Codigo) BEGIN
				RAISERROR('El código del producto ingresado NO existe',16,1)
				RETURN 0
		END

		SELECT @Id=Id FROM Producto WHERE Codigo=@Codigo
	END

		IF (@Id IS NOT NULL) BEGIN
			SELECT p.*, c.*, l.*   
			FROM 
			Producto p LEFT JOIN 
			(SELECT * FROM ListaPrecio WHERE Id IN (
			SELECT MAX(Id) FROM ListaPrecio Group by IdProducto)) l ON p.Id=l.IdProducto
			INNER JOIN Categoria c ON p.IdCategoria=c.Id
			WHERE p.Id=@Id
		END
		ELSE IF (@Search IS NOT NULL) BEGIN
			SELECT p.*, c.*, l.*   
			FROM 
			Producto p LEFT JOIN 
			(SELECT * FROM ListaPrecio WHERE Id IN (
			SELECT MAX(Id) FROM ListaPrecio Group by IdProducto)) l ON p.Id=l.IdProducto
			INNER JOIN Categoria c ON p.IdCategoria=c.Id
			WHERE p.Nombre LIKE '%' + @Search + '%' or p.Descripcion  LIKE '%' + @Search + '%' 
		END
		ELSE
			SELECT p.*, c.*, l.*   
			FROM 
			Producto p LEFT JOIN 
			(SELECT * FROM ListaPrecio WHERE Id IN (
			SELECT MAX(Id) FROM ListaPrecio Group by IdProducto)) l ON p.Id=l.IdProducto
			INNER JOIN Categoria c ON p.IdCategoria=c.Id
END
GO
create Procedure ProductoDel
(
@Codigo varchar(6)=null
)
AS
BEGIN
	declare @Id int

	IF  (@Codigo IS NOT NULL) BEGIN
		IF NOT EXISTS(SELECT 1 FROM Producto WHERE Codigo=@Codigo) BEGIN
				RAISERROR('El código del producto que desea NO existe',16,1)
				RETURN 0
		END

		SELECT @Id=Id FROM Producto WHERE Codigo=@Codigo
	END

	IF EXISTS(SELECT 1 FROM Detalle WHERE IdProducto=@Id) BEGIN
		RAISERROR('El Producto que trata de eliminar posee facturas ingresadas',16,1)
		RETURN 0
	END

	IF EXISTS(SELECT 1 FROM Kardex WHERE Id in (SELECT MAX(Id) FROM Kardex WHERE IdProducto=@Id) and Saldo>0) BEGIN
		RAISERROR('El Producto que trata de eliminar posee existencias en el Kardex',16,1)
		RETURN 0
	END

	DELETE FROM Kardex WHERE IdProducto=@Id
	DELETE FROM ListaPrecio WHERE IdProducto=@Id
	DELETE FROM Producto WHERE Id=@Id

END
GO
--Procedimientos Almacenados de la Tabla Categoria.
CREATE Procedure CategoriaGetAllOrSearch
(
@Codigo varchar(6)=null,
@Search varchar(max)=null
)
AS
BEGIN

		IF (@Codigo IS NOT NULL) BEGIN
			IF NOT EXISTS(SELECT 1 FROM Categoria c WHERE Codigo=@Codigo) BEGIN
				RAISERROR('El código ingresado NO existe',16,1)
				RETURN 0
			END
			SELECT c.* FROM Categoria c WHERE Codigo=@Codigo
		END
		ELSE IF (@Search IS NOT NULL) BEGIN
			SELECT c.*   
			FROM 
			Categoria c 
			WHERE c.Nombre LIKE '%' + @Search + '%' or c.Descripcion  LIKE '%' + @Search + '%' 
		END
		ELSE
			SELECT c.* FROM Categoria c 

END
GO
--Procedimientos almacenados de Facturas
create Procedure FacturaAddOrEdit
(
@IdCliente int,
@Subtotal decimal(18,2),
@Descuento decimal(18,2),
@Iva decimal(18,2)
)
AS
BEGIN
			DECLARE @Id int 
			SET @Descuento=ISNULL(@Descuento,0)
			SET @Iva=ISNULL(@Iva,0)  

			INSERT INTO Factura(IdCliente,Fecha,Subtotal,Descuento,Iva,Total)VALUES(@IdCliente,Getdate(),@Subtotal,@Descuento,@Iva,(@Subtotal+@Iva)-@Descuento)
			SELECT @Id = SCOPE_IDENTITY()

			SELECT Id,Codigo,IdCliente,Fecha,Subtotal,Descuento,Iva,Total FROM Factura WHERE Id=@Id 	   
END
GO
create Procedure DetalleAddOrEdit
(
@IdFactura int,
@IdProducto int,
@Cantidad int,
@Descuento decimal(4,2)=null,
@Iva decimal(4,2)=null
)
AS
BEGIN
		DECLARE @Saldo int,  @IdPrecio int
		Declare @IdAlmacen int, @UltimoCosto decimal(18,2),@CostoPromedio decimal(18,2)
				
		IF NOT EXISTS(SELECT 1 FROM Kardex WHERE IdProducto=@IdProducto) BEGIN
			RAISERROR('El Producto NO tiene Inventario',16,1)
			RETURN 0
		END

		SELECT @IdAlmacen=IdAlmacen, @Saldo=Isnull(Saldo,0), @UltimoCosto=UltimoCosto, @CostoPromedio=CostoPromedio
			FROM Kardex WHERE Id IN (
			SELECT Isnull(Max(Id),0) FROM Kardex WHERE IdProducto=@IdProducto)
		
		IF (@Cantidad>@Saldo) BEGIN
			RAISERROR('El producto NO tiene esa cantidad existente en el Inventario',16,1)
			RETURN 0
		END

		IF NOT EXISTS(SELECT 1 FROM ListaPrecio WHERE IdProducto=@IdProducto) BEGIN
			RAISERROR('El Producto NO tiene lista de precios',16,1)
			RETURN 0
		END

		SELECT @IdPrecio=Isnull(Id,0) FROM ListaPrecio WHERE Id IN (
			SELECT Isnull(MAX(Id),0) FROM ListaPrecio WHERE IdProducto=@IdProducto)

		SET @Descuento=ISNULL(@Descuento,0)
		SET @Iva=ISNULL(@Iva,0)  

		INSERT INTO Detalle(IdFactura,IdProducto,Cantidad,IdPrecio,Descuento,Iva)
			VALUES(@IdFactura,@IdProducto,@Cantidad,@IdPrecio,@Descuento,@Iva)

		INSERT INTO Kardex (IdAlmacen,IdProducto,Fecha,Documento,Entrada,Salida,Saldo,UltimoCosto,CostoPromedio)
			VALUES(@IdAlmacen,@IdProducto,Getdate(),'FC',0,@Cantidad,@Saldo-@Cantidad,@UltimoCosto,@CostoPromedio)
			
END
GO
create Procedure FacturaGetAllOrSearch
@Codigo varchar(6)=null
AS
BEGIN
		IF (@Codigo IS NOT NULL) BEGIN
			DECLARE @Id int

			IF NOT EXISTS(SELECT 1 FROM Factura WHERE Codigo=@Codigo) BEGIN
					RAISERROR('El número de la factura ingresado NO existe',16,1)
					RETURN 0
			END

			SELECT @Id=Id FROM Factura WHERE Codigo=@Codigo

			SELECT f.*, d.*,p.*,l.*,c.* 
				FROM Factura f INNER JOIN Cliente c ON f.IdCliente=c.Id INNER JOIN Detalle d ON f.Id=d.IdFactura
					INNER JOIN Producto p ON d.IdProducto=p.Id LEFT JOIN 
				(SELECT * FROM ListaPrecio WHERE Id IN (
				SELECT MAX(Id) FROM ListaPrecio Group by IdProducto)) l ON p.Id=l.IdProducto
				WHERE f.Id=@Id
		END
		ELSE BEGIN
				SELECT f.*, d.*,p.*,l.*,c.* 
				FROM Factura f INNER JOIN Cliente c ON f.IdCliente=c.Id INNER JOIN Detalle d ON f.Id=d.IdFactura
					INNER JOIN Producto p ON d.IdProducto=p.Id LEFT JOIN 
				(SELECT * FROM ListaPrecio WHERE Id IN (
				SELECT MAX(Id) FROM ListaPrecio Group by IdProducto)) l ON p.Id=l.IdProducto
				 

		END
END
GO
Create Procedure FacturaDel
@Codigo varchar(6)=null
AS
BEGIN
		
		DECLARE @Id int
		IF NOT EXISTS(SELECT 1 FROM Factura WHERE Codigo=@Codigo) BEGIN
				RAISERROR('El número de la factura ingresado NO existe',16,1)
				RETURN 0
		END

		SELECT @Id=Id FROM Factura WHERE Codigo=@Codigo
		SELECT * INTO #temp  FROM Detalle WHERE IdFactura=@Id
		
		DECLARE @count INT;
		SELECT @count = COUNT(*) FROM #temp;

		WHILE @count > 0
		BEGIN
			DECLARE @IdProducto int = (SELECT TOP(1) IdProducto FROM #temp)
			DECLARE @Cantidad int = (SELECT TOP(1) Cantidad FROM #temp)
			DECLARE @Saldo int
			Declare @IdAlmacen int, @UltimoCosto decimal(18,2),@CostoPromedio decimal(18,2)

			SELECT @IdAlmacen=IdAlmacen, @Saldo=Isnull(Saldo,0), @UltimoCosto=UltimoCosto, @CostoPromedio=CostoPromedio
			FROM Kardex WHERE Id IN (
			SELECT Isnull(Max(Id),0) FROM Kardex WHERE IdProducto=@IdProducto)
			
			INSERT INTO Kardex (IdAlmacen,IdProducto,Fecha,Documento,Entrada,Salida,Saldo,UltimoCosto,CostoPromedio)
			VALUES(@IdAlmacen,@IdProducto,Getdate(),'DV',@Cantidad,0,@Saldo+@Cantidad,@UltimoCosto,@CostoPromedio)

			DELETE  TOP(1)  FROM #temp
			SELECT @count = COUNT(*) FROM #temp;
		END

		DROP TABLE #temp;
	
		DELETE FROM Detalle WHERE IdFactura=@Id
		DELETE FROM Factura WHERE Id=@Id

END
GO
--Procedimientos almacenados de Clientes
create Procedure ClienteGetAllOrSearch
@Codigo varchar(6)=null
AS
BEGIN

		IF (@Codigo IS NOT NULL) BEGIN
			IF NOT EXISTS(SELECT 1 FROM Cliente WHERE Codigo=@Codigo) BEGIN
					RAISERROR('El Código del Cliente ingresado NO existe',16,1)
					RETURN 0
			END
			
			SELECT c.*, t.* FROM Cliente c INNER JOIN Tipo_Identificacion t ON c.Tipo_Documento=t.Id  WHERE Codigo=@Codigo
		END
		ELSE BEGIN
			SELECT c.*, t.* FROM Cliente c INNER JOIN Tipo_Identificacion t ON c.Tipo_Documento=t.Id  
		END

END
GO

