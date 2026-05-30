# Checklist Clase 07 (Para Exponer)

## 1. Estructura General
- [ ] Explicar la separación de carpetas:
- `Profesor/Usuario` = referencia del profe (backend).
- `Profesor/Cliente` = frontend básico del profe.
- `Alumno/Empleado` = mi proyecto adaptado.
- [ ] Mostrar que ambos siguen arquitectura por capas:
- `Api`, `Aplicacion`, `Dominio`, `Infrastructure`.

## 2. Qué Se Agregó en Clase 07 (Referencia Profe)
- [ ] Identificar novedades de `Clase 07/Profesor/Usuario` frente a Clase 06:
- Filtro global de excepciones (`GlobalExceptionFilter`).
- Filtro global de logging de acciones (`GlobalActionLoggingFilter`).
- Configuración CORS en `Program.cs`.
- [ ] Explicar para qué sirve cada novedad:
- Excepciones: respuesta controlada y consistente.
- Logging: trazabilidad de endpoints ejecutados.
- CORS: permitir frontend (otro origen) contra la API.

## 3. Aplicarlo a Mi Proyecto (Alumno/Empleado)
- [ ] Verificar si en `Alumno/Empleado` ya existen filtros globales.
- [ ] Si no existen, crear carpeta `Empleado.Api/Filter` y agregar:
- `GlobalExceptionFilter.cs`
- `GlobalActionLoggingFilter.cs`
- [ ] Registrar ambos filtros en `Program.cs` dentro de `AddControllers(...)`.
- [ ] Configurar política CORS (`defaultPolicy`) y usar `app.UseCors(...)`.
- [ ] Mantener `UseAuthentication()` y `UseAuthorization()` después de CORS.

## 4. Flujo Funcional Que Debo Poder Demostrar
- [ ] `GET /` (`HomeController`) muestra estado de inicialización.
- [ ] Crear primer cargo (`POST /api/cargos`) sin token (bootstrap).
- [ ] Crear primer empleado (`POST /api/empleados`) sin token (bootstrap).
- [ ] Login empleado (`POST /api/empleados/login`) devuelve JWT.
- [ ] Con JWT: listar/consultar/actualizar según reglas de autorización.

## 5. Preguntas del Profe (Prepárate)
- [ ] ¿Por qué CQRS + MediatR?
- Separación clara entre comandos (escritura) y queries (lectura).
- [ ] ¿Por qué Dapper en queries y EF en comandos?
- Dapper optimiza lectura; EF facilita persistencia y tracking.
- [ ] ¿Qué valor aportan los filtros globales?
- Menos código repetido en controladores y manejo centralizado.
- [ ] ¿Qué problema resuelve CORS?
- Permite que el frontend del navegador consuma tu API sin bloqueo.
- [ ] ¿Qué contiene el JWT?
- Claims como `NameIdentifier`, `Name`, `Role`.

## 6. Verificación Final Antes de Presentar
- [ ] Compila solución sin errores.
- [ ] Base de datos migra al arrancar (`MigrationDatabaseAsync`).
- [ ] Pruebas rápidas de endpoints en `.http` o Postman.
- [ ] Probar desde frontend del profe (`Profesor/Cliente`) contra tu API.
- [ ] Tener lista una demo corta de 3 minutos (inicio -> bootstrap -> login -> operación autenticada).

## 7. Guion de Exposición (Mini)
- [ ] 1) Arquitectura por capas.
- [ ] 2) Qué heredé del profe en Clase 07 (filtros + CORS).
- [ ] 3) Cómo lo adapté a `Empleado`.
- [ ] 4) Demo funcional con JWT y autorización.
- [ ] 5) Cierre técnico: decisiones (CQRS, Dapper, EF, filtros, CORS).
