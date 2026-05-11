# Estandar de Organizacion de Tareas

Este directorio define el formato base para organizar las tareas del curso.

## Estructura general

- `Entregadas`: contiene las tareas finalizadas y listas para sustento o revision.
- `Pendientes`: contiene las tareas aun no desarrolladas o no cerradas.

Cada tarea debe organizarse en una carpeta con el formato:

```text
NN Tarea
```

Ejemplos:

- `01 Tarea`
- `05 Tarea`
- `07 Tarea`

## Estandar para tareas entregadas

Dentro de cada carpeta en `Entregadas/NN Tarea` se debe mantener, de ser aplicable, la siguiente estructura:

```text
NN Tarea/
|- NN Tarea.pdf
|- Notas para el profesor.txt
|- Imagenes Relacionadas/
|- NombreDelProyecto/
|- archivo-entregable.zip
```

## Elementos esperados

- `NN Tarea.pdf`: enunciado original de la tarea.
- `Notas para el profesor.txt`: explicacion breve de lo entregado, alcance, decisiones tomadas y relacion con lo trabajado en clase.
- `Imagenes Relacionadas`: capturas o evidencias visuales de implementacion, ejecucion, resultados o configuracion.
- `NombreDelProyecto`: solucion o proyecto fuente que respalda la entrega.
- `archivo-entregable.zip`: comprimido final de entrega con nombre claro.

## Criterios de uso

- Reutilizar el proyecto de laboratorio cuando la tarea lo permita.
- Mantener coherencia entre el contenido del PDF, el proyecto entregado y las imagenes adjuntas.
- Incluir `Notas para el profesor.txt` en todas las tareas entregadas para contextualizar la evidencia.
- Incluir `Imagenes Relacionadas` en todas las tareas entregadas cuando existan pantallazos o pruebas visuales relevantes.
- Agregar un `README` tecnico dentro de la tarea solo si aporta contexto util, por ejemplo arquitectura, casos implementados o validacion con compilacion.

## Observacion

Este estandar se definio a partir del patron ya usado en las tareas entregadas, especialmente en las tareas 02, 03 y 04, para mantener una presentacion consistente en adelante.
