# Proyecto Base del Curso

Este directorio contiene la base principal del sistema trabajada durante las clases y reutilizada para las tareas del curso.

## Objetivo

Mantener una unica base de desarrollo para backend y frontend, de modo que las mejoras realizadas en clase puedan evolucionar hasta convertirse en entregables formales.

## Regla de trabajo

- `Proyecto` es la fuente principal de desarrollo.
- `Tareas` no debe ser el lugar de desarrollo principal.
- Las carpetas dentro de `Tareas/Entregadas` representan copias preparadas para entrega y evidencia historica.

## Estructura actual

- `SistemaComercial`
  - solucion backend en .NET
  - API protegida con JWT
  - acceso a datos y reglas de negocio del sistema
- `sistema-comercial-app`
  - frontend Angular
  - interfaz con Bootstrap
  - login, rutas protegidas y consumo de la API

## Funcionalidades implementadas

- Autenticacion con JWT desde Angular hacia la API.
- Interceptor para enviar `Authorization: Bearer ...` en las peticiones protegidas.
- Guard para restringir acceso a rutas privadas.
- Paginas principales:
  - `laboratorio`
  - `login`
  - `cargos`
  - `empleados`
- Navbar reutilizable con navegacion entre modulos.

## Despliegue

- API publicada en Azure App Service.
- Frontend Angular publicado en:
  - Azure App Service
  - Azure Static Web Apps

### Nota sobre rutas SPA

- En Azure App Service se usa `public/web.config`.
- En Azure Static Web Apps se usa `public/staticwebapp.config.json`.

## Flujo recomendado

1. Implementar y mejorar el backend en `Proyecto/SistemaComercial`.
2. Implementar y mejorar el frontend en `Proyecto/sistema-comercial-app`.
3. Validar localmente el flujo completo.
4. Publicar en Azure cuando la clase o la tarea lo requiera.
5. Cuando una tarea quede lista, preparar una copia limpia en `Tareas/Pendientes/NN Tarea`.
6. Luego de entregarla, moverla a `Tareas/Entregadas/NN Tarea`.

## Criterios

- Evitar mantener multiples versiones activas del mismo proyecto en carpetas paralelas.
- Reutilizar el trabajo de clase siempre que la tarea lo permita.
- Mantener las tareas entregadas como respaldo historico.
- No considerar `bin`, `obj`, `node_modules`, `dist` o `.angular` como parte relevante de la estructura funcional del entregable.

## Relacion con Tareas

La carpeta `Tareas` conserva los PDF, notas para el profesor, imagenes relacionadas, archivos comprimidos y copias preparadas para entrega.
La evolucion real del sistema debe ocurrir en `Proyecto`.
