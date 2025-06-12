# Prueba Técnica - Proyecto MVC .NET Core

Este proyecto es una aplicación web desarrollada con ASP.NET Core MVC que implementa operaciones CRUD para gestionar fórmulas, grupos, productos y usuarios.


## Tecnologías Utilizadas

- **ASP.NET Core MVC** - Framework para aplicaciones web
- **Entity Framework Core** - ORM para acceso a datos
- **FluentValidation** - Validación de modelos
- **BCrypt.Net-Next** - Encriptación de contraseñas
- **jQuery Validation** - Validación del lado del cliente:
  - `jquery.validate.min.js`
  - `jquery.validate.min.es.js` (localización en español)
  - `jquery.validate.unobtrusive.min.js`
  - `jquery.unobtrusive-ajax.min.js`
 
  - 
**Descripción:**

- **Data/**: Contiene la capa de acceso a datos con modelos, interfaces y contexto de base de datos.
- **Repositories/**: Implementa los repositorios para la gestión de entidades específicas.
- **Services/**: Lógica de negocio para cada entidad.
- **WebApp/**: Aplicación MVC con controladores, vistas, modelos de vista, validaciones y configuración.
- **WebApp.sln**: Solución principal que agrupa todos los proyectos.

```
PRUEBATECNICA/
├── Data/ # Capa de acceso a datos
│ ├── interfaces/
│ ├── Crud/
│ ├── Models/ # Modelos de entidades
│ │ ├── Formula/
│ │ ├── FormulaMaterials/
│ │ ├── Grupo/
│ │ ├── Producto/
│ │ └── Usuarios/
│ ├── ApplicationDbContext.cs # Contexto de base de datos
│ └── Data.csproj
│
├── Repositories/ # Repositorios para cada entidad
│ ├── Formula/
│ ├── Grupo/
│ ├── Producto/
│ └── Usuario/
│
├── Services/ # Lógica de negocio
│ ├── Formula/
│ ├── Grupo/
│ ├── Producto/
│ └── Usuario/
│
├── WebApp/ # Aplicación web MVC
│ ├── Controllers/ # Controladores
│ ├── Helpers/
│ ├── Models/ # ViewModels
│ │ ├── Formula/
│ │ └── Usuarios/
│ ├── Views/ # Vistas Razor
│ │ ├── Formula/
│ │ └── Usuarios/
│ ├── wwwroot/ # Archivos estáticos
│ ├── Validators/ # Validaciones FluentValidation
│ ├── appsettings.json # Configuración
│ ├── Program.cs # Configuración de la app
│ └── WebApp.csproj
│
└── WebApp.sln # Solución principal
``` 
## Requisitos Previos

- .NET Core SDK 8.0 o superior
- SQL Server 2022
- Visual Studio 2022 o VS Code (opcional)

## Configuración

1. Clonar el repositorio:
   ```bash
   git clone [URL del repositorio]
