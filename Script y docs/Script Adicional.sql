--Procedimientos Almacenados Consultas
--Obtener la lista de precios de todos los productos 
Create Procedure ListaPrecioProductos
AS
BEGIN

		SELECT p.Codigo, p.Nombre, l.Precio, l.Fecha   
			FROM 
			Producto p LEFT JOIN 
			(SELECT * FROM ListaPrecio WHERE Id IN (
			SELECT MAX(Id) FROM ListaPrecio Group by IdProducto)) l ON p.Id=l.IdProducto
			

END
GO
--Obtener la lista de productos cuya existencia en el inventario haya llegado al m�nimo permitido (5 unidades)
Create Procedure ListaProductosKardexLimite
AS
BEGIN

		SELECT p.*   
			FROM 
			Producto p  INNER JOIN Kardex k ON p.Id=k.IdProducto
			WHERE k.Saldo=5

END
GO
--Obtener una lista de clientes no mayores de 35 a�os que hayan realizado compras entre el 1 de febrero de 2000 y el 25 de mayo de 2000 
Create procedure ClientesMayoresCompras
AS
BEGIN

		SELECT c.*  FROM Cliente c INNER JOIN (SELECT * FROM Factura WHERE CONVERT(Date,Fecha) BETWEEN '02/01/2000' AND '05/25/2000') f ON c.Id=f.IdCliente
				WHERE Year(c.FechaNac)<=35

END
GO
--Obtener el valor total vendido por cada producto en el a�o 2000 
Create Procedure ProductosVendidos2000
AS
BEGIN
	
		SELECT p.Codigo, p.Nombre, sum(f.Total) Vendido FROM Factura f INNER JOIN Detalle d ON f.Id=d.IdFactura
					INNER JOIN Producto p ON d.IdProducto=p.Id 
					WHERE Year(f.Fecha)=2000
					GROUP BY  p.Codigo, p.Nombre
END
GO
--Obtener la �ltima fecha de compra de un cliente y seg�n su frecuencia de compra estimar en qu� fecha podr�a volver a comprar. 
Create Procedure Frecuencia
AS
BEGIN
	
		SELECT  c.Codigo, c.NombreCompleto As 'Cliente', MAX(f.Fecha) AS UltimaCompra  
			FROM Factura f INNER JOIN Cliente c ON f.IdCliente=c.Id


END