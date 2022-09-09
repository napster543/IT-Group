use IT_Group
go


IF OBJECT_ID('Cliente', 'U') is not null
	DROP TABLE Cliente
	GO
CREATE TABLE [dbo].[Cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](50) NULL,
	[apellidos] [varchar](50) NULL,
	[numero_identificacion] [varchar](20) NULL,
	[email] [varchar](50) NULL,
	telefono varchar(30),
	[tipo_identificacion] [varchar](50) NULL,
	[fecha_creacion] [datetime] NULL,
	[concat_identificacion_tipo]  AS (concat([numero_identificacion],' - ',[tipo_identificacion])),
	[concat_nombre_apellido]  AS (concat([nombres],' - ',[apellidos]))
	--[telefono] varchar(30)
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

IF OBJECT_ID('Usuario', 'U') is not null
	DROP TABLE Usuario
	GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](50) NULL,
	[pass] [varchar](50) NULL,
	[fecha_creacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

IF OBJECT_ID('Productos', 'U') is not null
	DROP TABLE Productos
	GO
CREATE TABLE [dbo].[Productos](
	[id] [int] IDENTITY(1,1) primary key NOT NULL,
	nombre varchar(50),
	valor money,	
	unitario int,
)

IF OBJECT_ID('Ventas', 'U') is not null
	DROP TABLE Ventas
	GO
CREATE TABLE [dbo].[Ventas](
	[id] [int] IDENTITY(1,1) primary key NOT NULL,
	id_producto int, 
	id_cliente int,
	cantidad int,
	ValorTotal money,
	fecha datetime default GETDATE()	
)
