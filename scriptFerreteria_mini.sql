create database ferreteria
go


USE [ferreteria]
GO
/****** Object:  User [KABI\gmgomez]    Script Date: 09/07/2021 20:49:27 ******/
--CREATE USER [KABI\gmgomez] FOR LOGIN [KABI\gmgomez] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 09/07/2021 20:49:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] NOT NULL,
	[Nombre] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 09/07/2021 20:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 09/07/2021 20:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[IdDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 0) NULL,
	[Importe]  AS ([PrecioUnitario]*[Cantidad]),
PRIMARY KEY CLUSTERED 
(
	[IdDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gastos]    Script Date: 09/07/2021 20:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gastos](
	[IdGastos] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Monto] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGastos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 09/07/2021 20:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[IdMenu] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Controlador] [nvarchar](100) NULL,
	[Accion] [nvarchar](100) NULL,
	[Activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuPermisos]    Script Date: 09/07/2021 20:49:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuPermisos](
	[IdPermiso] [int] NOT NULL,
	[IdMenu] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Tamaño] [nvarchar](50) NULL,
	[Cantidad] [int] NULL,
	[PrecioUnitario] [decimal](18, 0) NULL,
	[Ubicacion] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdPermiso] [int] NULL,
	[Nombre] [nvarchar](100) NULL,
	[Apellido] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Direccion] [nvarchar](500) NULL,
	[Clave] [nvarchar](100) NULL,
	[TipoUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[Fecha] [date] NULL,
	[Total] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([IdVenta])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([IdVenta])
GO
ALTER TABLE [dbo].[MenuPermisos]  WITH CHECK ADD FOREIGN KEY([IdMenu])
REFERENCES [dbo].[Menu] ([IdMenu])
GO
ALTER TABLE [dbo].[MenuPermisos]  WITH CHECK ADD FOREIGN KEY([IdMenu])
REFERENCES [dbo].[Menu] ([IdMenu])
GO
ALTER TABLE [dbo].[MenuPermisos]  WITH CHECK ADD FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permisos] ([IdPermiso])
GO
ALTER TABLE [dbo].[MenuPermisos]  WITH CHECK ADD FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permisos] ([IdPermiso])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permisos] ([IdPermiso])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permisos] ([IdPermiso])
GO
/****** Object:  StoredProcedure [dbo].[EditarVenta1]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EditarVenta1](
@IdVenta int,
@Descripcion nvarchar(200),
@Fecha date,
@Total decimal
)
as
begin
update Venta
set
Descripcion=@Descripcion,
Fecha=@Fecha,
Total=@Total

where IdVenta=@IdVenta

end
GO
/****** Object:  StoredProcedure [dbo].[EliminarVenta]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EliminarVenta](
@IdVenta int
)
as
begin
delete from Venta where(IdVenta=@IdVenta)
end
GO
/****** Object:  StoredProcedure [dbo].[InsertarVenta]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertarVenta](
@Descripcion nvarchar(100),
@Fecha date,
@Total decimal
)
as
insert into Venta(
Descripcion,
Fecha,
Total
)
values(
@Descripcion,
@Fecha,
@Total
)

select @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[Listar]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Listar]
as
begin
select*from Venta
end
GO
/****** Object:  StoredProcedure [dbo].[ListarPorFecha]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ListarPorFecha]
@Fecha date

as
begin
select*from Venta V
inner join DetalleVenta D
ON V.IdVenta=D.IdVenta
where(Fecha=@Fecha)
end
GO
/****** Object:  StoredProcedure [dbo].[ListarVenta]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ListarVenta](
@IdVenta int
) 
as
begin
select v.IdVenta, v.Fecha,c.Nombre, dv.IdProducto, dv.Cantidad, p.PrecioUnitario,v.Descripcion,v.Total from Venta v
inner join DetalleVenta dv on v.IdVenta=dv.IdVenta
inner join Cliente c on c.IdCliente=dv.IdCliente
inner join Producto p on p.IdProducto=dv.IdProducto
where(v.IdVenta=@IdVenta)
order by v.IdVenta
end
GO
/****** Object:  StoredProcedure [dbo].[Menu_Listar]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Menu_Listar]

as
select * from Menu
GO
/****** Object:  StoredProcedure [dbo].[Menu_ListarPorUsuario]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Menu_ListarPorUsuario](
@IdUsuario int
)

as
begin
select m.* from Usuarios u
inner join Permisos p on p.IdPermiso=u.IdPermiso
inner join MenuPermisos mp on mp.IdPermiso=p.IdPermiso
inner join Menu m on m.IdMenu=mp.IdMenu
where (IdUsuario=@IdUsuario)
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerDetalle]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ObtenerDetalle](
@IdVenta int
)
as
begin

select v.IdVenta, v.Fecha,c.Nombre, dv.IdProducto, dv.Cantidad,dv.Importe, p.PrecioUnitario,v.Descripcion,v.Total from Venta v
inner join DetalleVenta dv on v.IdVenta=dv.IdVenta
inner join Cliente c on c.IdCliente=dv.IdCliente
inner join Producto p on p.IdProducto=dv.IdProducto
where(v.IdVenta=@IdVenta)
order by v.IdVenta

end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerDetalleId]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ObtenerDetalleId](
 @IdVenta int
)
as
begin
select * from DetalleVenta 
inner join Venta on DetalleVenta.IdVenta=Venta.IdVenta
where(@IdVenta=DetalleVenta.IdVenta)
end
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuario]    Script Date: 09/07/2021 20:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ObtenerUsuario](
@Email NVARCHAR(100),  @Clave NVARCHAR(100)
)
AS
BEGIN
SET NOCOUNT ON;
SELECT *
FROM Usuarios
WHERE Email=@Email AND Clave =@Clave
end
GO



insert into Permisos
(Descripcion)
values
('Admin')

GO

Insert into Usuarios
(IdPermiso, Nombre, Apellido, Email, Direccion, Clave, TipoUsuario )
values
(1, 'Gustavo', 'Gomez', 'gomez@gmail.com', 'Calle A', '123', 1)

GO


Insert into Menu
(Descripcion, Controlador, Accion, Activo)
values
('Ventas', 'Ventas', 'Index', 1)

go

insert into MenuPermisos
(IdPermiso, IdMenu)
values
(1, 1)

go


insert into Venta
(Descripcion,Fecha,Total)
values
('Lamparitas 100w', getdate(), 100),
('Clavos', GETDATE(), 54)