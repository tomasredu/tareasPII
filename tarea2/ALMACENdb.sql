USE [ALMACEN]
GO
/****** Object:  Table [dbo].[articulos]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articulos](
	[id_articulo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[precio_unitario] [money] NOT NULL,
	[estado_activo] [bit] NOT NULL,
 CONSTRAINT [PK_articulos] PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalles_factura]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalles_factura](
	[id_detalle_factura] [int] IDENTITY(1,1) NOT NULL,
	[id_articulo] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[id_factura] [int] NOT NULL,
 CONSTRAINT [PK_detalles_factura] PRIMARY KEY CLUSTERED 
(
	[id_detalle_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facturas]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facturas](
	[id_factura] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[id_forma_pago] [int] NOT NULL,
	[cliente] [varchar](50) NOT NULL,
 CONSTRAINT [PK_facturas] PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[formas_pago]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[formas_pago](
	[id_forma_pago] [int] IDENTITY(1,1) NOT NULL,
	[forma_pago] [varchar](50) NOT NULL,
 CONSTRAINT [PK_formas_pago] PRIMARY KEY CLUSTERED 
(
	[id_forma_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[articulos] ON 

INSERT [dbo].[articulos] ([id_articulo], [nombre], [precio_unitario], [estado_activo]) VALUES (1, N'Coca 1,5L', 2775.3000, 1)
INSERT [dbo].[articulos] ([id_articulo], [nombre], [precio_unitario], [estado_activo]) VALUES (2, N'Harina 1KG', 1025.6550, 1)
INSERT [dbo].[articulos] ([id_articulo], [nombre], [precio_unitario], [estado_activo]) VALUES (5, N'Salsa de tomate', 1731.3300, 1)
INSERT [dbo].[articulos] ([id_articulo], [nombre], [precio_unitario], [estado_activo]) VALUES (6, N'Pan rayado 500g', 1851.0000, 1)
INSERT [dbo].[articulos] ([id_articulo], [nombre], [precio_unitario], [estado_activo]) VALUES (7, N'Dulce de leche', 1397.1750, 0)
INSERT [dbo].[articulos] ([id_articulo], [nombre], [precio_unitario], [estado_activo]) VALUES (8, N'Arroz 1KG', 432.0000, 0)
SET IDENTITY_INSERT [dbo].[articulos] OFF
GO
SET IDENTITY_INSERT [dbo].[detalles_factura] ON 

INSERT [dbo].[detalles_factura] ([id_detalle_factura], [id_articulo], [cantidad], [id_factura]) VALUES (5, 1, 14, 5)
INSERT [dbo].[detalles_factura] ([id_detalle_factura], [id_articulo], [cantidad], [id_factura]) VALUES (6, 2, 3, 5)
INSERT [dbo].[detalles_factura] ([id_detalle_factura], [id_articulo], [cantidad], [id_factura]) VALUES (7, 1, 1, 6)
INSERT [dbo].[detalles_factura] ([id_detalle_factura], [id_articulo], [cantidad], [id_factura]) VALUES (17, 6, 1, 15)
INSERT [dbo].[detalles_factura] ([id_detalle_factura], [id_articulo], [cantidad], [id_factura]) VALUES (18, 1, 2, 15)
INSERT [dbo].[detalles_factura] ([id_detalle_factura], [id_articulo], [cantidad], [id_factura]) VALUES (19, 7, 2, 15)
INSERT [dbo].[detalles_factura] ([id_detalle_factura], [id_articulo], [cantidad], [id_factura]) VALUES (22, 5, 4, 18)
SET IDENTITY_INSERT [dbo].[detalles_factura] OFF
GO
SET IDENTITY_INSERT [dbo].[facturas] ON 

INSERT [dbo].[facturas] ([id_factura], [fecha], [id_forma_pago], [cliente]) VALUES (5, CAST(N'2024-09-07T18:43:13.537' AS DateTime), 2, N'Julian Rago')
INSERT [dbo].[facturas] ([id_factura], [fecha], [id_forma_pago], [cliente]) VALUES (6, CAST(N'2024-09-07T18:46:30.767' AS DateTime), 2, N'Luciana Gennari')
INSERT [dbo].[facturas] ([id_factura], [fecha], [id_forma_pago], [cliente]) VALUES (15, CAST(N'2024-09-07T20:59:33.667' AS DateTime), 2, N'Catalina')
INSERT [dbo].[facturas] ([id_factura], [fecha], [id_forma_pago], [cliente]) VALUES (18, CAST(N'2024-09-07T21:35:03.110' AS DateTime), 3, N'Adrian Juarez')
SET IDENTITY_INSERT [dbo].[facturas] OFF
GO
SET IDENTITY_INSERT [dbo].[formas_pago] ON 

INSERT [dbo].[formas_pago] ([id_forma_pago], [forma_pago]) VALUES (1, N'Debito')
INSERT [dbo].[formas_pago] ([id_forma_pago], [forma_pago]) VALUES (2, N'Efectivo')
INSERT [dbo].[formas_pago] ([id_forma_pago], [forma_pago]) VALUES (3, N'Credito')
SET IDENTITY_INSERT [dbo].[formas_pago] OFF
GO
ALTER TABLE [dbo].[articulos] ADD  CONSTRAINT [d_estado]  DEFAULT ((1)) FOR [estado_activo]
GO
ALTER TABLE [dbo].[detalles_factura]  WITH CHECK ADD  CONSTRAINT [fk_det_articulo] FOREIGN KEY([id_articulo])
REFERENCES [dbo].[articulos] ([id_articulo])
GO
ALTER TABLE [dbo].[detalles_factura] CHECK CONSTRAINT [fk_det_articulo]
GO
ALTER TABLE [dbo].[detalles_factura]  WITH CHECK ADD  CONSTRAINT [fk_det_factura] FOREIGN KEY([id_factura])
REFERENCES [dbo].[facturas] ([id_factura])
GO
ALTER TABLE [dbo].[detalles_factura] CHECK CONSTRAINT [fk_det_factura]
GO
ALTER TABLE [dbo].[facturas]  WITH CHECK ADD  CONSTRAINT [fk_factura_forma_pago] FOREIGN KEY([id_forma_pago])
REFERENCES [dbo].[formas_pago] ([id_forma_pago])
GO
ALTER TABLE [dbo].[facturas] CHECK CONSTRAINT [fk_factura_forma_pago]
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_ARTICULO]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_AGREGAR_ARTICULO]
	@nombre varchar(50),
	@precio money
as
begin
	insert into articulos(nombre, precio_unitario)
	values(@nombre,@precio)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_DETALLE]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SP_AGREGAR_DETALLE]
	@id_factura int,
	@id_articulo int,
	@cantidad int
as
begin
	insert into detalles_factura(id_factura, id_articulo, cantidad)
	values(@id_factura, @id_articulo, @cantidad)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_FACTURA]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SP_AGREGAR_FACTURA]
	@fecha DATETIME,
	@id_forma_pago int,
	@cliente varchar(50),
	@id_factura int output
as
begin
	insert into facturas(fecha, id_forma_pago, cliente)
	values(@fecha, @id_forma_pago, @cliente)

	set @id_factura = SCOPE_IDENTITY()
end

GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_FORMA_PAGO]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_AGREGAR_FORMA_PAGO]
@forma varchar(50)
as
begin
	insert into formas_pago(forma_pago)
	values(@forma)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_AUMENTAR_PRECIOS]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_AUMENTAR_PRECIOS]
@aumento decimal(10,2)
as
begin
	update articulos
	set precio_unitario = precio_unitario * @aumento
end
GO
/****** Object:  StoredProcedure [dbo].[SP_BORRAR_ARTICULO]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_BORRAR_ARTICULO]
@id_articulo int
as
begin
	delete from articulos
	where id_articulo = @id_articulo
end
GO
/****** Object:  StoredProcedure [dbo].[SP_BORRAR_DETALLES_POR_FACTURA]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_BORRAR_DETALLES_POR_FACTURA]
	@id_factura int
as
begin
	delete from detalles_factura
	where id_factura = @id_factura
end
GO
/****** Object:  StoredProcedure [dbo].[SP_BORRAR_FACTURA]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_BORRAR_FACTURA]
	@id_factura int
as
begin
	delete from facturas
	where id_factura = @id_factura
end
GO
/****** Object:  StoredProcedure [dbo].[SP_BORRAR_FORMA_PAGO]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_BORRAR_FORMA_PAGO]
@id_forma_pago int
as
begin
	delete from formas_pago
	where id_forma_pago = @id_forma_pago
end
GO
/****** Object:  StoredProcedure [dbo].[SP_DESACTIVAR_ARTICULO]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DESACTIVAR_ARTICULO]
	-- Add the parameters for the stored procedure here
	@id_articulo int
AS
BEGIN
	DECLARE @estado bit
	SET @estado = (select estado_activo from articulos where id_articulo = @id_articulo)
	IF @estado = 1
		BEGIN
			update articulos
			set estado_activo = 0
			where id_articulo = @id_articulo
		END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EDITAR_ARTICULO]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_EDITAR_ARTICULO]
@id_articulo int,
@nombre varchar(50),
@precio money,
@estado bit
as
begin update articulos
		set nombre = @nombre,
			precio_unitario = @precio,
			estado_activo = @estado
		where id_articulo = @id_articulo
end
GO
/****** Object:  StoredProcedure [dbo].[SP_EDITAR_DETALLE]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_EDITAR_DETALLE]
	@id_detalle_factura int,
	@id_factura int,
	@id_articulo int,
	@cantidad int
as
begin
	update detalles_factura
	set id_factura = @id_factura,
		id_articulo = @id_articulo,
		cantidad = @cantidad
	where id_detalle_factura = @id_detalle_factura
end
GO
/****** Object:  StoredProcedure [dbo].[SP_EDITAR_FACTURA]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_EDITAR_FACTURA]
	@id_factura int,
	@fecha DATETIME,
	@id_forma_pago int,
	@cliente varchar(50)
as
begin
	update facturas
	set fecha = @fecha,
		id_forma_pago = @id_forma_pago,
		cliente = @cliente
	where id_factura = @id_factura
end
GO
/****** Object:  StoredProcedure [dbo].[SP_EDITAR_FORMA_PAGO]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_EDITAR_FORMA_PAGO]
@id int,
@forma varchar(50)
as
begin update formas_pago
		set forma_pago = @forma
		where id_forma_pago = @id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_ARTICULO_POR_CODIGO]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SP_RECUPERAR_ARTICULO_POR_CODIGO]
	@id_articulo int
as
begin
	select id_articulo Codigo, nombre Articulo, precio_unitario 'Precio Unitario', estado_activo
	from articulos
	where id_articulo = @id_articulo
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_ARTICULOS]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_RECUPERAR_ARTICULOS]
as
begin
	select id_articulo Codigo, nombre Articulo, precio_unitario 'Precio Unitario', estado_activo
	from articulos
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FACTURAS]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SP_RECUPERAR_FACTURAS]
as
begin
	select f.id_factura,
			fecha,
			cliente,
			fp.id_forma_pago,
			fp.forma_pago,
			d.id_detalle_factura,
			d.id_articulo,
			a.nombre,
			a.precio_unitario,
			d.cantidad
		
	from facturas f join detalles_factura d on f.id_factura = d.id_factura
		join formas_pago fp on f.id_forma_pago = fp.id_forma_pago
		join articulos a on d.id_articulo = a.id_articulo
end

GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FACTURAS_POR_CODIGO]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_RECUPERAR_FACTURAS_POR_CODIGO]
	@id_factura int
as
begin
	select f.id_factura,
			fecha,
			cliente,
			fp.id_forma_pago,
			fp.forma_pago,
			d.id_detalle_factura,
			d.id_articulo,
			a.nombre,
			a.precio_unitario,
			d.cantidad
		
	from facturas f join detalles_factura d on f.id_factura = d.id_factura
		join formas_pago fp on f.id_forma_pago = fp.id_forma_pago
		join articulos a on d.id_articulo = a.id_articulo
	where f.id_factura = @id_factura
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_FORMAS_PAGO]    Script Date: 9/17/2024 11:06:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_RECUPERAR_FORMAS_PAGO]
as
begin
	select id_forma_pago Codigo, forma_pago 'Forma de Pago'
	from formas_pago
end
GO
