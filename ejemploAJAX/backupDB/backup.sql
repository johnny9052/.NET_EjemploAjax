USE [master]
GO
/****** Object:  Database [EjemploAjax]    Script Date: 02/24/2016 11:28:54 ******/
CREATE DATABASE [EjemploAjax] ON  PRIMARY 
( NAME = N'EjemploAjax', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS2\MSSQL\DATA\EjemploAjax.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EjemploAjax_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS2\MSSQL\DATA\EjemploAjax_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EjemploAjax] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EjemploAjax].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EjemploAjax] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [EjemploAjax] SET ANSI_NULLS OFF
GO
ALTER DATABASE [EjemploAjax] SET ANSI_PADDING OFF
GO
ALTER DATABASE [EjemploAjax] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [EjemploAjax] SET ARITHABORT OFF
GO
ALTER DATABASE [EjemploAjax] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [EjemploAjax] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [EjemploAjax] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [EjemploAjax] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [EjemploAjax] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [EjemploAjax] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [EjemploAjax] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [EjemploAjax] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [EjemploAjax] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [EjemploAjax] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [EjemploAjax] SET  DISABLE_BROKER
GO
ALTER DATABASE [EjemploAjax] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [EjemploAjax] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [EjemploAjax] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [EjemploAjax] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [EjemploAjax] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [EjemploAjax] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [EjemploAjax] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [EjemploAjax] SET  READ_WRITE
GO
ALTER DATABASE [EjemploAjax] SET RECOVERY SIMPLE
GO
ALTER DATABASE [EjemploAjax] SET  MULTI_USER
GO
ALTER DATABASE [EjemploAjax] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [EjemploAjax] SET DB_CHAINING OFF
GO
USE [EjemploAjax]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 02/24/2016 11:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [nvarchar](20) NULL,
	[pass] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[municipio]    Script Date: 02/24/2016 11:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[municipio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[descripcion] [nvarchar](2000) NULL,
	[idDepartamento] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[departamento]    Script Date: 02/24/2016 11:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departamento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[descripcion] [nvarchar](2000) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[cargarMunicipio]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cargarMunicipio]

@IdDepartamento int

AS
BEGIN
	SELECT id, nombre
	FROM municipio
	where idDepartamento = @IdDepartamento	
END
GO
/****** Object:  StoredProcedure [dbo].[cargarDepartamento]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cargarDepartamento]

AS
BEGIN
	SELECT id, nombre
	FROM departamento	
END
GO
/****** Object:  StoredProcedure [dbo].[buscarUsuario]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscarUsuario]
@Usuario NVARCHAR(200)

AS
DECLARE @res INT = 0;
BEGIN
	SELECT id,usuario,pass
	FROM usuario
	WHERE usuario = @Usuario
END
GO
/****** Object:  StoredProcedure [dbo].[buscarMunicipio]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscarMunicipio]
@Nombre NVARCHAR(50)

AS
DECLARE @res INT = 0;
BEGIN
	SELECT id,nombre,descripcion,idDepartamento
	FROM municipio
	WHERE nombre = @Nombre
END
GO
/****** Object:  Table [dbo].[estudiante]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estudiante](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[apellido] [nvarchar](50) NULL,
	[semestre] [int] NULL,
	[documento] [nvarchar](50) NULL,
	[idMunicipio] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[eliminarUsuario]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminarUsuario]
@Id INT

AS

DECLARE @res INT = 0;

BEGIN		
		DELETE FROM usuario where id = @Id		
	    SET @res = 1;					
		SELECT @res;
END
GO
/****** Object:  StoredProcedure [dbo].[eliminarMunicipio]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminarMunicipio]
@Id INT

AS

DECLARE @res INT = 0;

BEGIN		
		DELETE FROM municipio where id = @Id		
	    SET @res = 1;					
		SELECT @res;
END
GO
/****** Object:  StoredProcedure [dbo].[listarUsuario]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listarUsuario]

AS
BEGIN
	SELECT id,usuario,pass
	FROM usuario	
END
GO
/****** Object:  StoredProcedure [dbo].[listarMunicipio]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listarMunicipio]

AS
BEGIN
	SELECT mun.id,mun.nombre,mun.descripcion,dep.nombre
	FROM municipio	as mun
	INNER JOIN departamento as dep on dep.id = mun.idDepartamento
END
GO
/****** Object:  StoredProcedure [dbo].[validarUsuario]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[validarUsuario]	
	@Usuario NVARCHAR(MAX),
	@Password NVARCHAR(MAX)
AS
BEGIN
	SELECT id, usuario, pass
	from usuario
	where usuario = @Usuario and pass = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[guardarUsuario]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[guardarUsuario]
@Id INT,
@Usuario NVARCHAR(200),
@Password NVARCHAR(200)



AS
DECLARE @res INT = 0;
BEGIN
	IF(@Id > 0)
		BEGIN
		
		UPDATE usuario
		SET usuario = @Usuario, pass = @Password
		WHERE id = @Id
		
		SET @res = 1;
	
		END
	ELSE
		BEGIN
		
		INSERT INTO usuario VALUES(@Usuario,@Password)
		
		SET @res = 1;
		
		END
		
		SELECT @res;
END
GO
/****** Object:  StoredProcedure [dbo].[guardarMunicipio]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[guardarMunicipio]
@Id INT,
@Nombre NVARCHAR(50),
@Descripcion NVARCHAR(200),
@IdDepartamento INT



AS
DECLARE @res INT = 0;
BEGIN
	IF(@Id > 0)
		BEGIN
		
		UPDATE municipio
		SET nombre = @Nombre, descripcion = @Descripcion, idDepartamento = @IdDepartamento
		WHERE id = @Id
		
		SET @res = 1;
	
		END
	ELSE
		BEGIN
		
		INSERT INTO municipio VALUES(@Nombre,@Descripcion,@idDepartamento)
		
		SET @res = 1;
		
		END
		
		SELECT @res;
END
GO
/****** Object:  StoredProcedure [dbo].[guardarEstudiante]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[guardarEstudiante]
@Id INT,
@Nombre NVARCHAR(50),
@Apellido NVARCHAR(50),
@Semestre int,
@Documento NVARCHAR(50),
@IdMunicipio INT

AS
DECLARE @res INT = 0;
BEGIN
	IF(@Id > 0)
		BEGIN
		
		UPDATE estudiante
		SET nombre = @Nombre, apellido = @Apellido, semestre = @Semestre, 
		    documento = @Documento, idMunicipio = @IdMunicipio
		WHERE id = @Id
		
		SET @res = 1;
	
		END
	ELSE
		BEGIN
		
		INSERT INTO estudiante VALUES(@Nombre, @apellido, @semestre, @documento,@idMunicipio)
		
		SET @res = 1;
		
		END
		
		SELECT @res;
END
GO
/****** Object:  StoredProcedure [dbo].[generarReporte1]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[generarReporte1]

AS
BEGIN
	SELECT COUNT(*) as total, mun.nombre
	FROM municipio as mun
	inner join estudiante as est on est.idMunicipio = mun.id
	group by mun.id, mun.nombre
END
GO
/****** Object:  StoredProcedure [dbo].[listarEstudiante]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[listarEstudiante]

AS
BEGIN
	SELECT est.id,est.nombre,est.apellido,est.semestre,est.documento,mun.nombre
	FROM estudiante	as est
	INNER JOIN municipio as mun on est.idMunicipio = mun.id
END
GO
/****** Object:  StoredProcedure [dbo].[eliminarEstudiante]    Script Date: 02/24/2016 11:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[eliminarEstudiante]
@Id INT

AS

DECLARE @res INT = 0;

BEGIN		
		DELETE FROM estudiante where id = @Id		
	    SET @res = 1;					
		SELECT @res;
END
GO
/****** Object:  StoredProcedure [dbo].[buscarEstudiante]    Script Date: 02/24/2016 11:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[buscarEstudiante]
@Documento NVARCHAR(50)

AS
DECLARE @res INT = 0;
BEGIN
	SELECT est.id,est.nombre,est.apellido,est.semestre,est.documento,est.idMunicipio,mun.idDepartamento
	FROM estudiante  as est
	inner join municipio as mun on mun.id = est.idMunicipio
	WHERE documento = @Documento
END
GO
/****** Object:  ForeignKey [FK__estudiant__idMun__173876EA]    Script Date: 02/24/2016 11:28:56 ******/
ALTER TABLE [dbo].[estudiante]  WITH CHECK ADD FOREIGN KEY([idMunicipio])
REFERENCES [dbo].[municipio] ([id])
GO
