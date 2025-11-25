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

