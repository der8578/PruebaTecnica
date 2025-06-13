# 🛠️ Instrucciones de Configuración del Proyecto

Este proyecto incluye un script para crear la base de datos, una carpeta con un archivo `.bacpac` para restauración opcional, y configuración de dependencias NuGet.

---

## 📌 1. Crear la base de datos desde `ScriptDataBase.sql`

1. Abre **SQL Server Management Studio (SSMS)** o **Azure Data Studio**.
2. Conéctate a tu servidor SQL.
3. Abre el archivo `ScriptDataBase.sql`.
4. Ejecuta el script (`F5` o `Ctrl + F5`) para crear la base de datos `DbPruebaTecnica` y sus tablas.

---

## 📦 2. Restaurar los paquetes NuGet

1. Abre el proyecto en **Visual Studio**.
2. Ve al menú: `Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes`.
3. Ejecuta el siguiente comando:

```powershell
Update-Package -reinstall
