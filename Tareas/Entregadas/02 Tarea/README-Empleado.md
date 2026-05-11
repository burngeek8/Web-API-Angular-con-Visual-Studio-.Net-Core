# Tarea 02 - Proyecto Empleado

## Contexto

El profesor indico que para la Tarea 02 se puede entregar el mismo proyecto desarrollado en laboratorio. En esta carpeta se deja la solucion `Empleado` organizada para entrega.

## Arquitectura

- `Empleado.Api`: expone endpoints y configura OpenAPI, DI y migracion automatica.
- `Empleado.Aplicacion`: contiene comandos, consultas y handlers con MediatR.
- `Empleado.Dominio`: define entidades, objetos de valor, reglas y contratos.
- `Empleado.Infrastructure`: implementa EF Core, repositorios, conexion SQL y migraciones.

## Casos implementados

- Registrar empleado.
- Actualizar empleado.
- Listar empleados.
- Obtener empleado por id.
- Persistencia con Entity Framework Core.
- Migracion automatica al iniciar la API desde `ApplicationBuilderExtensions`.

## Validacion

Comando ejecutado:

```powershell
dotnet build
```

Resultado: compilacion correcta desde `Tareas/02 Tarea/Empleado`.
