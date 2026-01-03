# GestorDeIdeas
# Gestor de Ideas de Contenido – C# (.NET)

Aplicación de consola desarrollada en **C# con .NET**, pensada para gestionar ideas de contenido de forma simple y organizada.

El proyecto implementa un **CRUD completo**, persistencia en archivo JSON y funcionalidades de búsqueda y filtrado, siguiendo buenas prácticas de separación de responsabilidades.

---

##  Funcionalidades

- Crear ideas de contenido
- Listar todas las ideas
- Editar ideas existentes
- Eliminar ideas
- Buscar ideas por texto (título, descripción, tags, plataforma o categoría)
- Filtrar ideas por categoría
- Persistencia de datos en archivo JSON
- Menú interactivo por consola
- Salida formateada y legible

---

## Estructura del proyecto

- **Program.cs**
  - Interacción con el usuario
  - Menú principal
  - Entrada y salida por consola

- **IdeaDeContenido.cs**
  - Modelo de datos de una idea
  - Propiedades como título, descripción, categoría, plataforma, tags y fechas

- **IdeaRepository.cs**
  - Manejo de la colección de ideas
  - Lógica de negocio (agregar, editar, eliminar, buscar, filtrar)
  - Persistencia en archivo JSON

---

##  Tecnologías utilizadas

- C#
- .NET (Console Application)
- LINQ
- System.Text.Json
- Git & GitHub

---

## ▶️ Cómo ejecutar el proyecto

1. Clonar el repositorio:
   ```bash
   git clone htt
