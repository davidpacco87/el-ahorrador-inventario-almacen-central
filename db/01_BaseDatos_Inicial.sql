USE master;
GO

IF DB_ID(N'ElAhorrador') IS NOT NULL
BEGIN
    ALTER DATABASE ElAhorrador SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE ElAhorrador;
END
GO

CREATE DATABASE ElAhorrador;
GO

USE ElAhorrador;
GO

CREATE TABLE dbo.Usuario (
    IdUsuario INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    NombreUsuario NVARCHAR(40) NOT NULL UNIQUE,
    NombreCompleto NVARCHAR(120) NOT NULL,
    Contrasena NVARCHAR(100) NOT NULL,
    Rol VARCHAR(20) NOT NULL CHECK (Rol IN ('JEFE_ALMACEN', 'AUXILIAR_ALMACEN')),
    Estado BIT NOT NULL DEFAULT (1)
);

CREATE TABLE dbo.Categoria (
    IdCategoria INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nombre NVARCHAR(80) NOT NULL UNIQUE,
    Descripcion NVARCHAR(250) NOT NULL,
    Estado BIT NOT NULL DEFAULT (1),
    IdCategoriaSuperior INT NULL REFERENCES dbo.Categoria (IdCategoria)
);

CREATE TABLE dbo.UnidadMedida (
    IdUnidadMedida INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nombre NVARCHAR(60) NOT NULL UNIQUE,
    Simbolo NVARCHAR(15) NOT NULL UNIQUE,
    Dimension VARCHAR(15) NOT NULL CHECK (Dimension IN ('MASA', 'VOLUMEN', 'UNIDAD', 'PRESENTACION')),
    FactorBase DECIMAL(18,9) NULL,
    Estado BIT NOT NULL DEFAULT (1)
);

CREATE TABLE dbo.UnidadControlStock (
    IdUnidadMedida INT NOT NULL PRIMARY KEY REFERENCES dbo.UnidadMedida (IdUnidadMedida),
    Descripcion NVARCHAR(250) NOT NULL,
    DecimalesPermitidos TINYINT NOT NULL CHECK (DecimalesPermitidos IN (0, 3)),
    Estado BIT NOT NULL DEFAULT (1)
);

CREATE TABLE dbo.Producto (
    IdProducto INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Codigo NVARCHAR(30) NOT NULL UNIQUE,
    Nombre NVARCHAR(120) NOT NULL,
    Descripcion NVARCHAR(300) NOT NULL,
    PresentacionFisica NVARCHAR(120) NOT NULL,
    IdCategoria INT NOT NULL REFERENCES dbo.Categoria (IdCategoria),
    Clasificacion VARCHAR(20) NOT NULL CHECK (Clasificacion IN ('ALIMENTO', 'CARNE', 'HIGIENE_PERSONAL', 'LIMPIEZA_HOGAR')),
    ConservacionRequerida VARCHAR(30) NOT NULL CHECK (ConservacionRequerida IN ('SECO', 'REFRIGERADO', 'CONGELADO')),
    ControlLote BIT NOT NULL,
    ControlVencimiento BIT NOT NULL,
    Estado BIT NOT NULL DEFAULT (1)
);

CREATE TABLE dbo.ProductoUnidadControlStock (
    IdProducto INT NOT NULL REFERENCES dbo.Producto (IdProducto),
    IdUnidadMedida INT NOT NULL REFERENCES dbo.UnidadControlStock (IdUnidadMedida),
    Estado BIT NOT NULL DEFAULT (1),
    PRIMARY KEY (IdProducto, IdUnidadMedida)
);

CREATE TABLE dbo.Zona (
    IdZona INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nombre NVARCHAR(80) NOT NULL UNIQUE,
    Descripcion NVARCHAR(250) NOT NULL,
    Clasificacion VARCHAR(20) NOT NULL,
    PermiteSeco BIT NOT NULL,
    PermiteRefrigerado BIT NOT NULL,
    PermiteCongelado BIT NOT NULL,
    Estado BIT NOT NULL DEFAULT (1)
);

CREATE TABLE dbo.Ubicacion (
    IdUbicacion INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Codigo NVARCHAR(30) NOT NULL UNIQUE,
    Nombre NVARCHAR(80) NOT NULL,
    Descripcion NVARCHAR(250) NOT NULL,
    IdZona INT NOT NULL REFERENCES dbo.Zona (IdZona),
    TipoConservacion VARCHAR(15) NOT NULL CHECK (TipoConservacion IN ('SECO', 'REFRIGERADO', 'CONGELADO')),
    Estado BIT NOT NULL DEFAULT (1)
);

CREATE TABLE dbo.Existencia (
    IdProducto INT NOT NULL REFERENCES dbo.Producto (IdProducto),
    IdUbicacion INT NOT NULL REFERENCES dbo.Ubicacion (IdUbicacion),
    Estado BIT NOT NULL DEFAULT (1),
    PRIMARY KEY (IdProducto, IdUbicacion)
);

CREATE TABLE dbo.Local (
    IdLocal INT NOT NULL PRIMARY KEY CHECK (IdLocal BETWEEN 1 AND 6),
    Nombre NVARCHAR(60) NOT NULL UNIQUE
);

CREATE TABLE dbo.Entrada (
    IdEntrada INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    NumeroConfirmacion INT NOT NULL,
    FechaHora DATETIME2(0) NOT NULL DEFAULT (SYSDATETIME()),
    Tipo VARCHAR(20) NOT NULL CHECK (Tipo IN ('COMPRA_PROVEEDOR', 'DEVOLUCION_LOCAL')),
    Proveedor NVARCHAR(120) NULL,
    IdLocalOrigen INT NULL REFERENCES dbo.Local (IdLocal),
    Conductor NVARCHAR(120) NOT NULL,
    Placa NVARCHAR(15) NOT NULL,
    Observaciones NVARCHAR(300) NULL,
    IdUsuarioRegistro INT NOT NULL REFERENCES dbo.Usuario (IdUsuario),
    CONSTRAINT UQ_Entrada_Confirmacion UNIQUE (IdUsuarioRegistro, NumeroConfirmacion)
);

CREATE TABLE dbo.DetalleEntrada (
    IdDetalleEntrada INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdEntrada INT NOT NULL REFERENCES dbo.Entrada (IdEntrada),
    Renglon INT NOT NULL,
    IdProducto INT NOT NULL,
    IdUnidadMedida INT NOT NULL,
    IdUbicacion INT NOT NULL,
    CantidadEsperada DECIMAL(18,3) NOT NULL,
    CantidadRecibida DECIMAL(18,3) NOT NULL,
    CantidadAceptada DECIMAL(18,3) NOT NULL,
    ResultadoVerificacion VARCHAR(20) NOT NULL,
    FOREIGN KEY (IdProducto, IdUnidadMedida) REFERENCES dbo.ProductoUnidadControlStock (IdProducto, IdUnidadMedida),
    FOREIGN KEY (IdProducto, IdUbicacion) REFERENCES dbo.Existencia (IdProducto, IdUbicacion)
);

CREATE TABLE dbo.IncidenciaRecepcion (
    IdIncidencia INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdDetalleEntrada INT NOT NULL REFERENCES dbo.DetalleEntrada (IdDetalleEntrada),
    Tipo VARCHAR(20) NOT NULL,
    CantidadAfectada DECIMAL(18,3) NOT NULL,
    Observaciones NVARCHAR(300) NOT NULL,
    FechaHora DATETIME2(0) NOT NULL DEFAULT (SYSDATETIME()),
    IdUsuarioRegistro INT NOT NULL REFERENCES dbo.Usuario (IdUsuario)
);

CREATE TABLE dbo.GrupoExistencia (
    IdGrupo INT IDENTITY(501,1) NOT NULL PRIMARY KEY,
    IdProducto INT NOT NULL,
    IdUnidadMedida INT NOT NULL,
    IdUbicacion INT NOT NULL,
    IdDetalleEntrada INT NULL REFERENCES dbo.DetalleEntrada (IdDetalleEntrada),
    FechaRecepcion DATETIME2(0) NOT NULL DEFAULT (SYSDATETIME()),
    Lote NVARCHAR(60) NULL,
    OrigenLote VARCHAR(12) NULL,
    Vencimiento DATE NULL,
    EstadoVerificacionVencimiento VARCHAR(15) NOT NULL,
    CantidadRegistrada DECIMAL(18,3) NOT NULL,
    FOREIGN KEY (IdProducto, IdUnidadMedida) REFERENCES dbo.ProductoUnidadControlStock (IdProducto, IdUnidadMedida),
    FOREIGN KEY (IdProducto, IdUbicacion) REFERENCES dbo.Existencia (IdProducto, IdUbicacion)
);

CREATE TABLE dbo.HistorialOperacion (
    IdHistorial BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TipoOperacion VARCHAR(30) NOT NULL,
    FechaHora DATETIME2(0) NOT NULL DEFAULT (SYSDATETIME()),
    IdUsuario INT NOT NULL REFERENCES dbo.Usuario (IdUsuario),
    Resumen NVARCHAR(400) NOT NULL,
    IdEntrada INT NULL REFERENCES dbo.Entrada (IdEntrada),
    IdIncidencia INT NULL REFERENCES dbo.IncidenciaRecepcion (IdIncidencia)
);
GO

CREATE VIEW dbo.vw_GrupoExistencia AS
SELECT
    g.IdGrupo, g.IdProducto, p.Codigo AS CodigoProducto, p.Nombre AS NombreProducto,
    g.IdUnidadMedida, u.Simbolo AS UnidadControl, g.IdUbicacion, ub.Codigo AS CodigoUbicacion,
    g.FechaRecepcion, ISNULL(g.Lote, N'Sin lote') AS Lote, g.Vencimiento,
    g.EstadoVerificacionVencimiento, g.CantidadRegistrada,
    CAST(CASE
        WHEN g.CantidadRegistrada <= 0 THEN 0
        WHEN g.EstadoVerificacionVencimiento = 'PENDIENTE' THEN 0
        WHEN g.Vencimiento IS NOT NULL AND g.Vencimiento < CAST(SYSDATETIME() AS DATE) THEN 0
        ELSE 1
    END AS BIT) AS HabilitadoParaSalida
FROM dbo.GrupoExistencia g
INNER JOIN dbo.Producto p ON p.IdProducto = g.IdProducto
INNER JOIN dbo.UnidadMedida u ON u.IdUnidadMedida = g.IdUnidadMedida
INNER JOIN dbo.Ubicacion ub ON ub.IdUbicacion = g.IdUbicacion;
GO

CREATE VIEW dbo.vw_Existencia AS
SELECT
    IdProducto, CodigoProducto, NombreProducto, IdUnidadMedida, UnidadControl,
    IdUbicacion, CodigoUbicacion,
    SUM(CantidadRegistrada) AS Registrada,
    SUM(CASE WHEN HabilitadoParaSalida = 1 THEN CantidadRegistrada ELSE 0 END) AS Habilitada
FROM dbo.vw_GrupoExistencia
GROUP BY IdProducto, CodigoProducto, NombreProducto, IdUnidadMedida, UnidadControl, IdUbicacion, CodigoUbicacion;
GO

INSERT INTO dbo.Usuario (NombreUsuario, NombreCompleto, Contrasena, Rol, Estado) VALUES
(N'd.pacco', N'David Pacco', N'Admin123*', 'JEFE_ALMACEN', 1),
(N'e.buendia', N'Erick Buendia', N'Auxiliar123*', 'AUXILIAR_ALMACEN', 1),
(N'p.pachauri', N'Piero Pachauri', N'Auxiliar123*', 'AUXILIAR_ALMACEN', 1);

INSERT INTO dbo.Local (IdLocal, Nombre) VALUES
(1, N'Local 01'), (2, N'Local 02'), (3, N'Local 03'),
(4, N'Local 04'), (5, N'Local 05'), (6, N'Local 06');

INSERT INTO dbo.Categoria (Nombre, Descripcion, Estado, IdCategoriaSuperior) VALUES
(N'Alimentos', N'Categoría raíz de productos alimenticios', 1, NULL),
(N'Bebidas', N'Aguas y bebidas embotelladas', 1, 1),
(N'Lácteos', N'Productos lácteos refrigerados', 1, 1);

INSERT INTO dbo.UnidadMedida (Nombre, Simbolo, Dimension, FactorBase, Estado) VALUES
(N'unidad', N'unidad', 'UNIDAD', NULL, 1),
(N'six-pack', N'six-pack', 'PRESENTACION', NULL, 1),
(N'kilogramo', N'kg', 'MASA', 1.000000000, 1);

INSERT INTO dbo.UnidadControlStock (IdUnidadMedida, Descripcion, DecimalesPermitidos, Estado) VALUES
(1, N'Control por unidad entera', 0, 1),
(2, N'Control por paquete six-pack', 0, 1),
(3, N'Control por masa en kilogramos', 3, 1);

INSERT INTO dbo.Zona (Nombre, Descripcion, Clasificacion, PermiteSeco, PermiteRefrigerado, PermiteCongelado, Estado) VALUES
(N'Productos secos', N'Almacenamiento seco de alimentos y bebidas', 'ALIMENTO', 1, 0, 0, 1),
(N'Carnes y Refrigerados', N'Almacenamiento refrigerado', 'ALIMENTO', 0, 1, 0, 1);

INSERT INTO dbo.Ubicacion (Codigo, Nombre, Descripcion, IdZona, TipoConservacion, Estado) VALUES
(N'SEC-01', N'Estante seco 01', N'Ubicación de productos secos', 1, 'SECO', 1),
(N'REF-01', N'Cámara refrigerada 01', N'Ubicación refrigerada', 2, 'REFRIGERADO', 1);

INSERT INTO dbo.Producto (Codigo, Nombre, Descripcion, PresentacionFisica, IdCategoria, Clasificacion, ConservacionRequerida, ControlLote, ControlVencimiento, Estado) VALUES
(N'AG-625', N'Agua de mesa 625 mL', N'Agua de mesa en botella', N'Botella de 625 mL', 2, 'ALIMENTO', 'SECO', 1, 1, 1),
(N'YG-1000', N'Yogurt natural 1 L', N'Yogurt natural en botella', N'Botella de 1 L', 3, 'ALIMENTO', 'REFRIGERADO', 1, 1, 1);

INSERT INTO dbo.ProductoUnidadControlStock (IdProducto, IdUnidadMedida, Estado) VALUES
(1, 1, 1), (1, 2, 1), (2, 1, 1);

INSERT INTO dbo.Existencia (IdProducto, IdUbicacion, Estado) VALUES
(1, 1, 1), (2, 2, 1);

INSERT INTO dbo.Entrada (NumeroConfirmacion, FechaHora, Tipo, Proveedor, IdLocalOrigen, Conductor, Placa, Observaciones, IdUsuarioRegistro)
VALUES (1, '2026-11-07T09:15:00', 'COMPRA_PROVEEDOR', N'Distribuidora Central', NULL, N'Luis Ramos', N'V5A-318', N'Recepción inicial de mercadería', 2);

INSERT INTO dbo.DetalleEntrada (IdEntrada, Renglon, IdProducto, IdUnidadMedida, IdUbicacion, CantidadEsperada, CantidadRecibida, CantidadAceptada, ResultadoVerificacion)
VALUES
(1, 1, 1, 1, 1, 8, 6, 6, 'CON_INCIDENCIA'),
(1, 2, 1, 1, 1, 9, 9, 9, 'CONFORME'),
(1, 3, 1, 2, 1, 4, 4, 4, 'CONFORME');

INSERT INTO dbo.IncidenciaRecepcion (IdDetalleEntrada, Tipo, CantidadAfectada, Observaciones, FechaHora, IdUsuarioRegistro)
VALUES (1, 'FALTANTE', 2, N'Diferencia respecto de la cantidad esperada', '2026-11-07T09:15:00', 2);

INSERT INTO dbo.GrupoExistencia (IdProducto, IdUnidadMedida, IdUbicacion, IdDetalleEntrada, FechaRecepcion, Lote, OrigenLote, Vencimiento, EstadoVerificacionVencimiento, CantidadRegistrada)
VALUES
(1, 1, 1, 1, '2026-11-07T09:15:00', N'L-251', 'FABRICANTE', '2027-01-10', 'VERIFICADO', 6),
(1, 1, 1, 2, '2026-11-07T09:15:00', N'L-252', 'FABRICANTE', '2027-02-10', 'VERIFICADO', 9),
(1, 2, 1, 3, '2026-11-07T09:15:00', N'L-251', 'FABRICANTE', '2027-01-10', 'VERIFICADO', 4);

INSERT INTO dbo.HistorialOperacion (TipoOperacion, FechaHora, IdUsuario, Resumen, IdEntrada, IdIncidencia)
VALUES
('ENTRADA', '2026-11-07T09:15:00', 2, N'Entrada EN-00001 registrada: 15 unidades y 4 six-pack aceptados', 1, NULL),
('INCIDENCIA', '2026-11-07T09:15:00', 2, N'Incidencia IN-00001: faltante de 2 unidades en AG-625', NULL, 1);
GO