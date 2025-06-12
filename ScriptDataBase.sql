-- Crear la base de datos
CREATE DATABASE DbPruebaTecnica;
GO

-- Usar la base de datos
USE DbPruebaTecnica;
GO

-- Crear tabla Grupo
CREATE TABLE [Grupo] (
  [IdGrupo] INT PRIMARY KEY,
  [Nombre] VARCHAR(150)
);
GO

-- Insertar registro inicial en Grupo
INSERT INTO [Grupo] ([IdGrupo], [Nombre])
VALUES (1, 'Administrador');
GO

-- Crear tabla Usuario
CREATE TABLE [Usuario] (
  [IdUsuario] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
  [Nombre] VARCHAR(150),
  [ContraseñaHash] VARCHAR(500),
  [IdGrupo] INT
);
GO

-- Insertar registro inicial en Usuario
INSERT INTO [Usuario] ([Nombre], [ContraseñaHash], [IdGrupo])
VALUES ('despinoza', '$2a$11$OoYr0dps89SVgw8wXbTB0eF4kZiTt/FmSDdDe9WUbhRYDk98RODfK', 1);
GO

-- Crear tabla Producto
CREATE TABLE [Producto] (
  [IdProducto] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
  [Nombre] VARCHAR(255),
  [Unidad] INT
);
GO

-- Crear tabla Formula
CREATE TABLE [Formula] (
  [IdFormula] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL, 
  [Nombre] VARCHAR(255),
  [Cantidad] DECIMAL
);
GO

-- Crear tabla FormulaMateriales
CREATE TABLE [FormulaMateriales] (
  [IdFormula] INT,
  [IdProducto] INT,
  [Nombre] VARCHAR(255),
  [Cantidad] DECIMAL,
  FOREIGN KEY ([IdFormula]) REFERENCES [Formula] ([IdFormula]),
  FOREIGN KEY ([IdProducto]) REFERENCES [Producto] ([IdProducto])
);
GO

-- Crear relaciones (FOREIGN KEYS)
ALTER TABLE [Usuario] 
ADD FOREIGN KEY ([IdGrupo]) REFERENCES [Grupo] ([IdGrupo]);
GO
