# Cambios en la Base de Datos - AutoParts

## Control de Cambios de la Base de Datos

Este documento registra todos los cambios, migraciones y alteraciones realizadas en la base de datos del proyecto AutoParts.

## Cambios Pendientes / En Desarrollo

### 1. Agregar Columna de Contraseña a la Tabla Usuario

**Descripción:** Agregar campo de contraseña cifrada a la tabla de usuarios.

**SQL:**
```sql
ALTER TABLE Usuario
ADD Clave VARCHAR(50) NOT NULL;
```

**Estado:** ⏳ Pendiente
**Fecha Planeada:** -
**Fecha de Implementación:** -

---

### 2. Crear Tabla de Noticias

**Descripción:** Nueva tabla para gestionar noticias y artículos del sitio.

**SQL:**
```sql
CREATE TABLE Noticias (
    IdNoticia INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(200) NOT NULL,
    Cuerpo TEXT NOT NULL, -- O VARCHAR(MAX) para el contenido
    FechaPublicacion DATETIME DEFAULT GETDATE(),
    Categoria VARCHAR(50), -- Ej: Novedades, Tecnología, Promociones
    ImagenUrl VARCHAR(200), -- Ruta de la imagen si tienen
    Activa BIT DEFAULT 1
);
GO
```

### 3. Insertar Roles Predeterminados

**Descripción:** Cargar los tres roles base del sistema: Cliente, Vendedor y Administrador.

**Roles:**
```sql
INSERT INTO Rol (IdRol, NombreRol, Descripcion)
VALUES
    (1, 'Cliente', 'Usuario comprador del sistema'),
    (2, 'Vendedor', 'Encargado de publicar productos'),
    (3, 'Administrador', 'Gestiona el sistema y usuarios');
```

```
SET IDENTITY_INSERT Rol ON;
GO

-- 2. Hacemos el Insert (¡IMPORTANTE! Mencionar las columnas explícitamente)
INSERT INTO Rol (IdRol, NombreRol, Descripcion)
VALUES
    (1, 'Cliente', 'Usuario comprador del sistema'),
    (2, 'Vendedor', 'Encargado de publicar productos'),
    (3, 'Administrador', 'Gestiona el sistema y usuarios');
GO

-- 3. Volvemos a bloquear la inserción manual (Buena práctica)
SET IDENTITY_INSERT Rol OFF;
GO

```

**Imagenes de noticias:**
//Tabla para las imagenes de las noticias
```sql
CREATE TABLE NoticiaImagen (
    IdNoticiaImagen INT IDENTITY(1,1) PRIMARY KEY,
    IdNoticia INT NOT NULL,
    UrlImagen VARCHAR(MAX) NOT NULL,
    Orden INT DEFAULT 0,
    FechaSubida DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (IdNoticia) REFERENCES Noticias(IdNoticia) ON DELETE CASCADE
);
```

**Modificación para envio de confirmacion de email:**
```sql
ALTER TABLE Usuario
ADD EmailConfirmado BIT DEFAULT 0,
    TokenConfirmacion VARCHAR(100) NULL,
    TokenRecuperacion VARCHAR(100) NULL,
    TokenRecuperacionExpiracion DATETIME NULL;
```

**BORRA TABLAS Carrito y CarritoItem**
```sql
DROP TABLE CarritoItem;
DROP TABLE Carrito;
```

**AGREGAR LA COLUMNA PARA FOTO DE PERFIL**
```sql
ALTER TABLE Usuario
ADD UrlFotoPerfil NVARCHAR(500) NULL;
```
**AGREGAR LA COLUMNA PARA PEDIDO**
```sql
ALTER TABLE Pedido ADD MetodoEnvio varchar(50) NULL; -- 'Domicilio' o 'Retiro'
ALTER TABLE Pedido ADD CostoEnvio decimal(10,2) DEFAULT 0;
ALTER TABLE Pedido ADD ProvinciaEnvio varchar(50) NULL;
ALTER TABLE Pedido ADD CodigoPostal varchar(10) NULL;
```

**TABLA PARA CONFIGURACIONES DEL SISTEMA**
```sql
CREATE TABLE Configuracion (
    IdConfig INT IDENTITY(1,1) PRIMARY KEY,
    Clave VARCHAR(100) NOT NULL UNIQUE,
    Valor VARCHAR(500) NOT NULL,
    Descripcion VARCHAR(200)
);
INSERT INTO Configuracion (Clave, Valor, Descripcion) VALUES
('EmailContacto', 'info@autoparts.com.ar', 'Correo de contacto que se muestra en las páginas'),
('EmailFrom', 'noreply@tuempresa.com', 'Correo desde donde se envían los emails automáticos');
```

**AGREGAR COLUMNAS PARA USUARIO**
```sql
ALTER TABLE Usuario ADD Altura varchar(10) NULL;
ALTER TABLE Usuario ADD CodigoPostal varchar(10) NULL;
ALTER TABLE Usuario ADD Provincia varchar(50) NULL;
```
**AGREGAR IMAGENES PARA PRODUCTOS**
```sql
INSERT INTO Imagen (IdProducto, UrlImagen) 
VALUES (1, '~/assets/img/Productos/Pastilla_Freno_A1.jpg');
INSERT INTO Imagen (IdProducto, UrlImagen) 
VALUES (2, '~/assets/img/Productos/Bujia_NGK_R567.jpg');
INSERT INTO Imagen (IdProducto, UrlImagen) 
VALUES (3, '~/assets/img/Productos/Amortiguador_TRX_Delantero.jpg');
INSERT INTO Imagen (IdProducto, UrlImagen) 
VALUES (4, '~/assets/img/Productos/Pastilla_Freno_Delantera.jpg');
INSERT INTO Imagen (IdProducto, UrlImagen) 
VALUES (5, '~/assets/img/Productos/Disco_Freno_Ventilados_280.jpg');
INSERT INTO Imagen (IdProducto, UrlImagen) 
VALUES (6, '~/assets/img/Productos/Amortiguador_Hidraulico_Delantero.jpg');
INSERT INTO Imagen (IdProducto, UrlImagen) 
VALUES (7, '~/assets/img/Productos/Kit_Bieletas_Estabilizadoras.jpg');
INSERT INTO Imagen (IdProducto, UrlImagen) 
VALUES (8, '~/assets/img/Productos/Extremo_Direccion_Derecho.jpg');
INSERT INTO Imagen (IdProducto, UrlImagen) 
VALUES (9, '~/assets/img/Productos/Precap_Axial_CajaDireccional.jpg');
INSERT INTO Imagen (IdProducto, UrlImagen) 
VALUES (10, '~/assets/img/Productos/Kit_Embrague_Completo.jpg');
INSERT INTO Imagen (IdProducto, UrlImagen) 
VALUES (11, '~/assets/img/Productos/Junta_Homocinetica_LadoRueda.jpg');
INSERT INTO Imagen (IdProducto, UrlImagen) 
VALUES (12, '~/assets/img/Productos/Filtro_AirePanel_AltoFlujo.jpg');
INSERT INTO Imagen (IdProducto, UrlImagen) 
VALUES (13, '~/assets/img/Productos/Bujia_Iridium.jpg');
INSERT INTO Imagen (IdProducto, UrlImagen) 
VALUES (14, '~/assets/img/Productos/Correa_Distribucion_104Dientes.jpg');
```

**MODIFICO LA RESTRICCION EN LA BBD PARA PODER ELIMINAR PRODUCTOS SIN NECESIDAD DE BORRAR OBLIGATORIAMENTE LA IMAGEN - LA IMAGEN QUEDARIA SIN REFERENCIA**
```sql

ALTER TABLE Imagen
ALTER COLUMN IdProducto INT NULL;
GO

-- Eliminar la restricción FK existente
ALTER TABLE Imagen
DROP CONSTRAINT FK_Imagen_Producto;
GO

-- Crear la nueva restricción con ON DELETE SET NULL (las imágenes quedan pero sin referencia al producto)
ALTER TABLE Imagen
ADD CONSTRAINT FK_Imagen_Producto 
FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto) ON DELETE SET NULL;
GO
```
**MODIFICO CATEGORIAS PARA QUE ESTE MEJOR DISTRIBUIDO**
```sql
UPDATE Categoria SET Descripcion = 'Filtros de aire, aceite, combustible' WHERE IdCategoria = 1;
UPDATE Categoria SET Descripcion = 'Pastillas, discos y líquidos de freno' WHERE IdCategoria = 2;
UPDATE Categoria SET Descripcion = 'Amortiguadores, resortes, bujes' WHERE IdCategoria = 3;
UPDATE Categoria SET Descripcion = 'Bujías, cables, bobinas' WHERE IdCategoria = 4; -- Antes era 'Pastillas y discos' repetido o algo asi
UPDATE Categoria SET Descripcion = 'Correas de distribución' WHERE IdCategoria = 5;   -- Antes 'Bujias y correas'
UPDATE Categoria SET Descripcion = 'Embragues, homocinéticas, juntas' WHERE IdCategoria = 6; -- Antes 'Amortiguadores y muelles' repetido

-- 2. Agregar las categorías nuevas que faltan
INSERT INTO Categoria (Descripcion) VALUES 
('Cajas, extremos, precaps'),
('Componentes internos de motor'),
('Accesorios');
GO
-- Esto era un error porque yo tenia id de categorias que habia borrado.  Si las tienen bien ignoren eso.
DELETE FROM Categoria WHERE IdCategoria IN (12, 13, 14);
GO

-- 2. Activar modo manual
SET IDENTITY_INSERT Categoria ON;
GO

-- 3. Insertar con los IDs correctos
INSERT INTO Categoria (IdCategoria, Descripcion) VALUES 
(7, 'Cajas, extremos, precaps'),
(8, 'Componentes internos de motor'),
(9, 'Accesorios');
GO

-- 4. Apagar modo manual y resetear contador (para que el próximo sea 10)
SET IDENTITY_INSERT Categoria OFF;
DBCC CHECKIDENT ('Categoria', RESEED, 9);
GO
```

-- Insert de noticias
INSERT INTO Noticias (Titulo, Cuerpo, FechaPublicacion, Categoria, ImagenUrl, Activa)
VALUES
('Actualización de seguridad 2024', 'Se implementaron nuevas medidas de seguridad para proteger los datos de los usuarios.', '2024-01-10 00:00:00.000', 'Tecnología', NULL, 1),

('Nuevo acuerdo comercial', 'Se cerró un acuerdo estratégico con importantes distribuidores nacionales.', '2024-01-15 00:00:00.000', 'Novedades', NULL, 1),

('Promoción verano 2024', 'Obtené descuentos exclusivos durante todo el mes de febrero.', '2024-02-01 00:00:00.000', 'Promociones', NULL, 1),

('Mantenimiento programado', 'El sistema estará en mantenimiento el día 20 de febrero.', '2024-02-18 00:00:00.000', 'Novedades', NULL, 0),

('Consejos para ahorrar combustible', 'Tips prácticos para mejorar el rendimiento del motor.', '2024-03-01 00:00:00.000', 'Tecnología', NULL, 1),

('Nueva línea de productos', 'Presentamos una nueva categoría de accesorios y repuestos.', '2024-03-10 00:00:00.000', 'Novedades', NULL, 1),

('Promoción especial de servicio', 'Durante marzo podés acceder a un 15% de descuento en servicios seleccionados.', '2024-03-15 00:00:00.000', 'Promociones', NULL, 1),

('Capacitación para clientes', 'Lanzamos cursos gratuitos sobre mantenimiento básico del vehículo.', '2024-04-01 00:00:00.000', 'Novedades', NULL, 1),

('Actualización de catálogo', 'Se incorporaron más de 50 nuevos productos al catálogo digital.', '2024-04-05 00:00:00.000', 'Tecnología', NULL, 1),

('Nueva funcionalidad en la app', 'Ya podés recibir notificaciones personalizadas desde nuestra aplicación móvil.', '2024-04-12 00:00:00.000', 'Tecnología', NULL, 1);


-- Creacion de tabla de reserva de stock
CREATE INDEX IX_ReservaStock_FechaExpiracion ON ReservaStock(FechaExpiracion);
CREATE INDEX IX_ReservaStock_SessionId ON ReservaStock(SessionId);
CREATE INDEX IX_ReservaStock_IdProducto ON ReservaStock(IdProducto);


CREATE TABLE ReservaStock (
    IdReserva INT IDENTITY(1,1) PRIMARY KEY,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    SessionId VARCHAR(100) NOT NULL,
    FechaReserva DATETIME DEFAULT GETDATE(),
    FechaExpiracion DATETIME NOT NULL,
    FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto) ON DELETE CASCADE
);