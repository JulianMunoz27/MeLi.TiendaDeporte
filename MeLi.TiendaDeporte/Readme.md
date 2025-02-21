# Descripción

Proyecto creado para el challenge de [Mercado Libre](https://choosealicense.com/licenses/mit/) en mi proceso de selección.

## Instrucciones

Para correr este proyecto es necesaria la conexión a base de datos, a continuación están los scripts.

## Creación de la base de datos

Corre el siguiente script para crear la base de datos:

```sql
USE [master]
GO

/****** Object:  Database [MeLiTiendaDeportes]    Script Date: 2/20/2025 7:47:47 PM ******/
CREATE DATABASE [MeLiTiendaDeportes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MeLiTiendaDeportes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MeLiTiendaDeportes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MeLiTiendaDeportes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MeLiTiendaDeportes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MeLiTiendaDeportes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MeLiTiendaDeportes] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET ARITHABORT OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET  MULTI_USER 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MeLiTiendaDeportes] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MeLiTiendaDeportes] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [MeLiTiendaDeportes] SET QUERY_STORE = OFF
GO

ALTER DATABASE [MeLiTiendaDeportes] SET  READ_WRITE 
GO
```

## Creación de la tabla productos

```sql
USE [MeLiTiendaDeportes]
GO

/****** Object:  Table [dbo].[Productos]    Script Date: 2/20/2025 7:49:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Category] [varchar](100) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[Brand] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```

# Insersión de los datos en la tabla
```sql
INSERT INTO productos (Name, Category, Price, Stock, Brand) VALUES
('Balon Pro 2026', 'Baloncesto', 52000, 450, 'Wilson'),
('Raqueta Master 3000', 'Tenis', 89000, 200, 'Babolat'),
('Guantes Elite', 'Boxeo', 67000, 150, 'Everlast'),
('Bicicleta Montana X5', 'Ciclismo', 780000, 75, 'Trek'),
('Balon Futbol Liga', 'Futbol', 43000, 600, 'Adidas'),
('Mancuernas 10kg', 'Gimnasio', 55000, 300, 'Reebok'),
('Casco Profesional', 'Ciclismo', 120000, 100, 'Giro'),
('Tobillera Reforzada', 'Rehabilitacion', 23000, 180, 'Nike'),
('Cuerda de Saltar Speed', 'Gimnasio', 15000, 400, 'Puma'),
('Banda Elastica Resistencia', 'Gimnasio', 18000, 500, 'Under Armour'),
('Balon Futbol Sala', 'Futbol', 39000, 350, 'Mitre'),
('Camiseta Compresion', 'Ropa Deportiva', 33000, 250, 'Under Armour'),
('Guayos Speed', 'Futbol', 210000, 140, 'Nike'),
('Pantaloneta Running', 'Atletismo', 29000, 320, 'Adidas'),
('Gorra UV', 'Outdoor', 27000, 280, 'Columbia'),
('Rodillera Ajustable', 'Rehabilitacion', 31000, 190, 'McDavid'),
('Pesas Tobilleras 5kg', 'Gimnasio', 42000, 220, 'Domyos'),
('Tennis Trail Runner', 'Atletismo', 185000, 130, 'Salomon'),
('Balon Voleibol Pro', 'Voleibol', 64000, 160, 'Mikasa'),
('Tabla de Surf Pro', 'Deportes Acuaticos', 350000, 90, 'Rip Curl');
```

# Creación del procedimiento al macenado para obtener las métricas

```sql
USE [MeLiTiendaDeportes]
GO

/****** Object:  StoredProcedure [dbo].[GetMetricas]    Script Date: 2/20/2025 7:52:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetMetricas]
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @total_products INT;
    SELECT @total_products = COUNT(*) FROM productos;
    
    DECLARE @top_categories NVARCHAR(MAX);
    SELECT @top_categories = STRING_AGG(Category, ',')
    FROM (
        SELECT TOP 2 Category
        FROM productos
        GROUP BY Category
        ORDER BY COUNT(*) DESC
    ) AS TopCategories;
    
    DECLARE @total_stock INT;
    SELECT @total_stock = SUM(Stock) FROM productos;
    
    DECLARE @average_price DECIMAL(10,2);
    SELECT @average_price = AVG(Price) FROM productos;
    
    SELECT
        @total_products AS total_products,
        @top_categories AS top_categoriesString,
        @total_stock AS total_stock,
        @average_price AS average_price;
END;
GO
```

## Conclusión

Con esto el proyecto está preparado para ser ejecutado.