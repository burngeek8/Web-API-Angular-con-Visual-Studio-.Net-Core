# Proyecto Base del Curso

Este directorio contiene el proyecto maestro utilizado para desarrollar tanto los laboratorios en clase como las tareas del curso.

## Objetivo

Mantener una unica base de trabajo sobre la cual se realizan mejoras progresivas durante las clases y que luego puede reutilizarse para las tareas solicitadas.

## Regla de trabajo

- `Proyecto` es la fuente principal de desarrollo.
- `Tareas` no debe ser el lugar de desarrollo principal.
- Las carpetas dentro de `Tareas/Entregadas` representan evidencias o versiones preparadas para entrega.

## Estructura actual

- `SistemaComercial`: proyecto principal trabajado en clase y reutilizable para tareas.
- `Cliente`: recursos o pruebas de cliente relacionados al consumo de la API.

## Flujo recomendado

1. Implementar y mejorar el sistema en `Proyecto/SistemaComercial`.
2. Validar el funcionamiento localmente en esta misma base.
3. Cuando una tarea quede lista, preparar una copia o entregable desde `Proyecto/SistemaComercial`.
4. Colocar la evidencia final en `Tareas/Entregadas/NN Tarea` siguiendo el estandar definido en `Tareas/README.md`.

## Criterios

- Evitar mantener multiples versiones activas del mismo proyecto en distintas carpetas.
- Reutilizar el trabajo de laboratorio siempre que la tarea lo permita.
- Mantener las tareas entregadas como respaldo historico de cada entrega.
- No considerar `bin` ni `obj` como parte relevante de la estructura funcional del proyecto.

## Relacion con Tareas

La carpeta `Tareas` conserva los PDF, notas para el profesor, imagenes relacionadas, archivos comprimidos y copias preparadas para entrega.  
La evolucion real del proyecto debe ocurrir en `Proyecto`.
