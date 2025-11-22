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

**SQL:**
```sql
INSERT INTO Rol (IdRol, NombreRol, Descripcion)
VALUES
    (1, 'Cliente', 'Usuario comprador del sistema'),
    (2, 'Vendedor', 'Encargado de publicar productos'),
    (3, 'Administrador', 'Gestiona el sistema y usuarios');
```

