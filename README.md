# 🚛 Sistema de Gestión de Transporte

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://docs.microsoft.com/en-us/aspnet/core/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-512BD4?style=for-the-badge&logo=nuget&logoColor=white)](https://docs.microsoft.com/en-us/ef/core/)
[![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)](https://www.mysql.com/)

## 📋 Descripción

Sistema integral de gestión y administración para empresas de transporte de carga. Permite llevar un registro completo de la flota de camiones, programar y controlar el mantenimiento preventivo y correctivo, así como gestionar los viajes y rutas realizadas por cada vehículo.

### ✨ Características principales

- 🚚 **Gestión de flota**: Registro completo de camiones y vehículos
- 🔧 **Control de mantenimiento**: Programación y seguimiento de mantenciones
- 📊 **Registro de viajes**: Historial detallado de rutas y transportes
- 💾 **Base de datos MySQL**: Persistencia robusta de datos
- 🏗️ **Database First**: Desarrollo basado en esquema de base de datos existente
- 🌐 **Web Application**: Interfaz web intuitiva y responsive

## 🛠️ Tecnologías utilizadas

### Framework y Runtime
- **[.NET 8.0](https://dotnet.microsoft.com/download)** - Framework principal
- **ASP.NET Core 8.0** - Framework web
- **C#** - Lenguaje de programación

### Base de datos y ORM
- **Entity Framework Core** - ORM principal
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.Tools`
  - `Microsoft.EntityFrameworkCore.Design`
- **MySQL** - Sistema de gestión de base de datos
  - `Pomelo.EntityFrameworkCore.MySql` - Proveedor MySQL para EF Core

### Arquitectura
- **Database First** - Generación de modelos desde base de datos existente
- **Razor Pages** - Motor de vistas para la interfaz web
- **MVC Pattern** - Patrón Modelo-Vista-Controlador

## 📋 Requisitos previos

Antes de ejecutar el proyecto, asegúrate de tener instalado:

- ✅ **[.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)**
- ✅ **[MySQL Server](https://dev.mysql.com/downloads/mysql/)** (local o remoto)
- ✅ **[MySQL Workbench](https://dev.mysql.com/downloads/workbench/)** (recomendado para administración)
- ✅ **Editor de código** (Visual Studio, VS Code, Rider, etc.)

## 🚀 Instalación y configuración

### 1. Clonar el repositorio

```bash
git clone https://github.com/zGreenCat/Transport-Company-System.git
cd Transport-Company-System
```

### 2. Configurar la base de datos

1. Crear una base de datos MySQL:
```sql
CREATE DATABASE transport_system;
```

2. Configurar la cadena de conexión en `Transport/appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=transport_system;Uid=tu_usuario;Pwd=tu_contraseña;"
  }
}
```

### 3. Restaurar dependencias

```bash
cd Transport
dotnet restore
```

### 4. Aplicar migraciones (si existen)

```bash
dotnet ef database update
```

### 5. Ejecutar la aplicación

```bash
dotnet run
```

La aplicación estará disponible en:
- **HTTP**: `http://localhost:5000`
- **HTTPS**: `https://localhost:5001`

## 📁 Estructura del proyecto

```
Transport-Company-System/
├── Transport/                 # Proyecto principal ASP.NET Core
│   ├── Pages/                # Razor Pages (vistas)
│   ├── wwwroot/             # Archivos estáticos (CSS, JS, imágenes)
│   ├── Properties/          # Configuraciones del proyecto
│   ├── Program.cs           # Punto de entrada de la aplicación
│   ├── Transport.csproj     # Archivo de proyecto
│   ├── Transport.sln        # Archivo de solución
│   ├── appsettings.json     # Configuración de producción
│   └── appsettings.Development.json # Configuración de desarrollo
├── Maintenance/             # Módulo de mantenimiento
└── README.md               # Este archivo
```

## 🔧 Comandos útiles

### Entity Framework

```bash
# Generar modelos desde la base de datos (Database First)
dotnet ef dbcontext scaffold "Server=localhost;Database=transport_system;Uid=root;Pwd=password;" Pomelo.EntityFrameworkCore.MySql

# Crear una nueva migración
dotnet ef migrations add NombreMigracion

# Aplicar migraciones
dotnet ef database update

# Revertir migración
dotnet ef database update MigracionAnterior
```

### Desarrollo

```bash
# Ejecutar en modo desarrollo con recarga automática
dotnet watch run

# Compilar el proyecto
dotnet build

# Limpiar archivos de compilación
dotnet clean

# Ejecutar tests (si existen)
dotnet test
```

## 📊 Funcionalidades del sistema

### Gestión de vehículos
- Registro de camiones y datos técnicos
- Control de documentación y licencias
- Historial de cada vehículo

### Control de mantenimiento
- Programación de mantenciones preventivas
- Registro de reparaciones y servicios
- Alertas de mantenimiento pendiente
- Control de costos de mantenimiento

### Gestión de viajes
- Registro de rutas y destinos
- Control de cargas transportadas
- Seguimiento de tiempos y distancias
- Asignación de conductores

## 🤝 Contribución

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/nueva-funcionalidad`)
3. Commit tus cambios (`git commit -m 'feat: agregar nueva funcionalidad'`)
4. Push a la rama (`git push origin feature/nueva-funcionalidad`)
5. Abre un Pull Request

## 📝 Convenciones de commits

Este proyecto utiliza [Conventional Commits](https://www.conventionalcommits.org/es/):

- `feat:` - Nueva funcionalidad
- `fix:` - Corrección de errores
- `docs:` - Cambios en documentación
- `style:` - Cambios de formato, espacios, etc.
- `refactor:` - Refactorización de código
- `test:` - Agregar o modificar tests
- `chore:` - Tareas de mantenimiento

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

## 👨‍💻 Autor

**Vicente Araya Rojas** - [@zGreenCat](https://github.com/zGreenCat)

---

⭐ ¡No olvides darle una estrella al proyecto si te ha sido útil!

📧 Para consultas o sugerencias, puedes crear un [issue](https://github.com/zGreenCat/Transport-Company-System/issues) en el repositorio.